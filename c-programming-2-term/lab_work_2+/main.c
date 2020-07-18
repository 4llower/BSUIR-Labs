#include <stdio.h>
#include <math.h>

double sqr(double x){
    return x * x;
}

int main() {

    puts("Enter your value of x");
    double x = 0;
    scanf("%lf", &x);

    puts("Enter your value of eps");
    double eps = 0;
    scanf("%lf", &eps);

    double left_value = sin(x);
    double right_value = 0, numerator = x + 0.0, denominator = 1.0, factor = 1;
    int n = 1;

    while (1){

        right_value += factor * (numerator / denominator);

        if (fabs(right_value - left_value) < eps) break;

        n += 1;
        numerator *= sqr(x);
        denominator *= (2 * n - 1) * (2 * n - 2) + 0.0;

        if (factor == 1) factor = -1;
        else factor = 1;
    }

    printf("%s%lf%s%lf%s%d\n", "left_value = ", left_value, ", right_value = ", right_value, " at n = ", n);

    return 0;
}
