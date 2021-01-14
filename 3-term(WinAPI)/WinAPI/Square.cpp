#include "Square.h"

void Square::drawInstance(HDC hdc, int x, int y, int brushSize, int objectSize, DrawProperties::Color color) {
	auto pen = CreatePen(PS_SOLID, brushSize, this->getColor(color));
	auto brush = CreateSolidBrush(WHITE);
	SelectObject(hdc, pen);
	SelectObject(hdc, brush);
	Rectangle(hdc, x - objectSize / 2, y - objectSize / 2, x + objectSize / 2, y + objectSize / 2);
	DeleteObject(pen);
	DeleteObject(brush);
}