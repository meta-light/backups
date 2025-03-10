#pragma once

#include <furi.h>
#include <gui/gui.h>
#include <gui/view_dispatcher.h>
#include <gui/scene_manager.h>
#include <notification/notification_messages.h>

#define TAG "SolanaWallet"

typedef struct {
    bool has_wallet;
    uint8_t private_key[32];
    uint8_t public_key[32];
    // Add other necessary key data
} SolanaWalletKeys;

typedef struct {
    // GUI
    Gui* gui;
    ViewDispatcher* view_dispatcher;
    SceneManager* scene_manager;
    NotificationApp* notifications;
    
    // Views
    View* main_view;
    View* create_view;
    View* import_view;
    View* address_view;
    
    // Data
    SolanaWalletKeys* keys;
} SolanaWallet;

typedef enum {
    SolanaSceneMain,
    SolanaSceneCreate,
    SolanaSceneImport,
    SolanaSceneAddress,
    SolanaSceneSignTransaction,
    // Add other scenes as needed
} SolanaScene;

typedef enum {
    SolanaWalletViewMain,
    SolanaWalletViewCreate,
    SolanaWalletViewImport,
    SolanaWalletViewAddress,
    // Add other views as needed
} SolanaWalletView;

extern const SceneManagerHandlers solana_wallet_scene_handlers; 