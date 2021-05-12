import numpy as np
from copy import copy
import random
n = 5


def classic_gauss_method(a1, b1):
    a, b = copy(a1), copy(b1)
    x = np.zeros(n)
    for i in range(0, n):
        for j in range(i + 1, n):
            q = a[j][i] / a[i][i]
            a[j] -= a[i] * q
            b[j] -= b[i] * q

    for i in reversed(range(n)):
        for j in range(i + 1, n):
            b[i] -= a[i][j] * x[j]
        x[i] = b[i] / a[i][i]
    return x


def main_elem_by_column(a1, b1):
    a, b = copy(a1), copy(b1)
    x = np.zeros(n)
    for i in range(0, n):
        mx = 0
        nm = -1
        for j in range(i, n):
            if abs(a[j][i]) > mx:
                mx = abs(a[j][i])
                nm = j
        #swapping ith row with nmth row
        temp = copy(a[i])
        a[i] = copy(a[nm])
        a[nm] = temp

        temp = copy(b[i])
        b[i] = copy(b[nm])
        b[nm] = temp
        for j in range(i + 1, n):
            q = a[j][i] / a[i][i]
            a[j] -= a[i] * q
            b[j] -= b[i] * q

    for i in reversed(range(n)):
        for j in range(i + 1, n):
            b[i] -= a[i][j] * x[j]
        x[i] = b[i] / a[i][i]
    return x


def main_elem_by_matrix(a1, b1):
    a, b = copy(a1), copy(b1)
    x = np.zeros(n)
    lst = []
    for i in range(0, n):
        mx = 0
        x1, y1 = -1, -1
        for i1 in range(i, n):
            for j1 in range(0, n):
                if abs(a[i1][j1]) >= mx:
                    mx = abs(a[i1][j1])
                    x1 = i1
                    y1 = j1
        lst.append(y1)
        #swapping ith row with xth row
        temp = copy(a[i])
        a[i] = copy(a[x1])
        a[x1] = temp

        temp = copy(b[i])
        b[i] = copy(b[x1])
        b[x1] = temp
        for j in range(i + 1, n):
            q = a[j][y1] / a[i][y1]
            a[j] -= a[i] * q
            b[j] -= b[i] * q
    for i in reversed(range(n)):
        for j in range(i + 1, n):
            b[i] -= a[i][lst[j]] * x[lst[j]]
        x[lst[i]] = b[i] / a[i][lst[i]]
    return x


def built_in_method(a, b):
    return np.linalg.inv(a).dot(b)


k = 3
c = np.array([[0.2,  0,  0.2,  0, 0],
              [0, 0.2,  0,  0.2,  0],
              [0.2,  0,  0.2,  0, 0.2],
              [0, 0.2,  0,  0.2,  0],
              [0,  0,  0.2,  0, 0.2]])


d = np.array([[2.33, 0.81, 0.67, 0.92, -0.53],
              [-0.53, 2.33, 0.81, 0.67, 0.92],
              [0.92, -0.53, 2.33, 0.81, 0.67],
              [0.67, 0.92, -0.53, 2.33, 0.81],
              [0.81, 0.67, 0.92, -0.53, 2.33]])

b = np.array([4.2, 4.2, 4.2, 4.2, 4.2])

a = k * c + d

print(a)
exp = 4
print(np.round(built_in_method(a, b), exp))
print(np.round(classic_gauss_method(a, b), exp))
print(np.round(main_elem_by_column(a, b), exp))
print(np.round(main_elem_by_matrix(a, b), exp))