#include "scenes.h"
#include "../solana_wallet.h"

const AppSceneOnEnterCallback scene_on_enter_handlers[] = {
    solana_scene_main_on_enter,
    solana_scene_create_on_enter,
    solana_scene_import_on_enter,
    solana_scene_address_on_enter,
};

const SceneManagerHandlers solana_wallet_scene_handlers = {
    .on_enter_handlers = scene_on_enter_handlers,
    .on_event_handlers = NULL,
    .on_exit_handlers = NULL,
    .scene_num = 4,
}; 