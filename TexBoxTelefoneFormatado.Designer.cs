namespace SisControl
{
    partial class TexBoxTelefoneFormatado
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTelefone
            // 
            this.txtTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefone.Location = new System.Drawing.Point(0, 0);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(166, 20);
            this.txtTelefone.TabIndex = 0;
            this.txtTelefone.TextChanged += new System.EventHandler(this.txtTelefone_TextChanged);
            this.txtTelefone.Enter += new System.EventHandler(this.txtTelefone_Enter);
            this.txtTelefone.Leave += new System.EventHandler(this.txtTelefone_Leave);
            // 
            // TexBoxTelefoneFormatado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTelefone);
            this.Name = "TexBoxTelefoneFormatado";
            this.Size = new System.Drawing.Size(169, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTelefone;
    }
}
