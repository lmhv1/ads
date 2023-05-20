#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#define LIST_TAM 20

typedef struct sLista{
        int item[LIST_TAM];
        int ultimo;
        int ocupado[LIST_TAM]; // utilizado para achar indices vazios (funcao q5)
}LISTA;

void iniciarLista(LISTA *lista){
    lista->ultimo=-1;
    for (int i=0; i<LIST_TAM; i++){
        lista->item[i] = 0;
        lista->ocupado[i] = -1;
    }
    return;
}

int listaVazia(LISTA *lista){
    if (lista->ultimo == -1) return 1;
    return 0;
}

int listaCheia(LISTA *lista){
    if (lista->ultimo == (LIST_TAM-1)) return 1;
    return 0;
}

int getIndiceVazio(LISTA *lista){
    for (int i=0; i<LIST_TAM; i++){
        if (lista->ocupado[i] == -1) return i;
    }
    return -1; // caso nao tenha indices vazios
}

void swap(int *x, int *y){
    int temp;
    temp = *x;
    *x = *y;
    *y = temp;
    return;
}

// 1. Crie uma função para imprimir todos os elementos da lista.
void q1(LISTA *lista){
/*
    for (int i=0; i<LIST_TAM; i++){
        printf("index %d ocup %d elem %d ultimo %d", i, lista->ocupado[i], lista->item[i], lista->ultimo);
        printf("\n");
    }
*/

    if (listaVazia(lista)){
        printf("A lista esta vazia.\n");
        return;
    }
    printf("Lista: ");
    for (int i=0; i<=lista->ultimo; i++){
        printf("%02d ", lista->item[i]);
    }
    printf("\n");
    return;
}

// 2. Crie uma função para inserir um elemento em um posição k informada pelo usuário.
void q2(LISTA *lista){
    int k = -1;
    while(k < 1 || k > LIST_TAM){
        printf("Posicao (1-%d): ", LIST_TAM);
        scanf("%d", &k);
    }
    k--; // ordinal para cardinal

    int elem;
    printf("Elemento (int): ");
    scanf("%d", &elem);

    lista->item[k] = elem;
    if (k>lista->ultimo) lista->ultimo = k;
    lista->ocupado[k] = 1;

    return;
}

// 3. Crie uma função para inverter a lista.
void q3(LISTA *lista){
    int meio = lista->ultimo/2;
    if ((lista->ultimo)%2==0) meio--;

    for (int i=0; i<=meio; i++){
        int ii = lista->ultimo-i;
        swap(&lista->item[i], &lista->item[ii]);
    }
    return;
}

// 4. Crie uma função para ordenar a lista.
void q4(LISTA *lista){
    for (int i=0; i<lista->ultimo; i++){
        if (lista->item[i]>lista->item[i+1]){
            swap(&lista->item[i], &lista->item[i+1]);
            q4(lista);
        }
    }
    return;
}

// 5. Inserir elemento aleatorio no primeiro indice desocupado
void q5(LISTA *lista){
    int indice = getIndiceVazio(lista);
    if (indice!=-1){
        int elemento = rand()%100;
        lista->item[indice] = elemento;
        lista->ocupado[indice] = 1;
        if (indice > lista->ultimo) lista->ultimo = indice;
        printf("Inserido na posicao %d: %d\n", indice+1, elemento);
    }else{
        printf("Nao ha posicoes disponiveis na lista\n");
    }
    return;
}


int menu(){
    int opc;
    while(1){
        printf("\n--------------------------------------------------\n");
        printf("== Exercicios de 17.jun.2021\n");
        printf("== 1 - Imprimir lista\n");
        printf("== 2 - Inserir elemento na lista\n");
        printf("== 3 - Inverter lista\n");
        printf("== 4 - Ordenar lista\n");
        printf("== 5 - Inserir elemento aleatorio no primeiro indice disponivel\n");
        printf("==\n");
        printf("== 0 - Sair\n");
        printf("--------------------------------------------------\n");

        fflush(stdin);
        scanf("%d", &opc);

        switch(opc){
            case 1: return opc;
            case 2: return opc;
            case 3: return opc;
            case 4: return opc;
            case 5: return opc;
            case 0: return opc;
        }
    }
}

// 5. Crie um procedimento na main que permite o usuário ter acesso a todas as funcionalidades descritas até então.
// Permita também que uma vez que o programa estiver funcionando, o usuário possa fazer quantas operações quiser.
int main(){
    srand(time(NULL));
    LISTA lista;
    iniciarLista(&lista);

    while(1){
        switch(menu()){
            case 1: q1(&lista); break;
            case 2: q2(&lista); break;
            case 3: q3(&lista); break;
            case 4: q4(&lista); break;
            case 5: q5(&lista); break;
            case 0: return 0;
        }
    }
}
