#pragma once

#include <gui/scene_manager.h>

void solana_scene_main_on_enter(void* context);
void solana_scene_create_on_enter(void* context);
void solana_scene_import_on_enter(void* context);
void solana_scene_address_on_enter(void* context);

extern const SceneManagerHandlers solana_wallet_scene_handlers; 