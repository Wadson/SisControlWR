namespace SisControl.View
{
    partial class FrmCadFabricante
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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFabricanteID = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEstado = new SisControl.TexBoxPersonalizado();
            this.txtCidade = new SisControl.TexBoxPersonalizado();
            this.txtBairro = new SisControl.TexBoxPersonalizado();
            this.txtNumero = new SisControl.TexBoxPersonalizado();
            this.txtEndereco = new SisControl.TexBoxPersonalizado();
            this.txtNomeFabricante = new SisControl.TexBoxPersonalizado();
            this.txtTelefone = new SisControl.PhoneFormat();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.Location = new System.Drawing.Point(324, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 196;
            this.label8.Text = "Estado:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.Location = new System.Drawing.Point(324, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 195;
            this.label7.Text = "Número";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(17, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 194;
            this.label4.Text = "Cidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(402, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 193;
            this.label1.Text = "Bairro/Setor";
            // 
            // txtFabricanteID
            // 
            this.txtFabricanteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFabricanteID.Location = new System.Drawing.Point(16, 38);
            this.txtFabricanteID.Name = "txtFabricanteID";
            this.txtFabricanteID.ReadOnly = true;
            this.txtFabricanteID.Size = new System.Drawing.Size(99, 21);
            this.txtFabricanteID.TabIndex = 178;
            this.txtFabricanteID.TabStop = false;
            this.txtFabricanteID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFechar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Image = global::SisControl.Properties.Resources.sair;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(404, 207);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 35);
            this.btnFechar.TabIndex = 10;
            this.btnFechar.Text = "&Sair";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.Image = global::SisControl.Properties.Resources.Novo;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(291, 207);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 35);
            this.btnNovo.TabIndex = 9;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Image = global::SisControl.Properties.Resources.salve_;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(178, 207);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 35);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "     &Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.Location = new System.Drawing.Point(513, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 192;
            this.label6.Text = "Telefone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(16, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 191;
            this.label5.Text = "Endereço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(19, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 190;
            this.label3.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(119, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 189;
            this.label2.Text = "Nome Fabricante:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(310, 143);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(217, 27);
            this.txtEstado.TabIndex = 6;
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(16, 143);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(299, 27);
            this.txtCidade.TabIndex = 5;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(398, 95);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(254, 27);
            this.txtBairro.TabIndex = 4;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(310, 95);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(88, 27);
            this.txtNumero.TabIndex = 3;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(14, 95);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(304, 27);
            this.txtEndereco.TabIndex = 2;
            // 
            // txtNomeFabricante
            // 
            this.txtNomeFabricante.Location = new System.Drawing.Point(122, 36);
            this.txtNomeFabricante.Name = "txtNomeFabricante";
            this.txtNomeFabricante.Size = new System.Drawing.Size(530, 27);
            this.txtNomeFabricante.TabIndex = 1;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(527, 147);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(125, 23);
            this.txtTelefone.TabIndex = 7;
            // 
            // FrmCadFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 280);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtNomeFabricante);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFabricanteID);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.KeyPreview = true;
            this.Name = "FrmCadFabricante";
            this.Text = "FrmCadFabricante";
            this.Load += new System.EventHandler(this.FrmCadFabricante_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCadFabricante_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public TexBoxPersonalizado txtEstado;
        public TexBoxPersonalizado txtCidade;
        public TexBoxPersonalizado txtBairro;
        public TexBoxPersonalizado txtNumero;
        public TexBoxPersonalizado txtEndereco;
        public TexBoxPersonalizado txtNomeFabricante;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtFabricanteID;
        public System.Windows.Forms.Button btnFechar;
        public System.Windows.Forms.Button btnNovo;
        public System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public PhoneFormat txtTelefone;
    }
}