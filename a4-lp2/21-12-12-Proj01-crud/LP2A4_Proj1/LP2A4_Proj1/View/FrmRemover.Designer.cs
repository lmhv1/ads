
namespace LP2A4_Proj1.View
{
    partial class FrmRemover
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblId = new System.Windows.Forms.Label();
            this.txbId = new System.Windows.Forms.TextBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnCarregarTabela = new System.Windows.Forms.Button();
            this.dgvFuncionario = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblId.Location = new System.Drawing.Point(12, 12);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(38, 21);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID *";
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(12, 36);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(100, 23);
            this.txbId.TabIndex = 2;
            // 
            // btnRemover
            // 
            this.btnRemover.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemover.Location = new System.Drawing.Point(12, 106);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(100, 50);
            this.btnRemover.TabIndex = 4;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnCarregarTabela
            // 
            this.btnCarregarTabela.Location = new System.Drawing.Point(31, 527);
            this.btnCarregarTabela.Name = "btnCarregarTabela";
            this.btnCarregarTabela.Size = new System.Drawing.Size(100, 23);
            this.btnCarregarTabela.TabIndex = 20;
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
            this.dgvFuncionario.TabIndex = 19;
            // 
            // FrmRemover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnCarregarTabela);
            this.Controls.Add(this.dgvFuncionario);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.lblId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmRemover";
            this.Text = "FrmRemover";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnCarregarTabela;
        private System.Windows.Forms.DataGridView dgvFuncionario;
    }
}