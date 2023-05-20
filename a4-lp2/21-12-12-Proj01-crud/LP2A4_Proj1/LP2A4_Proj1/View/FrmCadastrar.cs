using LP2A4_Proj1.Utils;
using System;
using System.Windows.Forms;
using LP2A4_Proj1.Model;
using System.Data.SqlClient;
using System.Data;

namespace LP2A4_Proj1
{
    public partial class FrmCadastrar : Form
    {
        public FrmCadastrar()
        {
            InitializeComponent();
            btnCarregarTabela_Click(null, null);
        }
        private void btnCadastrar1_Click(object sender, EventArgs e)
        {
            string nome = txbNome.Text;
            string sexo = cbxSexo.Text;
            string dtnasc = mtbDtNasc.Text;
            DateTime dtConvertida;
            try
            {
                dtConvertida = DateTime.ParseExact(dtnasc, "ddMMyyyy", null);
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO: Data de nascimento inválida.\n" + err.Message);
                return;
            }
            string cpf = mtbCpf.Text;
            string email = txbEmail.Text;
            string telefone = mtbTelefone.Text;
            string cargo = cbxCargo.Text;
            try
            {
                Funcionario funcionario = new(nome, sexo, dtConvertida, cpf, email, telefone, cargo);
                FuncionarioDAO funcionarioDAO = new();
                funcionarioDAO.Inserir(funcionario);
                MessageBox.Show("Funcionário cadastrado");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                cbxCargo.Focus();
                if (err.Message.ToUpper().Contains("TELEFONE"))
                    mtbTelefone.Focus();
                if (err.Message.ToUpper().Contains("E-MAIL"))
                    txbEmail.Focus();
                if (err.Message.ToUpper().Contains("CPF"))
                    mtbCpf.Focus();
                if (err.Message.ToUpper().Contains("DATA DE NASCIMENTO"))
                    mtbDtNasc.Focus();
                if (err.Message.ToUpper().Contains("SEXO"))
                    cbxSexo.Focus();
                if (err.Message.ToUpper().Contains("NOME"))
                    txbNome.Focus();
                return;
            }
            btnLimpar_Click(null, null);
            btnCarregarTabela_Click(null, null);
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

        private void btnCarregarTabela_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=LP2A4_Proj1DB;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Funcionario", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvFuncionario.DataSource = dt;
        }
    }
}