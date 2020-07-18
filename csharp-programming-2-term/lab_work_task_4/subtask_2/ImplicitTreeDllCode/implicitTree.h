#pragma once

#include <vector>

using namespace std;

extern "C" __declspec(dllexport) void _stdcall erase(int);
extern "C" __declspec(dllexport) int _stdcall getAmountBetween(int, int);
extern "C" __declspec(dllexport) void _stdcall insert(int);

void modify(int, int, int, int, int);
int get(int, int, int, int, int);
