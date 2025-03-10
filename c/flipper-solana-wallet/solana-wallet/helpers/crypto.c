#include "crypto.h"
#include <furi_hal_crypto.h>
#include <furi_hal_random.h>

bool solana_generate_keypair(uint8_t* private_key, uint8_t* public_key) {
    // Get random seed
    furi_hal_random_fill_buf(private_key, 32);
    // Generate public key from private key
    furi_hal_crypto_store_load_key(private_key, 32);
    furi_hal_crypto_pubkey_compute(public_key);
    return true;
}

bool solana_import_private_key(const uint8_t* private_key_bytes, uint8_t* public_key) {
    furi_hal_crypto_store_load_key(private_key_bytes, 32);
    furi_hal_crypto_pubkey_compute(public_key);
    return true;
}

bool solana_sign_message(
    const uint8_t* private_key,
    const uint8_t* message,
    size_t message_size,
    uint8_t* signature) {
    furi_hal_crypto_store_load_key(private_key, 32);
    return furi_hal_crypto_sign(message, message_size, signature);
}

bool solana_verify_signature(
    const uint8_t* public_key,
    const uint8_t* message,
    size_t message_size,
    const uint8_t* signature) {
    return furi_hal_crypto_verify(message, message_size, signature, public_key);
} 