#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>

int retry(){
    int retry;
    do{
        printf("\nDigite 1 para continuar ou 0 para voltar: ");
        fflush(stdin);
        scanf("%d", &retry);
    }while(retry!=0 && retry!=1);
    return retry;
}

void aula4_1(){
    // 1- Escreva uma função recursiva que mostre na tela os números inteiros de 1 a 5 em ordem crescente. Outra para imprimir em ordem decrescente.
    int cresc(int n){
        if (n==5){
            printf(" 5");
            return 5;
        }
        printf(" %d,", n);
        return cresc(n+1);
    }
    int decresc(int n){
        if (n==1){
            printf(" 1");
            return 1;
        }
        printf(" %d,", n);
        return decresc(n-1);
    }
    while(1){
        printf("\n==================================================\n");

        printf("\nCrescente:   ");
        cresc(1);
        printf("\nDecrescente: ");
        decresc(5);
        printf("\n");

        if (retry()==0) return;
    }
}

void aula4_2(){
    // 2 – Escreva uma função recursiva que imprima os elementos de um vetor de letras em ordem decrescente.
    char vetor[100];

    int decresc(int i){
        if (i==0){
            printf("%c",vetor[0]);
            return 0;
        }
        printf("%c",vetor[i]);
        return decresc(i-1);
    }

    while(1){
        printf("\n==================================================\n");

        printf("Insira o vetor: ");
        fflush(stdin);
        gets(vetor);

        decresc(strlen(vetor)-1);

        if (retry()==0) return;
    }
}

void aula4_3(){
    // 3 – Escreva uma função recursiva que retorne a soma dos números de um intervalo partindo-se sempre do maior número e terminando no menor.
    while(1){
        printf("\n==================================================\n");

        int arr[10];
        int maior = 0;  // maior numero
        int iMaior = 0; // indice do maior numero
        int menor = 21; // menor numero
        int iMenor = 0; // indice do menor numero
        int somatorio=0;

        // preenche a cadeia com inteiros de 0-20
        void fillArray(){
            for (int i=0; i<10; i++){
                arr[i]=rand()%21;
            }
        }

        // acha o maior numero e seu indice
        void getMaior(){
            for (int i=0; i<10; i++){
                if (arr[i]>maior){
                    maior = arr[i];
                    iMaior = i;
                }
            }
        }

        // acha o menor numero e seu indice
        void getMenor(){
            for (int i=0; i<10; i++){
                if (arr[i]<menor){
                    menor = arr[i];
                    iMenor = i;
                }
            }
        }

        // verifica se os numeros se repetem
        int checkRepetidos(){
            for (int i=0; i<10; i++){
                for (int j=0; j<10; j++){
                    if (arr[i]==arr[j] && i!=j) return 1;
                }
            }
            return 0;
        }

        // indice do maior numero é maior que o indice do menor numero (Menor <- Maior)
        int somaMeMa(int i){
            if (i==iMenor) return arr[i];
            return arr[i]+somaMeMa(i-1);
        }

        // indice do menor numero é maior que o indice do maior numero (Maior -> Menor)
        int somaMaMe(int i){
            if (i==iMenor) return arr[i];
            return arr[i]+somaMaMe(i+1);
        }

        do{
            fillArray();                // preenche a cadeia
        }while(checkRepetidos()!=0);    // verifica se os numeros se repetem

        getMaior();                     // acha o maior numero e seu indice
        getMenor();                     // acha o menor numero e seu indice

        if (iMenor < iMaior) somatorio=somaMeMa(iMaior);
        else somatorio=somaMaMe(iMaior);    // iMenor > iMaior

        printf("Cadeia: ");
        for (int i=0; i<10; i++){
            printf("%d ", arr[i]);
        }
        printf("\nMenor numero: %d Indice %d\n", menor, iMenor);
        printf("Maior numero: %d Indice %d\n", maior, iMaior);
        printf("\nSomatorio: %d\n",somatorio);

        if (retry()==0) return;
    }
}

void aula4_5(){
    // 5 – Implemente um algoritmo que dado um vetor de inteiros e uma chave digitada pelo usuário, verifica se a chave aparece em algum momento no vetor. Use busca binária!
    while(1){
        printf("\n==================================================\n");

        int TAM;
        printf("Digite o tamanho desejado da cadeia: ");
        fflush(stdin);
        scanf("%d", &TAM);
        printf("\n");

        int arr[TAM];
        int in;
        int cont=0;

        // preenche a cadeia com inteiros de 0 até 1*1/2 da cadeia
        void fillArray(){
            for (int i=0; i<TAM; i++){
                arr[i]=rand()%(((TAM*3)/2)+1);
            }
        }

        void sortArray(int array[]){
            int x;
            for (int i=0; i<TAM; i++){
                for (int j=i+1; j<TAM; j++){
                    if(array[i] > array[j]){
                        x = array[i];
                        array[i] = array[j];
                        array[j] = x;
                    }
                }
            }
        }

        void find(int n, int min, int max){
            int piv = min+((max-min)/2);
            cont += 1;
            if (cont>15){
                printf("Esse numero nao esta na cadeia.\n");
                return;
            }
            if (in == arr[piv]){
                printf("Esse numero esta na cadeia e pode ser encontrado no indice [%d].\n", piv);
                return;
            } else if (in < arr[piv]){
                //printf("primeira metade. arr[%d]=%d\n", piv, arr[piv]);
                find(n, min, piv-1);
            } else {
                //printf("segunda metade. arr[%d]=%d\n", piv, arr[piv]);
                find(n, piv+1, max);  // in > piv
            }
        }

        void printArray(){
            printf("Cadeia:\n");
            for (int i=0; i<TAM; i++){
                printf("%d ", arr[i]);
            }
            printf("\n");
        }

        fillArray();        // preenche a cadeia
        sortArray(arr);     // ordena

        printf("A cadeia contem %d numeros.\n", TAM);
        printf("Digite um numero (0 - %d): ", (TAM*3)/2);
        fflush(stdin);
        scanf("%d", &in);
        printf("\n");

        find(in, 0, TAM-1);

        // ver cadeia
        int opc;
        do{
            printf("\nDeseja ver a cadeia completa? (0/1)\n");
            fflush(stdin);
            scanf("%d", &opc);
            if (opc==1) printArray();
        }while(opc!=0 && opc!=1);

        if (retry()==0) return;
    }
}

int menu(){
    printf("\n==================================================\n");
    int opc;
    while(1){
        printf("== Exercicios de 20.mai.2021\n");
        printf("== 1 - Recursiva: 1 a 5 crescente/decrescente\n");
        printf("== 2 - Recursiva: Vetor de letras decrescente\n");
        printf("== 3 - Recursiva: Soma do maior ao menor\n");
        printf("==\n");
        printf("== 5 - Recursiva: Achar numero em um vetor\n");
        printf("== 0 - Sair\n");

        fflush(stdin);
        scanf("%d", &opc);

        switch(opc){
            case 1: return opc;
            case 2: return opc;
            case 3: return opc;
            case 5: return opc;
            case 0: return opc;
        }
    }
}

int main(){
    while(1){
        srand(time(NULL));
        switch(menu()){
            case 1: aula4_1(); break;
            case 2: aula4_2(); break;
            case 3: aula4_3(); break;
            case 5: aula4_5(); break;
            case 0: return 0;
        }
    }
}
