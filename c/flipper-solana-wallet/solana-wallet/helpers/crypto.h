#pragma once

#include <stdint.h>
#include "../solana_wallet.h"

// Generate new Ed25519 keypair
bool solana_generate_keypair(uint8_t* private_key, uint8_t* public_key);

// Import private key from bytes
bool solana_import_private_key(const uint8_t* private_key_bytes, uint8_t* public_key);

// Sign message using private key
bool solana_sign_message(
    const uint8_t* private_key,
    const uint8_t* message,
    size_t message_size,
    uint8_t* signature);

// Verify signature
bool solana_verify_signature(
    const uint8_t* public_key,
    const uint8_t* message,
    size_t message_size,
    const uint8_t* signature); 