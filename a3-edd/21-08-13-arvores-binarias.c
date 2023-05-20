#include <stdio.h>
#include <stdlib.h>

typedef struct sNode{
    int info;
    struct sNode *esq;
    struct sNode *dir;
}NO;

// Cria, aloca e atribui valor a um no
NO* criarNo(int valor){
    NO *novo = (NO*)malloc(sizeof(NO));
    if (novo != NULL){
        novo->info = valor;
        novo->esq = NULL;
        novo->dir = NULL;
    }else{
        printf("ERRO: Falha ao alocar novo no\n");
        return novo;
    }
    return novo;
}

// Imprime arvore inteira
void imprimirArvore(NO *raiz){
    if (raiz != NULL){
        imprimirArvore(raiz->esq);
        printf("%d, ", raiz->info);
        imprimirArvore(raiz->dir);
    }
}

// Imprime folhas da arvore
void imprimirFolhas(NO *raiz){
    if (raiz != NULL){
        imprimirFolhas(raiz->esq);
        if (raiz->esq == NULL && raiz->dir == NULL)
            printf("%d, ", raiz->info);
        imprimirFolhas(raiz->dir);
    }
}

// Pesquisa elemento
NO* pesquisarElemento(NO *raiz, int elem){
    if (raiz == NULL)
        return NULL;
    if (raiz->info == elem)
        return raiz;
    else if (elem < raiz->info)
        return pesquisarElemento(raiz->esq, elem);
    else
        return pesquisarElemento(raiz->dir, elem);
}

// Pega maior elemento da sub arvore
NO* maiorElemento(NO **raiz){
    if ((*raiz)->dir != NULL)
        return maiorElemento(&(*raiz)->dir);
    else{
        NO *aux = *raiz;
        if ((*raiz)->esq != NULL)
            *raiz = (*raiz)->esq;
        else
            *raiz = NULL;
        return aux;
    }
}

// Insere no na arvore (parte comentada == codigo do slide)
int inserir(NO **raizPtr, int elem){
    NO *raiz = *raizPtr;

    if (raiz == NULL){
        (*raizPtr) = criarNo(elem);
        return 1;
    }

//    NO *aux = raiz;
//    NO *anterior = NULL;
//    while (aux != NULL){
//        anterior = aux;
//        if (elem >= aux->info)
//            aux = aux->dir;
//        else
//            aux = aux->esq;
//    }
//    if (elem >= anterior->info)
//        anterior->dir = criarNo(elem);
//    else
//        anterior->esq = criarNo(elem);
//    return 1;

    // Implementa��o recursiva:
    if (elem < raiz->info)
        return inserir(&(raiz->esq), elem);
    else
        return inserir(&(raiz->dir), elem);
}

// Remover no - metodo recursivo
void removerRec(NO **raiz, int elem){
    NO *aux;

    if (elem < (*raiz)->info)
        removerRec(&(*raiz)->esq, elem);
    else if
        (elem > (*raiz)->info) removerRec(&(*raiz)->dir, elem);
    else{
        aux = *raiz;
        if (((*raiz)->esq == NULL) && ((*raiz)->dir == NULL)){ // caso 1 - eh folha
            free(aux);
            (*raiz) = NULL;
        }else{ // caso 2 - possui so uma sub arvore
            if ((*raiz)->esq == NULL){ // sub arvore eh direita
                (*raiz) = (*raiz)->dir;
                free(aux);
            }else{ // sub arvore eh esquerda
                if ((*raiz)->dir == NULL){
                    (*raiz) = (*raiz)->esq;
                    free(aux);
                }else{ // caso 3 - possui duas sub arvores
                    aux = maiorElemento(&(*raiz)->esq);
                    aux->esq = (*raiz)->esq;
                    aux->dir = (*raiz)->dir;
                    free(*raiz);
                    *raiz = aux;
                }
            }
        }
    }
}

// Remover no - metodo nao recursivo
int remover(NO **raiz, int elem){
    NO *aux;
    NO *anterior = NULL;

    aux = *raiz;

    while (aux->info != elem){
        anterior = aux;
        if (elem < aux->info)
            aux = aux->esq;
        else
            aux = aux->dir;
    }

    if ((aux->esq == NULL) && (aux->dir == NULL)){ // caso 1 - eh folha
        if (anterior == NULL) // raiz eh folha
            (*raiz) = NULL;
        else if (anterior->esq == aux)
            anterior->esq = NULL; // no anterior desconectado do no removido
        else
            anterior->dir = NULL;
        free(aux);
    }else{ // caso 2 - possui so uma sub arvore
        if (aux->esq == NULL){ // sub arvore eh direita
            if (anterior == NULL) // eh raiz
                *raiz = aux->dir;
            else if (anterior->info > aux->info)
                anterior->esq = aux->dir; // no anterior conectado ao proximo no
            else
                anterior->dir = aux->dir;
            free(aux);
        }else{ // sub arvore eh esquerda
            if (aux->dir == NULL){
                if (anterior == NULL) // eh raiz
                    *raiz = aux->esq;
                else if (anterior->info > aux->info)
                    anterior->esq = aux->esq; // no anterior conectado ao proximo no
                else
                    anterior->dir = aux->esq;
                free(aux);
            }else{ // caso 3 - possui duas sub arvores
                NO *maiorEsq = maiorElemento(&(aux->esq)); // maior no � determinado

                maiorEsq->esq = aux->esq;
                maiorEsq->dir = aux->dir;

                if (anterior == NULL) // era raiz
                    (*raiz) = maiorEsq;
                else if (anterior->esq == aux)
                    anterior->esq = maiorEsq; // no anterior conectado ao novo no
                else
                    anterior->dir = maiorEsq;

                free(aux);
            }
        }
    }
    return 1;
}

void opc_7(NO **raiz){
    printf("Inserindo elementos na arvore {14, 15, 4, 9, 7, 18, 3, 5, 16, 14, 20, 17, 9, 2, 5, 4}\n");
    inserir (raiz, 14);
    inserir (raiz, 15);
    inserir (raiz, 4);
    inserir (raiz, 9);
    inserir (raiz, 7);
    inserir (raiz, 18);
    inserir (raiz, 3);
    inserir (raiz, 5);
    inserir (raiz, 16);
    inserir (raiz, 14);
    inserir (raiz, 20);
    inserir (raiz, 17);
    inserir (raiz, 9);
    inserir (raiz, 2);
    inserir (raiz, 5);
    inserir (raiz, 4);
    printf("Arvore preenchida.\n");
}

int menu(){
    printf("--------------------------------------------------\n");
    printf("== 1 - INSERIR ELEMENTO\n");
    printf("== 2 - REMOVER ELEMENTO\n");
    printf("== 3 - REMOVER ELEMENTO - METODO RECURSIVO\n");
    printf("==\n");
    printf("== 4 - IMPRIMIR ARVORE\n");
    printf("== 5 - IMPRIMIR FOLHAS\n");
    printf("== 6 - PESQUISAR ELEMENTO\n");
    printf("==\n");
    printf("== 7 - PREENCHER ARVORE - SEMELHANTE AO SLIDE\n");
    printf("== 8 - LIMPAR ARVORE\n");
    printf("==\n");
    printf("== 0 - SAIR\n");
    printf("--------------------------------------------------\n");

    int opc;
    fflush(stdin);
    scanf("%d", &opc);
    return opc;
}

int main(){
    int opc, aux;
    NO *raizPtr = NULL;
    do{
        opc = menu();
        switch(opc){
            case 1:
                printf("Digite o valor a ser inserido: ");
                fflush(stdin);
                scanf("%d", &aux);
                inserir(&raizPtr, aux);
                break;
            case 2:
                if (raizPtr == NULL){
                    printf("A arvore esta vazia.\n");
                    break;
                }
                printf("Digite o valor a ser removido: ");
                fflush(stdin);
                scanf("%d", &aux);
                if (pesquisarElemento(raizPtr, aux)){
                    remover(&raizPtr, aux);
                    printf("Elemento removido.\n");
                }else
                    printf("O elemento nao foi encontrado na arvore.\n");
                break;
            case 3:
                if (raizPtr == NULL){
                    printf("A arvore esta vazia.\n");
                    break;
                }
                printf("Digite o valor a ser removido: ");
                fflush(stdin);
                scanf("%d", &aux);
                if (pesquisarElemento(raizPtr, aux)){
                    removerRec(&raizPtr, aux);
                    printf("Elemento removido.\n");
                }else
                    printf("O elemento nao foi encontrado na arvore.\n");
                break;
            case 4:
                if (raizPtr != NULL){
                    printf("Arvore: ");
                    imprimirArvore(raizPtr);
                    printf("\n");
                }else
                    printf("A arvore esta vazia.\n");
                break;
            case 5:
                if (raizPtr != NULL){
                    printf("Folhas: ");
                    imprimirFolhas(raizPtr);
                    printf("\n");
                }else
                    printf("A arvore esta vazia.\n");
                break;
            case 6:
                if (raizPtr == NULL){
                    printf("A arvore esta vazia.\n");
                    break;
                }
                printf("Digite o valor a ser encontrado: ");
                fflush(stdin);
                scanf("%d", &aux);
                if (pesquisarElemento(raizPtr, aux))
                    printf("O elemento esta na arvore.\n");
                else
                    printf("O elemento nao foi encontrado na arvore.\n");
                break;
            case 7:
                opc_7(&raizPtr);
                break;
            case 8:
                if (raizPtr != NULL){
                    while(raizPtr != NULL)
                        remover(&raizPtr, raizPtr->info);
                    printf("Arvore esvaziada.\n");
                }else
                    printf("A arvore esta vazia.\n");
                break;
        }
    }while(opc != 0);
    return 0;
}
