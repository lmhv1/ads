using System;

namespace LP2A4_Ativ04
{
    class Program
    {
        static int numerosIguais(string strCPF)
        {
            int primeiroNumero = int.Parse(strCPF[0].ToString());
            int iguais = 0;
            int i;
            // ---------------------------------------- Checa a cada iteração se o numero no indice é igual ao primeiro
            for (i = 1; i < strCPF.Length; i++)
            {
                if (int.Parse(strCPF[i].ToString()) == primeiroNumero) iguais++;
            }
            return iguais;
        }
        static bool testeCPF(string strCPF)
        {
            int i;
            int multiplicador;

            // ---------------------------------------- Remove "." e "-"
            strCPF = strCPF.Replace(".", "").Replace("-", "");
            if (strCPF.Length != 11) return false;

            // ---------------------------------------- Verifica se todos os numeros são iguais (ex 000.000.000-00)
            if (numerosIguais(strCPF) == 10) return false;

            // ---------------------------------------- Obtem o resto1
            int soma1 = 0;
            int resto1;
            multiplicador = 10;
            for (i = 0; i < 9; i++)
            {
                soma1 += int.Parse(strCPF[i].ToString()) * multiplicador;
                multiplicador--;
            }
            resto1 = (soma1 * 10) % 11;
            if (resto1 == 10) resto1 = 0;

            // ---------------------------------------- Obtem o resto2
            int soma2 = 0;
            int resto2;
            multiplicador = 11;
            for (i = 0; i < 10; i++)
            {
                soma2 += int.Parse(strCPF[i].ToString()) * multiplicador;
                multiplicador--;
            }
            resto2 = (soma2 * 10) % 11;
            if (resto2 == 10) resto2 = 0;

            // ---------------------------------------- Verificação final
            int digito1 = int.Parse(strCPF[9].ToString());
            int digito2 = int.Parse(strCPF[10].ToString());
            if (resto1 == digito1 && resto2 == digito2) return true;
            return false;
        }
        static void Main(string[] args)
        {
            string entrada;
            bool running = true;
            do
            {
                Console.Clear();
                Console.WriteLine("- Digite '0' para sair.");
                Console.Write("- Digite o CPF: ");
                entrada = Console.ReadLine();
                switch (entrada)
                {
                    case "0":
                        running = false;
                        break;
                    default:
                        if (testeCPF(entrada)) Console.WriteLine("- CPF válido.");
                        else Console.WriteLine("- CPF inválido.");
                        Console.WriteLine("- Pressione <ENTER> para continuar.");
                        Console.ReadLine();
                        break;
                }
            } while (running);
        }
    }
}
