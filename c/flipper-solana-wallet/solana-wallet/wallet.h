#pragma once

#include "solana_wallet.h"
#include "helpers/error.h"

typedef struct {
    uint8_t address[32];  // Base58 encoded public key
    uint64_t balance;
    bool is_initialized;
} SolanaAccount;

// Initialize or create new wallet
SolanaWalletError wallet_create(SolanaWallet* app);

// Import existing wallet from private key
SolanaWalletError wallet_import(SolanaWallet* app, const uint8_t* private_key);

// Get wallet address as Base58 string
SolanaWalletError wallet_get_address(SolanaWallet* app, char* address_out);

// Sign a transaction
SolanaWalletError wallet_sign_transaction(
    SolanaWallet* app,
    const uint8_t* transaction_data,
    size_t transaction_size,
    uint8_t* signature_out);

// Save wallet to storage
SolanaWalletError wallet_save(SolanaWallet* app);

// Load wallet from storage
SolanaWalletError wallet_load(SolanaWallet* app); 