#pragma once

#ifdef AES_EXPORTS
#define AES_128_API __declspec(dllexport)
#else
#define AES_128_API __declspec(dllimport)
#endif

typedef unsigned char byte;

extern "C++" AES_128_API byte* generateKey();

extern "C++" AES_128_API void setKey(byte* key);

extern "C++" AES_128_API void encrypt(byte* bytes, int count_block, bool isMixing = false);

extern "C++" AES_128_API void decrypt(byte* bytes, int count_block, bool isMixing = false);

extern "C++" AES_128_API void print(byte* bytes);

//extern "C++" AES_128_API void encryptOneBlock(byte* bytes);

//extern "C++" AES_128_API void decryptOneBlock(byte* bytes);