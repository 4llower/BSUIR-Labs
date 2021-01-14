#pragma once
#include <vector>
#include <memory>
#include "Point.h"

class Draw {
public:
	struct FigureState {
		int x, y;
		DrawProperties::DrawType drawType;
		int length;
		DrawProperties::Color color;
	};

	void addNewState(FigureState);
	void drawCurrentStates(HDC);

private:
	std::vector<FigureState> states = {};
};