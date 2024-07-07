#include <openssl/evp.h>
#include <openssl/pem.h>
#include <openssl/err.h>
#include <openssl/sha.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <chrono>
#include <string>
#include <iostream>

using namespace std;
using namespace std::chrono;

#ifdef BUILD_DLL
#define EXPORT __attribute__((visibility("default")))
#else
#define EXPORT
#endif

EXPORT void hashes(const char *algo, const char *input, const char *output_filename, bool isFile);

void hashes(const char *algo, const char *input, const char *output_filename, bool isFile)
{
    EVP_MD_CTX *hashes;
    const EVP_MD *md;
    FILE *f_in, *f_out;
    unsigned char buffer[1024];
    size_t read_bytes;
    unsigned char md_value[EVP_MAX_MD_SIZE];
    unsigned int md_len;
    int i;

    if (isFile)
    {
        // Open input file
        f_in = fopen(input, "rb");
        if (!f_in)
        {
            perror("Failed to open input file");
            exit(EXIT_FAILURE);
        }
    }
    else
    {
        // Use input from command line argument
        f_in = tmpfile();
        if (!f_in)
        {
            perror("Failed to create temporary file");
            exit(EXIT_FAILURE);
        }
        fwrite(input, 1, strlen(input), f_in);
        rewind(f_in);
    }

    // Open output file
    f_out = fopen(output_filename, "wb");
    if (!f_out)
    {
        perror("Failed to open output file");
        fclose(f_in);
        exit(EXIT_FAILURE);
    }

    // Get the message digest algorithm
    md = EVP_get_digestbyname(algo);
    if (!md)
    {
        fprintf(stderr, "Unknown message digest %s\n", algo);
        fclose(f_in);
        fclose(f_out);
        exit(EXIT_FAILURE);
    }

    // Initialize the message digest context
    hashes = EVP_MD_CTX_new();
    if (!hashes)
    {
        perror("Failed to create EVP_MD_CTX");
        fclose(f_in);
        fclose(f_out);
        exit(EXIT_FAILURE);
    }

    EVP_DigestInit_ex(hashes, md, NULL);

    // Read from the input file and update the digest
    while ((read_bytes = fread(buffer, 1, sizeof(buffer), f_in)) != 0)
    {
        EVP_DigestUpdate(hashes, buffer, read_bytes);
    }

    // Finalize the digest
    EVP_DigestFinal_ex(hashes, md_value, &md_len);
    EVP_MD_CTX_free(hashes);

    // Write the digest to the output file
    for (i = 0; i < md_len; i++)
    {
        fprintf(f_out, "%02x", md_value[i]);
    }
    fprintf(f_out, "\n");

    // Close files
    fclose(f_in);
    fclose(f_out);
}

long long current_timestamp()
{
    return duration_cast<milliseconds>(system_clock::now().time_since_epoch()).count();
}

int main(int argc, char **argv)
{
    if (argc != 3 && argc != 4)
    {
        cerr << "Usage: " << argv[0] << " <hash-algorithm> [<input-file>] <output-file>\n";
        exit(EXIT_FAILURE);
    }

    const char *algo = argv[1];
    const char *input = nullptr;
    const char *output_filename = nullptr;
    bool isFile = false;

    if (argc == 4)
    {
        input = argv[2];
        output_filename = argv[3];
        isFile = true;
    }
    else if (argc == 3)
    {
        output_filename = argv[2];
        cout << "Input the plain text: ";
        string plain;
        getline(cin, plain);
        input = plain.c_str();
        isFile = false;
    }

    auto start = std::chrono::high_resolution_clock::now();

    for (int i = 0; i < 10000; i++)
        hashes(algo, input, output_filename, isFile);

    auto stop = std::chrono::high_resolution_clock::now();

    auto duration = std::chrono::duration<double, std::milli>(stop - start);
    printf("\n----------------------------------------------------------\n");
    printf("Overview ECDSA Verification Test\n");
    printf("\nVerification time: %.3f milliseconds\n", duration);
    printf("----------------------------------------------------------\n");
    printf("Hashed saved to %s\n", output_filename);

    return 0;
}
