#pragma once

#include <stddef.h>
#include <stdbool.h>
#include <stdint.h>

/**
 * Encode binary data into base58 string
 * @param data Input binary data
 * @param data_size Size of input data
 * @param str Output string buffer
 * @param str_size Size of output string buffer, will be updated with actual size
 * @return true on success
 */
bool base58_encode(const uint8_t* data, size_t data_size, char* str, size_t* str_size);

/**
 * Decode base58 string into binary data
 * @param str Input string
 * @param str_size Size of input string
 * @param data Output binary buffer
 * @param data_size Size of output buffer, will be updated with actual size
 * @return true on success
 */
bool base58_decode(const char* str, size_t str_size, uint8_t* data, size_t* data_size); 