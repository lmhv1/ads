#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <unistd.h>

// atualizado: codigo novo sem uso de arrays para o problema 1212 do URI

void retornar(){
    int i;
    printf("\nRetornando");
    for (i=0;i<=200000000;i++){};
    printf(".");
    for (i=0;i<=200000000;i++){};
    printf(".");
    for (i=0;i<=200000000;i++){};
    printf(".");
    for (i=0;i<=200000000;i++){};
}

void aula1(){
    void aula1_1(){

        int active = 1, nota;
        do{
            printf("\nInsira a nota de 0 a 100: ");
            scanf("%d", &nota);
            if (nota == 0) {
                printf("Conceito E");
            } else if (nota >= 1 && nota <= 35 ) {
                printf("Conceito D");
            } else if (nota >= 36 && nota <= 60 ) {
                printf("Conceito C");
            } else if (nota >= 61 && nota <= 85 ) {
                printf("Conceito B");
            } else if (nota >= 86 && nota <= 100 ) {
                printf("Conceito A");
            } else if (nota < 0 || nota > 100) {
                printf("\nInsira um valor valido!");
            }
            printf("\nDigite um numero para continuar ou 0 para sair: ");
            scanf("%d", &active);
        }while(active);
        retornar();
        aula1();
    }
    void aula1_2(){
        int n, somatorio=0;

        do{
            printf("\nInsira o valor a ser somado ou digite 0 para sair: ");
            printf("\nSoma: %d + ", somatorio);
            scanf("%d", &n);

            somatorio += n;

        }while(n!=0);
        retornar();
        aula1();
    }
    void aula1_3(){
        // srand(time(NULL));
        int in, segredo;

        int genSeg(){
            do{
                segredo = rand();
            }while(segredo>1000);
            return segredo;
        }
        printf('oi 2');
        genSeg();
        printf('oi 3');

        do{
            printf("\nAche o valor do segredo (1-1000) ou digite 0 para sair: ");
            scanf("%d", &in);

            if (in == segredo){
                printf("\nVoce acertou! Reiniciando...");
                sleep(1);
                genSeg();
            }
            else if (in != 0 && in < segredo) printf("\nMaior...");
            else if (in > segredo) printf("\nMenor...");

        }while(in != 0);
        retornar();
        aula1();
    }

    char opc;
    printf("\n== Atividades realizadas na aula de 27.abr.2021");
    printf("\n== 1 - Nota");
    printf("\n== 2 - Somatorio");
    printf("\n== 3 - Segredo");
    printf("\n== 0 - Voltar ao Indice\n");
    do{
        fflush(stdin);
        scanf("%c", &opc);
    }while(opc>100);

    switch(opc){
        case '1': aula1_1(); break;
        case '2': aula1_2(); break;
        case '3': aula1_3(); break;
        case '0': break;
        default: aula1(); break;
    }
}

void aulas(){
    char opc;
    printf("\n== Aulas");
    printf("\n== 1 - Aula 27.abr.2021");
    printf("\n== 0 - Voltar ao Indice\n");
    do{
        fflush(stdin);
        scanf("%c", &opc);
    }while(opc>100);

    switch(opc){
        case '1': aula1(); break;
        case '0': break;
        default: aulas(); break;
    }
}

void lista1(){
    void lista1_1(){
        int q1;
        int k, n;

        printf("Numero a ser fatorado: ");
        scanf("%d", &q1);

        n = 1;
        for (k = q1; k > 1 ; k--) {
            n *= k;
        }
        printf ("O fatorial de %d e: %d\n", q1, n);
        sleep(1);
        retornar();
        lista1();
    }

    void lista1_2(){
        int q1;
        int k, n;

        printf("Numero a ser fatorado: ");
        scanf("%d", &q1);

        n = 1;
        k = q1;
        while (k > 1) {
            n *= k;
            k--;
        }
        printf ("O fatorial de %d e: %d\n", q1, n);
        sleep(1);
        retornar();
        lista1();
    }

    void lista1_3(){
        int q1;
        int k, n;

        printf("Numero a ser fatorado: ");
        scanf("%d", &q1);

        n = 1;
        k = q1;
        do{
            n *= k;
            k--;
        } while (k > 1);
        if (q1 > 0) printf ("O fatorial de %d e: %d\n", q1, n);
        else printf ("O fatorial de %d e: 1\n", q1);

        sleep(1);
        retornar();
        lista1();
    }

    void lista1_4(){
        int q2;
        int div, num = 2;

        do {
        printf("\nQuantidade de numeros primos a exibir: ");
        scanf("%d", &q2);
        } while (q2 < 0);

        while (q2 != 0){
            for (div = 2; div < num; div++){
                if (num % div == 0) break;
            }
            if (div==num){
                printf("%d ", num);
                q2--;
            }
            num++;
        }
        sleep(1);
        retornar();
        lista1();
    }

    void lista1_5(){
        int q3;
        int i, j;

        printf("\nNumero de linhas da arvore: ");
        scanf("%d", &q3);

        for (i = q3; i > 0; i--){

            for (j = i; j > 0; j--){
                printf("*");
            }

            printf("\n");
        }
        sleep(1);
        retornar();
        lista1();
    }

    char opc;
    printf("\n== Lista 1");
    printf("\n== 1 - Questao 1 - Fatorial for");
    printf("\n== 2 - Questao 1 - Fatorial while");
    printf("\n== 3 - Questao 1 - Fatorial do-while");
    printf("\n== 4 - Questao 2 - Numeros primos");
    printf("\n== 5 - Questao 3 - Arvore invertida");
    printf("\n== 0 - Voltar ao Indice\n");
    do{
        fflush(stdin);
        scanf("%c", &opc);
    }while(opc>100);

    switch(opc){
        case '1': lista1_1(); break;
        case '2': lista1_2(); break;
        case '3': lista1_3(); break;
        case '4': lista1_4(); break;
        case '5': lista1_5(); break;
        case '0': break;
        default: lista1(); break;
    }
}

void listaMain(){
    char opc;
    printf("\n== Listas de exercicio");
    printf("\n== 1 - Lista 1");
    printf("\n== 0 - Voltar ao Indice\n");
    do{
        fflush(stdin);
        scanf("%c", &opc);
    }while(opc>100);

    switch(opc){
        case '1': lista1(); break;
        case '0': break;
        default: listaMain(); break;
    }
}

void uri(){
    void uri1161(){
        int i;
        long long m, n;

        printf("\nDigite os valores\n"); // comentar esta linha p/ enviar como solução do desafio

        while(scanf("%llu %llu",&m, &n)!=EOF){ // loop infinito conforme solicitado no desafio do URI
            if (m>0){

                for (i=m-1;i>1;i--){
                    m*=i;
                }

            }else m=1;

            if (n>0){

                for (i=n-1;i>1;i--){
                    n*=i;
                }

            }else n=1;

            printf("%llu\n",m+n);
        }
    }

    void uri1170(){
        printf("Digite o numero de casos e em seguida a quantidade de comida: ");

        // URI inicio
        int blobs, dias;
        float comida;

        scanf("%d", &blobs);

        for (blobs; blobs>0; blobs--){
            scanf("%f", &comida);
            dias = 0;

            while (comida > 1){
                comida /= 2;
                dias++;
            }
            printf("%d dias\n", dias);
        }
        // URI fim
        retornar();
        uri();
    }

    void uri1212(){
        printf("Insira os 2 valores: ");

        //URI inicio
        int in1, in2, sum=0, carry=0, sB=0; // sB = adiciona 1 na proxima operação

        while(1){
            fflush(stdin);
            scanf("%d %d", &in1, &in2);
            if (in1==0 && in2==0) break;

            while (1){
                //printf("\n-1- in1 %d, in2 %d, sum %d, carry %d, sB %d\n", in1, in2, sum, carry, sB);
                if (in1==0 && in2==0) break;

                sum = (in1%10) + (in2%10);
                //printf("-2- in1 %d, in2 %d, sum %d, carry %d, sB %d\n", in1, in2, sum, carry, sB);

                if (sB){
                    sum++;
                    sB--;
                    //printf("-3- in1 %d, in2 %d, sum %d, carry %d, sB %d\n", in1, in2, sum, carry, sB);
                }
                if (sum>=10){
                    sB++;
                    carry++;
                    //printf("-4- in1 %d, in2 %d, sum %d, carry %d, sB %d\n", in1, in2, sum, carry, sB);
                }

                in1/=10;
                in2/=10;
                //printf("-5- in1 %d, in2 %d, sum %d, carry %d, sB %d\n", in1, in2, sum, carry, sB);
            }
            if (carry==0) printf("No carry operation.\n");
            else if (carry==1) printf("1 carry operation.\n");
            else printf("%d carry operations.\n", carry);

            carry=0;
            sB=0;
        }
        //URI fim

        /* codigo antigo
        //URI inicio
        int in1, in2, carry=0, i;
        int arr1[9]={0}, arr2[9]={0};

        int fillArray(int in, int arr[9]){
            int i, rest;
            for (i=8;i>=0;i--){
                rest = in%10;
                arr[i] = rest;
                in/=10;
            }
        }

        while(1){
            fflush(stdin);
            scanf("%d%d", &in1, &in2);
            if (in1==0 && in2==0) break;

            fillArray(in1, arr1);
            fillArray(in2, arr2);

            for (i=8;i>=0;i--){
                if (arr1[i]+arr2[i] >=10){
                    carry++;
                    arr1[i-1] += 1;
                }
            }

            if (carry==0) printf("No carry operation.\n");
            else if (carry==1) printf("1 carry operation.\n");
            else printf("%d carry operations.\n", carry);
            carry=0;
        }
        // URI fim
        */
        retornar();
        uri();
    }


    char opc;
    printf("\n== Exercicios do URI");
    printf("\n== 1 - (1161) Fabrica de fatoriais");
    printf("\n== 2 - (1170) Blobs");
    printf("\n== 3 - (1212) Aritmetica primaria");
    printf("\n== 0 - Voltar ao Indice\n");
    do{
        fflush(stdin);
        scanf("%c", &opc);
    }while(opc>100);

    switch(opc){
        case '1': uri1161(); break;
        case '2': uri1170(); break;
        case '3': uri1212(); break;
        case '0': break;
        default: uri(); break;
    }
}

int mainMenu(){
    char opc;
    printf("\n== Indice");
    printf("\n== 1 - Aulas");
    printf("\n== 2 - Listas");
    printf("\n== 3 - URI Online Judge");
    printf("\n== 0 - Sair\n");
    do{
        fflush(stdin);
        scanf("%c", &opc);
    }while(opc>100);
    return opc;
}

int main(void){
    char opc;
    while(1){
        opc = mainMenu();

        switch(opc){
        case '1': aulas(); break;
        case '2': listaMain(); break;
        case '3': uri(); break;
        case '0': printf("\nVolte sempre!"); return;
        }
    }
}

