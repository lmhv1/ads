using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LP2A4_Proj1.Model
{
    class FuncionarioDAO
    {
        public void Inserir(Funcionario funcionario)
        {
            SqlConnection con = new SqlConnection(@"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=LP2A4_Proj1DB;Integrated Security=true");
            con.Open();

            SqlCommand cmd = new("SELECT Id FROM Funcionario", con);
            int id = 0;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if ((int)rd["Id"] > id)
                    id = (int)rd["Id"];
            }
            rd.Close();

            cmd = new("INSERT INTO Funcionario (Nome, Sexo, Data_de_nascimento, CPF, Email, Telefone, Cargo, Id) " +
                      "VALUES (@nome, @sexo, @dtnasc, @cpf, @email, @telefone, @cargo, @id)", con);
            
            cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
            cmd.Parameters.AddWithValue("@sexo", funcionario.Sexo);
            cmd.Parameters.AddWithValue("@dtnasc", funcionario.Dtnasc);
            cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
            cmd.Parameters.AddWithValue("@email", funcionario.Email);
            cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
            cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
            cmd.Parameters.AddWithValue("@id", id + 1);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception err)
            {
                throw new Exception("ERRO: Não foi possível inserir o funcionário no banco de dados.\n" + err.Message);
            }
        }
        public void Atualizar(int id, Funcionario funcionario)
        {
            SqlConnection con = new SqlConnection(@"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=LP2A4_Proj1DB;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE Funcionario
                                                SET Nome =      @nome,
                                                    Sexo =      @sexo,
                                                    Data_de_nascimento = @dtnasc,
                                                    CPF =       @cpf,
                                                    Email =     @email,
                                                    Telefone =  @telefone,
                                                    Cargo =     @cargo
                                                WHERE Id = @id", con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
            cmd.Parameters.AddWithValue("@sexo", funcionario.Sexo);
            cmd.Parameters.AddWithValue("@dtnasc", funcionario.Dtnasc);
            cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
            cmd.Parameters.AddWithValue("@email", funcionario.Email);
            cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
            cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);

            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception err)
            {
                throw new Exception("ERRO: Não foi possível atualizar o funcionário no banco de dados.\n" + err.Message);
            }
        }
    }
}
