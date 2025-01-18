namespace SisControl.View
{
    partial class FrmVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVendas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnParcelar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtValorRecebido = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbUmaParcela = new System.Windows.Forms.RadioButton();
            this.rbParcelar = new System.Windows.Forms.RadioButton();
            this.txtNumeroParcelas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpVencimento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLocalizarProduto = new System.Windows.Forms.Button();
            this.txtProdutoID = new System.Windows.Forms.TextBox();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValorProduto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnLocalizarCliente = new System.Windows.Forms.Button();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvItensVenda = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClienteID = new System.Windows.Forms.TextBox();
            this.dtpDataVenda = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVendaID = new System.Windows.Forms.TextBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dgvParcelas = new System.Windows.Forms.DataGridView();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnParcelar
            // 
            this.btnParcelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnParcelar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnParcelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnParcelar.Enabled = false;
            this.btnParcelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnParcelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnParcelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnParcelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParcelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnParcelar.ForeColor = System.Drawing.Color.Black;
            this.btnParcelar.Image = global::SisControl.Properties.Resources.Parcelar1;
            this.btnParcelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParcelar.Location = new System.Drawing.Point(163, 73);
            this.btnParcelar.Name = "btnParcelar";
            this.btnParcelar.Size = new System.Drawing.Size(115, 37);
            this.btnParcelar.TabIndex = 561;
            this.btnParcelar.Text = "&Gerar Parcelas";
            this.btnParcelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnParcelar.UseVisualStyleBackColor = false;
            this.btnParcelar.Click += new System.EventHandler(this.btnParcelar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnFinalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnFinalizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFinalizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalizar.Image")));
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizar.Location = new System.Drawing.Point(594, 445);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(130, 37);
            this.btnFinalizar.TabIndex = 566;
            this.btnFinalizar.Text = "Finali&zar Venda";
            this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox4.Controls.Add(this.txtValorRecebido);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtSubTotal);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.dtpVencimento);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.btnLocalizarProduto);
            this.groupBox4.Controls.Add(this.txtProdutoID);
            this.groupBox4.Controls.Add(this.txtNomeProduto);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtQuantidade);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtValorProduto);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.btnIncluir);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.ForeColor = System.Drawing.Color.Teal;
            this.groupBox4.Location = new System.Drawing.Point(-15, 77);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1025, 172);
            this.groupBox4.TabIndex = 575;
            this.groupBox4.TabStop = false;
            // 
            // txtValorRecebido
            // 
            this.txtValorRecebido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorRecebido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorRecebido.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtValorRecebido.Location = new System.Drawing.Point(228, 121);
            this.txtValorRecebido.Name = "txtValorRecebido";
            this.txtValorRecebido.Size = new System.Drawing.Size(95, 24);
            this.txtValorRecebido.TabIndex = 4;
            this.txtValorRecebido.Text = "0,00";
            this.txtValorRecebido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorRecebido.Leave += new System.EventHandler(this.txtValorRecebido_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Menu;
            this.label11.Location = new System.Drawing.Point(226, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 584;
            this.label11.Text = "VALOR RECEBIDO";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtSubTotal.Location = new System.Drawing.Point(328, 120);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(90, 26);
            this.txtSubTotal.TabIndex = 565;
            this.txtSubTotal.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtNumeroParcelas);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnParcelar);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(692, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 118);
            this.groupBox1.TabIndex = 582;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parcelar";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Controls.Add(this.rbUmaParcela);
            this.groupBox2.Controls.Add(this.rbParcelar);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(58, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 51);
            this.groupBox2.TabIndex = 585;
            this.groupBox2.TabStop = false;
            // 
            // rbUmaParcela
            // 
            this.rbUmaParcela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbUmaParcela.AutoSize = true;
            this.rbUmaParcela.Checked = true;
            this.rbUmaParcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbUmaParcela.ForeColor = System.Drawing.Color.White;
            this.rbUmaParcela.Location = new System.Drawing.Point(103, 17);
            this.rbUmaParcela.Name = "rbUmaParcela";
            this.rbUmaParcela.Size = new System.Drawing.Size(52, 21);
            this.rbUmaParcela.TabIndex = 584;
            this.rbUmaParcela.TabStop = true;
            this.rbUmaParcela.Text = "Não";
            this.rbUmaParcela.UseVisualStyleBackColor = true;
            this.rbUmaParcela.CheckedChanged += new System.EventHandler(this.rbUmaParcela_CheckedChanged);
            // 
            // rbParcelar
            // 
            this.rbParcelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbParcelar.AutoSize = true;
            this.rbParcelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbParcelar.ForeColor = System.Drawing.Color.White;
            this.rbParcelar.Location = new System.Drawing.Point(20, 17);
            this.rbParcelar.Name = "rbParcelar";
            this.rbParcelar.Size = new System.Drawing.Size(49, 21);
            this.rbParcelar.TabIndex = 583;
            this.rbParcelar.Text = "Sim";
            this.rbParcelar.UseVisualStyleBackColor = true;
            this.rbParcelar.CheckedChanged += new System.EventHandler(this.rbParcelar_CheckedChanged);
            // 
            // txtNumeroParcelas
            // 
            this.txtNumeroParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNumeroParcelas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroParcelas.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtNumeroParcelas.Location = new System.Drawing.Point(58, 86);
            this.txtNumeroParcelas.Name = "txtNumeroParcelas";
            this.txtNumeroParcelas.Size = new System.Drawing.Size(99, 22);
            this.txtNumeroParcelas.TabIndex = 578;
            this.txtNumeroParcelas.Text = "1";
            this.txtNumeroParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(55, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 579;
            this.label5.Text = "Nº de Parcelas";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Menu;
            this.label10.Location = new System.Drawing.Point(338, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 16);
            this.label10.TabIndex = 566;
            this.label10.Text = "SUBTOTAL";
            // 
            // dtpVencimento
            // 
            this.dtpVencimento.CalendarForeColor = System.Drawing.Color.Blue;
            this.dtpVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimento.Location = new System.Drawing.Point(420, 123);
            this.dtpVencimento.Name = "dtpVencimento";
            this.dtpVencimento.Size = new System.Drawing.Size(127, 22);
            this.dtpVencimento.TabIndex = 5;
            this.dtpVencimento.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Menu;
            this.label6.Location = new System.Drawing.Point(420, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 15);
            this.label6.TabIndex = 545;
            this.label6.Text = "DATA VENCIMENTO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Menu;
            this.label4.Location = new System.Drawing.Point(28, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 545;
            this.label4.Text = "ID PRODUTO";
            // 
            // btnLocalizarProduto
            // 
            this.btnLocalizarProduto.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnLocalizarProduto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnLocalizarProduto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLocalizarProduto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLocalizarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalizarProduto.Image = global::SisControl.Properties.Resources.LocalizarProduto32;
            this.btnLocalizarProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalizarProduto.Location = new System.Drawing.Point(554, 33);
            this.btnLocalizarProduto.Name = "btnLocalizarProduto";
            this.btnLocalizarProduto.Size = new System.Drawing.Size(130, 37);
            this.btnLocalizarProduto.TabIndex = 1;
            this.btnLocalizarProduto.Text = "Localizar Produto";
            this.btnLocalizarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocalizarProduto.UseVisualStyleBackColor = false;
            this.btnLocalizarProduto.Click += new System.EventHandler(this.btnLocalizarProduto_Click);
            // 
            // txtProdutoID
            // 
            this.txtProdutoID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProdutoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdutoID.Location = new System.Drawing.Point(29, 49);
            this.txtProdutoID.Name = "txtProdutoID";
            this.txtProdutoID.ReadOnly = true;
            this.txtProdutoID.Size = new System.Drawing.Size(79, 21);
            this.txtProdutoID.TabIndex = 544;
            this.txtProdutoID.TabStop = false;
            this.txtProdutoID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNomeProduto.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtNomeProduto.Location = new System.Drawing.Point(113, 49);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(440, 21);
            this.txtNomeProduto.TabIndex = 1;
            this.txtNomeProduto.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.Menu;
            this.label17.Location = new System.Drawing.Point(113, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(145, 13);
            this.label17.TabIndex = 467;
            this.label17.Text = "DESCRIÇÃO DO PRODUTO";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtQuantidade.Location = new System.Drawing.Point(28, 121);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(95, 24);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.Text = "1";
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Menu;
            this.label7.Location = new System.Drawing.Point(31, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 563;
            this.label7.Text = "QUANTIDADE";
            // 
            // txtValorProduto
            // 
            this.txtValorProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorProduto.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtValorProduto.Location = new System.Drawing.Point(128, 121);
            this.txtValorProduto.Name = "txtValorProduto";
            this.txtValorProduto.Size = new System.Drawing.Size(95, 24);
            this.txtValorProduto.TabIndex = 3;
            this.txtValorProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorProduto.Leave += new System.EventHandler(this.txtValorProduto_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Menu;
            this.label8.Location = new System.Drawing.Point(125, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 564;
            this.label8.Text = "PREÇO UNITÁRIO";
            // 
            // btnIncluir
            // 
            this.btnIncluir.BackColor = System.Drawing.SystemColors.Control;
            this.btnIncluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnIncluir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnIncluir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnIncluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.Image = global::SisControl.Properties.Resources.inserir32;
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncluir.Location = new System.Drawing.Point(556, 108);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(130, 37);
            this.btnIncluir.TabIndex = 6;
            this.btnIncluir.Text = "&Incluir Ìtem";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncluir.UseVisualStyleBackColor = false;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnLocalizarCliente
            // 
            this.btnLocalizarCliente.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnLocalizarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnLocalizarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLocalizarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLocalizarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalizarCliente.Image = global::SisControl.Properties.Resources.Localizar32;
            this.btnLocalizarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalizarCliente.Location = new System.Drawing.Point(739, 32);
            this.btnLocalizarCliente.Name = "btnLocalizarCliente";
            this.btnLocalizarCliente.Size = new System.Drawing.Size(130, 37);
            this.btnLocalizarCliente.TabIndex = 0;
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
            this.txtNomeCliente.Location = new System.Drawing.Point(218, 39);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(515, 21);
            this.txtNomeCliente.TabIndex = 0;
            this.txtNomeCliente.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Menu;
            this.label14.Location = new System.Drawing.Point(219, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 15);
            this.label14.TabIndex = 296;
            this.label14.Text = "NOME DO CLIENTE";
            // 
            // dgvItensVenda
            // 
            this.dgvItensVenda.AllowUserToAddRows = false;
            this.dgvItensVenda.AllowUserToDeleteRows = false;
            this.dgvItensVenda.AllowUserToResizeColumns = false;
            this.dgvItensVenda.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvItensVenda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItensVenda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvItensVenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvItensVenda.BackgroundColor = System.Drawing.Color.White;
            this.dgvItensVenda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItensVenda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvItensVenda.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItensVenda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItensVenda.ColumnHeadersHeight = 20;
            this.dgvItensVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItensVenda.EnableHeadersVisualStyles = false;
            this.dgvItensVenda.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvItensVenda.Location = new System.Drawing.Point(3, 255);
            this.dgvItensVenda.MultiSelect = false;
            this.dgvItensVenda.Name = "dgvItensVenda";
            this.dgvItensVenda.ReadOnly = true;
            this.dgvItensVenda.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItensVenda.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItensVenda.RowHeadersWidth = 20;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvItensVenda.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItensVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItensVenda.Size = new System.Drawing.Size(571, 170);
            this.dgvItensVenda.TabIndex = 562;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(375, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 565;
            this.label2.Text = "TOTAL";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtClienteID);
            this.groupBox3.Controls.Add(this.btnLocalizarCliente);
            this.groupBox3.Controls.Add(this.txtNomeCliente);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.dtpDataVenda);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtVendaID);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(-9, -1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1019, 79);
            this.groupBox3.TabIndex = 572;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Menu;
            this.label3.Location = new System.Drawing.Point(136, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 543;
            this.label3.Text = "ID CLIENTE";
            // 
            // txtClienteID
            // 
            this.txtClienteID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClienteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteID.Location = new System.Drawing.Point(133, 39);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.ReadOnly = true;
            this.txtClienteID.Size = new System.Drawing.Size(79, 21);
            this.txtClienteID.TabIndex = 542;
            this.txtClienteID.TabStop = false;
            this.txtClienteID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpDataVenda
            // 
            this.dtpDataVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataVenda.CalendarForeColor = System.Drawing.Color.Blue;
            this.dtpDataVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataVenda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataVenda.Location = new System.Drawing.Point(890, 38);
            this.dtpDataVenda.Name = "dtpDataVenda";
            this.dtpDataVenda.Size = new System.Drawing.Size(117, 22);
            this.dtpDataVenda.TabIndex = 19;
            this.dtpDataVenda.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(888, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 465;
            this.label1.Text = "DATA DA VENDA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Menu;
            this.label9.Location = new System.Drawing.Point(24, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 15);
            this.label9.TabIndex = 498;
            this.label9.Text = "VENDA NÚMERO";
            // 
            // txtVendaID
            // 
            this.txtVendaID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVendaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendaID.Location = new System.Drawing.Point(21, 39);
            this.txtVendaID.Name = "txtVendaID";
            this.txtVendaID.ReadOnly = true;
            this.txtVendaID.Size = new System.Drawing.Size(108, 21);
            this.txtVendaID.TabIndex = 463;
            this.txtVendaID.TabStop = false;
            this.txtVendaID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtValorTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtValorTotal.Location = new System.Drawing.Point(444, 456);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(130, 26);
            this.txtValorTotal.TabIndex = 560;
            this.txtValorTotal.TabStop = false;
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnNovo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = global::SisControl.Properties.Resources.Novo;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(730, 445);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(130, 37);
            this.btnNovo.TabIndex = 571;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
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
            this.btnFechar.Location = new System.Drawing.Point(866, 445);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(130, 37);
            this.btnFechar.TabIndex = 568;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 580;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dgvParcelas
            // 
            this.dgvParcelas.AllowUserToAddRows = false;
            this.dgvParcelas.AllowUserToDeleteRows = false;
            this.dgvParcelas.AllowUserToResizeColumns = false;
            this.dgvParcelas.AllowUserToResizeRows = false;
            this.dgvParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParcelas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvParcelas.BackgroundColor = System.Drawing.Color.White;
            this.dgvParcelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvParcelas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvParcelas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParcelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvParcelas.ColumnHeadersHeight = 20;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParcelas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvParcelas.EnableHeadersVisualStyles = false;
            this.dgvParcelas.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvParcelas.Location = new System.Drawing.Point(581, 254);
            this.dgvParcelas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvParcelas.Name = "dgvParcelas";
            this.dgvParcelas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParcelas.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvParcelas.RowHeadersWidth = 20;
            this.dgvParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParcelas.Size = new System.Drawing.Size(417, 170);
            this.dgvParcelas.TabIndex = 585;
            // 
            // FrmVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 517);
            this.Controls.Add(this.dgvParcelas);
            this.Controls.Add(this.dgvItensVenda);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnFechar);
            this.Name = "FrmVendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmVendas_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnParcelar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLocalizarCliente;
        public System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnLocalizarProduto;
        public System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.DataGridView dgvItensVenda;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.DateTimePicker dtpDataVenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtVendaID;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtValorProduto;
        public System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFechar;
        public System.Windows.Forms.TextBox txtNumeroParcelas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtClienteID;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtProdutoID;
        public System.Windows.Forms.DateTimePicker dtpVencimento;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbParcelar;
        private System.Windows.Forms.RadioButton rbUmaParcela;
        private System.Windows.Forms.DataGridView dgvParcelas;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtValorRecebido;
        private System.Windows.Forms.Label label11;
    }
}
