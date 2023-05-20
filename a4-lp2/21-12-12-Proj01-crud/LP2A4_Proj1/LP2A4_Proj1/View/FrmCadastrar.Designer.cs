
namespace LP2A4_Proj1
{
    partial class FrmCadastrar
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNome = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.cbxSexo = new System.Windows.Forms.ComboBox();
            this.lblDtNasc = new System.Windows.Forms.Label();
            this.mtbDtNasc = new System.Windows.Forms.MaskedTextBox();
            this.lblCpf = new System.Windows.Forms.Label();
            this.mtbCpf = new System.Windows.Forms.MaskedTextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.lblFone = new System.Windows.Forms.Label();
            this.mtbTelefone = new System.Windows.Forms.MaskedTextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.cbxCargo = new System.Windows.Forms.ComboBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnCarregarTabela = new System.Windows.Forms.Button();
            this.dgvFuncionario = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNome.Location = new System.Drawing.Point(12, 12);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(68, 21);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome *";
            // 
            // txbNome
            // 
            this.txbNome.Location = new System.Drawing.Point(12, 36);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(388, 23);
            this.txbNome.TabIndex = 1;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSexo.Location = new System.Drawing.Point(406, 12);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(58, 21);
            this.lblSexo.TabIndex = 2;
            this.lblSexo.Text = "Sexo *";
            // 
            // cbxSexo
            // 
            this.cbxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSexo.FormattingEnabled = true;
            this.cbxSexo.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cbxSexo.Location = new System.Drawing.Point(406, 36);
            this.cbxSexo.Name = "cbxSexo";
            this.cbxSexo.Size = new System.Drawing.Size(121, 23);
            this.cbxSexo.TabIndex = 3;
            // 
            // lblDtNasc
            // 
            this.lblDtNasc.AutoSize = true;
            this.lblDtNasc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDtNasc.Location = new System.Drawing.Point(533, 12);
            this.lblDtNasc.Name = "lblDtNasc";
            this.lblDtNasc.Size = new System.Drawing.Size(173, 21);
            this.lblDtNasc.TabIndex = 4;
            this.lblDtNasc.Text = "Data de nascimento *";
            // 
            // mtbDtNasc
            // 
            this.mtbDtNasc.Location = new System.Drawing.Point(533, 36);
            this.mtbDtNasc.Mask = "00/00/0000";
            this.mtbDtNasc.Name = "mtbDtNasc";
            this.mtbDtNasc.Size = new System.Drawing.Size(173, 23);
            this.mtbDtNasc.TabIndex = 5;
            this.mtbDtNasc.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCpf.Location = new System.Drawing.Point(12, 82);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(49, 21);
            this.lblCpf.TabIndex = 6;
            this.lblCpf.Text = "CPF *";
            // 
            // mtbCpf
            // 
            this.mtbCpf.Location = new System.Drawing.Point(12, 106);
            this.mtbCpf.Mask = "000,000,000-00";
            this.mtbCpf.Name = "mtbCpf";
            this.mtbCpf.Size = new System.Drawing.Size(100, 23);
            this.mtbCpf.TabIndex = 7;
            this.mtbCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.Location = new System.Drawing.Point(118, 82);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(70, 21);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "E-Mail *";
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(118, 106);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(282, 23);
            this.txbEmail.TabIndex = 9;
            // 
            // lblFone
            // 
            this.lblFone.AutoSize = true;
            this.lblFone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFone.Location = new System.Drawing.Point(406, 82);
            this.lblFone.Name = "lblFone";
            this.lblFone.Size = new System.Drawing.Size(87, 21);
            this.lblFone.TabIndex = 10;
            this.lblFone.Text = "Telefone *";
            // 
            // mtbTelefone
            // 
            this.mtbTelefone.Location = new System.Drawing.Point(406, 106);
            this.mtbTelefone.Mask = "(00) 00000-0000";
            this.mtbTelefone.Name = "mtbTelefone";
            this.mtbTelefone.Size = new System.Drawing.Size(121, 23);
            this.mtbTelefone.TabIndex = 11;
            this.mtbTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCargo.Location = new System.Drawing.Point(533, 82);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(66, 21);
            this.lblCargo.TabIndex = 12;
            this.lblCargo.Text = "Cargo *";
            // 
            // cbxCargo
            // 
            this.cbxCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCargo.FormattingEnabled = true;
            this.cbxCargo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxCargo.Items.AddRange(new object[] {
            "Diretor",
            "Secretário",
            "Professor"});
            this.cbxCargo.Location = new System.Drawing.Point(533, 106);
            this.cbxCargo.Name = "cbxCargo";
            this.cbxCargo.Size = new System.Drawing.Size(173, 23);
            this.cbxCargo.TabIndex = 13;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.Location = new System.Drawing.Point(12, 162);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(100, 50);
            this.btnCadastrar.TabIndex = 15;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar1_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpar.Location = new System.Drawing.Point(118, 162);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 50);
            this.btnLimpar.TabIndex = 16;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnCarregarTabela
            // 
            this.btnCarregarTabela.Location = new System.Drawing.Point(31, 527);
            this.btnCarregarTabela.Name = "btnCarregarTabela";
            this.btnCarregarTabela.Size = new System.Drawing.Size(100, 23);
            this.btnCarregarTabela.TabIndex = 18;
            this.btnCarregarTabela.Text = "Carregar tabela";
            this.btnCarregarTabela.UseVisualStyleBackColor = true;
            this.btnCarregarTabela.Click += new System.EventHandler(this.btnCarregarTabela_Click);
            // 
            // dgvFuncionario
            // 
            this.dgvFuncionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFuncionario.Location = new System.Drawing.Point(31, 302);
            this.dgvFuncionario.Name = "dgvFuncionario";
            this.dgvFuncionario.RowTemplate.Height = 25;
            this.dgvFuncionario.Size = new System.Drawing.Size(721, 208);
            this.dgvFuncionario.TabIndex = 17;
            // 
            // FrmCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnCarregarTabela);
            this.Controls.Add(this.dgvFuncionario);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.cbxCargo);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.mtbTelefone);
            this.Controls.Add(this.lblFone);
            this.Controls.Add(this.txbEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.mtbCpf);
            this.Controls.Add(this.lblCpf);
            this.Controls.Add(this.mtbDtNasc);
            this.Controls.Add(this.lblDtNasc);
            this.Controls.Add(this.cbxSexo);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.txbNome);
            this.Controls.Add(this.lblNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmCadastrar";
            this.Text = "FrmCadastrar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.ComboBox cbxSexo;
        private System.Windows.Forms.Label lblDtNasc;
        private System.Windows.Forms.MaskedTextBox mtbDtNasc;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.MaskedTextBox mtbCpf;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label lblFone;
        private System.Windows.Forms.MaskedTextBox mtbTelefone;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.ComboBox cbxCargo;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCarregarTabela;
        private System.Windows.Forms.DataGridView dgvFuncionario;
    }
}

