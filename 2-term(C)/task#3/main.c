#include <stdio.h>
#include <stdlib.h>

int n, m, i, j, last_move = -1, now;
int** a;

int ax[4] = {0, 1, 0, -1};
int ay[4] = {1, 0, -1, 0};

int check(int x, int y) {
    return (x < n && x >= 0 && y < m && y >= 0) && a[x][y] == 0;
}

void change_last_move(int x, int y) {
    if (check(x, y + 1)) last_move = 0;
    else if (check(x + 1, y)) last_move = 1;
    else if (check(x, y - 1)) last_move = 2;
    else last_move = 3;
}

void add(int x, int y) {

    a[x][y] = ++now;

    if (now == n * m) return;

    if (last_move == -1) change_last_move(x, y);
    if (check(x + ax[last_move], y + ay[last_move])) add(x + ax[last_move], y + ay[last_move]);
    else {
        change_last_move(x, y);
        add(x + ax[last_move], y + ay[last_move]);
    }
}

int main() {

    puts("Enter size of your matrix: ");
    scanf("%d%d", &n, &m);

    if (n == 0 && m == 0){
        puts("Matrix with this sizes is not exists");
        return 0;
    }

    a = (int **) malloc(n * sizeof(int*));

    for (i = 0; i < n; ++i){
        a[i] = (int *) malloc(m * sizeof(int*));
        for (j = 0; j < m; ++j) a[i][j] = 0;
    }

    add(0, 0);

    for (i = 0; i < n; ++i){
        for (j = 0; j < m; ++j) printf("%d ", a[i][j]);
        printf("\n");
    }


    return 0;
}
