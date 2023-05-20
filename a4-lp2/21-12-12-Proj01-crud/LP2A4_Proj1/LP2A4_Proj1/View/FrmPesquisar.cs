using LP2A4_Proj1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LP2A4_Proj1.View
{
    public partial class FrmPesquisar : Form
    {

        public FrmPesquisar()
        {
            InitializeComponent();
            btnCarregarTabela_Click(null, null);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txbNome.Text;
            string sexo = cbxSexo.Text;
            string dtnasc = mtbDtNasc.Text;
            DateTime dtConvertida = DateTime.ParseExact("31129999", "ddMMyyyy", null);
            try
            {
                if (cbxPesqPor.SelectedIndex == 2)
                    dtConvertida = DateTime.ParseExact(dtnasc, "ddMMyyyy", null);
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO: Data de nascimento inválida.");
                return;
            }
            string cpf = mtbCpf.Text;
            string email = txbEmail.Text;
            string telefone = mtbTelefone.Text;
            string cargo = cbxCargo.Text;
            SqlConnection con = new SqlConnection(@"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=LP2A4_Proj1DB;Integrated Security=true");
            con.Open();
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;
            switch (cbxPesqPor.SelectedIndex)
            {
                case 0: // Nome
                    cmd = new("SELECT * FROM Funcionario WHERE [Nome] = @valor", con);
                    cmd.Parameters.AddWithValue("@valor", nome);

                    break;
                case 1: // Sexo
                    cmd = new("SELECT * FROM Funcionario WHERE [Sexo] = @valor", con);
                    cmd.Parameters.AddWithValue("@valor", sexo);

                    break;
                case 2: // Dtnasc
                    cmd = new("SELECT * FROM Funcionario WHERE [Data_de_nascimento] = @valor", con);
                    cmd.Parameters.AddWithValue("@valor", dtConvertida);

                    break;
                case 3: // CPF
                    cmd = new("SELECT * FROM Funcionario WHERE [CPF] = @valor", con);
                    cmd.Parameters.AddWithValue("@valor", cpf);

                    break;
                case 4: // Email
                    cmd = new("SELECT * FROM Funcionario WHERE [Email] = @valor", con);
                    cmd.Parameters.AddWithValue("@valor", email);

                    break;
                case 5: // Telefone
                    cmd = new("SELECT * FROM Funcionario WHERE [Telefone] = @valor", con);
                    cmd.Parameters.AddWithValue("@valor", telefone);

                    break;
                case 6: // Cargo
                    cmd = new("SELECT * FROM Funcionario WHERE [Cargo] = @valor", con);
                    cmd.Parameters.AddWithValue("@valor", cargo);

                    break;
                default:
                    MessageBox.Show("Selecione pelo menos um item para pesquisar!\n" + cbxPesqPor.SelectedIndex);
                    cmd = new SqlCommand("SELECT * FROM Funcionario", con);
                    break;
            }
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvFuncionario.DataSource = dt;
            con.Close();
        }

        private void btnCarregarTabela_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=LP2A4_Proj1DB;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Funcionario", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvFuncionario.DataSource = dt;
            con.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbNome.Clear();
            cbxSexo.SelectedIndex = -1;
            mtbDtNasc.Clear();
            mtbCpf.Clear();
            txbEmail.Clear();
            mtbTelefone.Clear();
            cbxCargo.SelectedIndex = -1;

            txbNome.Focus();
        }
    }
}
