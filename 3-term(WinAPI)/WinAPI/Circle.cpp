#include "Circle.h"

void Circle::drawInstance(HDC hdc, int x, int y, int brushSize, int objectSize, DrawProperties::Color color) {
	auto pen = CreatePen(PS_SOLID, brushSize, this->getColor(color));
	auto brush = CreateSolidBrush(WHITE);
	SelectObject(hdc, pen);

	Ellipse(hdc, x - objectSize / 2, y - objectSize / 2, x + objectSize / 2, y + objectSize / 2);

	DeleteObject(pen);
	DeleteObject(brush);
}