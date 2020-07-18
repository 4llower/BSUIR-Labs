#include <stdio.h>
#include <string.h>

const int max_length = 400;
const int value_words = 1000;
const int max_vocabulary_word_size = 200;
const int alphabet_size = 512;

int main() {

    char word[max_length];
    int alphabet[alphabet_size];
    int i, j, k;
    char * filepath = "D:\\Projects\\university-tasks-programming-2020\\lab_work_4+\\vocabulary.txt";
    FILE* vocabulary = fopen(filepath, "r");

    puts("Enter your word: ");
    gets(word);

    for (i = 0; i < alphabet_size; ++i) alphabet[i] = 0;
    for (i = 0; i < strlen(word); ++i) alphabet[word[i]] = 1;

    int ans = 0;

    for (i = 0; i < value_words; ++i){

        int is_ans = 1;
        char temp[max_vocabulary_word_size];

        fgets(temp, max_vocabulary_word_size, vocabulary);

        for (j = 0; j < strlen(temp) - 1; ++j){
            if (alphabet[temp[j]] == 0){
                is_ans = 0;
                break;
            }
        }

        if (is_ans) {
            ans++;
            printf("%s", temp);
        }
    }

    printf("Total words which fit our condition is %d", ans);

    return 0;
}
