#include "wallet.h"
#include <furi.h>
#include <storage/storage.h>
#include <furi_hal_random.h>
#include "helpers/base58.h"

static const char* WALLET_FILE_PATH = EXT_PATH("apps/solana/.wallet");

SolanaWalletError wallet_create(SolanaWallet* app) {
    if(!solana_generate_keypair(app->keys->private_key, app->keys->public_key)) {
        return SolanaWalletErrorCrypto;
    }
    
    app->keys->has_wallet = true;
    return wallet_save(app);
}

SolanaWalletError wallet_import(SolanaWallet* app, const uint8_t* private_key) {
    if(!solana_import_private_key(private_key, app->keys->public_key)) {
        return SolanaWalletErrorCrypto;
    }
    
    memcpy(app->keys->private_key, private_key, 32);
    app->keys->has_wallet = true;
    return wallet_save(app);
}

SolanaWalletError wallet_get_address(SolanaWallet* app, char* address_out) {
    if(!app->keys->has_wallet) {
        return SolanaWalletErrorInvalidInput;
    }
    
    size_t len = 45;  // Base58 encoded public key length
    if(!base58_encode(app->keys->public_key, 32, address_out, &len)) {
        return SolanaWalletErrorCrypto;
    }
    
    return SolanaWalletErrorNone;
}

SolanaWalletError wallet_sign_transaction(
    SolanaWallet* app,
    const uint8_t* transaction_data,
    size_t transaction_size,
    uint8_t* signature_out) {
    if(!app->keys->has_wallet) {
        return SolanaWalletErrorInvalidInput;
    }
    
    if(!solana_sign_message(
        app->keys->private_key,
        transaction_data,
        transaction_size,
        signature_out)) {
        return SolanaWalletErrorCrypto;
    }
    
    return SolanaWalletErrorNone;
}

SolanaWalletError wallet_save(SolanaWallet* app) {
    Storage* storage = furi_record_open(RECORD_STORAGE);
    File* file = storage_file_alloc(storage);
    
    if(!storage_file_open(file, WALLET_FILE_PATH, FSAM_WRITE, FSOM_CREATE_ALWAYS)) {
        storage_file_free(file);
        furi_record_close(RECORD_STORAGE);
        return SolanaWalletErrorStorage;
    }
    
    // TODO: Add encryption before saving
    uint16_t written = storage_file_write(file, app->keys, sizeof(SolanaWalletKeys));
    storage_file_close(file);
    storage_file_free(file);
    furi_record_close(RECORD_STORAGE);
    
    return written == sizeof(SolanaWalletKeys) ? 
        SolanaWalletErrorNone : SolanaWalletErrorStorage;
}

SolanaWalletError wallet_load(SolanaWallet* app) {
    Storage* storage = furi_record_open(RECORD_STORAGE);
    File* file = storage_file_alloc(storage);
    
    if(!storage_file_open(file, WALLET_FILE_PATH, FSAM_READ, FSOM_OPEN_EXISTING)) {
        storage_file_free(file);
        furi_record_close(RECORD_STORAGE);
        return SolanaWalletErrorStorage;
    }
    
    // TODO: Add decryption after loading
    uint16_t read = storage_file_read(file, app->keys, sizeof(SolanaWalletKeys));
    storage_file_close(file);
    storage_file_free(file);
    furi_record_close(RECORD_STORAGE);
    
    return read == sizeof(SolanaWalletKeys) ? 
        SolanaWalletErrorNone : SolanaWalletErrorStorage;
} 