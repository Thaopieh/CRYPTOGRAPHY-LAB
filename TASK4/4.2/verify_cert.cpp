#include <openssl/bio.h>
#include <openssl/err.h>
#include <openssl/pem.h>
#include <openssl/x509.h>
#include <openssl/x509v3.h>

#include <string>
#include <iostream>
#include <fstream>
#include <stdint.h>

using namespace std;

int detect_pem(const char *filename)
{
    ifstream file(filename);
    if (!file.is_open())
    {
        return 2;
    }
    string line;
    getline(file, line);
    if (line != "-----BEGIN CERTIFICATE-----")
    {
        return 0;
    }
    while (getline(file, line))
    {
        if (line == "-----END CERTIFICATE-----")
        {
            return 1;
        }
    }
    return 0;
}

int sig_verify(X509 *intermediate, X509 *cert)
{
    EVP_PKEY *signing_key = X509_get_pubkey(intermediate);
    int result = X509_verify(cert, signing_key);
    EVP_PKEY_free(signing_key);
    return result;
}

void readCert(const char *filename, X509 **cert)
{
    BIO *cert_file = BIO_new(BIO_s_file());
    if (BIO_read_filename(cert_file, filename) <= 0)
    {
        cerr << "Error opening certificate file.\n";
        *cert = NULL;
    }
    int fileType = detect_pem(filename);
    if (fileType == 0)
    {
        *cert = d2i_X509_bio(cert_file, NULL);
        if (*cert == NULL)
        {
            cerr << "Error reading certificate.\n";
            *cert = NULL;
        }
    }
    else if (fileType == 1)
    {
        *cert = PEM_read_bio_X509(cert_file, NULL, 0, NULL);
        if (*cert == NULL)
        {
            cerr << "Error reading certificate.\n";
            *cert = NULL;
        }
    }
    BIO_free_all(cert_file);
}
void printInFormat(string hex)
{
    cout << '\t';
    for (int i = 0; i < hex.length(); i++)
    {
        cout << hex[i];
        if (i % 2 && (i + 1 != hex.length()))
            cout << ':';
        if ((i + 1) % 30 == 0)
            cout << "\n\t";
    }
    cout << endl;
}

string printDateTime(const ASN1_TIME *time)
{
    BIO *bio = BIO_new(BIO_s_mem());
    ASN1_TIME_print(bio, time);
    char *printTime = new char[BIO_number_written(bio) + 1];
    memset(printTime, 0, BIO_number_written(bio) + 1);
    BIO_read(bio, printTime, BIO_number_written(bio));
    string time_str = string(printTime);
    delete[] printTime;
    BIO_free(bio);
    return time_str;
}

void validateAndPrintCertificate(const char *fileCert, const char *intermediate)
{
    X509 *cert = NULL;
    X509 *inter = NULL;

    // Read certificate files
    readCert(fileCert, &cert);
    if (cert == NULL)
    {
        cerr << "Error reading certificate: " << fileCert << endl;
        return;
    }

    readCert(intermediate, &inter);
    if (inter == NULL)
    {
        cerr << "Error reading intermediate certificate: " << intermediate << endl;
        X509_free(cert);
        return;
    }

    // Verify certificate chain
    if (sig_verify(inter, cert))
    {
        cout << "Validate certificate successfully!!!" << endl;

        char *subject_name = X509_NAME_oneline(X509_get_subject_name(cert), NULL, 0);
        char *issuer_name = X509_NAME_oneline(X509_get_issuer_name(cert), NULL, 0);

        // Print certificate details
        cout << "Subject: " << string(subject_name) << endl;
        cout << "Issuer: " << string(issuer_name) << endl;

        // Subject public key info
        EVP_PKEY *pubkey = X509_get_pubkey(cert);
        if (pubkey == NULL)
        {
            cerr << "Error reading public key.\n";
            X509_free(cert);
            X509_free(inter);
            return;
        }
        else
        {
            int type = EVP_PKEY_base_id(pubkey);
            const char *name = OBJ_nid2ln(type);
            cout << "Subject Public Key Info: \n";

            // Handle EC keys
            if (EVP_PKEY_id(pubkey) == EVP_PKEY_EC)
            {
                EC_KEY *ec_key = EVP_PKEY_get1_EC_KEY(pubkey);
                const EC_GROUP *ec_group = EC_KEY_get0_group(ec_key);
                int curve_nid = EC_GROUP_get_curve_name(ec_group);
                const char *curve_name = OBJ_nid2sn(curve_nid);

                cout << "\tPublic Key Algorithm: " << name << "\n";
                cout << "\tPublic-Key: (" << EVP_PKEY_bits(pubkey) << " bit)\n";

                // Print EC public key in hex format
                const EC_POINT *pub_point = EC_KEY_get0_public_key(ec_key);
                BIGNUM *bn = EC_POINT_point2bn(ec_group, pub_point, EC_KEY_get_conv_form(ec_key), NULL, NULL);
                char *hex = BN_bn2hex(bn);
                printInFormat(string(hex));
                OPENSSL_free(hex);
                BN_free(bn);

                cout << "\tASN1 OID: " << curve_name << "\n";
                cout << "NIST CURVE: " << curve_name << "\n";
                EC_KEY_free(ec_key);
            }
            // Handle RSA keys
            else if (EVP_PKEY_id(pubkey) == EVP_PKEY_RSA)
            {
                RSA *rsa_key = EVP_PKEY_get1_RSA(pubkey);

                cout << "\tPublic Key Algorithm: " << name << "\n";
                cout << "\tPublic-Key: (" << RSA_bits(rsa_key) << " bit)\n";

                const BIGNUM *n = NULL;
                const BIGNUM *e = NULL;
                RSA_get0_key(rsa_key, &n, &e, NULL);

                // Print modulus in hex format
                char *hex_n = BN_bn2hex(n);
                cout << "\tModulus:\n";
                printInFormat(hex_n);
                OPENSSL_free(hex_n);

                // Print exponent in hex format
                char *hex_e = BN_bn2hex(e);
                cout << "\tExponent: " << hex_e << "\n";
                OPENSSL_free(hex_e);

                RSA_free(rsa_key);
            }
            else
            {
                cerr << "Unsupported subject public key algorithm!!!" << endl;
                EVP_PKEY_free(pubkey);
                X509_free(cert);
                X509_free(inter);
                return;
            }

            // Print signature
            const ASN1_BIT_STRING *signature;
            X509_get0_signature(&signature, NULL, cert);
            if (signature == NULL)
            {
                cerr << "Error reading signature.\n";
                EVP_PKEY_free(pubkey);
                X509_free(cert);
                X509_free(inter);
                return;
            }
            else
            {
                BIO *bio = BIO_new(BIO_s_mem());
                i2a_ASN1_STRING(bio, signature, V_ASN1_OCTET_STRING);
                BUF_MEM *bptr;
                BIO_get_mem_ptr(bio, &bptr);

                // bptr->data contains the hex string
                string hex_str(bptr->data, bptr->length);
                cout << "Signature:\n"
                     << hex_str << endl;

                BIO_free_all(bio);
            }

            // Print signature algorithm
            const X509_ALGOR *sig_alg;
            X509_get0_signature(NULL, &sig_alg, cert);
            if (sig_alg == NULL)
            {
                cerr << "Error reading signature algorithm.\n";
            }
            else
            {
                int pkey_nid = OBJ_obj2nid(sig_alg->algorithm);
                string ln = string(OBJ_nid2ln(pkey_nid));
                cout << "Signature algorithm: " << ln << "\n";
            }

            // Print validity dates
            const ASN1_TIME *not_before = X509_get0_notBefore(cert);
            const ASN1_TIME *not_after = X509_get0_notAfter(cert);
            cout << "Validity:\n";
            cout << "\tNot before: " << printDateTime(not_before) << endl;
            cout << "\tNot after: " << printDateTime(not_after) << endl;

            // Print purposes
            cout << "Purpose: ";
            for (int i = 0; i < X509_PURPOSE_get_count(); i++)
            {
                X509_PURPOSE *purpose = X509_PURPOSE_get0(i);
                int id = X509_PURPOSE_get_id(purpose);
                if (X509_check_purpose(cert, id, 0))
                    cout << X509_PURPOSE_get0_name(purpose) << " ";
            }
            cout << endl;

            EVP_PKEY_free(pubkey);
        }

        OPENSSL_free(subject_name);
        OPENSSL_free(issuer_name);
    }
    else
    {
        cout << "Failed to validate certificate!!!" << endl;
    }

    // Free certificate structures
    X509_free(cert);
    X509_free(inter);
}

int main(int argc, char **argv)
{
    if (argc != 3)
    {
        fprintf(stderr, "Usage: %s <certificate-file> <intermediate-certificate>\n\tYou can choose both type DER and PEM", argv[0]);

        exit(EXIT_FAILURE);
    }

    const char *fileCert = argv[1];
    const char *intermediate = argv[2];

    validateAndPrintCertificate(fileCert, intermediate);

    return 0;
}
