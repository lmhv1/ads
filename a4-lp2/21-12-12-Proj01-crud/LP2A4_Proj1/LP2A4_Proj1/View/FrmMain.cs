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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public void CarregarForm(object Form)
        {
            if (this.panelMain.Controls.Count > 0)
                this.panelMain.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(f);
            this.panelMain.Tag = f;
            f.Show();
        }

        private void btnFormCadastrar_Click(object sender, EventArgs e)
        {
            CarregarForm(new FrmCadastrar());
        }

        private void btnFormPesquisar_Click(object sender, EventArgs e)
        {
            CarregarForm(new FrmPesquisar());
        }

        private void btnFormAtualizar_Click(object sender, EventArgs e)
        {
            CarregarForm(new FrmAtualizar());
        }

        private void btnFormRemover_Click(object sender, EventArgs e)
        {
            CarregarForm(new FrmRemover());
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
