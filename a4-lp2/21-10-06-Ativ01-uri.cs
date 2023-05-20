using System;

namespace LP2A4_Ativ01
{
    class Program
    {
        static int menu()
        {
            Console.WriteLine("================= MENU =================");
            Console.WriteLine("1 - URI 1049 - Animal");
            Console.WriteLine("2 - URI 1059 - Numeros Pares");
            Console.WriteLine("3 - URI 1073 - Quadrado de Pares");
            Console.WriteLine("4 - URI 1079 - Medias Ponderadas");
            Console.WriteLine("5 - URI 1133 - Resto da Divisao");
            Console.WriteLine("");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("========================================");
            return Convert.ToInt32(Console.ReadLine());
        }
        static void URI_1049()
        {
            string tipo1, tipo2, tipo3, opc;
            bool running = true;
            do
            {
                Console.WriteLine("Vertebrado ou invertebrado?");
                tipo1 = Console.ReadLine();
                if (tipo1.ToLower() == "vertebrado")
                {
                    //vertebrado
                    Console.WriteLine("Ave ou mamifero?");
                    tipo2 = Console.ReadLine();

                    if (tipo2.ToLower() == "ave")
                    {
                        //vertebrado, ave
                        Console.WriteLine("Carnivoro ou onivoro?");
                        tipo3 = Console.ReadLine();

                        if (tipo3.ToLower() == "carnivoro")
                        {
                            //vertebrado, ave, carnivoro
                            Console.WriteLine("aguia");
                        }
                        else if (tipo3.ToLower() == "onivoro")
                        {
                            //vertebrado, ave, onivoro
                            Console.WriteLine("pomba");
                        }
                        else
                        {
                            Console.WriteLine("Animal nao encontrado");
                        }
                    }
                    else if (tipo2.ToLower() == "mamifero")
                    {
                        //vertebrado, mamifero
                        Console.WriteLine("Onivoro ou herbivoro?");
                        tipo3 = Console.ReadLine();

                        if (tipo3.ToLower() == "onivoro")
                        {
                            //vertebrado, mamifero, onivoro
                            Console.WriteLine("homem");
                        }
                        else if (tipo3.ToLower() == "herbivoro")
                        {
                            //vertebrado, mamifero, herbivoro
                            Console.WriteLine("vaca");
                        }
                        else
                        {
                            Console.WriteLine("Animal nao encontrado");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Animal nao encontrado");
                    }
                }
                else if (tipo1.ToLower() == "invertebrado")
                {
                    //invertebrado
                    Console.WriteLine("Inseto ou anelideo?");
                    tipo2 = Console.ReadLine();

                    if (tipo2.ToLower() == "inseto")
                    {
                        //invertebrado, inseto
                        Console.WriteLine("hematofago ou herbivoro?");
                        tipo3 = Console.ReadLine();

                        if (tipo3.ToLower() == "hematofago")
                        {
                            //invertebrado, inseto, hematofago
                            Console.WriteLine("pulga");
                        }
                        else if (tipo3.ToLower() == "herbivoro")
                        {
                            //invertebrado, inseto, herbivoro
                            Console.WriteLine("lagarta");
                        }
                        else
                        {
                            Console.WriteLine("Animal nao encontrado");
                        }

                    }
                    else if (tipo2.ToLower() == "anelideo")
                    {
                        //invertebrado, anelideo
                        Console.WriteLine("Hematofago ou onivoro?");
                        tipo3 = Console.ReadLine();

                        if (tipo3.ToLower() == "hematofago")
                        {
                            //invertebrado, anelideo, hematofago
                            Console.WriteLine("sanguessuga");
                        }
                        else if (tipo3.ToLower() == "onivoro")
                        {
                            //invertebrado, anelideo, onivoro
                            Console.WriteLine("minhoca");
                        }
                        else
                        {
                            Console.WriteLine("Animal nao encontrado");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Animal nao encontrado");
                    }
                }
                else
                {
                    Console.WriteLine("Animal nao encontrado");
                }

                do
                {
                    Console.WriteLine("Continuar? s/n");
                    opc = Console.ReadLine();
                    if (opc == "n")
                    {
                        running = false;
                    }
                } while (opc != "s" && opc != "n");

            } while (running);
        }
        static void URI_1049_alt() // codificao de acordo com o site URI
        {
            string tipo1, tipo2, tipo3;
            tipo1 = Console.ReadLine();
            tipo2 = Console.ReadLine();
            tipo3 = Console.ReadLine();

            if (tipo1 == "vertebrado")
            {
                //vertebrado
                if (tipo2 == "ave")
                {
                    //vertebrado, ave
                    if (tipo3 == "carnivoro")
                    {
                        //vertebrado, ave, carnivoro
                        Console.WriteLine("aguia");
                    }
                    else
                    {
                        //vertebrado, ave, onivoro
                        Console.WriteLine("pomba");
                    }
                }
                else
                {
                    //vertebrado, mamifero
                    if (tipo3 == "onivoro")
                    {
                        //vertebrado, mamifero, onivoro
                        Console.WriteLine("homem");
                    }
                    else
                    {
                        //vertebrado, mamifero, herbivoro
                        Console.WriteLine("vaca");
                    }
                }
            }
            else
            {
                //invertebrado
                if (tipo2 == "inseto")
                {
                    //invertebrado, inseto
                    if (tipo3 == "hematofago")
                    {
                        //invertebrado, inseto, hematofago
                        Console.WriteLine("pulga");
                    }
                    else
                    {
                        //invertebrado, inseto, herbivoro
                        Console.WriteLine("lagarta");
                    }
                }
                else
                {
                    //invertebrado, anelideo
                    if (tipo3 == "hematofago")
                    {
                        //invertebrado, anelideo, hematofago
                        Console.WriteLine("sanguessuga");
                    }
                    else
                    {
                        //invertebrado, anelideo, onivoro
                        Console.WriteLine("minhoca");
                    }
                }
            }
        }
        static void URI_1059()
        {
            for (int i = 1; i<=100; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void URI_1073()
        {
            Console.WriteLine("Insira um valor inteiro"); // comentar linha para envio no URI
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i<=n; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0}^2 = {1}", i, i*i);
                }
            }

        }
        static void URI_1079()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine("Numero de casos: "); // comentar linha para envio no URI
            int casos = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i<casos; i++)
            {
                Console.WriteLine("Notas do caso {0}: (utilize ponto nas casas decimais)", i+1); // comentar linha para envio no URI
                string[] notas = Console.ReadLine().Split();
                float nota1 = float.Parse(notas[0]);
                float nota2 = float.Parse(notas[1]);
                float nota3 = float.Parse(notas[2]);
                Console.WriteLine("Media ponderada: "); // comentar linha para envio no URI
                Console.WriteLine("{0:F1}", ((nota1 * 2) + (nota2 * 3) + (nota3 * 5)) / 10);
            }

        }
        static void URI_1133()
        {
            Console.WriteLine("Insira o valor de X"); // comentar linha para envio no URI
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o valor de Y"); // comentar linha para envio no URI
            int y = int.Parse(Console.ReadLine());

            if (x < y)
            {
                for (int i = x + 1; i < y; i++)
                {
                    if (i % 5 == 2 || i % 5 == 3)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            else
            {
                for (int i = y + 1; i < x; i++)
                {
                    if (i % 5 == 2 || i % 5 == 3)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            bool running = true;
            do
            {
                switch (menu())
                {
                    case 1:
                        URI_1049();
                        break;
                    case 2:
                        URI_1059();
                        break;
                    case 3:
                        URI_1073();
                        break;
                    case 4:
                        URI_1079();
                        break;
                    case 5:
                        URI_1133();
                        break;
                    case 0:
                        running = false;
                        break;
                }
            } while (running);
        }
    }
}
