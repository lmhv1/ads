#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct sPessoa{
    char nome[50];
    int matricula;
}PESSOA;

typedef struct sCell{
    PESSOA info;
    struct sCell *proxima;
}CELULA;

void iniciarLista(CELULA **lista){
    *lista = NULL;
}

CELULA* criarCelula(){
    CELULA *nova = (CELULA *)malloc(sizeof(CELULA));
    return nova;
}

int listaVazia(CELULA **lista){
    if (*lista == NULL) return 1;
    return 0;
}

// verificar se vazia
int q1(CELULA **lista){
    if (listaVazia(lista)){
        printf("A lista esta vazia\n");
        return 1;
    }
    printf("A lista nao esta vazia\n");
    return 0;
}

// inserir pessoa no fim
int q2(CELULA **lista){
    CELULA *novaCelula;
    CELULA *auxiliar;

    novaCelula = criarCelula();
    if (novaCelula == NULL){
        printf("ERRO: Memoria Cheia\n");
        return 0;
    }

    printf("Digite a matricula: ");
    fflush(stdin);
    scanf("%d", &novaCelula->info.matricula);
    printf("Digite o nome: ");
    fflush(stdin);
    gets(novaCelula->info.nome);
    novaCelula->proxima = NULL;

    if (listaVazia(lista)){
        *lista = novaCelula;
        printf("Operacao realizada com exito\n");
        return 1;
    }

    auxiliar = *lista;

    while (auxiliar->proxima != NULL){
        auxiliar = auxiliar->proxima;
    }

    auxiliar->proxima = novaCelula;
    printf("Operacao realizada com exito\n");
    return 1;
}

// inserir pessoa no inicio
int q3(CELULA **lista){
    CELULA *novaCelula = criarCelula();
    if (novaCelula == NULL){
        printf("ERRO: memoria cheia\n");
        return 0;
    }

    if (listaVazia(lista)) return q2(lista);

    printf("Digite a matricula: ");
    fflush(stdin);
    scanf("%d", &novaCelula->info.matricula);
    printf("Digite o nome: ");
    fflush(stdin);
    gets(novaCelula->info.nome);

    novaCelula->proxima = *lista;
    *lista = novaCelula;

    printf("Operacao realizada com exito\n");
    return 1;
}

// imprimir lista
void q4(CELULA **lista){
    CELULA *auxiliar = *lista;
    if (listaVazia(lista)){
        printf("Lista vazia\n");
    }else{
        printf("Lista:\n");
        while (auxiliar != NULL){
            printf("Matricula: %d, Nome: %s\n", auxiliar->info.matricula, auxiliar->info.nome);
            auxiliar = auxiliar->proxima;
        }
    }
    return;
}

// remover pessoa no inicio
int q5(CELULA **lista){
    if (listaVazia(lista)){
        printf("ERRO: Lista vazia\n");
        return 0;
    }
    CELULA *removida;

    PESSOA removido;
    strcpy(removido.nome," ");
    removido.matricula = -1;

    removida = *lista;
    removido = removida->info;

    *lista = (*lista)->proxima;

    free(removida);
    printf("Operacao realizada com exito\n");
    return 1;
}

// remover pessoa no fim
int q6(CELULA **lista){
    if (listaVazia(lista)){
        printf("ERRO: Lista vazia\n");
        return 0;
    }
    CELULA *removida;
    CELULA *anterior;

    PESSOA removido;
    strcpy(removido.nome," ");
    removido.matricula = -1;

    if ((*lista)->proxima == NULL) return q5(lista);

    removida = *lista;
    while (removida->proxima != NULL){
        anterior = removida;
        removida = removida->proxima;
    }

    removido = removida->info;
    anterior->proxima = NULL;
    free(removida);
    printf("Operacao realizada com exito\n");
    return 1;
}

// pesquisar por matricula
CELULA *q7(CELULA **lista, int mat){
    if (listaVazia(lista)){
        printf("ERRO: Lista vazia\n");
        return NULL;
    }

    CELULA *auxiliar = *lista;
    while (auxiliar != NULL){
        if (auxiliar->info.matricula == mat){
            printf("Matricula encontrada\n");
            return auxiliar;
        }
        auxiliar = auxiliar->proxima;
    }
    printf("Matricula nao encontrada\n");
    return NULL;
}

// remover por matricula
int q8(CELULA **lista, int mat){
    if (listaVazia(lista)){
        printf("ERRO: Lista vazia\n");
        return 0;
    }

    CELULA *removida;
    CELULA *anterior;
    PESSOA pRemover;
    strcpy(pRemover.nome," ");
    pRemover.matricula = -1;

    removida = q7(lista, mat);

    if (removida == NULL) return 0;
    if (removida == *lista) return q5(lista);

    pRemover = removida->info;

    anterior = *lista;
    while(anterior->proxima != removida){
        anterior = anterior->proxima;
    }

    anterior->proxima = removida->proxima;
    free(removida);
    printf("Operacao realizada com exito\n");
    return 1;
}

int preq78(CELULA **lista, int opc){
    int mat;
    printf("Matricula: ");
    fflush(stdin);
    scanf("%d", &mat);

    if (opc==7) q7(lista, mat);
    else if (opc==8) q8(lista, mat);
}

int menu(){
    int opc;
    do{
        printf("======================MENU======================\n");
        printf("0 - SAIR\n");
        printf("1 - VERIFICAR SE VAZIA\n");
        printf("2 - INSERIR PESSOA NO FIM\n");
        printf("3 - INSERIR PESSOA NO INICIO\n");
        printf("4 - IMPRIMIR LISTA DE PESSOAS\n");
        printf("5 - REMOVER PESSOA NO INICIO\n");
        printf("6 - REMOVER PESSOA NO FIM\n");
        printf("7 - PESQUISAR POR MATRICULA\n");
        printf("8 - REMOVER POR MATRICULA\n");

        fflush(stdin);
        scanf("%d", &opc);
    }while(opc<0 || opc>8);
    return opc;
}

int main(){
    CELULA *ptrLista;
    iniciarLista(&ptrLista);

    while(1){
        switch(menu()){
            case 0: return 0;
            case 1: q1(&ptrLista); break;
            case 2: q2(&ptrLista); break;
            case 3: q3(&ptrLista); break;
            case 4: q4(&ptrLista); break;
            case 5: q5(&ptrLista); break;
            case 6: q6(&ptrLista); break;
            case 7: preq78(&ptrLista, 7); break;
            case 8: preq78(&ptrLista, 8); break;
        }
    }
}
