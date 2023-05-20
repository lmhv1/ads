#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int retry(){
    int retry;
    do{
        printf("\nDigite 1 para continuar ou 0 para voltar: ");
        fflush(stdin);
        scanf("%d", &retry);
    }while(retry!=0 && retry!=1);
    return retry;
}

// 1 - Faça um programa que leia dois números inteiros, armazenando-os em memória alocada dinamicamente e depois escreva-os na tela.
void aula5_1(){
    while(1){
        printf("\n==================================================\n");

        // Declaracao e alocacao dos ponteiros
        int *x = (int*)malloc(sizeof(int));
        int *y = (int*)malloc(sizeof(int));

        // Entrada de valores
        printf("Insira dois inteiros: ");
        fflush(stdin);
        scanf("%d%d", x, y);

        // Saida dos valores
        printf("%d, %d\n", *x, *y);

        free(x);
        free(y);

        if (retry()==0) return;
    }
}

// 2 – Faça um programa que leia n inteiros (definidos pelo usuário) armazenando-os em um vetor alocada dinamicamente
void aula5_2(){
    while(1){
        printf("\n==================================================\n");

        // Definicao do tamanho do vetor
        int tam=0;
        printf("Digite o tamanho do vetor desejado: ");
        fflush(stdin);
        scanf("%d", &tam);

        // Alocacao do vetor
        int *arr = (int*)malloc(tam*sizeof(int));

        // Entrada de valores
        printf("Insira %d valores: ", tam);
        for (int i=0; i<tam; i++){
            scanf("%d", &arr[i]);
        }

        // Saida dos valores
        printf("Vetor: ");
        for (int i=0; i<tam; i++){
            if (i==(tam-1)) printf("%d\n", arr[i]); // ultimo termo
            else printf("%d, ", arr[i]);
        }

        free(arr);

        if (retry()==0) return;
    }
}

// 3 – Defina uma estrutura para armazenar um cadastro de cliente: nome, idade e telefone.
//     Peça ao usuário o número de clientes e aloque dinamicamente na memória a quantidade de estruturas necessárias.
//     Em seguida, leia os dados destes clientes.
void aula5_3(){
    while(1){
        printf("\n==================================================\n");
        typedef struct cad{
            char nome[20];
            int idade;
            int telefone;
        }CADASTRO;

        // Definicao do numero de clientes
        int tam=0;
        printf("Digite o numero de clientes: ");
        fflush(stdin);
        scanf("%d", &tam);

        // Definicao e alocacao do vetor de clientes
        CADASTRO *pClientes;
        pClientes = (CADASTRO*)malloc(tam*sizeof(CADASTRO));
        if(pClientes == NULL){
            printf("Nao foi possivel alocar memoria. \n");
            exit(0);
        }

        // Entrada dos dados dos clientes
        for (int i=0; i<tam; i++){
            printf("Nome do cliente %d: ", i+1);
            fflush(stdin);
            gets(pClientes[i].nome);

            printf("Idade do cliente %d: ", i+1);
            fflush(stdin);
            scanf("%d", &pClientes[i].idade);

            printf("Telefone do cliente %d: ", i+1);
            fflush(stdin);
            scanf("%d", &pClientes[i].telefone);

            printf("\n");
        }

        // Saida dos dados dos clientes
        if (tam>0) printf("\nDados armazenados: \n\n");
        for (int i=0; i<tam; i++){
            printf("== Cliente %2d ==\n", i+1);
            printf("Nome: %s\n", pClientes[i].nome);
            printf("Idade: %d\n", pClientes[i].idade);
            printf("Telefone: %d\n", pClientes[i].telefone);
            printf("================\n\n");
        }

        free(pClientes);

        if (retry()==0) return;
    }
}

// 4 – Aloque dinamicamente uma matriz de tamanho a ser informado pelo usuário. Preencha, imprima e depois libere a memória alocada.
void aula5_4(){
    while(1){
        printf("\n==================================================\n");
        // Definindo tamanho da matriz
        int tamL, tamC;
        printf("Digite a quantidade de linhas: ");
        fflush(stdin);
        scanf("%d", &tamL);
        printf("Digite a quantidade de colunas: ");
        fflush(stdin);
        scanf("%d", &tamC);

        // Alocando matriz
        int **matriz;
        matriz = (int**)malloc(tamL*sizeof(int*));
        for(int i=0; i<tamL; i++){
            matriz[i] = (int*)malloc(tamC*sizeof(int));
            for(int j=0; j<tamC; j++){
                matriz[i][j] = rand()%10;
            }
        }

        printf("\n");
        for (int i=0; i<tamL; i++){
            for (int j=0; j<tamC; j++){
                printf("%d, ", matriz[i][j]);
            }
            printf("\n");
        }

        free(matriz);
        matriz = NULL;

        if (retry()==0) return;
    }
}

// 5 – Crie um programa com uma struct para armazenar as informações de carros em uma garagem de venda de veículos.
//     Crie uma função externa ao main para realizar o cadastro de um automóvel e outra para edição dos dados de um automóvel.
//     A variável do tipo struct de tamanho 100 deve obrigatoriamente ser declarada na main e passada como referência para a função.
void aula5_5(){
    typedef struct car{
        char marca[20];
        char modelo[20];
        char cor[20];
        int ano;
        float preco;
    }CARRO;

    CARRO *pCarros;
    pCarros = (CARRO*)malloc(100*sizeof(CARRO));
    if(pCarros == NULL){
        printf("Nao foi possivel alocar memoria. \n");
        exit(0);
    }

    void cadVeiculo(CARRO *p, int i){
        printf("\n=============================================\n");
        printf("== Realizando cadastro de veiculo na vaga %d\n", i+1);

        printf("Marca do veiculo: ");
        fflush(stdin);
        gets(p[i].marca);

        printf("Modelo do veiculo: ");
        fflush(stdin);
        gets(p[i].modelo);

        printf("Cor do veiculo: ");
        fflush(stdin);
        gets(p[i].cor);

        printf("Ano de fabricacao: ");
        fflush(stdin);
        scanf("%d", &p[i].ano);

        printf("Preco do veiculo: ");
        fflush(stdin);
        scanf("%f", &p[i].preco);

        printf("\nVeiculo cadastrado.\n");
    }

    void editarCad(CARRO *p, int i){
        printf("\n===========================================\n");
        printf("== Editando cadastro de veiculo na vaga %d\n", i+1);
        printf("==\n");
        printf("== Qual atributo gostaria de atualizar?\n");
        printf("== 1 - Marca\n");
        printf("== 2 - Modelo\n");
        printf("== 3 - Cor\n");
        printf("== 4 - Ano de fabricacao\n");
        printf("== 5 - Preco do veiculo\n");
        printf("==\n");
        printf("== 0 - Cancelar\n");

        int edOpc;
        fflush(stdin);
        scanf("%d", &edOpc);

        if (edOpc==0) return;

        if (edOpc==1){
            printf("Editando Marca\n");
            printf("Digite o novo valor: ");

            fflush(stdin);
            gets(p[i].marca);

            printf("\nAtributo atualizado.\n");

        } else if (edOpc==2){
            printf("Editando Modelo\n");
            printf("Digite o novo valor: ");

            fflush(stdin);
            gets(p[i].modelo);

            printf("\nAtributo atualizado.\n");

        } else if (edOpc==3){
            printf("Editando Cor\n");
            printf("Digite o novo valor: ");

            fflush(stdin);
            gets(p[i].cor);

            printf("\nAtributo atualizado.\n");

        } else if (edOpc==4){
            printf("Editando Ano de fabricacao\n");
            printf("Digite o novo valor: ");

            fflush(stdin);
            scanf("%d", &p[i].ano);

            printf("\nAtributo atualizado.\n");

        } else if (edOpc==5){
            printf("Editando Preco\n");
            printf("Digite o novo valor: ");

            fflush(stdin);
            scanf("%f", &p[i].preco);

            printf("\nAtributo atualizado.\n");
        }
    }

    void exibirCad(CARRO *p, int i){
        printf("\n==========================================\n");
        printf("== Exibindo veiculo cadastrado na vaga %d\n", i+1);
        printf("==\n");
        printf("== Marca: %s\n", p[i].marca);
        printf("== Modelo: %s\n", p[i].modelo);
        printf("== Cor: %s\n", p[i].cor);
        printf("== Ano de fabricacao: %d\n", p[i].ano);
        printf("== Preco: %.2f\n", p[i].preco);

    }

    void operacao(CARRO *p, int tipo){
        int carro;
        printf("Informe o numero da vaga (1-100): ");
        fflush(stdin);
        scanf("%d", &carro);
        carro--;

        switch(tipo){
            case 1: cadVeiculo(p, carro); break;
            case 2: editarCad(p, carro); break;
            case 3: exibirCad(p, carro); break;
        }
        return;
    }

    int opc=123;
    do{
        printf("\n==============================\n");
        printf("== Menu garagem de veiculos ==\n");
        printf("== 1 - Cadastrar um veiculo\n");
        printf("== 2 - Editar um cadastro\n");
        printf("== 3 - Exibir um cadastro\n");
        printf("==\n");
        printf("== 0 - Sair\n");

        fflush(stdin);
        scanf("%d", &opc);

        switch(opc){
            case 1: operacao(pCarros, 1); break;
            case 2: operacao(pCarros, 2); break;
            case 3: operacao(pCarros, 3); break;
            case 0: break;
        }
    }while(opc!=0);

    free(pCarros);
    return;
}

int menu(){
    printf("\n==================================================\n");
    int opc;
    while(1){
        printf("== Exercicios de 01.jun.2021\n");
        printf("== 1 - Ponteiros: Ler e escrever dois numeros inteiros\n");
        printf("== 2 - Ponteiros: Vetor alocado dinamicamente\n");
        printf("== 3 - Ponteiros: Cadastro de clientes\n");
        printf("== 4 - Ponteiros: Matriz\n");
        printf("== 5 - Ponteiros: Garagem de veiculos\n");
        printf("==\n");
        printf("== 0 - Sair\n");

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

int main(){
    while(1){
        srand(time(NULL));
        switch(menu()){
            case 1: aula5_1(); break;
            case 2: aula5_2(); break;
            case 3: aula5_3(); break;
            case 4: aula5_4(); break;
            case 5: aula5_5(); break;
            case 0: return 0;
        }
    }
}
