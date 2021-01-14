#pragma once
#include <vector>
#include <memory>
#include "Point.h"
#include "Circle.h"
#include "Square.h"

class Draw {
public:
	struct FigureState {
		int x, y;
		DrawProperties::DrawType drawType;
		int brushSize;
		int objectSize;
		DrawProperties::Color color;
	};

	void addNewState(FigureState);
	void drawCurrentStates(HDC);

private:
	std::vector<FigureState> states = {};
	void removeIntersectFigures();
};