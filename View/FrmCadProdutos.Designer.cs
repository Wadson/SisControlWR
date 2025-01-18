namespace SisControl.View
{
    partial class FrmCadProdutos
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrecoCusto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantidadeEmEstoque = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecoDeVenda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLucro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pbImagem = new System.Windows.Forms.PictureBox();
            this.dtpDataDeEntrada = new System.Windows.Forms.DateTimePicker();
            this.dtpDataDeVencimento = new System.Windows.Forms.DateTimePicker();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbFabricante = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtProdutoID = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCategoriaID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFabricanteID = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtFornecedorID = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnLocalizarCliente = new System.Windows.Forms.Button();
            this.btnLocalizarImagem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbUnidadeDeMedida = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Produto:";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeProduto.Location = new System.Drawing.Point(21, 114);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(312, 20);
            this.txtNomeProduto.TabIndex = 0;
            this.txtNomeProduto.Enter += new System.EventHandler(this.txtNomeProduto_Enter);
            this.txtNomeProduto.Leave += new System.EventHandler(this.txtNomeProduto_Leave);
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(336, 114);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(324, 20);
            this.txtDescricao.TabIndex = 1;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição:";
            // 
            // txtPrecoCusto
            // 
            this.txtPrecoCusto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecoCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrecoCusto.Location = new System.Drawing.Point(21, 216);
            this.txtPrecoCusto.Name = "txtPrecoCusto";
            this.txtPrecoCusto.Size = new System.Drawing.Size(100, 20);
            this.txtPrecoCusto.TabIndex = 5;
            this.txtPrecoCusto.Enter += new System.EventHandler(this.txtPrecoCusto_Enter);
            this.txtPrecoCusto.Leave += new System.EventHandler(this.txtPrecoCusto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Preço de Custo:";
            // 
            // txtQuantidadeEmEstoque
            // 
            this.txtQuantidadeEmEstoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantidadeEmEstoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantidadeEmEstoque.Location = new System.Drawing.Point(336, 216);
            this.txtQuantidadeEmEstoque.Name = "txtQuantidadeEmEstoque";
            this.txtQuantidadeEmEstoque.Size = new System.Drawing.Size(100, 20);
            this.txtQuantidadeEmEstoque.TabIndex = 8;
            this.txtQuantidadeEmEstoque.Enter += new System.EventHandler(this.txtQuantidadeEmEstoque_Enter);
            this.txtQuantidadeEmEstoque.Leave += new System.EventHandler(this.txtQuantidadeEmEstoque_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Qtde. em Estoque:";
            // 
            // txtPrecoDeVenda
            // 
            this.txtPrecoDeVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecoDeVenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrecoDeVenda.Location = new System.Drawing.Point(233, 216);
            this.txtPrecoDeVenda.Name = "txtPrecoDeVenda";
            this.txtPrecoDeVenda.Size = new System.Drawing.Size(100, 20);
            this.txtPrecoDeVenda.TabIndex = 7;
            this.txtPrecoDeVenda.Enter += new System.EventHandler(this.txtPrecoDeVenda_Enter);
            this.txtPrecoDeVenda.Leave += new System.EventHandler(this.txtPrecoDeVenda_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Preço de Venda:";
            // 
            // txtLucro
            // 
            this.txtLucro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLucro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLucro.Location = new System.Drawing.Point(127, 216);
            this.txtLucro.Name = "txtLucro";
            this.txtLucro.Size = new System.Drawing.Size(100, 20);
            this.txtLucro.TabIndex = 6;
            this.txtLucro.Enter += new System.EventHandler(this.txtLucro_Enter);
            this.txtLucro.Leave += new System.EventHandler(this.txtLucro_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Lucro:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(698, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Data de Entrada:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Status:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Unidade de Medida:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(125, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Fabricante:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(443, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Categoria:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(449, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Data de Vencimento:";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFornecedor.Location = new System.Drawing.Point(130, 306);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(411, 20);
            this.txtFornecedor.TabIndex = 10;
            this.txtFornecedor.Enter += new System.EventHandler(this.txtFornecedor_Enter);
            this.txtFornecedor.Leave += new System.EventHandler(this.txtFornecedor_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(127, 289);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Fornecedor:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(566, 199);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Adicionar Imagem";
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
            this.btnFechar.Location = new System.Drawing.Point(557, 358);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 35);
            this.btnFechar.TabIndex = 14;
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
            this.btnNovo.Location = new System.Drawing.Point(324, 358);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 35);
            this.btnNovo.TabIndex = 13;
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
            this.btnSalvar.Location = new System.Drawing.Point(91, 358);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 35);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "     &Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // pbImagem
            // 
            this.pbImagem.Location = new System.Drawing.Point(666, 141);
            this.pbImagem.Name = "pbImagem";
            this.pbImagem.Size = new System.Drawing.Size(158, 137);
            this.pbImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagem.TabIndex = 172;
            this.pbImagem.TabStop = false;
            // 
            // dtpDataDeEntrada
            // 
            this.dtpDataDeEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDeEntrada.Location = new System.Drawing.Point(692, 31);
            this.dtpDataDeEntrada.Name = "dtpDataDeEntrada";
            this.dtpDataDeEntrada.Size = new System.Drawing.Size(110, 20);
            this.dtpDataDeEntrada.TabIndex = 100;
            this.dtpDataDeEntrada.TabStop = false;
            // 
            // dtpDataDeVencimento
            // 
            this.dtpDataDeVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDeVencimento.Location = new System.Drawing.Point(446, 216);
            this.dtpDataDeVencimento.Name = "dtpDataDeVencimento";
            this.dtpDataDeVencimento.Size = new System.Drawing.Size(110, 20);
            this.dtpDataDeVencimento.TabIndex = 101;
            this.dtpDataDeVencimento.TabStop = false;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(443, 164);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(217, 21);
            this.cmbCategoria.TabIndex = 4;
            this.cmbCategoria.TextChanged += new System.EventHandler(this.cmbCategoria_TextChanged);
            this.cmbCategoria.Enter += new System.EventHandler(this.cmbCategoria_Enter);
            this.cmbCategoria.Leave += new System.EventHandler(this.cmbCategoria_Leave);
            // 
            // cmbFabricante
            // 
            this.cmbFabricante.FormattingEnabled = true;
            this.cmbFabricante.Location = new System.Drawing.Point(128, 259);
            this.cmbFabricante.Name = "cmbFabricante";
            this.cmbFabricante.Size = new System.Drawing.Size(532, 21);
            this.cmbFabricante.TabIndex = 9;
            this.cmbFabricante.TextChanged += new System.EventHandler(this.cmbFabricante_TextChanged);
            this.cmbFabricante.VisibleChanged += new System.EventHandler(this.cmbFabricante_VisibleChanged);
            this.cmbFabricante.Enter += new System.EventHandler(this.cmbFabricante_Enter);
            this.cmbFabricante.Leave += new System.EventHandler(this.cmbFabricante_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label15.Location = new System.Drawing.Point(295, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(221, 25);
            this.label15.TabIndex = 173;
            this.label15.Text = "Cadastro de Produtos";
            // 
            // txtProdutoID
            // 
            this.txtProdutoID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdutoID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProdutoID.Location = new System.Drawing.Point(9, 31);
            this.txtProdutoID.Name = "txtProdutoID";
            this.txtProdutoID.ReadOnly = true;
            this.txtProdutoID.Size = new System.Drawing.Size(100, 20);
            this.txtProdutoID.TabIndex = 175;
            this.txtProdutoID.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 174;
            this.label16.Text = "Código Produto:";
            // 
            // txtCategoriaID
            // 
            this.txtCategoriaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoriaID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCategoriaID.Location = new System.Drawing.Point(337, 164);
            this.txtCategoriaID.Name = "txtCategoriaID";
            this.txtCategoriaID.ReadOnly = true;
            this.txtCategoriaID.Size = new System.Drawing.Size(100, 20);
            this.txtCategoriaID.TabIndex = 177;
            this.txtCategoriaID.TabStop = false;
            this.txtCategoriaID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(334, 147);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 13);
            this.label17.TabIndex = 176;
            this.label17.Text = "Código Categoria";
            // 
            // txtFabricanteID
            // 
            this.txtFabricanteID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFabricanteID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFabricanteID.Location = new System.Drawing.Point(22, 260);
            this.txtFabricanteID.Name = "txtFabricanteID";
            this.txtFabricanteID.ReadOnly = true;
            this.txtFabricanteID.Size = new System.Drawing.Size(100, 20);
            this.txtFabricanteID.TabIndex = 179;
            this.txtFabricanteID.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 243);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 13);
            this.label18.TabIndex = 178;
            this.label18.Text = "Código Fabricante:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "DISPONÍVEL",
            "INDISPONÍVEL",
            "EM PRODUÇÃO",
            "DESCONTINUADO",
            "EM ESPERA"});
            this.cmbStatus.Location = new System.Drawing.Point(21, 164);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(206, 21);
            this.cmbStatus.TabIndex = 2;
            // 
            // txtFornecedorID
            // 
            this.txtFornecedorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFornecedorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFornecedorID.Location = new System.Drawing.Point(21, 306);
            this.txtFornecedorID.Name = "txtFornecedorID";
            this.txtFornecedorID.ReadOnly = true;
            this.txtFornecedorID.Size = new System.Drawing.Size(100, 20);
            this.txtFornecedorID.TabIndex = 182;
            this.txtFornecedorID.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 288);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 13);
            this.label19.TabIndex = 181;
            this.label19.Text = "Código Fornecedor:";
            // 
            // btnLocalizarCliente
            // 
            this.btnLocalizarCliente.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnLocalizarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnLocalizarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLocalizarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLocalizarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalizarCliente.Image = global::SisControl.Properties.Resources.Fornecedor;
            this.btnLocalizarCliente.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLocalizarCliente.Location = new System.Drawing.Point(547, 305);
            this.btnLocalizarCliente.Name = "btnLocalizarCliente";
            this.btnLocalizarCliente.Size = new System.Drawing.Size(110, 22);
            this.btnLocalizarCliente.TabIndex = 11;
            this.btnLocalizarCliente.Text = "&Localizar";
            this.btnLocalizarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocalizarCliente.UseVisualStyleBackColor = false;
            this.btnLocalizarCliente.Click += new System.EventHandler(this.btnLocalizarCliente_Click);
            // 
            // btnLocalizarImagem
            // 
            this.btnLocalizarImagem.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnLocalizarImagem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnLocalizarImagem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLocalizarImagem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLocalizarImagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalizarImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalizarImagem.Location = new System.Drawing.Point(562, 214);
            this.btnLocalizarImagem.Name = "btnLocalizarImagem";
            this.btnLocalizarImagem.Size = new System.Drawing.Size(98, 22);
            this.btnLocalizarImagem.TabIndex = 184;
            this.btnLocalizarImagem.TabStop = false;
            this.btnLocalizarImagem.Text = "&Localizar...";
            this.btnLocalizarImagem.UseVisualStyleBackColor = false;
            this.btnLocalizarImagem.Click += new System.EventHandler(this.btnLocalizarImagem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDataDeEntrada);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtProdutoID);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(818, 62);
            this.groupBox1.TabIndex = 185;
            this.groupBox1.TabStop = false;
            // 
            // cmbUnidadeDeMedida
            // 
            this.cmbUnidadeDeMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadeDeMedida.FormattingEnabled = true;
            this.cmbUnidadeDeMedida.Items.AddRange(new object[] {
            "ML",
            "L",
            "G",
            "KG",
            "UN",
            "M",
            "CM",
            "MM",
            "KM",
            "M²",
            "M³"});
            this.cmbUnidadeDeMedida.Location = new System.Drawing.Point(231, 164);
            this.cmbUnidadeDeMedida.Name = "cmbUnidadeDeMedida";
            this.cmbUnidadeDeMedida.Size = new System.Drawing.Size(100, 21);
            this.cmbUnidadeDeMedida.TabIndex = 186;
            // 
            // FrmCadProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(842, 428);
            this.Controls.Add(this.cmbUnidadeDeMedida);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLocalizarImagem);
            this.Controls.Add(this.btnLocalizarCliente);
            this.Controls.Add(this.txtFornecedorID);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtFabricanteID);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtCategoriaID);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbFabricante);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.dtpDataDeVencimento);
            this.Controls.Add(this.pbImagem);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtQuantidadeEmEstoque);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrecoDeVenda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLucro);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrecoCusto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadProdutos";
            this.Text = "SisControl - Cadastro de Produtos";
            this.Load += new System.EventHandler(this.FrmCadProdutos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCadProdutos_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Button btnFechar;
        public System.Windows.Forms.Button btnNovo;
        public System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox pbImagem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnLocalizarCliente;
        private System.Windows.Forms.Button btnLocalizarImagem;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtFornecedor;
        public System.Windows.Forms.TextBox txtFornecedorID;
        public System.Windows.Forms.TextBox txtNomeProduto;
        public System.Windows.Forms.TextBox txtDescricao;
        public System.Windows.Forms.TextBox txtPrecoCusto;
        public System.Windows.Forms.TextBox txtQuantidadeEmEstoque;
        public System.Windows.Forms.TextBox txtPrecoDeVenda;
        public System.Windows.Forms.TextBox txtLucro;
        public System.Windows.Forms.ComboBox cmbFabricante;
        public System.Windows.Forms.TextBox txtCategoriaID;
        public System.Windows.Forms.TextBox txtFabricanteID;
        public System.Windows.Forms.DateTimePicker dtpDataDeEntrada;
        public System.Windows.Forms.DateTimePicker dtpDataDeVencimento;
        public System.Windows.Forms.ComboBox cmbCategoria;
        public System.Windows.Forms.TextBox txtProdutoID;
        public System.Windows.Forms.ComboBox cmbStatus;
        public System.Windows.Forms.ComboBox cmbUnidadeDeMedida;
    }
}
