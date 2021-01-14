#pragma once
#include "DrawProperties.h"
#include <windows.h>

#define RED RGB(255, 0, 0)
#define GREEN RGB(0, 128, 0)
#define BLUE RGB(0, 0, 255)
#define WHITE RGB(255, 255, 255)

class Point
{
public:
    virtual void drawInstance(HDC, int, int, int, DrawProperties::Color);
private:
    COLORREF getColor(DrawProperties::Color);
};

