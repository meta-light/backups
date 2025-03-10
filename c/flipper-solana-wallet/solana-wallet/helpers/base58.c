#include "base58.h"
#include <string.h>

static const char base58_alphabet[] = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

bool base58_encode(const uint8_t* data, size_t data_size, char* str, size_t* str_size) {
    size_t zeros = 0;
    while(zeros < data_size && data[zeros] == 0) {
        zeros++;
    }

    size_t size = (data_size - zeros) * 138 / 100 + 1;
    uint8_t* buffer = malloc(size);
    if(buffer == NULL) return false;

    memset(buffer, 0, size);
    for(size_t i = zeros; i < data_size; i++) {
        uint32_t carry = data[i];
        for(size_t j = 0; j < size; j++) {
            carry += (uint32_t)buffer[j] << 8;
            buffer[j] = carry % 58;
            carry /= 58;
        }
    }

    size_t result_size = zeros;
    while(result_size < size && buffer[result_size] == 0) {
        result_size++;
    }
    result_size = size - result_size + zeros;

    if(result_size > *str_size) {
        free(buffer);
        return false;
    }

    for(size_t i = 0; i < zeros; i++) {
        str[i] = '1';
    }

    for(size_t i = zeros; i < result_size; i++) {
        str[i] = base58_alphabet[buffer[size - 1 - (i - zeros)]];
    }

    str[result_size] = '\0';
    *str_size = result_size;
    free(buffer);
    return true;
}

bool base58_decode(const char* str, size_t str_size, uint8_t* data, size_t* data_size) {
    size_t zeros = 0;
    while(zeros < str_size && str[zeros] == '1') {
        zeros++;
    }

    size_t size = (str_size - zeros) * 733 / 1000 + 1;
    uint8_t* buffer = malloc(size);
    if(buffer == NULL) return false;

    memset(buffer, 0, size);
    for(size_t i = zeros; i < str_size; i++) {
        const char* p = strchr(base58_alphabet, str[i]);
        if(p == NULL) {
            free(buffer);
            return false;
        }

        uint32_t carry = p - base58_alphabet;
        for(size_t j = 0; j < size; j++) {
            carry += (uint32_t)buffer[j] * 58;
            buffer[j] = carry & 0xff;
            carry >>= 8;
        }
    }

    size_t result_size = zeros;
    while(result_size < size && buffer[result_size] == 0) {
        result_size++;
    }
    result_size = size - result_size + zeros;

    if(result_size > *data_size) {
        free(buffer);
        return false;
    }

    memset(data, 0, zeros);
    for(size_t i = zeros; i < result_size; i++) {
        data[i] = buffer[size - 1 - (i - zeros)];
    }

    *data_size = result_size;
    free(buffer);
    return true;
} 