#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int menu(){
    printf("\n==================================================\n");
    char opc;
    while(1){
        printf("\n== Exercicios da aula de 06.mai.2021");
        printf("\n== 1 - Numero presente no vetor");
        printf("\n== 2 - Matriz transposta");
        printf("\n== 3 - Soma de pares e impares de uma matriz");
        printf("\n== 0 - Sair\n");

        fflush(stdin);
        opc = getchar();

        switch(opc){
            case '1': return opc;
            case '2': return opc;
            case '3': return opc;
            case '0': return opc;
        }
    }
}


int main(void){
    void aula2_1(){
        char retry;
        
        do{

            printf("-- Deseja tentar novamente? (s/n)\n");
            fflush(stdin);
            retry = getchar();
        }while(retry!='s' && retry!='n');

        if (retry=='s') aula2_1(); else return;
    }
    void aula2_2(){
        // Dada uma matriz de inteiros 10 x 10 preenchida aleatoriamente, apresentar sua matriz transposta.
        printf("\n==================================================\n");
        int arr1[10][10], arr2[10][10];
        srand(time(NULL));

        printf("\n\n-- Matriz inicial: \n");
        for (int i=0; i<10; i++){
            for (int j=0; j<10; j++){
                arr1[i][j] = rand()%100;
                printf("%2d, ", arr1[i][j]);
            }
            printf("\n");
        }

        printf("\n\n-- Matriz transposta: \n");
        for (int j=0; j<10; j++){
            for (int i=0; i<10; i++){
                arr2[i][j] = arr1[i][j];
                printf("%2d, ", arr2[i][j]);
            }
            printf("\n");
        }

        printf("\n-- Pressione alguma tecla para continuar...\n");
        fflush(stdin);
        arr2[6][9] = getchar();
        return;
    }
    void aula2_3(){
        // Dada uma matriz  5 x 5 preenchida aleatoriamente, apresentar a soma dos seus elementos pares e a soma dos �mpares.
        printf("\n==================================================\n");
        int arr[5][5], somap=0, somai=0;
        srand(time(NULL));

        for (int i=0; i<5; i++){
            for (int j=0; j<5; j++){
                arr[i][j] = (rand()%9)+1;
                if (arr[i][j]%2==0) somap+=arr[i][j]; else somai+=arr[i][j];
            }
        }

        for (int i=0; i<5; i++){
            for (int j=0; j<5; j++){
                printf("%d, ", arr[i][j]);
            }
            printf("\n");
        }

        printf("\n\n-- Soma dos elementos pares: %d\n", somap);
        printf("-- Soma dos elementos impares: %d\n", somai);

        printf("\n-- Pressione alguma tecla para continuar...\n");
        fflush(stdin);
        somap = getchar();

        return;
    }

    char opc;

    do{
        opc = menu();
        switch(opc){
            case '1': aula2_1(); break;
            case '2': aula2_2(); break;
            case '3': aula2_3(); break;
        }
    }while(opc!='0');

    return;
}
