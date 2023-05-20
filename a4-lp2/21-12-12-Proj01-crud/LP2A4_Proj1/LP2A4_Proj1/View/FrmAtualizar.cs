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
    public partial class FrmAtualizar : Form
    {
        public FrmAtualizar()
        {
            InitializeComponent();
            btnCarregarTabela_Click(null, null);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = int.Parse(txbId.Text);
            }
            catch (Exception err)
            {
                //throw new Exception("ERRO: Não foi possível converter o ID para número.\n" + err.Message);
                MessageBox.Show("ERRO: Não foi possível converter o ID para número.\n" + err.Message);
                return;
            }
            string nome =       txbNome.Text;
            string sexo =       cbxSexo.Text;
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
            string email =      txbEmail.Text;
            string telefone =   mtbTelefone.Text;
            string cargo =      cbxCargo.Text;
            try
            {
                Funcionario funcionario = new(nome, sexo, dtConvertida, cpf, email, telefone, cargo);
                FuncionarioDAO funcionarioDAO = new();
                funcionarioDAO.Atualizar(id, funcionario);
                MessageBox.Show("Informações atualizadas.");
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
            txbId.Clear();
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
