#include "cryptopp/integer.h"
// C/C++ libraries
#include <iostream>
using std::cerr;
using std::cin;
using std::cout;
using std::endl;
#include <string>
using std::exit;
#include <cstdlib>
using std::string;

// header part
#ifdef _WIN32
#include <windows.h>
#endif
#include <cstdlib>
#include <locale>
#include <cctype>

// Cryptopp libraries

#include "cryptopp/osrng.h"
using CryptoPP::AutoSeededRandomPool;

#include "cryptopp/cryptlib.h"
using CryptoPP::Exception;

#include "cryptopp/hex.h"
using CryptoPP::HexDecoder;
using CryptoPP::HexEncoder;
// base64
#include "cryptopp/base64.h"
using CryptoPP::Base64Decoder;
using CryptoPP::Base64Encoder;

#include "cryptopp/filters.h"
using CryptoPP::PK_DecryptorFilter;
using CryptoPP::PK_EncryptorFilter;
using CryptoPP::StreamTransformationFilter;
using CryptoPP::StringSink;
using CryptoPP::StringSource;

/* Integer arithmatics*/
#include <cryptopp/integer.h>
using CryptoPP::Integer;

#include <cryptopp/nbtheory.h>
using CryptoPP::ModularSquareRoot;

#include <cryptopp/modarith.h>
using CryptoPP::ModularArithmetic;
#include <iostream>
using std::cerr;
using std::cout;
using std::endl;

#include <string>
using std::string;

#include <stdexcept>
using std::runtime_error;

#include <cryptopp/queue.h>
using CryptoPP::ByteQueue;

#include <cryptopp/files.h>
using CryptoPP::FileSink;
using CryptoPP::FileSource;

#include "cryptopp/rsa.h"
using CryptoPP::RSA;

#include "cryptopp/base64.h"
using CryptoPP::Base64Decoder;
using CryptoPP::Base64Encoder;

#include "cryptopp/hex.h"
using CryptoPP::HexDecoder;
using CryptoPP::HexEncoder;

#include <cryptopp/cryptlib.h>
using CryptoPP::BufferedTransformation;
using CryptoPP::PrivateKey;
using CryptoPP::PublicKey;

#include "cryptopp/osrng.h"
using CryptoPP::AutoSeededRandomPool;

// them vo ba cai nay de lam encode decode
#include "cryptopp/filters.h"
using CryptoPP::StreamTransformationFilter;
using CryptoPP::StringSink;
using CryptoPP::StringSource;

#include "cryptopp/rsa.h"
using CryptoPP::InvertibleRSAFunction;
using CryptoPP::RSA;
using CryptoPP::RSAES_OAEP_SHA_Decryptor;
using CryptoPP::RSAES_OAEP_SHA_Encryptor;

#include "cryptopp/sha.h"
using CryptoPP::SHA1; // for padding OAEP

using namespace CryptoPP;
using namespace std;

// Save (BER-BIN) key to file
void Save(const string& filename, const BufferedTransformation& bt);
void SavePrivateKey(const string& filename, const PrivateKey& key);
void SavePublicKey(const string& filename, const PublicKey& key);

// Save (BER)
void SaveBase64(const string& filename, const BufferedTransformation& bt);
void SaveBase64PrivateKey(const string& filename, const PrivateKey& key);
void SaveBase64PublicKey(const string& filename, const PublicKey& key);

void Load(const string& filename, BufferedTransformation& bt);
void LoadPrivateKey(const string& filename, PrivateKey& key);
void LoadPublicKey(const string& filename, PublicKey& key);

// Load BER_BASE64
void LoadBase64(const string& filename, BufferedTransformation& bt);
void LoadBase64PrivateKey(const string& filename, PrivateKey& key);
void LoadBase64PublicKey(const string& filename, PublicKey& key);

string ConvertFromPEM(const string& pemCipher)
{
    string decodedCipher;
    StringSource(pemCipher, true,
        new Base64Decoder(
            new StringSink(decodedCipher)));
    return decodedCipher;
}

string ConvertToPEM(const string& cipher)
{
    string pemCipher;
    StringSource(cipher, true,
        new Base64Encoder(
            new StringSink(pemCipher)));
    pemCipher.erase(remove(pemCipher.begin(), pemCipher.end(), '\n'), pemCipher.end());

    return pemCipher;
}

string ConvertToHex(const string& cipher)
{
    string hexCipher;
    StringSource(cipher, true, new HexEncoder(new StringSink(hexCipher)));
    return hexCipher;
}

string ConvertFromHex(const string& hexCipher)
{
    string cipher;
    StringSource(hexCipher, true, new HexDecoder(new StringSink(cipher)));
    return cipher;
}

string LoadCipherText(const char* CipherFile, const string& strCipherFormat)
{
    // Load cipher
    string cipher;
    if (strCipherFormat == "DER" || strCipherFormat == "PEM")
    {
        // Load ciphertext from file with the specified format
        string encodedCipher;
        FileSource(CipherFile, true, new StringSink(encodedCipher));

        if (strCipherFormat == "PEM")
        {
            // Decode Base64 ciphertext
            StringSource(encodedCipher, true,
                new Base64Decoder(new StringSink(cipher)));
        }
        else
        {
            // Use ciphertext as is (DER format)
            cipher = encodedCipher;
        }
    }
    else
    {
        cerr << "Unsupported cipher format. Please choose 'DER', 'PEM' or 'HEX'\n";
        exit(1);
    }
    return cipher;
}

void SaveCipherFile(const string& cipher, const string& strCipherFormat, const char* CipherFile)
{

    if (strCipherFormat == "DER")
    {
        StringSource(cipher, true,
            new FileSink(CipherFile, true));
    }
    else if (strCipherFormat == "PEM")
    {
        StringSource(cipher, true,
            new Base64Encoder(
                new FileSink(CipherFile, false)));
        // cout << "PEM format cipher: \n"
        //      << ConvertToPEM(cipher) << endl;
    }
    else
    {
        cerr << "Unsupported cipher format. Please choose 'DER', 'PEM'\n";
        exit(1);
    }
}

// RSA keys generation
void GenerationAndSaveRSAKeys(int keySize, const char* format, const char* privateKeyFile, const char* publicKeyFile)
{

    string strFormat(format);
    string strPrivateKeyFile(privateKeyFile);
    string strPublicKeyFile(publicKeyFile);
    AutoSeededRandomPool rnd;

    // General private key
    RSA::PrivateKey rsaPrivate;
    rsaPrivate.GenerateRandomWithKeySize(rnd, keySize); // tao RSA

    // General public key
    RSA::PublicKey rsaPublic(rsaPrivate);

    if (strFormat == "DER")
    {

        // Save keys to file (BIN)
        SavePrivateKey(strPrivateKeyFile, rsaPrivate);
        SavePublicKey(strPublicKeyFile, rsaPublic);
    }
    else if (strFormat == "PEM")
    {
        // Save keys to file (BASE64)
        SaveBase64PrivateKey(strPrivateKeyFile, rsaPrivate);
        SaveBase64PublicKey(strPublicKeyFile, rsaPublic);
    }
    else
    {
        cerr << "Unsupported format. Please choose 'DER, 'Base64'." << endl;
        exit(1);
    }

    // Integer modul1 = rsaPrivate.GetModulus();
    // Integer prime1 = rsaPrivate.GetPrime1();
    // Integer prime2 = rsaPrivate.GetPrime2();
    // Integer SK = rsaPrivate.GetPrivateExponent();

    // Integer PK = rsaPublic.GetPublicExponent();
    // Integer modul2 = rsaPublic.GetModulus();
    // cout<<"Modulo (private) n= "<<modul1<<endl;
    // cout<<"Modulo (public) n= "<<modul2<<endl;
    // cout<<"Prime number 1 (private) p= "<<std::hex<<prime1<<std::dec<<endl;
    // cout<<"Prime number 2 (private) q= "<<std::hex<<prime2<<std::dec<<endl;
    // cout<<"Secret exponent d= "<<SK<<endl;
    // cout<<"Public exponent e= "<<PK<<endl;

    // //Checking the key generator function
    // RSA::PrivateKey r1, r2;
    // r1.GenerateRandomWithKeySize(rnd, 3072);

    // SavePrivateKey("rsa-roundtrip.key", r1);
    // LoadPrivateKey("rsa-roundtrip.key", r2);

    // r1.Validate(rnd, 3);
    // r2.Validate(rnd, 3);

    // if(r1.GetModulus() != r2.GetModulus() ||
    //    r1.GetPublicExponent() != r2.GetPublicExponent() ||
    //    r1.GetPrivateExponent() != r2.GetPrivateExponent())
    // {
    // 	throw runtime_error("key data did not round trip");
    // }

    ////////////////////////////////////////////////////////////////////////////////////

    cout << "Successfully generated and saved RSA keys" << endl;
}

void RSAencrypt(const char* format, const char* publicKeyFile, const char* PlaintextFile, const char* CipherFile)
{
    string strFormat(format);
    RSA::PrivateKey privateKey;
    RSA::PublicKey publicKey;
    AutoSeededRandomPool rnd;

    // load key from files
    if (strFormat == "DER")
    {
        LoadPublicKey(publicKeyFile, publicKey);
    }
    else if (strFormat == "PEM")
    {
        LoadBase64PublicKey(publicKeyFile, publicKey);
    }
    else
    {
        cerr << "Unsupported format. Please choose 'DER' or 'PEM'." << endl;
        exit(1);
    }

    string plain, cipher;

    if (PlaintextFile == nullptr)
    {
        cout << "Enter the plaintext: ";
        getline(cin, plain);
    }
    else
    {
        FileSource(PlaintextFile, true, new StringSink(plain), false);
    }

    auto start = std::chrono::high_resolution_clock::now();
    for (int i = 0; i < 10000; i++)
    {
        // Encryption
        RSAES_OAEP_SHA_Encryptor e(publicKey);

        StringSource(
            plain, true,
            new PK_EncryptorFilter(rnd, e,
                new StringSink(cipher)) // PK_EncryptorFilter
        );
    }

    auto stop = std::chrono::high_resolution_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(stop - start);
    cout << "\n----------------------------------------------------------" << endl;
    cout << "Overview RSA Encryption Test" << endl;
    cout << "\nEncryption time: " << duration.count() << " milliseconds" << endl;
    cout << "----------------------------------------------------------" << endl;


    SaveCipherFile(cipher, strFormat, CipherFile);

    // cout << "Successfully encrypted to CipherFile: " << CipherFile << endl;
}

// decrypt
void RSAdecrypt(const char* format, const char* privateKeyFile, const char* CipherFile, const char* PlaintextFile)
{
    string strFormat(format);
    RSA::PrivateKey privateKey;
    RSA::PublicKey publicKey;
    AutoSeededRandomPool rnd;

    if (strFormat == "DER")
    {
        LoadPrivateKey(privateKeyFile, privateKey);
    }
    else if (strFormat == "PEM")
    {
        LoadBase64PrivateKey(privateKeyFile, privateKey);
    }
    else
    {
        cerr << "Unsupported Format. Please choose 'DER' or 'PEM'." << endl;
        exit(1);
    }

    // Initialize RSA decryptor
    RSAES_OAEP_SHA_Decryptor d(privateKey);

    string encodedCipher, cipher;

    if (CipherFile == nullptr)
    {
        cout << "Enter the ciphertext: ";
        getline(cin, encodedCipher);
        if (strFormat == "PEM")
        {
            cipher = ConvertFromPEM(encodedCipher);
        }
        else
        {
            cerr << "Type input invalid in DER";
        }
    }
    else
    {
        FileSource(CipherFile, true, new StringSink(encodedCipher));

        if (strFormat == "PEM")
        {
            StringSource(encodedCipher, true,
                new Base64Decoder(
                    new StringSink(cipher)) // Base64Decoder
            );
        }
        else
        {
            cipher = encodedCipher;
        }
    }

    // Read the ciphertext from the CipherFile

    string recover;

    // Decrypt the data
    auto start = std::chrono::high_resolution_clock::now();
    for (int i = 0; i < 10000; i++)
    {
        StringSource(
            cipher, true,
            new PK_DecryptorFilter(rnd, d,
                new StringSink(recover)) // PK_DecryptorFilter
        );
    }
    auto stop = std::chrono::high_resolution_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(stop - start);
    cout << "\n----------------------------------------------------------" << endl;
    cout << "Overview RSA Decryption Test" << endl;
    cout << "\nDecryption time: " << duration.count() << " milliseconds" << endl;
    cout << "----------------------------------------------------------" << endl;
    // cout << "Recovered text: " << recover << endl;

    StringSource(recover, true,
        new FileSink(PlaintextFile, false));

    // cout << "Successfully decrypted to RecoveredFile: " << PlaintextFile << endl;
}

int main(int argc, char** argv)
{
    // Set locale to support UTF-8
#ifdef _linux_
    std::locale::global(std::locale("C.utf8"));
#endif
#ifdef _WIN32
    // Set console code page to UTF-8 on Windows C.utf8, CP_UTF8
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
#endif

    std::ios_base::sync_with_stdio(false);


    if (argc < 2)
    {
        cerr << "Invalid arguments. Please follow the instructions:\n";

        cerr << "Usage: \n"
            << "\t" << argv[0] << " genkey <keysize> <format> <privateKeyFile> <publicKeyFile>\n"
            << "\t" << argv[0] << " encrypt <format> <publicKeyFile> [<plaintextFile>] <cipherFile>\n"
            << "\t" << argv[0] << " decrypt <format> <privateKeyFile> [<cipherFile>] <recoveredFile>\n"
            << "Note:\n"
            << "\tkeySize represents the size of the key in bits (3072, 4096, 7680)\n"
            << "\targument in [] is option, when u ignore it, u will input from screen\n"
            << "\tFormat options: 'DER', 'PEM'\n"
            << "Example:\n"
            << "\t" << argv[0] << " genkey 3072 PEM privateKey.txt publicKey.txt\n"
            << "\t" << argv[0] << " encrypt PEM publicKey.txt cipher.txt ----{input plaintext from screen}\n"
            << "\t" << argv[0] << " decrypt PEM privateKey.txt recovered.txt  ----{input ciphertext from screen}\n\n"
            << "\t" << argv[0] << " genkey 3072 DER privateKey.bin publicKey.bin\n"
            << "\t" << argv[0] << " encrypt DER publicKey.bin plaintext.txt cipher.bin \n"
            << "\t" << argv[0] << " decrypt DER privateKey.bin cipher.bin recovered.txt \n";

        return -1;
    }

    string mode = argv[1];

    if (mode == "genkey" && argc == 6)
    {
        int keySize = std::stoi(argv[2]);
        GenerationAndSaveRSAKeys(keySize, argv[3], argv[4], argv[5]);
    }
    else if (mode == "encrypt" && (argc == 5 || argc == 6))
    {
        const char* format = argv[2];
        const char* publicKeyFile = argv[3];
        const char* plaintextFile = nullptr;
        const char* cipherFile = argv[argc - 1];

        if (argc == 6)
        {
            plaintextFile = argv[4];
        }
        for (int i = 0; i < 10000; i++)
        {
            RSAencrypt(format, publicKeyFile, plaintextFile, cipherFile);
        }

    }
    else if (mode == "decrypt" && (argc == 5 || argc == 6))
    {
        const char* format = argv[2];
        const char* privateKeyFile = argv[3];
        const char* cipherFile = nullptr;
        const char* recoveredFile = argv[argc - 1];

        if (argc == 6)
        {
            cipherFile = argv[4];
        }

        for (int i = 0; i < 10000; i++)
        {

            RSAdecrypt(format, privateKeyFile, cipherFile, recoveredFile);
        }

    }
    else
    {
        cerr << "Invalid arguments. Please check the usage instructions.\n";
        return -1;
    }

    return 0;
}

// encryption

// Def functions
/* ################################################################ */

void SavePrivateKey(const string& filename, const PrivateKey& key)
{
    ByteQueue queue;
    key.Save(queue);

    Save(filename, queue);
}

void SavePublicKey(const string& filename, const PublicKey& key)
{
    ByteQueue queue;
    key.Save(queue);

    Save(filename, queue);
}

void Save(const string& filename, const BufferedTransformation& bt)
{
    FileSink file(filename.c_str());

    bt.CopyTo(file);
    file.MessageEnd();
}

void SaveBase64PrivateKey(const string& filename, const PrivateKey& key)
{
    ByteQueue queue;
    key.Save(queue);

    SaveBase64(filename, queue);
}

void SaveBase64PublicKey(const string& filename, const PublicKey& key)
{
    ByteQueue queue;
    key.Save(queue);

    SaveBase64(filename, queue);
}

void SaveBase64(const string& filename, const BufferedTransformation& bt)
{
    Base64Encoder encoder;

    bt.CopyTo(encoder);
    encoder.MessageEnd();

    Save(filename, encoder);
}

void LoadPrivateKey(const string& filename, PrivateKey& key)
{
    // http://www.cryptopp.com/docs/ref/class_byte_queue.html
    ByteQueue queue;

    Load(filename, queue);
    key.Load(queue);
}

void LoadPublicKey(const string& filename, PublicKey& key)
{
    // http://www.cryptopp.com/docs/ref/class_byte_queue.html
    ByteQueue queue;

    Load(filename, queue);
    key.Load(queue);
}

void Load(const string& filename, BufferedTransformation& bt)
{
    // http://www.cryptopp.com/docs/ref/class_file_source.html
    FileSource file(filename.c_str(), true /*pumpAll*/);

    file.TransferTo(bt);
    bt.MessageEnd();
}

void LoadBase64(const string& filename, BufferedTransformation& bt)
{
    FileSource file(filename.c_str(), true, new Base64Decoder);

    file.TransferTo(bt);
    bt.MessageEnd();
}

void LoadBase64PrivateKey(const string& filename, PrivateKey& key)
{
    ByteQueue queue;
    LoadBase64(filename, queue);
    key.Load(queue);

    AutoSeededRandomPool prng;
    if (!key.Validate(prng, 3))
    {
        throw std::runtime_error("Loaded private key is invalid.");
    }
}

void LoadBase64PublicKey(const string& filename, PublicKey& key)
{
    ByteQueue queue;
    LoadBase64(filename, queue);
    key.Load(queue);

    AutoSeededRandomPool prng;
    if (!key.Validate(prng, 3))
    {
        throw std::runtime_error("Loaded public key is invalid.");
    }
}