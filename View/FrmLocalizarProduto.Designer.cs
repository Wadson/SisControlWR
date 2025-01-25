namespace SisControl.View
{
    partial class FrmLocalizarProduto
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridPesquisar = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPesquisar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnSair.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.btnSair.Location = new System.Drawing.Point(449, 331);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(199, 50);
            this.txtPesquisa.Size = new System.Drawing.Size(368, 20);
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            // 
            // dataGridPesquisar
            // 
            this.dataGridPesquisar.AllowUserToAddRows = false;
            this.dataGridPesquisar.AllowUserToDeleteRows = false;
            this.dataGridPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPesquisar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPesquisar.Location = new System.Drawing.Point(12, 82);
            this.dataGridPesquisar.MultiSelect = false;
            this.dataGridPesquisar.Name = "dataGridPesquisar";
            this.dataGridPesquisar.ReadOnly = true;
            this.dataGridPesquisar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPesquisar.Size = new System.Drawing.Size(555, 239);
            this.dataGridPesquisar.TabIndex = 599;
            this.dataGridPesquisar.SelectionChanged += new System.EventHandler(this.dataGridPesquisar_SelectionChanged);
            this.dataGridPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridPesquisar_KeyDown);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.label28.Location = new System.Drawing.Point(165, 2);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(226, 24);
            this.label28.TabIndex = 600;
            this.label28.Text = "LOCALIZAR PRODUTO...";
            // 
            // FrmLocalizarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(588, 369);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.dataGridPesquisar);
            this.Name = "FrmLocalizarProduto";
            this.Text = "Localizar Produto...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLocalizarProduto_FormClosing);
            this.Load += new System.EventHandler(this.FrmLocalizarProduto_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtPesquisa, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.dataGridPesquisar, 0);
            this.Controls.SetChildIndex(this.label28, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPesquisar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridPesquisar;
        private System.Windows.Forms.Label label28;
    }
}
