 #include <stdio.h>

int main() {

    int sum = 0;
    printf("Enter your number:");
    (void)scanf("%d", &sum);

    if (sum <= 7 && sum % 3 && sum % 5){
        puts("I'm sorry, but we can't build this number with \"3\" and \"5\" :(");
        return 0;
    }

    //We take max value of 5 which can contain in our number
    int num_of_5 = sum / 5;
    int max_value_of_5 = (sum / 5) * 5;

    //and if can't add any 3 to get our sum, we need to decrease on 5 our "maxValueOf5", to get answer.
    while ((sum - max_value_of_5) % 3){
        max_value_of_5 -= 5;
        num_of_5--;
    }
    //it’s easy to understand that there will be little such operations

    printf("%s%d%s%d%s", "This number we can build with number of 5 = ", num_of_5, ", and with number of 3 = ", (sum - max_value_of_5) / 3, "\n");
    printf("%d%s%d%s%d%s", num_of_5, " * 5 + ", (sum - max_value_of_5) / 3, " * 3 = ", sum, "\n");

    return 0;
}
