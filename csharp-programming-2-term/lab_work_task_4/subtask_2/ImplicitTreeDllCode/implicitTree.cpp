#include "pch.h"
#include "implicitTree.h"

const int BORDER = 2147483647;
const int CAPACITY = 33;
int currentEmpty = 2;

struct Tree {
	int value = 0, left, right;
};


vector <Tree> p(1e7);

void _stdcall insert(int value) {
	if (value > BORDER) return;
	if (value < 0) return;
	modify(1, 0, BORDER, value, 1);
}

void _stdcall erase(int value) {
	if (value > BORDER) return;
	if (value < 0) return;
	modify(1, 0, BORDER, value, 0);
}

int _stdcall getAmountBetween(int leftBorder, int rightBorder) {
	return get(1, 0, BORDER, leftBorder, rightBorder);
}

void modify(int v, int ls, int rs, int pos, int val) {
	if (ls == rs) {
		p[v].value = val;
		return;
	}
	int mid = (ls + rs) / 2;
	if (pos <= mid) {
		if (p[v].left == 0) {
			if (val == 0) return;
			p[v].left = currentEmpty++;
		}
		modify(p[v].left, ls, mid, pos, val);
	}
	else {
		if (p[v].right == 0) {
			if (val == 0) return;
			p[v].right = currentEmpty++;
		}
		modify(p[v].right, mid + 1, rs, pos, val);
	}
	p[v].value = p[p[v].left].value + p[p[v].right].value;
}

int get(int v, int ls, int rs, int l, int r) {
	if (l > r) return 0;
	if (ls == l && rs == r) {
		return p[v].value;
	}
	int mid = (ls + rs) / 2;
	return (p[v].left != 0 ? get(p[v].left, ls, mid, l, min(r, mid)) : 0) + (p[v].right != 0 ? get(p[v].right, mid + 1, rs, max(mid + 1, l), r) : 0);
}



