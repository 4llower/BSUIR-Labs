#include <stdio.h>
#include <string.h>

const int max_strings = 400;
const int max_length = 400;
const char const* finish_string = "^_^";

int max(int a, int b){
    return (a > b ? a : b);
}

int main() {
    printf("Enter your text (To finish the text, press \"%s\".\n", finish_string);
    printf("Max number of string which you can enter is %d, max length of one line is %d\n", max_strings, max_length);

    int i, j, n = 0, mx = 0;
    char a[max_strings][max_length];

    while (1) {

        int marker = 0;
        char temp[max_length], changed[max_length];

        gets(temp);

        for (i = 0; i < strlen(temp); ++i) {
            if (temp[i] != ' ') {
                if (i > 0 && temp[i - 1] == ' ') changed[marker++] = ' ';
                changed[marker++] = temp[i];
            }
        }

        strncpy(a[n], changed, marker);
        mx = max(strlen(a[n]), mx);

        if (n == max_strings){
            puts("limit is reached");
            break;
        }

        if (!strcmp(a[n], finish_string)) break;

        n++;
    }

    for (i = 0; i < n; ++i) {

        int spaces = 0;
        int number_space_area = 0;

        for (j = 0; j < strlen(a[i]); ++j) {
            if (a[i][j] == ' ') spaces++;
            else {
                if (j == 0) continue;
                if (a[i][j - 1] == ' ') number_space_area++;
            }
        }

        if (number_space_area == 0) {
            printf("%s\n", a[i]);
            continue;
        }

        if (a[i][0] == ' ') number_space_area--;

        if (number_space_area == 0){
            for (j = 0; j < strlen(a[i]); ++j) if (a[i][j] != ' ') printf("%c", a[i][j]);
            printf("\n");
            continue;
        }

        int between_words = (mx - strlen(a[i]) + spaces) / number_space_area;
        int rest = mx - between_words * number_space_area - strlen(a[i]) + spaces;
        int is_writed = 0;

        for (j = 0; j < strlen(a[i]); ++j){

            if (j > 0 && a[i][j] != ' ' && a[i][j - 1] == ' ' && is_writed) {
                int sym;
                if (rest){
                    rest--;
                    printf(" ");
                }
                for (sym = 0; sym < between_words; ++sym) printf(" ");
            }

            if (a[i][j] != ' ') {
                is_writed = 1;
                printf("%c", a[i][j]);
            }
        }

        printf("\n");
    }

    return 0;
}
