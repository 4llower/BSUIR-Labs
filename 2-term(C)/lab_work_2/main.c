#include <stdio.h>
#include <stdlib.h>

const double perCent = 12.75 / (12.0 * 100);
const int month[] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

void operations_definition(){
    puts("Enter 0, if you want open bank deposit.");
    puts("Enter 1, if you want make extra contribution on your deposit.");
    puts("Enter 2, if you want check balance(sum of deposit).");
    puts("Enter 3, if you want check balance on specific day.");
    puts("Enter 4, if you want close your deposit (deposit without percents output).");
    puts("Enter 5, if you want bank information.");
    puts("Enter 6, if you want finish.");
}

void open_deposit(int *deposit){
    if (*deposit){
        puts("Deposit already exists, that's why we can't open deposit:(");
        return;
    }

    puts("Enter value of your deposit (BLR)");

    int num = 0;
    scanf("%d", &num);

    if (num <= 0){
        puts("We can't open deposit:(");
        return;
    }

    *deposit = num;
}

void make_extra_contribution(int *deposit){
    if (*deposit == 0){
        puts("We can't make extra contribution, because your deposit is't exists:(");
        return;
    }

    puts("Enter value of your extra contribution (BLR)");

    int num = 0;
    scanf("%d", &num);

    if (num <= 0){
        puts("Uncorrect value");
        return;
    }

    *deposit += num;
}

void check_balance(int *deposit){
    if (*deposit == 0){
        puts("Your deposit is't exists:(");
        return;
    }
    printf("%d%s", *deposit, "\n");
}

void check_balance_special_day(int *deposit){
    if (*deposit == 0){
        puts("Your deposit is't exists:(");
        return;
    }

    int day;
    puts("Enter the day");

    scanf("%d", &day);

    if (day <= 0){
        puts("Day is incorrect");
        return;
    }

    if (day > 365) day = 365;

    double sum = *deposit;
    int i;

    for (i = 0; i < 12; ++i){
        if (day <= 0) break;
        sum = (sum + sum * perCent);
        day -= month[i];
    }

    printf("%lf%s", sum, "\n");
}

void close_deposit(int *deposit){
    if (*deposit == 0){
        puts("Deposit is't exists");
        return;
    }

    printf("%d%s", *deposit, "\n");
    *deposit = 0;
}

void get_info(){
    puts("...::::Transit bank::::...");
    puts("Contacts: ");
    puts("+375 29 188-73-78 - contact center for individual.");
    puts("Annual interest rate for deposits 12.75 per year.");
    puts("Fresh decision bank");
}

int main() {

    int *deposit = 0;

    puts("Hi, it's TransitBank, choose what you need.");

    while (1){
        int num;

        operations_definition();
        scanf("%d", &num);

        if (num == 0) open_deposit(&deposit);
        if (num == 1) make_extra_contribution(&deposit);
        if (num == 2) check_balance(&deposit);
        if (num == 3) check_balance_special_day(&deposit);
        if (num == 4) close_deposit(&deposit);
        if (num == 5) get_info();
        if (num == 6) break;
    }

    return 0;
}
