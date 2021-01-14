#include "Point.h"

COLORREF Point::getColor(DrawProperties::Color color)
{
	switch (color) {
	case DrawProperties::Color::Blue:
		return BLUE;
	case DrawProperties::Color::Green:
		return GREEN;
	case DrawProperties::Color::Red:
		return RED;
	default:
		return WHITE;
	}
}

void Point::drawInstance(HDC hdc, int x, int y, int brushSize, int objectSize, DrawProperties::Color color)
{
	auto brush = CreateSolidBrush(this->getColor(color));
	auto pen = CreatePen(PS_SOLID, 1, this->getColor(color));
	SelectObject(hdc, brush);
	SelectObject(hdc, pen);
	
	Ellipse(hdc, x - objectSize / 2, y - objectSize / 2, x + objectSize / 2, y + objectSize / 2);

	DeleteObject(brush);
	DeleteObject(pen);
}
