#include "Point.h"

COLORREF Point::getColor(DrawProperties::Color color)
{
	switch (color) {
	case DrawProperties::Color::Blue:
		return RED;
	case DrawProperties::Color::Green:
		return GREEN;
	case DrawProperties::Color::Red:
		return RED;
	default:
		return WHITE;
	}
}

void Point::drawInstance(HDC hdc, int x, int y, int length, DrawProperties::Color color)
{
	auto brush = CreateSolidBrush(RED);
	auto pen = CreatePen(PS_SOLID, 1,RED);
	SelectObject(hdc, brush);
	SelectObject(hdc, pen);
	
	Ellipse(hdc, x - length / 2, y - length / 2, x + length / 2, y + length / 2);

	DeleteObject(brush);
	DeleteObject(pen);
}
