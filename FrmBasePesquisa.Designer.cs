namespace SisControl
{
    partial class FrmBasePesquisa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtDescricao = new System.Windows.Forms.RadioButton();
            this.rbtCodigo = new System.Windows.Forms.RadioButton();
            this.dataGridPesquisa = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnSair.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Century Gothic", 10.25F);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(452, 331);
            this.btnSair.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(117, 25);
            this.btnSair.TabIndex = 421;
            this.btnSair.Text = "&OK";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.txtPesquisa.Location = new System.Drawing.Point(199, 26);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(371, 20);
            this.txtPesquisa.TabIndex = 419;
            this.txtPesquisa.Enter += new System.EventHandler(this.txtPesquisa_Enter);
            this.txtPesquisa.Leave += new System.EventHandler(this.txtPesquisa_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtDescricao);
            this.groupBox1.Controls.Add(this.rbtCodigo);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(180, 42);
            this.groupBox1.TabIndex = 420;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro:";
            // 
            // rbtDescricao
            // 
            this.rbtDescricao.AutoSize = true;
            this.rbtDescricao.Checked = true;
            this.rbtDescricao.Location = new System.Drawing.Point(72, 15);
            this.rbtDescricao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtDescricao.Name = "rbtDescricao";
            this.rbtDescricao.Size = new System.Drawing.Size(73, 17);
            this.rbtDescricao.TabIndex = 5;
            this.rbtDescricao.TabStop = true;
            this.rbtDescricao.Text = "Descrição";
            this.rbtDescricao.UseVisualStyleBackColor = true;
            this.rbtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbtDescricao_KeyDown);
            // 
            // rbtCodigo
            // 
            this.rbtCodigo.AutoSize = true;
            this.rbtCodigo.Location = new System.Drawing.Point(6, 15);
            this.rbtCodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtCodigo.Name = "rbtCodigo";
            this.rbtCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtCodigo.TabIndex = 4;
            this.rbtCodigo.Text = "Código";
            this.rbtCodigo.UseVisualStyleBackColor = true;
            this.rbtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbtCodigo_KeyDown);
            // 
            // dataGridPesquisa
            // 
            this.dataGridPesquisa.AllowUserToAddRows = false;
            this.dataGridPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPesquisa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridPesquisa.BackgroundColor = System.Drawing.Color.White;
            this.dataGridPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridPesquisa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridPesquisa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPesquisa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridPesquisa.ColumnHeadersHeight = 20;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridPesquisa.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridPesquisa.EnableHeadersVisualStyles = false;
            this.dataGridPesquisa.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridPesquisa.Location = new System.Drawing.Point(12, 59);
            this.dataGridPesquisa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridPesquisa.Name = "dataGridPesquisa";
            this.dataGridPesquisa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPesquisa.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridPesquisa.RowHeadersWidth = 20;
            this.dataGridPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPesquisa.Size = new System.Drawing.Size(558, 264);
            this.dataGridPesquisa.TabIndex = 449;
            // 
            // FrmBasePesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(591, 369);
            this.Controls.Add(this.dataGridPesquisa);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmBasePesquisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBasePesquisa";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBasePesquisa_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnSair;
        public System.Windows.Forms.TextBox txtPesquisa;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rbtDescricao;
        public System.Windows.Forms.RadioButton rbtCodigo;
        private System.Windows.Forms.DataGridView dataGridPesquisa;
    }
}