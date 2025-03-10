#include <gui/canvas.h>
#include <gui/view.h>
#include "../solana_wallet.h"

typedef struct {
    SolanaWallet* app;
    uint8_t selected_menu_item;
} MainViewModel;

static void main_view_draw_callback(Canvas* canvas, void* context) {
    MainViewModel* model = context;
    canvas_clear(canvas);
    canvas_set_font(canvas, FontPrimary);
    
    const char* menu_items[] = {
        "Create Wallet",
        "Import Wallet",
        "View Address",
        "Sign Transaction",
        "Settings"
    };
    
    for(int i = 0; i < 5; i++) {
        if(i == model->selected_menu_item) {
            canvas_set_color(canvas, ColorBlack);
            canvas_draw_box(canvas, 0, i * 12, 128, 12);
            canvas_set_color(canvas, ColorWhite);
        } else {
            canvas_set_color(canvas, ColorBlack);
        }
        canvas_draw_str(canvas, 2, (i * 12) + 10, menu_items[i]);
    }
}

static bool main_view_input_callback(InputEvent* event, void* context) {
    MainViewModel* model = context;
    bool consumed = false;

    if(event->type == InputTypeShort) {
        switch(event->key) {
            case InputKeyUp:
                if(model->selected_menu_item > 0) {
                    model->selected_menu_item--;
                    consumed = true;
                }
                break;
            case InputKeyDown:
                if(model->selected_menu_item < 4) {
                    model->selected_menu_item++;
                    consumed = true;
                }
                break;
            case InputKeyOk:
                scene_manager_handle_custom_event(
                    model->app->scene_manager, 
                    model->selected_menu_item);
                consumed = true;
                break;
            case InputKeyBack:
                view_dispatcher_stop(model->app->view_dispatcher);
                consumed = true;
                break;
            default:
                break;
        }
    }

    return consumed;
}

View* main_view_alloc(SolanaWallet* app) {
    View* view = view_alloc();
    MainViewModel* model = malloc(sizeof(MainViewModel));
    model->app = app;
    model->selected_menu_item = 0;
    
    view_set_context(view, model);
    view_set_draw_callback(view, main_view_draw_callback);
    view_set_input_callback(view, main_view_input_callback);
    
    return view;
}

void main_view_free(View* view) {
    MainViewModel* model = view_get_context(view);
    free(model);
    view_free(view);
} 