using System;
using System.Collections.Generic;

namespace LP2A4_Ativ02
{
    public class Cliente
    {
        public string Nome, CPF, RG, Renda_Bruta_Mensal, Email, Telefone, Classificacao;
        public int Idade;
        public double Patrimonio;

        public void EntrarDados()
        {
            // (Nome, CPF, RG, idade, Renda Bruta Mensal, e-mail, telefone e patrimônio)
            Console.Write("- Nome: ");
            Nome = Console.ReadLine();
            Console.Write("- CPF: ");
            CPF = Console.ReadLine();
            Console.Write("- RG: ");
            RG = Console.ReadLine();
            Console.Write("- Idade: ");
            Idade = int.Parse(Console.ReadLine());
            Console.Write("- Renda bruta mensal: ");
            Renda_Bruta_Mensal = Console.ReadLine();
            Console.Write("- E-Mail: ");
            Email = Console.ReadLine();
            Console.Write("- Telefone: ");
            Telefone = Console.ReadLine();
            Console.Write("- Patrimônio: ");
            Patrimonio = double.Parse(Console.ReadLine());

            Classificacao = GetClassificacao();

            Console.WriteLine("\n- Cadastro efetuado com sucesso.");
        }
        public void ExibirDados()
        {
            Console.WriteLine(
                "- 1 - Nome: {0}\n" +
                "- 2 - CPF: {1}\n" +
                "- 3 - RG: {2}\n" +
                "- 4 - Idade: {3}\n" +
                "- 5 - Renda bruta mensal: {4}\n" +
                "- 6 - E-Mail: {5}\n" +
                "- 7 - Telefone: {6}\n" +
                "- 8 - Patrimônio: {7}", 
                Nome, CPF, RG, Idade, Renda_Bruta_Mensal, Email, Telefone, Patrimonio);
        }

        public string GetClassificacao()
        {
            if ((10000000 <= Patrimonio && Idade < 39) || (Patrimonio >= 35000000 && Idade >= 39))
            {
                return "Cliente Diamante";
            }
            else if ((7000000 <= Patrimonio && Patrimonio < 10000000 && Idade < 36) || (20000000 <= Patrimonio && Patrimonio < 35000000 && Idade >= 36))
            {
                return "Cliente Ouro";
            }
            else if ((5000000 <= Patrimonio && Patrimonio < 7000000 && Idade < 33) || (10000000 <= Patrimonio && Patrimonio < 20000000 && Idade >= 33))
            {
                return "Cliente Prata";
            }
            else if ((1000000 <= Patrimonio && Patrimonio < 5000000 && Idade < 30) || (5000000 <= Patrimonio && Patrimonio < 10000000 && Idade >= 30))
            {
                return "Cliente Bronze";
            }
            else// if ((0 <= patrimonio && patrimonio < 1000000 && idade < 27) || (0 <= patrimonio && patrimonio < 5000000 && idade >= 27))
            {
                return "Cliente Safira";
            }
        }
    }

    class Program
    {
        static int Menu()
        {
            Console.WriteLine(" ========================================");
            Console.WriteLine(" = 1 - Cadastrar cliente                =");
            Console.WriteLine(" = 2 - Exibir lista de clientes         =");
            Console.WriteLine(" = 3 - Exibir dados de um cliente       =");
            Console.WriteLine(" = 4 - Editar dados de um cliente       =");
            Console.WriteLine(" =                                      =");
            Console.WriteLine(" = 0 - Sair                             =");
            Console.WriteLine(" ========================================");
            return int.Parse(Console.ReadLine());
        }
        static int Atributos(Cliente cliente)
        {
            Console.WriteLine("- Selecione o atributo:\n");
            cliente.ExibirDados();
            Console.WriteLine("-\n- 0 - Voltar\n");
            return int.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            /* Você foi contratado por uma corretora de serviços financeiros e precisa desenvolver
             * uma aplicação que dê suporte às operações da empresa. Portanto, seu primeiro trabalho
             * consiste em criar um sistema de gestão de clientes. Cada cliente ao solicitar um 
             * cadastro, precisará informar os seguintes dados: (Nome, CPF, RG, idade,
             * Renda Bruta Mensal, e-mail, telefone e patrimônio). Além dos dados informados, há um 
             * dado interno (classificação) que precisa ser definido com base nos seguintes critérios: 
             * Cliente diamante : 10MM ou mais de patr. e menos de 39 anos OU 35MM ou mais de patr. e 39 ou mais anos.
             * Cliente ouro     : entre [7MM, 10MM) de patr. e menos de 36 anos OU entre [20MM, 35MM) de patr. e 36 ou mais anos.
             * Cliente prata    : entre [5MM, 7MM) de patr. e menos de 33 anos OU entre [10MM, 20MM) de patr. e 33 ou mais anos.
             * Cliente bronze   : entre [1MM, 5MM) de patr. e menos de 30 anos OU entre [5MM, 10MM) de patr. e 30 ou mais anos.
             * Cliente safira   : entre [0 e 1MM) de patr. e menos de 27 anos OU entre [0, 5MM) e 27 ou mais anos.
             * IMPORTANTE: caso haja sobreposição em relação a idade e patrimônio, escolha sempre a classificação acima.
             *
             * Crie as variáveis necessárias para armazenar os dados a serem informados, além daquela que informa a classificação.
             * Crie um menu com as opções:
             * 1 - Editar dados (pergunte ao usuário se ele quer atualizar um a um os dados. Se houver alteração de idade ou patrimônio deve atualizar a classificação.
             * 2 - Exibir os dados cadastrados para aquele cliente.
             * 
             * Além disso, possibilite que as opções do menu possam ser escolhidas quantas vezes forem necessárias.
             */

            List<Cliente> lstClientes = new List<Cliente>();
            bool running = true;
            do
            {
                Console.Clear();

                //Exibir menu
                switch (Menu())
                {
                    case 1:
                        // Adicionar cliente
                        Console.Clear();
                        Console.WriteLine("========== Cadastro ==========");

                        Cliente novoCliente = new Cliente();
                        novoCliente.EntrarDados();
                        lstClientes.Add(novoCliente);

                        Console.WriteLine("\n- Aperte <ENTER> para continuar");
                        Console.ReadLine();
                        break;
                    case 2:
                        // Exibir lista de clientes
                        Console.Clear();
                        Console.WriteLine("========== Clientes ==========");

                        int i = 1;
                        foreach (Cliente c in lstClientes)
                        {
                            Console.WriteLine("- ID {0} - Nome: {1}", i, c.Nome);
                            i++;
                        }
                        Console.WriteLine("\n- Aperte <ENTER> para continuar");
                        Console.ReadLine();
                        break;
                    case 3:
                        // Exibir dados de um cliente
                        Console.Write("- ID do cliente: ");
                        int id = int.Parse(Console.ReadLine());
                        Cliente cliente = lstClientes[id - 1];

                        Console.Clear();
                        Console.WriteLine("========== Cliente {0} ==========", id);

                        cliente.ExibirDados();
                        Console.WriteLine("- Classificação: {0}", cliente.GetClassificacao());

                        Console.WriteLine("\n- Aperte <ENTER> para continuar");
                        Console.ReadLine();
                        break;
                    case 4:
                        // Editar dados de um cliente
                        // Se houver alteração de idade ou patrimônio deve atualizar a classificação
                        Console.Write("- ID do cliente: ");
                        id = int.Parse(Console.ReadLine());
                        cliente = lstClientes[id - 1];
                        int opc;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("========== Editando dados de Cliente {0} ==========", id);
                            opc = Atributos(cliente);
                            switch (opc)
                            {
                                case 1:
                                    Console.Write("- Novo nome: ");
                                    cliente.Nome = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Write("- Novo CPF: ");
                                    cliente.CPF = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.Write("- Novo RG: ");
                                    cliente.RG = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.Write("- Nova idade: ");
                                    cliente.Idade = int.Parse(Console.ReadLine());
                                    cliente.Classificacao = cliente.GetClassificacao();
                                    break;
                                case 5:
                                    Console.Write("- Novo valor: ");
                                    cliente.Renda_Bruta_Mensal = Console.ReadLine();
                                    break;
                                case 6:
                                    Console.Write("- Novo e-mail: ");
                                    cliente.Email = Console.ReadLine();
                                    break;
                                case 7:
                                    Console.Write("- Novo telefone: ");
                                    cliente.Telefone = Console.ReadLine();
                                    break;
                                case 8:
                                    Console.Write("- Novo patrimônio: ");
                                    cliente.Patrimonio = double.Parse(Console.ReadLine());
                                    cliente.Classificacao = cliente.GetClassificacao();
                                    break;
                            }
                        } while (opc != 0);

                        break;
                    case 0:
                        running = false;
                        break;
                }

            } while (running);
        }
    }
}
