#pragma once
#include "Point.h"
class Circle :
	public Point
{
public:
	void drawInstance(HDC, int, int, int, int, DrawProperties::Color) override;
};

