#include <stdio.h>

int main(void){
    int q1, q2, q3; // valores de entrada
    int k, n; // contadores

    // 1. Considerando que o fatorial de um n�mero � calculado por: 4! = 4 * 3 * 2 * 1.
    // Crie tr�s trechos de c�digo para calcular o fatorial de um n�mero, utilizando em cada um, um la�o de repeti��o diferente: for, while e do-while.

    //q1 input
    printf("Numero a ser fatorado: ");
    scanf("%d", &q1);

    //for
    n = 1;
    for (k = q1; k > 1 ; k--) {
        n *= k;
    }
    printf ("O fatorial de %d e: %d (laco for)\n", q1, n);

    //while
    n = 1;
    k = q1;
    while (k > 1) {
        n *= k;
        k--;
    }
    printf ("O fatorial de %d e: %d (laco while)\n", q1, n);

    //do while
    n = 1;
    k = q1;
    do {
        n *= k;
        k--;
    } while (k > 1);
    if (q1 > 0){
    printf ("O fatorial de %d e: %d (laco do-while)\n", q1, n);
    } else {
    printf ("O fatorial de %d e: 1 (laco do-while)\n", q1);
    }

    // 2. Fa�a um programa para escrever os N primeiros n�meros primos. N � informado pelo usu�rio.

    do {
    printf("\nQuantidade de numeros primos a exibir: ");
    scanf("%d", &q2);
    } while (q2 < 0);

    n = 2;               // n: n�mero a ser testado
    while (q2 != 0){
        for (k = 2; k < n; k++){
            if (n % k == 0) break;
        }
        if (k==n){
            printf("%d ", n);
            q2--;
        }
        n++;
    }

    // 3. Crie um programa que seja capaz de imprimir uma meia �rvore com N linhas:

    printf("\n\nNumero de linhas da arvore: ");
    scanf("%d", &q3);

    for (k = q3; k > 0; k--){
        for (n = k; n > 0; n--){
            printf("*");
        }
        printf("\n");
    }

    return 0;
}
