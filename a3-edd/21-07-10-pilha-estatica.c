#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#define TAM 5

typedef struct stack{
    int elem[TAM];
    int topo;
}PILHA;

void inicializar(PILHA *pilha){
    pilha->topo = -1;
}

int pilhaVazia(PILHA *pilha){
    if (pilha->topo == -1) return 1;
    return 0;
}

int pilhaCheia(PILHA *pilha){
    if (pilha->topo == (TAM-1)) return 1;
    return 0;
}

int push(PILHA *pilha, int elemento){
    pilha->elem[pilha->topo+1] = elemento;
    pilha->topo++;
    return 1;
}

int pop(PILHA *pilha){
    int aux = -1;
    aux = pilha->elem[pilha->topo];
    pilha->topo--;
    return aux;
}

int inserirElemento(){
    int elemento;
    printf("Digite um inteiro: ");
    fflush(stdin);
    scanf("%d", &elemento);
    return elemento;
}

void imprimir(PILHA pilha){

    if (pilhaVazia(&pilha)){
        printf("A pilha esta vazia.\n");
        return;
    }

    printf("Pilha: (TOPO ---> FUNDO)\n");
    while (pilha.topo != -1){
        printf("%d\t", pop(&pilha));
    }
    printf("\n");
    return;
}

/* nao utilizado
int qtdElem(PILHA pilha){

    if (pilhaVazia(&pilha)) return 0;
    if (pilhaCheia(&pilha)) return TAM;

    int aux = 0;
    while (pilha.topo != -1){
        pop(&pilha);
        aux++;
    }
    return aux;
}
*/

int contemElemento(PILHA pilha, int elemento){ // pesquisaElemento()

    while (pilha.topo != -1){
        if (pilha.elem[pilha.topo] == elemento){
            return 1;
        }
        pop(&pilha);
    }

    return 0;
}

int esvaziarPilha(PILHA *pilha){
    if (pilhaVazia(pilha)){
        printf("ERRO: A pilha ja esta vazia.\n");
        return 0;
    }
    pilha->topo = -1;
    return 1;
}

int encherPilha(PILHA *pilha){
    if (pilhaCheia(pilha)){
        printf("ERRO: A pilha ja esta cheia.\n");
        return 0;
    }
    while (!pilhaCheia(pilha)){
        push(pilha, rand()%100);
    }
    return 1;
}

int menu(){
    printf("--------------------------------------------------\n");
    printf("== 1 - VERIFICAR SE A PILHA ESTA VAZIA\n");
    printf("== 2 - VERIFICAR SE A PILHA ESTA CHEIA\n");
    printf("== 3 - INSERIR ELEMENTO NO TOPO DA PILHA\n");
    printf("== 4 - REMOVER ELEMENTO NO TOPO DA PILHA\n");
    printf("== 5 - VERIFICAR ELEMENTO NO TOPO DA PILHA\n");
    printf("== 6 - PESQUISAR ELEMENTO NA PILHA\n");
    printf("== 7 - IMPRIMIR PILHA\n");
    printf("== 8 - ESVAZIAR PILHA\n");
    printf("== 9 - PREENCHER PILHA COM INTEIROS ALEATORIOS\n");
    printf("== 0 - SAIR\n");
    printf("--------------------------------------------------\n");

    int opc;
    fflush(stdin);
    scanf("%d", &opc);
    return opc;
}

int main(){
    srand(time(NULL));
    PILHA p;
    inicializar(&p);
    int opc, aux;

    do{
        opc = menu();
        switch(opc){
            case 1:
                if (pilhaVazia(&p)) printf("A pilha esta vazia.\n");
                else printf("A pilha nao esta vazia.\n");
                break;
            case 2:
                if (pilhaCheia(&p)) printf("A pilha esta cheia.\n");
                else printf("A pilha nao esta cheia.\n");
                break;
            case 3:
                if (pilhaCheia(&p)) printf("ERRO: A pilha esta cheia.\n");
                else push(&p, inserirElemento());
                break;
            case 4:
                if (pilhaVazia(&p)) printf("ERRO: A lista esta vazia.\n");
                else printf("Elemento removido: %d\n", pop(&p));
                break;
            case 5:
                if (pilhaVazia(&p)) printf("ERRO: A pilha esta vazia.\n");
                else printf("O elemento no topo da pilha eh: %d\n", p.elem[p.topo]);
                break;
            case 6:
                aux = inserirElemento();
                if (pilhaVazia(&p)) printf("ERRO: A pilha esta vazia.\n");
                else if (contemElemento(p, aux)) printf("O elemento existe na pilha.\n");
                else printf("O elemento nao existe na pilha.\n");
                break;
            case 7:
                imprimir(p);
                break;
            case 8:
                if (esvaziarPilha(&p)) printf("A pilha foi esvaziada com sucesso.\n");
                break;
            case 9:
                if (encherPilha(&p)) printf("A pilha foi preenchida com sucesso.\n");
                break;
        }
    }while(opc != 0);

    return 0;
}
