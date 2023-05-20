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
    public partial class FrmRemover : Form
    {
        public FrmRemover()
        {
            InitializeComponent();
            btnCarregarTabela_Click(null, null);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=LP2A4_Proj1DB;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE Funcionario WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", txbId.Text);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO: Não foi possível remover o funcionário do banco de dados.\n" + err.Message);
            }
            txbId.Clear();
            btnCarregarTabela_Click(null, null);
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
