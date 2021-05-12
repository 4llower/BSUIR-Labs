#include <iostream>
#include <iomanip>
#include <windows.h>
#include <math.h>

using namespace std;

void Solve(double a, double b, double h, double eps)
{
    double pi;
    double D_1 = 1.0, D_2 = 2.0, D_4 = 4.0, D_8 = 8.0;
    __asm
    {
        fldpi
        fstp pi
    }
    std::cout << setprecision(3) << scientific << showpos <<
        "                                    eps = " << eps << "        " << endl;
    std::cout << " -------------------------------------------------------- " << endl;
    std::cout << " |     x      |    S(x)    |    Y(x)    | abs(S - Y) | n   " << endl;
    std::cout << " |------------|------------|------------|------------|--- " << endl;
    for (double xval = a; xval < b + h / 2; xval += h)
    {
        double x, Y, S, NM2P1, trash;

        //x = fmod(xval, pi);
        __asm
        {
            FLD pi
            FLD xval
            FPREM
            FSTP x
            FSTP trash
        }

        //Y = pi * pi / 8 - pi / 4 * abs(x);
        __asm
        {
            FLD pi
            FLD pi
            FMUL
            FLD D_8
            FDIV

            FLD pi
            FLD D_4
            FDIV
            FLD x
            FABS
            FMUL

            FSUB

            FSTP Y
        }

        S = 0.0;
        int n = 0;
        while (abs(S - Y) > eps) 
        {
            n++;

            //NM2P1 = (2.0 * n - 1);
            __asm
            {
                FLD D_2
                FILD n
                FMUL
                FLD D_1
                FSUB
                FSTP NM2P1
            }

            //S = S + cos((2.0 * n - 1) * x) / pow(2.0 * n - 1, 2);
            __asm
            {
                FLD S

                FLD NM2P1
                FLD x
                FMUL
                FCOS

                FLD NM2P1
                FLD NM2P1
                FMUL

                FDIV

                FADD

                FSTP S
            }
        }
        std::cout << setprecision(3) << scientific << showpos <<
            " | " << x << " | " << S << " | " << Y << " | " << abs(S - Y) << " | " <<
            noshowpos << right << setw(2) << n << endl;
    }
    std::cout << " -------------------------------------------------------- " << endl;
}

int main()
{
    SetConsoleTitle(TEXT("ABC_8"));
    for (;;)
    {
        double a, b, h, eps;
        std::cout << "\n Enter numbers a, b, h, eps: \n ";
        cin >> a >> b >> h >> eps;
        Solve(a, b, h, eps);
    }
    return 0;
}