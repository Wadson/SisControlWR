﻿namespace SisControl.View
{
    partial class FrmLocalizarFornedeor
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
            this.dataGridPesquisar = new System.Windows.Forms.DataGridView();
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
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // dataGridPesquisar
            // 
            this.dataGridPesquisar.AllowUserToAddRows = false;
            this.dataGridPesquisar.AllowUserToDeleteRows = false;
            this.dataGridPesquisar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPesquisar.Location = new System.Drawing.Point(17, 52);
            this.dataGridPesquisar.Name = "dataGridPesquisar";
            this.dataGridPesquisar.ReadOnly = true;
            this.dataGridPesquisar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPesquisar.Size = new System.Drawing.Size(557, 264);
            this.dataGridPesquisar.TabIndex = 452;
            this.dataGridPesquisar.SelectionChanged += new System.EventHandler(this.dataGridPesquisar_SelectionChanged);
            this.dataGridPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridPesquisar_KeyDown);
            // 
            // FrmLocalizarFornedeor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(591, 369);
            this.Controls.Add(this.dataGridPesquisar);
            this.Name = "FrmLocalizarFornedeor";
            this.Text = "Localizar Fornecedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLocalizarFornedeor_FormClosing);
            this.Load += new System.EventHandler(this.FrmLocalizarFornedeor_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtPesquisa, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.dataGridPesquisar, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPesquisar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPesquisar;
    }
}
