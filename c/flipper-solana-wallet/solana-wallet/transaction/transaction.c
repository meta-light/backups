#include <stdbool.h>
#include <stdint.h>
#include <stddef.h>
#include "../solana_wallet.h"

bool solana_sign_transaction(
    SolanaWallet* app,
    const uint8_t* transaction_data,
    size_t transaction_size,
    uint8_t* signature_out) {
} 