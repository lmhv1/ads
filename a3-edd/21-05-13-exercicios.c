#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int menu(){
    printf("\n==================================================\n");
    int opc;
    while(1){
        printf("== Exercicios da aula de 13.mai.2021\n");
        printf("== 1 - Distancia de coordenadas\n");
        printf("== 2 - Fatorial\n");
        printf("== 3 - Somatorio\n");
        printf("== 4 - Soma de algarismos\n");
        printf("== 0 - Sair\n");

        fflush(stdin);
        scanf("%d", &opc);

        switch(opc){
            case 1: return opc;
            case 2: return opc;
            case 3: return opc;
            case 4: return opc;
            case 0: return opc;
        }
    }
}


int main(void){
    void aula3_1(){
        while(1){
            printf("\n==================================================\n");
            double x1=0,y1=0,x2=0,y2=0;
            double dist;

            printf("Insira as coordenadas X e Y do ponto 1:\n");
            fflush(stdin);
            scanf("%lf%lf", &x1, &y1);

            printf("Insira as coordenadas X e Y do ponto 2:\n");
            fflush(stdin);
            scanf("%lf%lf", &x2, &y2);

            dist = sqrt( pow(x1-x2,2) + pow(y1-y2,2) );
            printf("Distancia dos dois pontos: %.2lf\n", dist);

            int cont;
            printf("\nDigite qualquer coisa para continuar ou 0 para sair.\n");
            fflush(stdin);
            scanf("%d", &cont);
            if (cont==0) return;
        }
    }

    void aula3_2(){
        int fatorial(int n){
            if (n==0) return 1; else{
                for(int i=n-1; i>1; i--){
                    n *= i;
                }
            }
            return n;
        }

        while(1){
            printf("\n==================================================\n");
            int num;

            printf("Numero a ser fatorado:\n");
            fflush(stdin);
            scanf("%d", &num);

            printf("O fatorial de %d eh %d\n", num, fatorial(num));

            int cont;
            printf("\nDigite qualquer coisa para continuar ou 0 para sair.\n");
            fflush(stdin);
            scanf("%d", &cont);
            if (cont==0) return;
        }
    }

    void aula3_3(){
        int somatorio(int n){
            if (n==0) return 1; else{
                for (int i=n-1; i>=1; i--){
                    n += i;
                }
            }
            return n;
        }

        while(1){
            printf("\n==================================================\n");
            int num;

            printf("Digite um numero:\n");
            fflush(stdin);
            scanf("%d", &num);

            printf("O somatorio de 1 ate %d eh %d\n", num, somatorio(num));

            int cont;
            printf("\nDigite qualquer coisa para continuar ou 0 para sair.\n");
            fflush(stdin);
            scanf("%d", &cont);
            if (cont==0) return;
        }
    }

    void aula3_4(){
        int fillArray(int n, int arr[3]){
            for (int i=0;i<3;i++){
                int rest = n%10;
                arr[i] = rest;
                n/=10;
            }
        }

        int somaAlg(int n){
            int arr[3]={0};

            fillArray(n, arr);

            int soma = arr[0]+arr[1]+arr[2];
            return soma;
        }

        while(1){
            printf("\n==================================================\n");
            int num;

            printf("Digite um numero:\n");
            fflush(stdin);
            scanf("%d", &num);

            printf("O somatorio dos algarismos de %d eh %d\n", num, somaAlg(num));

            int cont;
            printf("\nDigite qualquer coisa para continuar ou 0 para sair.\n");
            fflush(stdin);
            scanf("%d", &cont);
            if (cont==0) return;
        }
    }


    while(1){
        int opc = menu();
        switch(opc){
            case 1: aula3_1(); break;
            case 2: aula3_2(); break;
            case 3: aula3_3(); break;
            case 4: aula3_4(); break;
            case 0: return 0;
        }
    }
}
