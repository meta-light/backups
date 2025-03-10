#include <stdbool.h>
#include <storage/storage.h>
#include "../solana_wallet.h"

bool solana_wallet_save_keys(SolanaWallet* app) {
    Storage* storage = furi_record_open(RECORD_STORAGE);
}

bool solana_wallet_load_keys(SolanaWallet* app) {
    Storage* storage = furi_record_open(RECORD_STORAGE);
} 