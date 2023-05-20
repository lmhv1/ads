using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LP2A4_Proj1.Utils;

namespace LP2A4_Proj1.Model
{
    class Funcionario
    {
        public string _nome;
        public string _sexo;
        public DateTime _dtnasc;
        public string _cpf;
        public string _email;
        public string _telefone;
        public string _cargo;

        public Funcionario(string nome, string sexo, DateTime dtnasc, string cpf, string email, string telefone, string cargo)
        {
            Nome = nome;
            Sexo = sexo;
            Dtnasc = dtnasc;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            Cargo = cargo;
        }

        public string Nome
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("ERRO: O campo Nome é obrigatório.");
                if (value.Length > 100)
                    throw new Exception("ERRO: O nome é muito longo.");
                _nome = value;
            }
            get
            {
                return _nome;
            }
        }
        public string Sexo
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("ERRO: O campo Sexo é obrigatório.");
                _sexo = value;
            }
            get
            {
                return _sexo;
            }
        }
        public DateTime Dtnasc
        {
            set
            {
                if (String.IsNullOrEmpty(value.ToString()))
                    throw new Exception("ERRO: O campo Data de nascimento é obrigatório.");
                if (value.ToString().Length < 8)
                    throw new Exception("ERRO: Data de nascimento inválida.");
                _dtnasc = value;
            }
            get
            {
                return _dtnasc;
            }
        }
        public string Cpf
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("ERRO: O campo CPF é obrigatório.");
                if (value.Length < 11)
                    throw new Exception("ERRO: CPF inválido.");
                if (!ValidaCPF.TestarCPF(value))
                    throw new Exception("ERRO: CPF inválido.");
                _cpf = value;
            }
            get
            {
                return _cpf;
            }
        }
        public string Email
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("ERRO: O campo E-Mail é obrigatório.");
                if (value.Length > 70)
                    throw new Exception("ERRO: O e-mail é muito longo.");
                if (!value.Contains("@"))
                    throw new Exception("ERRO: E-Mail inválido.");
                _email = value;
            }
            get
            {
                return _email;
            }
        }
        public string Telefone
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("ERRO: O campo Telefone é obrigatório.");
                if (value.Length < 11)
                    throw new Exception("ERRO: Telefone inválido.");
                _telefone = value;
            }
            get
            {
                return _telefone;
            }
        }
        public string Cargo
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("ERRO: O campo Cargo é obrigatório.");
                _cargo = value;
            }
            get
            {
                return _cargo;
            }
        }
    }
}
