#pragma once
#include "Point.h"
class Square :
	public Point
{
public:
	void drawInstance(HDC, int, int, int, int, DrawProperties::Color) override;
};

