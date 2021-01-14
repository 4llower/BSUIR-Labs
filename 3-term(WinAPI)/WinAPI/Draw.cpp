#include "Draw.h"

void Draw::addNewState(FigureState state)
{
	this->states.push_back(state);
}

void Draw::drawCurrentStates(HDC hdc)
{
	for (auto state : this->states) {
		auto [x, y, drawType, length, color] = state;

		switch (drawType) {
		case DrawProperties::DrawType::Point: {
			auto point = new Point();
			point->drawInstance(hdc, x, y, length, color);
			break;
		}
		case DrawProperties::DrawType::Circle: {
			break;
		}
		case DrawProperties::DrawType::Square: {
			break;
		}
		}
	}
}
