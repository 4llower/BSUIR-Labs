#include "Draw.h"

void Draw::addNewState(FigureState state)
{
	this->states.push_back(state);
}

void Draw::drawCurrentStates(HDC hdc)
{
	this->removeIntersectFigures();
	for (auto state : this->states) {
		auto [x, y, drawType, brushSize, objectSize, color] = state;

		switch (drawType) {
		case DrawProperties::DrawType::Point: {
			auto point = std::make_unique<Point>();
			point->drawInstance(hdc, x, y, brushSize, objectSize, color);
			break;
		}
		case DrawProperties::DrawType::Circle: {
			auto circle = std::make_unique<Circle>();
			circle->drawInstance(hdc, x, y, brushSize, objectSize, color);
			break;
		}
		case DrawProperties::DrawType::Square: {
			auto square = std::make_unique<Square>();
			square->drawInstance(hdc, x, y, brushSize, objectSize, color);
			break;
		}
		default: {
			auto point = std::make_unique<Point>();
			HBRUSH brush = CreateSolidBrush(point->getColor(color));
			SelectObject(hdc, brush);
			ExtFloodFill(hdc, x, y, GetPixel(hdc, x, y), FLOODFILLSURFACE);
			DeleteObject(brush);
			break;
		}
		}
	}
}

void Draw::removeIntersectFigures()
{

	if (this->states.empty()) return;
	std::vector<FigureState> newStates = {};
	std::vector<bool> layer(this->states.size(), true);
 	for (int i = this->states.size() - 1; i >= 0; --i) {
		if (layer[i]) {
			auto state = this->states[i];
			auto [x, y, drawType, brushSize, objectSize, color] = state;
			if (drawType == DrawProperties::DrawType::Filling && i != this->states.size() - 1) continue;
			for (int j = i - 1; j >= 0; --j) {
				auto state1 = this->states[j];
				auto [x1, y1, drawType1, brushSize1, objectSize1, color1] = state1;
				if (x - objectSize / 2 <= x1 && x1 <= x + objectSize / 2 && y - objectSize / 2 <= y1 && y1 <= y + objectSize / 2) {
					layer[j] = false;
				}
			}
			newStates.push_back(state);
		}
	}
	this->states.clear();
	std::copy(newStates.begin(), newStates.end(), std::back_inserter(this->states));
}
