using System;

namespace LP2A4_Ativ03
{
    class Program
    {
        static double[,] GerarMatriz(int size)
        {
            double[,] matriz = new double[size, size];
            double num = 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matriz[i, j] = num;
                    num++;
                }
            }
            return matriz;
        }
        static double[,] Preencher(double[,] matriz, int size)
        {
            for (int i = 0; i < size; i++) // percorre a matriz para edição de cada indice
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Clear();
                    Console.WriteLine("\n- Editando matriz: \n");

                    for (int ii = 0; ii < size; ii++) // percorre a matriz para indicar qual indice está sendo editado
                    {
                        for (int jj = 0; jj < size; jj++)
                        {
                            if (i == ii && j == jj) Console.Write("{0} <--\t", matriz[ii, jj]); // se o indice a ser editado == indice sendo imprimido
                            else Console.Write("{0}\t", matriz[ii, jj]);
                        }
                        Console.WriteLine("");
                    }
                    
                    Console.Write("\n- ENTER: Próximo índice | \'x\': Sair\n- Digite um novo valor: ");
                    double currentVal = matriz[i, j];
                    string val = Console.ReadLine();
                    if (!double.TryParse(val, out matriz[i, j])) // se val for numero, será atribuido à matriz
                    {
                        matriz[i, j] = currentVal;
                        if (val.ToLower().Equals("x")) return matriz; // se nao, verifica se quer sair
                    }
                }
            }
            return matriz;
        }
        static double Determinante(double[,] matriz, int size)
        {
            double det = 0;
            if (size == 1)
            {
                det = matriz[0,0];
            }
            else
            {
                for (int i = 0; i < size; i++) // Teorema de Laplace
                {
                    if (matriz[i, 0] == 0) continue;
                    else
                    {
                        det = det + (matriz[i, 0] * (Math.Pow(-1, i) * Determinante(Cofator(matriz, size, i, 0), size - 1)));
                    }
                }
            }
            return (det);
        }
        static double[,] Cofator(double[,] matriz, int size, int x, int y) 
        {
            int sizeAux = size - 1;
            double[,] matAux = new double[sizeAux, sizeAux];
            int m = 0, n = 0;
            for (int i = 0; i < size; i++) // forma a matriz auxiliar 1 ordem menor, excluindo a linha do parametro x (i da funçao Determinante) e a coluna y (0 da funçao Determinante)
            {
                if (i == x) continue;
                for (int j = 0; j < size; j++)
                {
                    if (j == y) continue;
                    matAux[m, n] = matriz[i, j];
                    if (n < (size - 2)) n++;
                    else
                    {
                        n = 0;
                        m++;
                    }
                }
            }
            return matAux; // [size - 1, size - 1]
        }
        static double[,] MatrizCofatores(double[,] matriz, int size)
        {
            double[,] matCof = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matCof[i, j] = Math.Pow(-1, i + j) * Determinante(Cofator(matriz, size, i, j), size - 1);
                }
            }
            return matCof;
        }
        static double[,] InverterMatriz(double[,] matriz, int size, double det)
        {
            double[,] matInv = new double[size, size];
            double[,] matCof = MatrizCofatores(matriz, size);
            matCof = Transpor(matCof, size); // matriz adjunta

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matInv[i, j] = matCof[i, j] / det;
                }
            }
            return matInv;
        }
        static double[,] Transpor(double[,] matriz, int size)
        {
            double[,] matAux = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matAux[i, j] = matriz[j, i];
                }
            }
            return matAux;
        }
        static void ExibirMatriz(double[,] matriz, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0:n}\t", matriz[i, j]);
                }
                Console.WriteLine("");
            }
        }
        static string Menu(int ordem)
        {
            Console.WriteLine(" ================= MENU =================");
            Console.WriteLine(" - 1 - Gerar matriz");
            Console.WriteLine(" - 2 - Preencher matriz");
            Console.WriteLine(" - 3 - Inverter matriz");
            Console.WriteLine(" - 4 - Exibir matriz");
            Console.WriteLine(" -");
            Console.WriteLine(" - 5 - Mudar ordem da matriz (Atual: {0})", ordem);
            Console.WriteLine(" -");
            Console.WriteLine(" - 0 - Sair");
            Console.WriteLine(" ========================================");
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            /*
             * Crie um programa capaz de realizar a impressão de uma matriz em sua forma normal e também sua matriz inversa.
             * Por questões de simplificação, basta fazer para matrizes de tamanho 3x3!
             * Faz parte da atividade procurar e entender o conceito de matriz inversa.
             */
            int size = 3;
            double[,] matriz = new double[size, size];
            double det = Determinante(matriz, size);
            bool running = true;
            do
            {
                Console.Clear();
                Console.WriteLine("\n- Matriz: \n");
                ExibirMatriz(matriz, size);
                Console.WriteLine($"\n- Determinante: {det}\n");
                switch (Menu(size))
                {
                    case "1": // Gerar matriz
                        matriz = GerarMatriz(size);
                        det = Determinante(matriz, size);

                        break;
                    case "2": // Preencher matriz
                        matriz = Preencher(matriz, size);
                        det = Determinante(matriz, size);

                        break;
                    case "3": // Inverter matriz
                        Console.WriteLine($"\n- Determinante = {det}");
                        if (det == 0)
                        {
                            Console.WriteLine("- A matriz atual não possui inversa!");
                            Console.WriteLine("\n- Pressione <ENTER> para continuar");
                            Console.ReadLine();
                        }
                        else matriz = InverterMatriz(matriz, size, det);

                        break;
                    case "4": // Exibir matriz
                        Console.Clear();
                        Console.WriteLine("\n- Matriz: \n");
                        ExibirMatriz(matriz, size);

                        Console.WriteLine("\n- Pressione <ENTER> para continuar");
                        Console.ReadLine();
                        
                        break;
                    case "5": // Mudar ordem
                        do
                        {
                            Console.Write("Ordem nova: ");
                            if (!int.TryParse(Console.ReadLine(), out size))
                            {
                                Console.WriteLine("Valor inválido!");
                                size = -1;
                            }
                        } while (size == -1);
                        matriz = new double[size, size];

                        break;
                    case "0":
                        running = false;
                        break;
                }
            } while (running);
        }
    }
}
