#pragma once

#define MENU_ERASER 100
#define MENU_CIRCLE 101
#define MENU_SQUARE 102
#define MENU_PEN 103
#define MENU_FILLING 104


#define MENU_BRUSH_5px 200
#define MENU_BRUSH_10px 201
#define MENU_BRUSH_25px 202
#define MENU_BRUSH_50px 203

#define MENU_OBJECT_5px 300
#define MENU_OBJECT_10px 301
#define MENU_OBJECT_25px 302
#define MENU_OBJECT_50px 303

#define MENU_COLOR_RED 400
#define MENU_COLOR_BLUE 401
#define MENU_COLOR_GREEN 402

class DrawProperties {
public:
	enum class DrawType {
		Point,
		Square,
		Circle,
		Filling,
	};

	enum class Color {
		Red,
		Blue,
		White,
		Green,
	};
};