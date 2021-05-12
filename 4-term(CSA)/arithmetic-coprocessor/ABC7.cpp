#include <iostream>
#include <string>
#include <windows.h>

using namespace std;

string Solve(double a, double b, double c) 
{
    const double EPS = 1e-300;
    const double LD_4 = 4.0;
    if (abs(a) < EPS)
    {
        return "Coefficient a is zero";
    }
    double D;
    __asm
    {
        FLD b
        FLD b
        FMUL
        FLD LD_4
        FLD a
        FLD c
        FMUL
        FMUL
        FSUB
        FSTP D
    }
    if (!isfinite(D)) 
    {
        return "Discriminant is not finite number";
    }
    if (abs(D) < EPS)
    {
        long double x;
        __asm
        {
            FLD b
            FCHS
            FLD a
            FLD a
            FADD
            FDIV
            FSTP x
        }
        return "x = " + to_string(x);
    }
    if (D < 0.0) 
    {
        return "Discriminant is negative number";
    }
    double x1, x2;
    __asm
    {
        FLD b
        FCHS
        FLD D
        FSQRT

        FSUB

        FLD a
        FLD a
        FADD
        FDIV

        FSTP x1
    }
    __asm
    {
        FLD b
        FCHS
        FLD D
        FSQRT

        FADD

        FLD a
        FLD a
        FADD
        FDIV

        FSTP x2
    }
    return "x_1 = " + to_string(x1) + "; " + "x_2 = " + to_string(x2);
}

int main()
{
    SetConsoleTitle(TEXT("ABC_7"));
    for (;;)
    {
        double a, b, c;
        cout << "\n Enter coefficients a, b, c: \n ";
        cin >> a >> b >> c;
        cout << ' ' << Solve(a, b, c) << endl;
    }
    return 0;
}