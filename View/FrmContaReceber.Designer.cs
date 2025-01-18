namespace SisControl.View
{
    partial class FrmContaReceber
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvContasReceber = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClienteID = new System.Windows.Forms.TextBox();
            this.btnLocalizarCliente = new System.Windows.Forms.Button();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpDataVencimentoInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpDataVencimentoFim = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioBtnPeriodoVencimento = new System.Windows.Forms.RadioButton();
            this.radioBtnDataEmissao = new System.Windows.Forms.RadioButton();
            this.radioBtnStatusConta = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtEmissao = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioBtnAVencer = new System.Windows.Forms.RadioButton();
            this.radioBtnAberto = new System.Windows.Forms.RadioButton();
            this.radioBtnPago = new System.Windows.Forms.RadioButton();
            this.radioBtnVencido = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContasReceber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvContasReceber
            // 
            this.dgvContasReceber.AllowUserToAddRows = false;
            this.dgvContasReceber.AllowUserToDeleteRows = false;
            this.dgvContasReceber.AllowUserToResizeColumns = false;
            this.dgvContasReceber.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgvContasReceber.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvContasReceber.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvContasReceber.BackgroundColor = System.Drawing.Color.White;
            this.dgvContasReceber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvContasReceber.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvContasReceber.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContasReceber.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvContasReceber.ColumnHeadersHeight = 20;
            this.dgvContasReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvContasReceber.EnableHeadersVisualStyles = false;
            this.dgvContasReceber.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvContasReceber.Location = new System.Drawing.Point(12, 267);
            this.dgvContasReceber.MultiSelect = false;
            this.dgvContasReceber.Name = "dgvContasReceber";
            this.dgvContasReceber.ReadOnly = true;
            this.dgvContasReceber.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContasReceber.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvContasReceber.RowHeadersWidth = 20;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvContasReceber.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvContasReceber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContasReceber.Size = new System.Drawing.Size(748, 192);
            this.dgvContasReceber.TabIndex = 563;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFechar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Image = global::SisControl.Properties.Resources.sair;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(630, 488);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(130, 37);
            this.btnFechar.TabIndex = 569;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPagar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnPagar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnPagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Image = global::SisControl.Properties.Resources.pagar;
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(494, 488);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(130, 37);
            this.btnPagar.TabIndex = 570;
            this.btnPagar.Text = "&Pagar";
            this.btnPagar.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 575;
            this.label3.Text = "Cód. Cliente";
            // 
            // txtClienteID
            // 
            this.txtClienteID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClienteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteID.Location = new System.Drawing.Point(7, 37);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.ReadOnly = true;
            this.txtClienteID.Size = new System.Drawing.Size(79, 21);
            this.txtClienteID.TabIndex = 574;
            this.txtClienteID.TabStop = false;
            this.txtClienteID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLocalizarCliente
            // 
            this.btnLocalizarCliente.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnLocalizarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnLocalizarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLocalizarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLocalizarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalizarCliente.ForeColor = System.Drawing.Color.Black;
            this.btnLocalizarCliente.Image = global::SisControl.Properties.Resources.Localizar32;
            this.btnLocalizarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalizarCliente.Location = new System.Drawing.Point(613, 30);
            this.btnLocalizarCliente.Name = "btnLocalizarCliente";
            this.btnLocalizarCliente.Size = new System.Drawing.Size(130, 37);
            this.btnLocalizarCliente.TabIndex = 571;
            this.btnLocalizarCliente.TabStop = false;
            this.btnLocalizarCliente.Text = "&Localizar Cliente";
            this.btnLocalizarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocalizarCliente.UseVisualStyleBackColor = false;
            this.btnLocalizarCliente.Click += new System.EventHandler(this.btnLocalizarCliente_Click);
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtNomeCliente.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtNomeCliente.Location = new System.Drawing.Point(92, 37);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(515, 21);
            this.txtNomeCliente.TabIndex = 572;
            this.txtNomeCliente.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(93, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 17);
            this.label14.TabIndex = 573;
            this.label14.Text = "Nome Cliente";
            // 
            // dtpDataVencimentoInicio
            // 
            this.dtpDataVencimentoInicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dtpDataVencimentoInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dtpDataVencimentoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataVencimentoInicio.Location = new System.Drawing.Point(14, 48);
            this.dtpDataVencimentoInicio.Name = "dtpDataVencimentoInicio";
            this.dtpDataVencimentoInicio.Size = new System.Drawing.Size(110, 23);
            this.dtpDataVencimentoInicio.TabIndex = 576;
            // 
            // dtpDataVencimentoFim
            // 
            this.dtpDataVencimentoFim.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dtpDataVencimentoFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dtpDataVencimentoFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataVencimentoFim.Location = new System.Drawing.Point(146, 48);
            this.dtpDataVencimentoFim.Name = "dtpDataVencimentoFim";
            this.dtpDataVencimentoFim.Size = new System.Drawing.Size(110, 23);
            this.dtpDataVencimentoFim.TabIndex = 577;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(158, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 578;
            this.label1.Text = "Dt. Venc. Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(19, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 579;
            this.label2.Text = "Dt. Venc. Inic";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(128, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 580;
            this.label4.Text = "a";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 169);
            this.groupBox1.TabIndex = 581;
            this.groupBox1.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioBtnPeriodoVencimento);
            this.groupBox6.Controls.Add(this.radioBtnDataEmissao);
            this.groupBox6.Controls.Add(this.radioBtnStatusConta);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox6.Location = new System.Drawing.Point(6, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(738, 37);
            this.groupBox6.TabIndex = 586;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Filtrar Por:";
            // 
            // radioBtnPeriodoVencimento
            // 
            this.radioBtnPeriodoVencimento.AutoSize = true;
            this.radioBtnPeriodoVencimento.Location = new System.Drawing.Point(469, 10);
            this.radioBtnPeriodoVencimento.Name = "radioBtnPeriodoVencimento";
            this.radioBtnPeriodoVencimento.Size = new System.Drawing.Size(173, 21);
            this.radioBtnPeriodoVencimento.TabIndex = 590;
            this.radioBtnPeriodoVencimento.TabStop = true;
            this.radioBtnPeriodoVencimento.Text = "Período de Vencimento";
            this.radioBtnPeriodoVencimento.UseVisualStyleBackColor = true;
            // 
            // radioBtnDataEmissao
            // 
            this.radioBtnDataEmissao.AutoSize = true;
            this.radioBtnDataEmissao.Location = new System.Drawing.Point(267, 10);
            this.radioBtnDataEmissao.Name = "radioBtnDataEmissao";
            this.radioBtnDataEmissao.Size = new System.Drawing.Size(133, 21);
            this.radioBtnDataEmissao.TabIndex = 589;
            this.radioBtnDataEmissao.TabStop = true;
            this.radioBtnDataEmissao.Text = "Data de Emissão";
            this.radioBtnDataEmissao.UseVisualStyleBackColor = true;
            // 
            // radioBtnStatusConta
            // 
            this.radioBtnStatusConta.AutoSize = true;
            this.radioBtnStatusConta.Checked = true;
            this.radioBtnStatusConta.Location = new System.Drawing.Point(90, 10);
            this.radioBtnStatusConta.Name = "radioBtnStatusConta";
            this.radioBtnStatusConta.Size = new System.Drawing.Size(127, 21);
            this.radioBtnStatusConta.TabIndex = 588;
            this.radioBtnStatusConta.TabStop = true;
            this.radioBtnStatusConta.Text = "Status da Conta";
            this.radioBtnStatusConta.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtEmissao);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox5.Location = new System.Drawing.Point(273, 74);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(196, 81);
            this.groupBox5.TabIndex = 585;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Data de Emissão:";
            // 
            // dtEmissao
            // 
            this.dtEmissao.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dtEmissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dtEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEmissao.Location = new System.Drawing.Point(43, 45);
            this.dtEmissao.Name = "dtEmissao";
            this.dtEmissao.Size = new System.Drawing.Size(110, 23);
            this.dtEmissao.TabIndex = 581;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.Location = new System.Drawing.Point(42, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 17);
            this.label6.TabIndex = 582;
            this.label6.Text = "Data de Emissão:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioBtnAVencer);
            this.groupBox4.Controls.Add(this.radioBtnAberto);
            this.groupBox4.Controls.Add(this.radioBtnPago);
            this.groupBox4.Controls.Add(this.radioBtnVencido);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox4.Location = new System.Drawing.Point(9, 74);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(258, 81);
            this.groupBox4.TabIndex = 584;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status da Conta:";
            // 
            // radioBtnAVencer
            // 
            this.radioBtnAVencer.AutoSize = true;
            this.radioBtnAVencer.ForeColor = System.Drawing.Color.Gray;
            this.radioBtnAVencer.Location = new System.Drawing.Point(183, 37);
            this.radioBtnAVencer.Name = "radioBtnAVencer";
            this.radioBtnAVencer.Size = new System.Drawing.Size(69, 17);
            this.radioBtnAVencer.TabIndex = 587;
            this.radioBtnAVencer.TabStop = true;
            this.radioBtnAVencer.Text = "A Vencer";
            this.radioBtnAVencer.UseVisualStyleBackColor = true;
            // 
            // radioBtnAberto
            // 
            this.radioBtnAberto.AutoSize = true;
            this.radioBtnAberto.Checked = true;
            this.radioBtnAberto.ForeColor = System.Drawing.Color.Green;
            this.radioBtnAberto.Location = new System.Drawing.Point(6, 37);
            this.radioBtnAberto.Name = "radioBtnAberto";
            this.radioBtnAberto.Size = new System.Drawing.Size(56, 17);
            this.radioBtnAberto.TabIndex = 584;
            this.radioBtnAberto.TabStop = true;
            this.radioBtnAberto.Text = "Aberto";
            this.radioBtnAberto.UseVisualStyleBackColor = true;
            // 
            // radioBtnPago
            // 
            this.radioBtnPago.AutoSize = true;
            this.radioBtnPago.ForeColor = System.Drawing.Color.Blue;
            this.radioBtnPago.Location = new System.Drawing.Point(63, 37);
            this.radioBtnPago.Name = "radioBtnPago";
            this.radioBtnPago.Size = new System.Drawing.Size(50, 17);
            this.radioBtnPago.TabIndex = 585;
            this.radioBtnPago.TabStop = true;
            this.radioBtnPago.Text = "Pago";
            this.radioBtnPago.UseVisualStyleBackColor = true;
            // 
            // radioBtnVencido
            // 
            this.radioBtnVencido.AutoSize = true;
            this.radioBtnVencido.ForeColor = System.Drawing.Color.Red;
            this.radioBtnVencido.Location = new System.Drawing.Point(116, 37);
            this.radioBtnVencido.Name = "radioBtnVencido";
            this.radioBtnVencido.Size = new System.Drawing.Size(64, 17);
            this.radioBtnVencido.TabIndex = 586;
            this.radioBtnVencido.TabStop = true;
            this.radioBtnVencido.Text = "Vencido";
            this.radioBtnVencido.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpDataVencimentoFim);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpDataVencimentoInicio);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(475, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 81);
            this.groupBox3.TabIndex = 583;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Período de Vencimento:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.txtNomeCliente);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnLocalizarCliente);
            this.groupBox2.Controls.Add(this.txtClienteID);
            this.groupBox2.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox2.Location = new System.Drawing.Point(12, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(748, 78);
            this.groupBox2.TabIndex = 582;
            this.groupBox2.TabStop = false;
            // 
            // FrmContaReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(781, 537);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvContasReceber);
            this.Name = "FrmContaReceber";
            this.Text = "Manutenção de Conta a Receber";
            this.Load += new System.EventHandler(this.FrmContaReceber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContasReceber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContasReceber;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtClienteID;
        private System.Windows.Forms.Button btnLocalizarCliente;
        public System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpDataVencimentoInicio;
        private System.Windows.Forms.DateTimePicker dtpDataVencimentoFim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioBtnAVencer;
        private System.Windows.Forms.RadioButton radioBtnAberto;
        private System.Windows.Forms.RadioButton radioBtnPago;
        private System.Windows.Forms.RadioButton radioBtnVencido;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dtEmissao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioBtnPeriodoVencimento;
        private System.Windows.Forms.RadioButton radioBtnDataEmissao;
        private System.Windows.Forms.RadioButton radioBtnStatusConta;
    }
}
