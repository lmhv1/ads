using System;
using System.Collections.Generic;

namespace LP2A4_Ativ05
{
    class Cliente
    {
        string nome;
        string cpf;
        string telefone;
        string email;
        bool status;
        
        public Cliente(string nome, string cpf, string telefone, string email)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.email = email;
            status = true;
        }
        public bool AlterarStatus()
        {
            if (status == true)
            {
                status = false;
                return status;
            }
            else
            {
                status = true;
                return status;
            }
        }
        public bool ConsultarCpf(string cpf)
        {
            if (cpf.Equals(this.cpf)) return true;
            return false;
        }
        public string RetornarCpf()
        {
            return cpf;
        }
        public override string ToString()
        {
            return $"- Nome:.....  {nome}\n" +
                $"- CPF:......  {cpf}\n" +
                $"- Telefone:.  {telefone}\n" +
                $"- E-Mail:...  {email}";
        }
    }
    class Conta
    {
        Cliente cliente;
        string numero;
        float saldo;
        DateTime dataAbertura;
        bool status;

        public Conta(Cliente cliente, string numero)
        {
            this.cliente = cliente;
            this.numero = numero;
            saldo = 0;
            dataAbertura = DateTime.Now;
            status = true;
        }
        public float RetornarSaldo()
        {
            return saldo;
        }
        public bool RetornarStatus()
        {
            return status;
        }
        public bool AlterarStatus()
        {
            if (status == true)
            {
                status = false;
                return status;
            }
            else
            {
                status = true;
                return status;
            }
        }
        public string Depositar(float n)
        {
            if (n <= 0)
            {
                Console.WriteLine("- ERRO: Valor invalido");
                return saldo.ToString();
            }
            saldo += n;
            Console.WriteLine($"- Adicionou com sucesso R$ {n} à conta");
            return saldo.ToString();

        }
        public string Sacar(float n)
        {
            if (n <= 0)
            {
                Console.WriteLine("- ERRO: Valor invalido");
                return saldo.ToString();
            }
            if (n > saldo)
            {
                Console.WriteLine("- ERRO: Saldo insuficiente");
                return saldo.ToString();
            }
            saldo -= n;
            Console.WriteLine($"- Retirou com sucesso R$ {n} da conta");
            return saldo.ToString();
        }
        public string RetornarInfoCliente()
        {
            return $"{cliente.ToString()}";
        }
        public string RetornarNumConta()
        {
            return numero;
        }
        public bool EncerrarConta()
        {
            if (saldo != 0)
            {
                Console.WriteLine($"- ERRO: Conta possui saldo diferente de zero");
                return false;
            }
            if (status == false)
            {
                Console.WriteLine($"- ERRO: Conta não está ativa");
                return false;
            }
            status = false;
            return true;
        }
        public string RetornarCpf()
        {
            return $"{cliente.RetornarCpf()}";
        }
        public override string ToString()
        {
            return $"- Numero:...  {numero}\n" +
                cliente.ToString() +
                $"\n- Saldo:....  R$ {saldo:N}\n" +
                $"- Abertura:.  {dataAbertura}";
        }
    }
    class Corretora
    {
        public List<Conta> corretora = new List<Conta>();
        int contador = 0;
        string contaAtiva = "";
        public int ExibirMenu()
        {
            // ==========
            string stringOpc;
            int intOpc;

            do
            {
                Console.WriteLine("<ENTER> - continuar");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("================= MENU =================");
                Console.WriteLine("= 1 - Cadastrar conta                  =");
                Console.WriteLine("= 2 - Listar contas ativas             =");
                Console.WriteLine("= 3 - Listar contas inativas           =");
                if (contaAtiva.Equals(""))
                    Console.WriteLine("= 4 - Selecionar conta para operação   =");
                else
                {
                    Console.WriteLine("=                                      =");
                    Console.WriteLine($"= Conta selecionada: {contaAtiva}                 =");
                    Console.WriteLine("=                                      =");
                    Console.WriteLine("= 4 - Verificar dados da conta         =");
                    Console.WriteLine("= 5 - Realizar saque                   =");
                    Console.WriteLine("= 6 - Realizar depósito                =");
                    Console.WriteLine("= 7 - Encerrar conta                   =");
                    Console.WriteLine("= 8 - Sair da conta                    =");
                }
                Console.WriteLine("=                                      =");
                Console.WriteLine("= 0 - Sair                             =");
                Console.WriteLine("========================================");

                stringOpc = Console.ReadLine();
            } while (int.TryParse(stringOpc, out intOpc) == false);
                return intOpc;
        }
        public void GerirCorretora()
        {
            bool running = true;
            do
            {
                int opc;
                opc = ExibirMenu();
                switch (opc)
                {
                    case 1:
                        bool sucesso = CadastrarConta();
                        if (sucesso) Console.WriteLine("- Conta cadastrada com sucesso");
                        else Console.WriteLine("- Não foi possível cadastrar a conta");
                        break;
                    case 2:
                        ListarContasAtivas();
                        break;
                    case 3:
                        ListarContasInativas();
                        break;
                    case 4: // Escolher conta / verificar ja tenha escolhido
                        if (contaAtiva.Equals(""))
                        {
                            contaAtiva = SelecionarConta();
                        }
                        else
                        {
                            VerificarConta();
                        }
                        break;
                    case 5: // Saque caso tenha escolhido conta
                        if (!contaAtiva.Equals(""))
                        {
                            RealizarSaque();
                        }
                        break;
                    case 6: // Deposito caso tenha escolhido conta
                        if (!contaAtiva.Equals(""))
                        {
                            RealizarDeposito();
                        }
                        break;
                    case 7: // Encerrar conta caso tenha escolhido conta
                        if (!contaAtiva.Equals(""))
                        {
                            Console.WriteLine("- Tem certeza que deseja encerrar a conta? (s/n)");
                            string encerrarOpc;
                            do
                            {
                                encerrarOpc = Console.ReadLine();
                            } while (!encerrarOpc.Equals("s") && !encerrarOpc.Equals("n"));
                            if (encerrarOpc.Equals("s"))
                            {
                                if (corretora[int.Parse(contaAtiva)].EncerrarConta())
                                {
                                    Console.WriteLine("- Conta encerrada com sucesso");
                                    contaAtiva = "";
                                }
                                else
                                    Console.WriteLine("- Não foi possível encerrar a conta");
                            }
                            else
                                break;
                        }
                        break;
                    case 8: // Sair da conta caso tenha escolhido conta
                        if (!contaAtiva.Equals(""))
                        {
                            contaAtiva = "";
                        }
                        break;
                    case 0:
                        running = false;
                        break;
                }
            } while (running == true);
        }
        public bool CadastrarConta()
        {
            string nome, cpf, telefone, email;
            Console.Write("- Nome: ");
            nome = Console.ReadLine();
            Console.Write("- CPF: ");
            cpf = Console.ReadLine();

            foreach (Conta c in corretora)
            {
                if (cpf == c.RetornarCpf())
                {
                    Console.WriteLine("- ERRO: CPF já cadastrado");
                    return false;
                }
            }

            Console.Write("- Telefone: ");
            telefone = Console.ReadLine();
            Console.Write("- E-Mail: ");
            email = Console.ReadLine();
            Cliente cliente = new Cliente(nome, cpf, telefone, email);
            Conta conta = new Conta(cliente, contador.ToString());
            corretora.Add(conta);
            contador++;
            return true;
        }
        public void ListarContasAtivas()
        {
            foreach (Conta conta in corretora)
            {
                if (conta.RetornarStatus() == true)
                {
                    Console.WriteLine($"- Numero:....{conta.RetornarNumConta()}");
                    Console.WriteLine($"{conta.RetornarInfoCliente()}\n");
                }
            }
        }
        public void ListarContasInativas()
        {
            foreach (Conta conta in corretora)
            {
                if (conta.RetornarStatus() == false)
                {
                    Console.WriteLine($"- Numero:....{conta.RetornarNumConta()}");
                    Console.WriteLine($"{conta.RetornarInfoCliente()}\n");
                }
            }
        }
        public void RealizarSaque()
        {
            string stringQuantia;
            float floatQuantia;
            Console.Write("- Quantia a sacar: ");
            do
            {
                stringQuantia = Console.ReadLine();
            } while (float.TryParse(stringQuantia, out floatQuantia) == false);
            Console.WriteLine($"- Saldo: R$ {corretora[int.Parse(contaAtiva)].Sacar(floatQuantia)}");
        }
        public void RealizarDeposito()
        {
            string stringQuantia;
            float floatQuantia;
            Console.Write("- Quantia a depositar: ");
            do
            {
                stringQuantia = Console.ReadLine();
            } while (float.TryParse(stringQuantia, out floatQuantia) == false);
            Console.WriteLine($"- Saldo: R$ {corretora[int.Parse(contaAtiva)].Depositar(floatQuantia)}");
        }
        public void VerificarConta()
        {
            Console.WriteLine(corretora[int.Parse(contaAtiva)].ToString());
        }
        public string SelecionarConta()
        {
            if (contador == 0)
            {
                Console.WriteLine("- ERRO: Não existem contas cadastradas");
                return "";
            }
            string stringOpc;
            while (true)
            {
                Console.WriteLine("- Digite 'v' para listar todas as contas ativas ou 'x' para sair");
                Console.Write("- Digite o numero da conta: ");
                stringOpc = Console.ReadLine();
                Console.WriteLine();

                if (stringOpc.Equals("v")) ListarContasAtivas();
                else if (stringOpc.Equals("x")) return contaAtiva;
                else
                {
                    foreach (Conta c in corretora)
                    {
                        if (stringOpc.Equals(c.RetornarNumConta()))
                        {
                            if (c.RetornarStatus()) return stringOpc;
                            else
                            {
                                Console.WriteLine("- ERRO: A conta está desativada");
                                return contaAtiva;
                            }
                        }
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Corretora corretora = new Corretora();
            corretora.GerirCorretora();
        }
    }
}
