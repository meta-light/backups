#include "solana_wallet.h"
#include <furi.h>

static bool solana_wallet_custom_event_callback(void* context, uint32_t event) {
    furi_assert(context);
    SolanaWallet* app = context;
    return scene_manager_handle_custom_event(app->scene_manager, event);
}

static bool solana_wallet_back_event_callback(void* context) {
    furi_assert(context);
    SolanaWallet* app = context;
    return scene_manager_handle_back_event(app->scene_manager);
}

static SolanaWallet* solana_wallet_alloc() {
    SolanaWallet* app = malloc(sizeof(SolanaWallet));

    // GUI
    app->gui = furi_record_open(RECORD_GUI);
    app->view_dispatcher = view_dispatcher_alloc();
    app->scene_manager = scene_manager_alloc(&solana_wallet_scene_handlers, app);
    app->notifications = furi_record_open(RECORD_NOTIFICATION);

    // View allocation
    app->main_view = main_view_alloc(app);
    app->create_view = create_view_alloc(app);
    app->import_view = import_view_alloc(app);
    app->address_view = address_view_alloc(app);

    // View configuration
    view_dispatcher_add_view(
        app->view_dispatcher, SolanaWalletViewMain, app->main_view);
    view_dispatcher_add_view(
        app->view_dispatcher, SolanaWalletViewCreate, app->create_view);
    view_dispatcher_add_view(
        app->view_dispatcher, SolanaWalletViewImport, app->import_view);
    view_dispatcher_add_view(
        app->view_dispatcher, SolanaWalletViewAddress, app->address_view);

    // Wallet data
    app->keys = malloc(sizeof(SolanaWalletKeys));
    app->keys->has_wallet = false;

    return app;
}

static void solana_wallet_free(SolanaWallet* app) {
    furi_assert(app);

    // Free views
    view_dispatcher_remove_view(app->view_dispatcher, SolanaWalletViewMain);
    view_dispatcher_remove_view(app->view_dispatcher, SolanaWalletViewCreate);
    view_dispatcher_remove_view(app->view_dispatcher, SolanaWalletViewImport);
    view_dispatcher_remove_view(app->view_dispatcher, SolanaWalletViewAddress);
    
    view_free(app->main_view);
    view_free(app->create_view);
    view_free(app->import_view);
    view_free(app->address_view);

    // Free GUI
    view_dispatcher_free(app->view_dispatcher);
    scene_manager_free(app->scene_manager);
    furi_record_close(RECORD_GUI);
    furi_record_close(RECORD_NOTIFICATION);

    // Free wallet data
    free(app->keys);
    free(app);
}

int32_t solana_wallet_app(void* p) {
    UNUSED(p);
    SolanaWallet* app = solana_wallet_alloc();

    view_dispatcher_enable_queue(app->view_dispatcher);
    view_dispatcher_attach_to_gui(
        app->view_dispatcher, app->gui, ViewDispatcherTypeFullscreen);
    
    view_dispatcher_run(app->view_dispatcher);

    solana_wallet_free(app);
    return 0;
} 