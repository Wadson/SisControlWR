namespace SisControl.View
{
    partial class FrmGerarParcelas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGerarParcelas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDias = new System.Windows.Forms.NumericUpDown();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdVenda = new System.Windows.Forms.TextBox();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQtdParcelas = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid_Parcelas = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dtPrimeiraParc = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.txtDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtdParcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Parcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F);
            this.label2.Location = new System.Drawing.Point(7, 214);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 18);
            this.label2.TabIndex = 572;
            this.label2.Text = "Intervalo Entre Parcelas";
            // 
            // txtDias
            // 
            this.txtDias.BackColor = System.Drawing.Color.Aquamarine;
            this.txtDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F);
            this.txtDias.Location = new System.Drawing.Point(7, 232);
            this.txtDias.Margin = new System.Windows.Forms.Padding(4);
            this.txtDias.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.txtDias.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(185, 36);
            this.txtDias.TabIndex = 571;
            this.txtDias.TabStop = false;
            this.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDias.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtDias.ValueChanged += new System.EventHandler(this.txtDias_ValueChanged);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnFinalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnFinalizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFinalizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalizar.Image")));
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizar.Location = new System.Drawing.Point(462, 342);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(130, 37);
            this.btnFinalizar.TabIndex = 570;
            this.btnFinalizar.Text = "&Salvar";
            this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(7, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 17);
            this.label9.TabIndex = 568;
            this.label9.Text = "Código Venda:";
            // 
            // txtIdVenda
            // 
            this.txtIdVenda.BackColor = System.Drawing.Color.Aquamarine;
            this.txtIdVenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdVenda.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtIdVenda.Location = new System.Drawing.Point(10, 28);
            this.txtIdVenda.Name = "txtIdVenda";
            this.txtIdVenda.ReadOnly = true;
            this.txtIdVenda.Size = new System.Drawing.Size(98, 24);
            this.txtIdVenda.TabIndex = 567;
            this.txtIdVenda.TabStop = false;
            this.txtIdVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.BackColor = System.Drawing.Color.Aquamarine;
            this.txtNomeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeCliente.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtNomeCliente.Location = new System.Drawing.Point(115, 28);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.ReadOnly = true;
            this.txtNomeCliente.Size = new System.Drawing.Size(473, 24);
            this.txtNomeCliente.TabIndex = 565;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(114, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 17);
            this.label14.TabIndex = 566;
            this.label14.Text = "Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F);
            this.label4.Location = new System.Drawing.Point(10, 281);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 18);
            this.label4.TabIndex = 564;
            this.label4.Text = "Nº Parcela                          ";
            // 
            // txtQtdParcelas
            // 
            this.txtQtdParcelas.BackColor = System.Drawing.Color.Aquamarine;
            this.txtQtdParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F);
            this.txtQtdParcelas.Location = new System.Drawing.Point(10, 299);
            this.txtQtdParcelas.Margin = new System.Windows.Forms.Padding(4);
            this.txtQtdParcelas.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.txtQtdParcelas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQtdParcelas.Name = "txtQtdParcelas";
            this.txtQtdParcelas.Size = new System.Drawing.Size(185, 36);
            this.txtQtdParcelas.TabIndex = 561;
            this.txtQtdParcelas.TabStop = false;
            this.txtQtdParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQtdParcelas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQtdParcelas.ValueChanged += new System.EventHandler(this.txtQtdParcelas_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F);
            this.label1.Location = new System.Drawing.Point(11, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 18);
            this.label1.TabIndex = 563;
            this.label1.Text = "Valor Total                          ";
            // 
            // dataGrid_Parcelas
            // 
            this.dataGrid_Parcelas.AllowUserToAddRows = false;
            this.dataGrid_Parcelas.AllowUserToDeleteRows = false;
            this.dataGrid_Parcelas.AllowUserToResizeColumns = false;
            this.dataGrid_Parcelas.AllowUserToResizeRows = false;
            this.dataGrid_Parcelas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid_Parcelas.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid_Parcelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGrid_Parcelas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGrid_Parcelas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_Parcelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid_Parcelas.ColumnHeadersHeight = 20;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid_Parcelas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid_Parcelas.EnableHeadersVisualStyles = false;
            this.dataGrid_Parcelas.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGrid_Parcelas.Location = new System.Drawing.Point(203, 75);
            this.dataGrid_Parcelas.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid_Parcelas.Name = "dataGrid_Parcelas";
            this.dataGrid_Parcelas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_Parcelas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrid_Parcelas.RowHeadersWidth = 20;
            this.dataGrid_Parcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid_Parcelas.Size = new System.Drawing.Size(389, 260);
            this.dataGrid_Parcelas.TabIndex = 562;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(10, 139);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(182, 16);
            this.label16.TabIndex = 560;
            this.label16.Text = "Data 1º Parcela                           ";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.Aquamarine;
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F);
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTotal.Location = new System.Drawing.Point(10, 92);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(185, 36);
            this.txtTotal.TabIndex = 558;
            this.txtTotal.TabStop = false;
            this.txtTotal.Text = "0,00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtPrimeiraParc
            // 
            this.dtPrimeiraParc.CalendarForeColor = System.Drawing.Color.Blue;
            this.dtPrimeiraParc.CalendarTitleForeColor = System.Drawing.Color.AliceBlue;
            this.dtPrimeiraParc.CustomFormat = "dd/MM/yyyy";
            this.dtPrimeiraParc.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtPrimeiraParc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F);
            this.dtPrimeiraParc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPrimeiraParc.Location = new System.Drawing.Point(10, 157);
            this.dtPrimeiraParc.Margin = new System.Windows.Forms.Padding(4);
            this.dtPrimeiraParc.Name = "dtPrimeiraParc";
            this.dtPrimeiraParc.Size = new System.Drawing.Size(185, 36);
            this.dtPrimeiraParc.TabIndex = 559;
            this.dtPrimeiraParc.ValueChanged += new System.EventHandler(this.dtPrimeiraParc_ValueChanged);
            // 
            // FrmGerarParcelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(600, 415);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDias);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtIdVenda);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQtdParcelas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid_Parcelas);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dtPrimeiraParc);
            this.MaximizeBox = false;
            this.Name = "FrmGerarParcelas";
            this.Text = "Formulário - Parcelas";
            this.Load += new System.EventHandler(this.FrmGerarParcelas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtdParcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Parcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown txtDias;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtIdVenda;
        public System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown txtQtdParcelas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGrid_Parcelas;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.DateTimePicker dtPrimeiraParc;
    }
}
