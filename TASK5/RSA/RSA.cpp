#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <openssl/evp.h>
#include <openssl/pem.h>
#include <openssl/rsa.h>
#include <openssl/err.h>
#include <openssl/sha.h>
#include <openssl/bio.h>
#include <chrono>
using std::runtime_error;

using namespace std;

#ifdef BUILD_DLL
#define EXPORT __attribute__((visibility("default")))
#else
#define EXPORT
#endif

extern "C"
{
    EXPORT bool genKeyPair(const char *filePrivate, const char *filePublic, const char *format, int keysize);
    EXPORT bool sign(const char *filePrivate, const char *filename, const char *signFile, const char *format);
    EXPORT bool verify(const char *filePublic, const char *filename, const char *signFile, const char *format);
}

bool writePrivateKey(const char *filePrivate, RSA *rsa, const string &format)
{
    FILE *privateFile = fopen(filePrivate, "wb");
    if (!privateFile)
    {
        cerr << "Failed to open private key file." << endl;
        return false;
    }

    bool success = false;
    if (format == "DER")
    {
        if (i2d_RSAPrivateKey_fp(privateFile, rsa))
        {
            success = true;
        }
    }
    else
    {
        if (PEM_write_RSAPrivateKey(privateFile, rsa, NULL, NULL, 0, NULL, NULL))
        {
            success = true;
        }
    }

    fclose(privateFile);
    return success;
}

bool writePublicKey(const char *filePublic, RSA *rsa, const string &format)
{
    FILE *publicFile = fopen(filePublic, "wb");
    if (!publicFile)
    {
        cerr << "Failed to open public key file." << endl;
        return false;
    }

    bool success = false;
    if (format == "DER")
    {
        if (i2d_RSA_PUBKEY_fp(publicFile, rsa))
        {
            success = true;
        }
    }
    else
    {
        if (PEM_write_RSA_PUBKEY(publicFile, rsa))
        {
            success = true;
        }
    }

    fclose(publicFile);
    return success;
}

bool genKeyPair(const char *filePrivate, const char *filePublic, const char *format, int keysize)
{
    RSA *rsa = RSA_new();
    BIGNUM *bne = BN_new();
    BN_set_word(bne, RSA_F4);

    if (!RSA_generate_key_ex(rsa, keysize, bne, NULL))
    {
        cerr << "Failed to generate key pair." << endl;
        BN_free(bne);
        RSA_free(rsa);
        return false;
    }

    if (!writePrivateKey(filePrivate, rsa, format))
    {
        BN_free(bne);
        RSA_free(rsa);
        return false;
    }

    if (!writePublicKey(filePublic, rsa, format))
    {
        BN_free(bne);
        RSA_free(rsa);
        return false;
    }

    BN_free(bne);
    RSA_free(rsa);
    return true;
}

bool readPrivateKey(const char *filePrivate, EVP_PKEY **pkey, const string &format)
{
    BIO *bio = BIO_new_file(filePrivate, "rb");
    if (!bio)
    {
        cerr << "Failed to open private key file." << endl;
        return false;
    }

    RSA *rsa = NULL;
    if (format == "DER")
    {
        rsa = d2i_RSAPrivateKey_bio(bio, NULL);
    }
    else
    {
        rsa = PEM_read_bio_RSAPrivateKey(bio, NULL, NULL, NULL);
    }

    if (!rsa)
    {
        cerr << "Failed to read private key." << endl;
        ERR_print_errors_fp(stderr);
        BIO_free(bio);
        return false;
    }

    *pkey = EVP_PKEY_new();
    EVP_PKEY_assign_RSA(*pkey, rsa);
    BIO_free(bio);
    return true;
}

bool readPublicKey(const char *filePublic, EVP_PKEY **pkey, const string &format)
{
    BIO *bio = BIO_new_file(filePublic, "rb");
    if (!bio)
    {
        cerr << "Failed to open public key file." << endl;
        return false;
    }

    RSA *rsa = NULL;
    if (format == "DER")
    {
        rsa = d2i_RSA_PUBKEY_bio(bio, NULL);
    }
    else
    {
        rsa = PEM_read_bio_RSA_PUBKEY(bio, NULL, NULL, NULL);
    }

    if (!rsa)
    {
        cerr << "Failed to read public key." << endl;
        ERR_print_errors_fp(stderr);
        BIO_free(bio);
        return false;
    }

    *pkey = EVP_PKEY_new();
    EVP_PKEY_assign_RSA(*pkey, rsa);
    BIO_free(bio);
    return true;
}

bool computeFileHash(const char *filename, unsigned char hash[SHA256_DIGEST_LENGTH])
{
    ifstream file(filename, ios::binary);
    if (!file.is_open())
    {
        cerr << "Failed to open file for hashing." << endl;
        return false;
    }

    SHA256_CTX sha256;
    SHA256_Init(&sha256);

    char buffer[8192];
    while (file.good())
    {
        file.read(buffer, sizeof(buffer));
        SHA256_Update(&sha256, buffer, file.gcount());
    }

    SHA256_Final(hash, &sha256);
    file.close();
    return true;
}

bool readSignature(const char *signFile, vector<unsigned char> &signature)
{
    ifstream sigFile(signFile, ios::binary);
    if (!sigFile.is_open())
    {
        cerr << "Failed to open signature file." << endl;
        return false;
    }

    sigFile.seekg(0, ios::end);
    size_t sigLen = sigFile.tellg();
    sigFile.seekg(0, ios::beg);
    signature.resize(sigLen);
    sigFile.read(reinterpret_cast<char *>(signature.data()), sigLen);
    sigFile.close();
    return true;
}

bool verifySignature(EVP_PKEY *pkey, const unsigned char *hash, size_t hashLen, const vector<unsigned char> &signature)
{
    EVP_MD_CTX *mdCtx = EVP_MD_CTX_new();
    if (!mdCtx)
    {
        cerr << "Failed to create message digest context." << endl;
        return false;
    }

    EVP_PKEY_CTX *pkeyCtx = NULL;
    if (EVP_DigestVerifyInit(mdCtx, &pkeyCtx, EVP_sha256(), NULL, pkey) <= 0)
    {
        cerr << "Failed to initialize verification context." << endl;
        EVP_MD_CTX_free(mdCtx);
        return false;
    }

    if (EVP_PKEY_CTX_set_rsa_padding(pkeyCtx, RSA_PKCS1_PSS_PADDING) <= 0)
    {
        cerr << "Failed to set RSA PSS padding." << endl;
        EVP_MD_CTX_free(mdCtx);
        return false;
    }

    if (EVP_DigestVerifyUpdate(mdCtx, hash, hashLen) <= 0)
    {
        cerr << "Failed to update verification context." << endl;
        EVP_MD_CTX_free(mdCtx);
        return false;
    }

    int verifyResult = EVP_DigestVerifyFinal(mdCtx, signature.data(), signature.size());
    if (verifyResult != 1)
    {
        cerr << "Signature verification failed." << endl;
        ERR_print_errors_fp(stderr);
        EVP_MD_CTX_free(mdCtx);
        return false;
    }

    EVP_MD_CTX_free(mdCtx);
    return true;
}

bool signFileWithKey(EVP_PKEY *pkey, const unsigned char *hash, size_t hashLen, vector<unsigned char> &signature)
{
    EVP_MD_CTX *mdCtx = EVP_MD_CTX_new();
    if (!mdCtx)
    {
        cerr << "Failed to create message digest context." << endl;
        return false;
    }

    EVP_PKEY_CTX *pkeyCtx = NULL;
    if (EVP_DigestSignInit(mdCtx, &pkeyCtx, EVP_sha256(), NULL, pkey) <= 0)
    {
        cerr << "Failed to initialize signing context." << endl;
        EVP_MD_CTX_free(mdCtx);
        return false;
    }

    if (EVP_PKEY_CTX_set_rsa_padding(pkeyCtx, RSA_PKCS1_PSS_PADDING) <= 0)
    {
        cerr << "Failed to set RSA PSS padding." << endl;
        EVP_MD_CTX_free(mdCtx);
        return false;
    }

    size_t sigLen;
    if (EVP_DigestSign(mdCtx, NULL, &sigLen, hash, hashLen) <= 0)
    {
        cerr << "Failed to determine signature length." << endl;
        EVP_MD_CTX_free(mdCtx);
        return false;
    }

    signature.resize(sigLen);
    if (EVP_DigestSign(mdCtx, signature.data(), &sigLen, hash, hashLen) <= 0)
    {
        cerr << "Failed to create signature." << endl;
        EVP_MD_CTX_free(mdCtx);
        return false;
    }

    signature.resize(sigLen);
    EVP_MD_CTX_free(mdCtx);
    return true;
}

bool sign(const char *filePrivate, const char *filename, const char *signFile, const char *format)
{
    OpenSSL_add_all_algorithms();
    ERR_load_crypto_strings();

    EVP_PKEY *pkey = nullptr;
    if (!readPrivateKey(filePrivate, &pkey, format))
    {
        return false;
    }

    unsigned char hash[SHA256_DIGEST_LENGTH];
    if (!computeFileHash(filename, hash))
    {
        EVP_PKEY_free(pkey);
        return false;
    }

    vector<unsigned char> signature;
    if (!signFileWithKey(pkey, hash, SHA256_DIGEST_LENGTH, signature))
    {
        EVP_PKEY_free(pkey);
        return false;
    }

    ofstream sigFileStream(signFile, ios::binary);
    if (!sigFileStream.is_open())
    {
        cerr << "Failed to open signature file for writing." << endl;
        EVP_PKEY_free(pkey);
        return false;
    }

    sigFileStream.write(reinterpret_cast<char *>(signature.data()), signature.size());
    sigFileStream.close();

    EVP_PKEY_free(pkey);
    EVP_cleanup();
    ERR_free_strings();
    return true;
}

bool verify(const char *filePublic, const char *filename, const char *signFile, const char *format)
{
    OpenSSL_add_all_algorithms();
    ERR_load_crypto_strings();

    EVP_PKEY *pkey = nullptr;
    if (!readPublicKey(filePublic, &pkey, format))
    {
        return false;
    }

    unsigned char hash[SHA256_DIGEST_LENGTH];
    if (!computeFileHash(filename, hash))
    {
        EVP_PKEY_free(pkey);
        return false;
    }

    vector<unsigned char> signature;
    if (!readSignature(signFile, signature))
    {
        EVP_PKEY_free(pkey);
        return false;
    }

    bool result = verifySignature(pkey, hash, SHA256_DIGEST_LENGTH, signature);

    EVP_PKEY_free(pkey);
    EVP_cleanup();
    ERR_free_strings();
    return result;
}

int main(int argc, char *argv[])
{
    if (argc < 2)
    {
        cerr << "Usage:" << endl;
        cerr << "\tkeygen <private_key_file> <public_key_file> <format (PEM/DER)> <key size>" << endl;
        cerr << "\tsign <private_key_file> <input_file> <signature_file> <format (PEM/DER)>" << endl;
        cerr << "\tverify <public_key_file> <input_file> <signature_file> <format (PEM/DER)>" << endl;
        return -1;
    }

    OpenSSL_add_all_algorithms();
    ERR_load_crypto_strings();

    string command = argv[1];

    if (command == "keygen")
    {
        if (argc != 6)
        {
            cerr << "Usage: keygen <private_key_file> <public_key_file> <format (PEM/DER)> <key size>" << endl;
            return -1;
        }
        const char *filePrivate = argv[2];
        const char *filePublic = argv[3];
        const char *format = argv[4];
        int keysize = stoi(argv[5]);

        bool result = genKeyPair(filePrivate, filePublic, format, keysize);
        if (result)
        {
            cout << "Key generation successful." << endl;
        }
        else
        {
            cerr << "Key generation failed." << endl;
            return -1;
        }
    }
    else if (command == "sign")
    {
        if (argc != 6)
        {
            cerr << "Usage: sign <private_key_file> <input_file> <signature_file> <format (PEM/DER)>" << endl;
            return -1;
        }
        const char *filePrivate = argv[2];
        const char *filename = argv[3];
        const char *signFile = argv[4];
        const char *format = argv[5];
        auto start = std::chrono::high_resolution_clock::now();

        if (!sign(filePrivate, filename, signFile, format))
        {
            cerr << "Signing failed." << endl;
            return -1;
        }
        else
        {
            cout << "Signing successful." << endl;
        }
        std::cout << "PDF signed successfully." << std::endl;
        auto stop = std::chrono::high_resolution_clock::now();
        auto duration = std::chrono::duration<double, std::milli>(stop - start);
        cout << "\n----------------------------------------------------------" << endl;
        cout << "Overview RSA Sign File Test" << endl;
        cout << "\nSign time: " << duration.count() << " milliseconds" << endl;
        cout << "----------------------------------------------------------" << endl;
    }
    else if (command == "verify")
    {
        if (argc != 6)
        {
            cerr << "Usage: verify <public_key_file> <input_file> <signature_file> <format (PEM/DER)>" << endl;
            return -1;
        }
        const char *filePublic = argv[2];
        const char *filename = argv[3];
        const char *signFile = argv[4];
        const char *format = argv[5];
        auto start = std::chrono::high_resolution_clock::now();

        if (!verify(filePublic, filename, signFile, format))
        {
            cerr << "Signature verification failed." << endl;
            return -1;
        }
        else
        {
            cout << "Signature verification successful." << endl;
        }
        auto stop = std::chrono::high_resolution_clock::now();
        auto duration = std::chrono::duration<double, std::milli>(stop - start);
        cout << "\n----------------------------------------------------------" << endl;
        cout << "Overview RSA Verification Test" << endl;
        cout << "\nVerification time: " << duration.count() << " milliseconds" << endl;
        cout << "----------------------------------------------------------" << endl;
    }
    else
    {
        cerr << "Unknown command: " << command << endl;
        return -1;
    }

    ERR_free_strings();
    EVP_cleanup();

    return 0;
}