#include <stdio.h>
#define TAM 10

typedef struct sFilaE{
    int elem[TAM];
    int cabecalho, ultimo;
}FILAE;

typedef struct sCell{
    int info;
    struct sCell *next;
}CELULA;

typedef struct sFilaD{
    CELULA *inicio;
    CELULA *fim;
}FILAD;

CELULA* criarCelula(){
    CELULA *nova = (CELULA*)malloc(sizeof(CELULA));
    return nova;
}

int inserirElemento(){
    int elem;
    printf("Insira o elemento: ");
    fflush(stdin);
    scanf("%d", &elem);
    return elem;
}

// Inicializacao fila estatica
void inicializarE(FILAE *fila){
    fila->ultimo = 0;
    fila->cabecalho = fila->ultimo;
}

// Inicializacao fila dinamica
void inicializarD(FILAD *fila){
    fila->inicio = NULL;
    fila->fim = NULL;
}

// Fila vazia estatica
int filaVaziaE(FILAE *fila){
    return (fila->ultimo == fila->cabecalho);
}

// Fila vazia dinamica
int filaVaziaD(FILAD *fila){
    return (fila->inicio == NULL && fila->fim == NULL);
}

// Fila cheia estatica
int filaCheiaE(FILAE *fila){
    int proxi = (fila->ultimo+1)%TAM;
    return (proxi == fila->cabecalho);
}

// Enfileirar fila estatica
int enfileirarE(FILAE *fila, int elemento){
    if (filaCheiaE(fila)){
        printf("\nERRO: A fila esta cheia\n");
        return 0;
    }
    int proxi = (fila->ultimo+1)%TAM;
    fila->elem[proxi] = elemento;
    fila->ultimo = proxi;
    return 1;
}

// Enfileirar fila dinamica
int enfileirarD(FILAD *fila, int elemento){
    CELULA *nova = criarCelula();
    if (nova == NULL){
        printf("\nERRO: Nao foi possivel alocar\n");
        return 0;
    }
    nova->info = elemento;
    nova->next = NULL;
    if (filaVaziaD(fila)){
        fila->inicio = nova;
        fila->fim = nova;
        return 1;
    }
    (fila->fim)->next = nova;
    fila->fim = nova;
    return 1;
}

// Desenfileirar fila estatica
int desenfileirarE(FILAE *fila){
    if (filaVaziaE(fila)){
        printf("\nERRO: A fila esta vazia\n");
        return -1;
    }
    int removido = -1;
    fila->cabecalho = (fila->cabecalho+1)%TAM;
    removido = fila->elem[fila->cabecalho];
    return removido;
}

// Desenfileirar fila dinamica
int desenfileirarD(FILAD *fila){
    if (filaVaziaD(fila)){
        printf("\nERRO: A fila esta vazia\n");
        return -1;
    }
    if (fila->inicio == fila->fim) fila->fim = NULL;
    CELULA *auxiliar;
    int elemento = (fila->inicio)->info;
    auxiliar = (fila->inicio);
    (fila->inicio) = (fila->inicio)->next;
    free(auxiliar);
    return elemento;
}

// Imprimir fila estatica desenfileirando
void imprimirFilaE1(FILAE *fila){
    if (filaVaziaE(fila)){
        printf("\nA fila esta vazia\n");
        return;
    }
    printf("\nFila: ");
    while (!filaVaziaE(fila)){
        printf("%d ", desenfileirarE(fila));
    }
}

// Imprimir fila estatica usando auxiliar
void imprimirFilaE2 (FILAE *fila){
    if (filaVaziaE(fila)){
        printf("\nA fila esta vazia\n");
        return;
    }
    FILAE filaAux;
    inicializarE(&filaAux);
    int aux;
    printf("\nFila: ");
    while (!filaVaziaE(fila)){
        aux = desenfileirarE(fila);
        printf("%d ", aux);
        enfileirarE(&filaAux, aux);
    }
    while (!filaVaziaE(&filaAux)){
        enfileirarE(fila, desenfileirarE(&filaAux));
    }
}

// Imprimir fila dinamica desenfileirando
void imprimirFilaD1(FILAD *fila){
    if (filaVaziaD(fila)){
        printf("\nA fila esta vazia\n");
        return;
    }
    printf("\nFila: ");
    while (!filaVaziaD(fila)){
        printf("%d ", desenfileirarD(fila));
    }
}

// Imprimir fila dinamica usando auxiliar
void imprimirFilaD2 (FILAD *fila){
    if (filaVaziaD(fila)){
        printf("\nA fila esta vazia\n");
        return;
    }
    FILAD filaAux;
    inicializarD(&filaAux);
    int aux;
    printf("\nFila: ");
    while (!filaVaziaD(fila)){
        aux = desenfileirarD(fila);
        printf("%d ", aux);
        enfileirarD(&filaAux, aux);
    }
    while (!filaVaziaD(&filaAux)){
        enfileirarD(fila, desenfileirarD(&filaAux));
    }
}

int mainMenu(){
    int opc;
    while(1){
        printf("\n-------------------- MENU --------------------");
        printf("\n-- 1 - Fila Estatica");
        printf("\n-- 2 - Fila Dinamica");
        printf("\n-- 0 - Sair");
        printf("\n----------------------------------------------");
        printf("\nOpcao: ");
        fflush(stdin);
        scanf("%d", &opc);
        if (opc>=0&&opc<=2) break;
    }
    return opc;
}

int menuE(){
    int opcc;
    while(1){
        printf("\n---------------- FILA ESTATICA ---------------");
        printf("\n-- 1 - Inicializar");
        printf("\n-- 2 - Checar se vazia");
        printf("\n-- 3 - Enfileirar");
        printf("\n-- 4 - Desenfileirar");
        printf("\n-- 5 - Imprimir fila (liberando)");
        printf("\n-- 6 - Imprimir fila (usando auxiliar)");
        printf("\n-- 0 - Voltar");
        printf("\n----------------------------------------------");
        printf("\nOpcao: ");
        fflush(stdin);
        scanf("%d", &opcc);
        if (opcc>=0&&opcc<=6) break;
    }
    return opcc;
}

int menuD(){
    int opcc;
    while(1){
        printf("\n---------------- FILA DINAMICA ---------------");
        printf("\n-- 1 - Inicializar");
        printf("\n-- 2 - Checar se vazia");
        printf("\n-- 3 - Enfileirar");
        printf("\n-- 4 - Desenfileirar");
        printf("\n-- 5 - Imprimir fila (liberando)");
        printf("\n-- 6 - Imprimir fila (usando auxiliar)");
        printf("\n-- 0 - Voltar");
        printf("\n----------------------------------------------");
        printf("\nOpcao: ");
        fflush(stdin);
        scanf("%d", &opcc);
        if (opcc>=0&&opcc<=6) break;
    }
    return opcc;
}

int main(){
    FILAE fe;
    FILAD fd;
    int opc, opcc;
    do{
        opc = mainMenu();
        switch(opc){
            case 1:
                do{
                    opcc = menuE();
                    switch(opcc){
                        case 1:
                            inicializarE(&fe);
                            break;
                        case 2:
                            if (filaVaziaE(&fe)) printf("\nA fila esta vazia\n");
                            else printf("\nA fila nao esta vazia\n");
                            break;
                        case 3:
                            enfileirarE(&fe, inserirElemento());
                            break;
                        case 4:
                            desenfileirarE(&fe);
                            break;
                        case 5:
                            imprimirFilaE1(&fe);
                            break;
                        case 6:
                            imprimirFilaE2(&fe);
                            break;
                    }
                }while(opcc!=0);
                break;
            case 2:
                do{
                    opcc = menuD();
                    switch(opcc){
                        case 1:
                            inicializarD(&fd);
                            break;
                        case 2:
                            if (filaVaziaD(&fd)) printf("\nA fila esta vazia\n");
                            else printf("\nA fila nao esta vazia\n");
                            break;
                        case 3:
                            enfileirarD(&fd, inserirElemento());
                            break;
                        case 4:
                            desenfileirarD(&fd);
                            break;
                        case 5:
                            imprimirFilaD1(&fd);
                            break;
                        case 6:
                            imprimirFilaD2(&fd);
                            break;
                    }
                }while(opcc!=0);
                break;
        }

    }while(opc!=0);

    return 0;
}
