namespace SisControl
{
    partial class FrmTelaPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEstação = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblData = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel11 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHoraAtual = new System.Windows.Forms.ToolStripStatusLabel();
            this.usuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telaUiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manutençãoDeCadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fabricanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusData = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusExecutablePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCommonAppDataPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuarioLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MenuVertical = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFornecedor = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRelatorio = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnUsuarios = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnContasReceber = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCadClientes = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSair = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnProdutos = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnContasPagar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnVendas = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnFerramentas = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panelContenedor = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.statusStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuVertical)).BeginInit();
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContenedor)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel8,
            this.lblEstação,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel10,
            this.lblData,
            this.toolStripStatusLabel11,
            this.lblHoraAtual});
            this.statusStrip2.Location = new System.Drawing.Point(0, 644);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1228, 22);
            this.statusStrip2.TabIndex = 550;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusLabel7.Text = "Nome do Host:";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel8.Text = ":";
            // 
            // lblEstação
            // 
            this.lblEstação.BackColor = System.Drawing.SystemColors.Control;
            this.lblEstação.Name = "lblEstação";
            this.lblEstação.Size = new System.Drawing.Size(12, 17);
            this.lblEstação.Text = "-";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel9.Text = "|";
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabel10.Text = "Data:";
            // 
            // lblData
            // 
            this.lblData.BackColor = System.Drawing.SystemColors.Control;
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(12, 17);
            this.lblData.Text = "-";
            // 
            // toolStripStatusLabel11
            // 
            this.toolStripStatusLabel11.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel11.Name = "toolStripStatusLabel11";
            this.toolStripStatusLabel11.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel11.Text = "|";
            // 
            // lblHoraAtual
            // 
            this.lblHoraAtual.BackColor = System.Drawing.SystemColors.Control;
            this.lblHoraAtual.Name = "lblHoraAtual";
            this.lblHoraAtual.Size = new System.Drawing.Size(12, 17);
            this.lblHoraAtual.Text = "-";
            // 
            // usuárioToolStripMenuItem
            // 
            this.usuárioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuárioToolStripMenuItem1,
            this.clienteToolStripMenuItem,
            this.fornecedorToolStripMenuItem,
            this.produtoToolStripMenuItem,
            this.categoriaToolStripMenuItem,
            this.telaUiToolStripMenuItem});
            this.usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            this.usuárioToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.usuárioToolStripMenuItem.Text = "&Cadastro";
            // 
            // usuárioToolStripMenuItem1
            // 
            this.usuárioToolStripMenuItem1.Name = "usuárioToolStripMenuItem1";
            this.usuárioToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.usuárioToolStripMenuItem1.Text = "&Usuário";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.clienteToolStripMenuItem.Text = "&Cliente";
            // 
            // fornecedorToolStripMenuItem
            // 
            this.fornecedorToolStripMenuItem.Name = "fornecedorToolStripMenuItem";
            this.fornecedorToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.fornecedorToolStripMenuItem.Text = "&Fornecedor";
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.produtoToolStripMenuItem.Text = "&Produto";
            // 
            // categoriaToolStripMenuItem
            // 
            this.categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            this.categoriaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.categoriaToolStripMenuItem.Text = "Ca&tegoria";
            this.categoriaToolStripMenuItem.Click += new System.EventHandler(this.categoriaToolStripMenuItem_Click);
            // 
            // telaUiToolStripMenuItem
            // 
            this.telaUiToolStripMenuItem.Name = "telaUiToolStripMenuItem";
            this.telaUiToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.telaUiToolStripMenuItem.Text = "TelaUi";
            this.telaUiToolStripMenuItem.Click += new System.EventHandler(this.telaUiToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuárioToolStripMenuItem,
            this.manutençãoDeCadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1228, 24);
            this.menuStrip1.TabIndex = 551;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manutençãoDeCadastrosToolStripMenuItem
            // 
            this.manutençãoDeCadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuárioToolStripMenuItem2,
            this.clienteToolStripMenuItem1,
            this.fornecedorToolStripMenuItem1,
            this.produtoToolStripMenuItem1,
            this.fabricanteToolStripMenuItem});
            this.manutençãoDeCadastrosToolStripMenuItem.Name = "manutençãoDeCadastrosToolStripMenuItem";
            this.manutençãoDeCadastrosToolStripMenuItem.Size = new System.Drawing.Size(157, 20);
            this.manutençãoDeCadastrosToolStripMenuItem.Text = "&Manutenção de Cadastros";
            // 
            // usuárioToolStripMenuItem2
            // 
            this.usuárioToolStripMenuItem2.Name = "usuárioToolStripMenuItem2";
            this.usuárioToolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.usuárioToolStripMenuItem2.Text = "&Usuário";
            // 
            // clienteToolStripMenuItem1
            // 
            this.clienteToolStripMenuItem1.Name = "clienteToolStripMenuItem1";
            this.clienteToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.clienteToolStripMenuItem1.Text = "&Cliente";
            // 
            // fornecedorToolStripMenuItem1
            // 
            this.fornecedorToolStripMenuItem1.Name = "fornecedorToolStripMenuItem1";
            this.fornecedorToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.fornecedorToolStripMenuItem1.Text = "&Fornecedor";
            // 
            // produtoToolStripMenuItem1
            // 
            this.produtoToolStripMenuItem1.Name = "produtoToolStripMenuItem1";
            this.produtoToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.produtoToolStripMenuItem1.Text = "&Produto";
            // 
            // fabricanteToolStripMenuItem
            // 
            this.fabricanteToolStripMenuItem.Name = "fabricanteToolStripMenuItem";
            this.fabricanteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.fabricanteToolStripMenuItem.Text = "&Fabricante";
            this.fabricanteToolStripMenuItem.Click += new System.EventHandler(this.fabricanteToolStripMenuItem_Click);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "Nova seleção de item";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(1228, 22);
            this.miniToolStrip.TabIndex = 22;
            // 
            // toolStripStatusData
            // 
            this.toolStripStatusData.Name = "toolStripStatusData";
            this.toolStripStatusData.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusData.Text = "-";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusHora
            // 
            this.toolStripStatusHora.Name = "toolStripStatusHora";
            this.toolStripStatusHora.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusHora.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusExecutablePath
            // 
            this.toolStripStatusExecutablePath.Name = "toolStripStatusExecutablePath";
            this.toolStripStatusExecutablePath.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusExecutablePath.Text = "-";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLocation
            // 
            this.toolStripStatusLocation.Name = "toolStripStatusLocation";
            this.toolStripStatusLocation.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLocation.Text = "-";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusCommonAppDataPath
            // 
            this.toolStripStatusCommonAppDataPath.Name = "toolStripStatusCommonAppDataPath";
            this.toolStripStatusCommonAppDataPath.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusCommonAppDataPath.Text = "-";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel5.Text = "|";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel6.Text = "Usuário: ";
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(12, 17);
            this.lblUsuarioLogado.Text = "-";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusData,
            this.toolStripStatusLabel1,
            this.toolStripStatusHora,
            this.toolStripStatusLabel2,
            this.toolStripStatusExecutablePath,
            this.toolStripStatusLabel4,
            this.toolStripStatusLocation,
            this.toolStripStatusLabel3,
            this.toolStripStatusCommonAppDataPath,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.lblUsuarioLogado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 541);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1228, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MenuVertical
            // 
            this.MenuVertical.Controls.Add(this.pictureBox1);
            this.MenuVertical.Controls.Add(this.btnFornecedor);
            this.MenuVertical.Controls.Add(this.btnRelatorio);
            this.MenuVertical.Controls.Add(this.btnUsuarios);
            this.MenuVertical.Controls.Add(this.btnContasReceber);
            this.MenuVertical.Controls.Add(this.btnCadClientes);
            this.MenuVertical.Controls.Add(this.btnSair);
            this.MenuVertical.Controls.Add(this.btnProdutos);
            this.MenuVertical.Controls.Add(this.btnContasPagar);
            this.MenuVertical.Controls.Add(this.btnVendas);
            this.MenuVertical.Controls.Add(this.btnFerramentas);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 24);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(206, 620);
            this.MenuVertical.TabIndex = 554;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SisControl.Properties.Resources.WR_SOFT;
            this.pictureBox1.Location = new System.Drawing.Point(7, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFornecedor.Location = new System.Drawing.Point(9, 139);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnFornecedor.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFornecedor.OverrideDefault.Back.ColorAngle = 45F;
            this.btnFornecedor.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFornecedor.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFornecedor.OverrideDefault.Border.ColorAngle = 45F;
            this.btnFornecedor.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFornecedor.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFornecedor.OverrideDefault.Border.Rounding = 1;
            this.btnFornecedor.OverrideDefault.Border.Width = 1;
            this.btnFornecedor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnFornecedor.Size = new System.Drawing.Size(190, 30);
            this.btnFornecedor.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnFornecedor.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnFornecedor.StateCommon.Back.ColorAngle = 45F;
            this.btnFornecedor.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnFornecedor.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFornecedor.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFornecedor.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFornecedor.StateCommon.Border.Rounding = 1;
            this.btnFornecedor.StateCommon.Border.Width = 1;
            this.btnFornecedor.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFornecedor.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFornecedor.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFornecedor.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFornecedor.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnFornecedor.StatePressed.Back.ColorAngle = 135F;
            this.btnFornecedor.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnFornecedor.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnFornecedor.StatePressed.Border.ColorAngle = 135F;
            this.btnFornecedor.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFornecedor.StatePressed.Border.Rounding = 1;
            this.btnFornecedor.StatePressed.Border.Width = 1;
            this.btnFornecedor.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFornecedor.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnFornecedor.StateTracking.Back.ColorAngle = 45F;
            this.btnFornecedor.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnFornecedor.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFornecedor.StateTracking.Border.ColorAngle = 45F;
            this.btnFornecedor.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFornecedor.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFornecedor.StateTracking.Border.Rounding = 1;
            this.btnFornecedor.StateTracking.Border.Width = 1;
            this.btnFornecedor.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnFornecedor.TabIndex = 556;
            this.btnFornecedor.Values.ImageStates.ImageCheckedNormal = null;
            this.btnFornecedor.Values.ImageStates.ImageCheckedPressed = null;
            this.btnFornecedor.Values.ImageStates.ImageCheckedTracking = null;
            this.btnFornecedor.Values.ImageStates.ImageNormal = global::SisControl.Properties.Resources.Fornec24;
            this.btnFornecedor.Values.Text = "Fornecedor";
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRelatorio.Location = new System.Drawing.Point(9, 319);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnRelatorio.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnRelatorio.OverrideDefault.Back.ColorAngle = 45F;
            this.btnRelatorio.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnRelatorio.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnRelatorio.OverrideDefault.Border.ColorAngle = 45F;
            this.btnRelatorio.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRelatorio.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnRelatorio.OverrideDefault.Border.Rounding = 1;
            this.btnRelatorio.OverrideDefault.Border.Width = 1;
            this.btnRelatorio.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnRelatorio.Size = new System.Drawing.Size(190, 30);
            this.btnRelatorio.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnRelatorio.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnRelatorio.StateCommon.Back.ColorAngle = 45F;
            this.btnRelatorio.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnRelatorio.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnRelatorio.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRelatorio.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnRelatorio.StateCommon.Border.Rounding = 1;
            this.btnRelatorio.StateCommon.Border.Width = 1;
            this.btnRelatorio.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnRelatorio.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnRelatorio.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorio.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnRelatorio.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnRelatorio.StatePressed.Back.ColorAngle = 135F;
            this.btnRelatorio.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnRelatorio.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnRelatorio.StatePressed.Border.ColorAngle = 135F;
            this.btnRelatorio.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRelatorio.StatePressed.Border.Rounding = 1;
            this.btnRelatorio.StatePressed.Border.Width = 1;
            this.btnRelatorio.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnRelatorio.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnRelatorio.StateTracking.Back.ColorAngle = 45F;
            this.btnRelatorio.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnRelatorio.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnRelatorio.StateTracking.Border.ColorAngle = 45F;
            this.btnRelatorio.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRelatorio.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnRelatorio.StateTracking.Border.Rounding = 1;
            this.btnRelatorio.StateTracking.Border.Width = 1;
            this.btnRelatorio.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRelatorio.TabIndex = 562;
            this.btnRelatorio.Values.ImageStates.ImageCheckedNormal = null;
            this.btnRelatorio.Values.ImageStates.ImageCheckedPressed = null;
            this.btnRelatorio.Values.ImageStates.ImageCheckedTracking = null;
            this.btnRelatorio.Values.ImageStates.ImageNormal = global::SisControl.Properties.Resources.Relatorio24;
            this.btnRelatorio.Values.Text = "Relatórios";
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUsuarios.Location = new System.Drawing.Point(9, 67);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnUsuarios.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnUsuarios.OverrideDefault.Back.ColorAngle = 45F;
            this.btnUsuarios.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnUsuarios.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnUsuarios.OverrideDefault.Border.ColorAngle = 45F;
            this.btnUsuarios.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUsuarios.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnUsuarios.OverrideDefault.Border.Rounding = 1;
            this.btnUsuarios.OverrideDefault.Border.Width = 1;
            this.btnUsuarios.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnUsuarios.Size = new System.Drawing.Size(190, 30);
            this.btnUsuarios.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnUsuarios.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnUsuarios.StateCommon.Back.ColorAngle = 45F;
            this.btnUsuarios.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnUsuarios.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnUsuarios.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUsuarios.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnUsuarios.StateCommon.Border.Rounding = 1;
            this.btnUsuarios.StateCommon.Border.Width = 1;
            this.btnUsuarios.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnUsuarios.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnUsuarios.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnUsuarios.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnUsuarios.StatePressed.Back.ColorAngle = 135F;
            this.btnUsuarios.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnUsuarios.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnUsuarios.StatePressed.Border.ColorAngle = 135F;
            this.btnUsuarios.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUsuarios.StatePressed.Border.Rounding = 1;
            this.btnUsuarios.StatePressed.Border.Width = 1;
            this.btnUsuarios.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnUsuarios.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnUsuarios.StateTracking.Back.ColorAngle = 45F;
            this.btnUsuarios.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnUsuarios.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnUsuarios.StateTracking.Border.ColorAngle = 45F;
            this.btnUsuarios.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUsuarios.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnUsuarios.StateTracking.Border.Rounding = 1;
            this.btnUsuarios.StateTracking.Border.Width = 1;
            this.btnUsuarios.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnUsuarios.TabIndex = 555;
            this.btnUsuarios.Values.ImageStates.ImageCheckedNormal = null;
            this.btnUsuarios.Values.ImageStates.ImageCheckedPressed = null;
            this.btnUsuarios.Values.ImageStates.ImageCheckedTracking = null;
            this.btnUsuarios.Values.ImageStates.ImageNormal = global::SisControl.Properties.Resources.Usuario24;
            this.btnUsuarios.Values.Text = "Usuários";
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnContasReceber
            // 
            this.btnContasReceber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnContasReceber.Location = new System.Drawing.Point(9, 283);
            this.btnContasReceber.Name = "btnContasReceber";
            this.btnContasReceber.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnContasReceber.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasReceber.OverrideDefault.Back.ColorAngle = 45F;
            this.btnContasReceber.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasReceber.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasReceber.OverrideDefault.Border.ColorAngle = 45F;
            this.btnContasReceber.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnContasReceber.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnContasReceber.OverrideDefault.Border.Rounding = 1;
            this.btnContasReceber.OverrideDefault.Border.Width = 1;
            this.btnContasReceber.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnContasReceber.Size = new System.Drawing.Size(190, 30);
            this.btnContasReceber.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnContasReceber.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnContasReceber.StateCommon.Back.ColorAngle = 45F;
            this.btnContasReceber.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnContasReceber.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasReceber.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnContasReceber.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnContasReceber.StateCommon.Border.Rounding = 1;
            this.btnContasReceber.StateCommon.Border.Width = 1;
            this.btnContasReceber.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasReceber.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasReceber.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContasReceber.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasReceber.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnContasReceber.StatePressed.Back.ColorAngle = 135F;
            this.btnContasReceber.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnContasReceber.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnContasReceber.StatePressed.Border.ColorAngle = 135F;
            this.btnContasReceber.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnContasReceber.StatePressed.Border.Rounding = 1;
            this.btnContasReceber.StatePressed.Border.Width = 1;
            this.btnContasReceber.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasReceber.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnContasReceber.StateTracking.Back.ColorAngle = 45F;
            this.btnContasReceber.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnContasReceber.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasReceber.StateTracking.Border.ColorAngle = 45F;
            this.btnContasReceber.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnContasReceber.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnContasReceber.StateTracking.Border.Rounding = 1;
            this.btnContasReceber.StateTracking.Border.Width = 1;
            this.btnContasReceber.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnContasReceber.TabIndex = 561;
            this.btnContasReceber.Values.ImageStates.ImageCheckedNormal = null;
            this.btnContasReceber.Values.ImageStates.ImageCheckedPressed = null;
            this.btnContasReceber.Values.ImageStates.ImageCheckedTracking = null;
            this.btnContasReceber.Values.ImageStates.ImageNormal = global::SisControl.Properties.Resources.Receber24;
            this.btnContasReceber.Values.Text = "Receber";
            this.btnContasReceber.Click += new System.EventHandler(this.btnContasReceber_Click);
            // 
            // btnCadClientes
            // 
            this.btnCadClientes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCadClientes.Location = new System.Drawing.Point(9, 103);
            this.btnCadClientes.Name = "btnCadClientes";
            this.btnCadClientes.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnCadClientes.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCadClientes.OverrideDefault.Back.ColorAngle = 45F;
            this.btnCadClientes.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCadClientes.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCadClientes.OverrideDefault.Border.ColorAngle = 45F;
            this.btnCadClientes.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadClientes.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadClientes.OverrideDefault.Border.Rounding = 1;
            this.btnCadClientes.OverrideDefault.Border.Width = 1;
            this.btnCadClientes.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnCadClientes.Size = new System.Drawing.Size(190, 30);
            this.btnCadClientes.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnCadClientes.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnCadClientes.StateCommon.Back.ColorAngle = 45F;
            this.btnCadClientes.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnCadClientes.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCadClientes.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadClientes.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadClientes.StateCommon.Border.Rounding = 1;
            this.btnCadClientes.StateCommon.Border.Width = 1;
            this.btnCadClientes.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCadClientes.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCadClientes.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadClientes.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCadClientes.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnCadClientes.StatePressed.Back.ColorAngle = 135F;
            this.btnCadClientes.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnCadClientes.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnCadClientes.StatePressed.Border.ColorAngle = 135F;
            this.btnCadClientes.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadClientes.StatePressed.Border.Rounding = 1;
            this.btnCadClientes.StatePressed.Border.Width = 1;
            this.btnCadClientes.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCadClientes.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnCadClientes.StateTracking.Back.ColorAngle = 45F;
            this.btnCadClientes.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnCadClientes.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCadClientes.StateTracking.Border.ColorAngle = 45F;
            this.btnCadClientes.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadClientes.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadClientes.StateTracking.Border.Rounding = 1;
            this.btnCadClientes.StateTracking.Border.Width = 1;
            this.btnCadClientes.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnCadClientes.TabIndex = 557;
            this.btnCadClientes.Values.ImageStates.ImageCheckedNormal = null;
            this.btnCadClientes.Values.ImageStates.ImageCheckedPressed = null;
            this.btnCadClientes.Values.ImageStates.ImageCheckedTracking = null;
            this.btnCadClientes.Values.ImageStates.ImageNormal = global::SisControl.Properties.Resources.Cliente24;
            this.btnCadClientes.Values.Text = "Clientes";
            this.btnCadClientes.Click += new System.EventHandler(this.btnCadClientes_Click);
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSair.Location = new System.Drawing.Point(9, 391);
            this.btnSair.Name = "btnSair";
            this.btnSair.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnSair.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.OverrideDefault.Back.ColorAngle = 45F;
            this.btnSair.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.OverrideDefault.Border.ColorAngle = 45F;
            this.btnSair.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSair.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSair.OverrideDefault.Border.Rounding = 1;
            this.btnSair.OverrideDefault.Border.Width = 1;
            this.btnSair.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnSair.Size = new System.Drawing.Size(190, 30);
            this.btnSair.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnSair.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnSair.StateCommon.Back.ColorAngle = 45F;
            this.btnSair.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSair.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSair.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSair.StateCommon.Border.Rounding = 1;
            this.btnSair.StateCommon.Border.Width = 1;
            this.btnSair.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnSair.StatePressed.Back.ColorAngle = 135F;
            this.btnSair.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnSair.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnSair.StatePressed.Border.ColorAngle = 135F;
            this.btnSair.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSair.StatePressed.Border.Rounding = 1;
            this.btnSair.StatePressed.Border.Width = 1;
            this.btnSair.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnSair.StateTracking.Back.ColorAngle = 45F;
            this.btnSair.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSair.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateTracking.Border.ColorAngle = 45F;
            this.btnSair.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSair.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSair.StateTracking.Border.Rounding = 1;
            this.btnSair.StateTracking.Border.Width = 1;
            this.btnSair.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSair.TabIndex = 560;
            this.btnSair.Values.Image = global::SisControl.Properties.Resources.Sair24;
            this.btnSair.Values.ImageStates.ImageCheckedNormal = null;
            this.btnSair.Values.ImageStates.ImageCheckedPressed = null;
            this.btnSair.Values.ImageStates.ImageCheckedTracking = null;
            this.btnSair.Values.ImageStates.ImageNormal = global::SisControl.Properties.Resources.Sair24;
            this.btnSair.Values.Text = "&Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnProdutos.Location = new System.Drawing.Point(9, 175);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnProdutos.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnProdutos.OverrideDefault.Back.ColorAngle = 45F;
            this.btnProdutos.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnProdutos.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnProdutos.OverrideDefault.Border.ColorAngle = 45F;
            this.btnProdutos.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnProdutos.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnProdutos.OverrideDefault.Border.Rounding = 1;
            this.btnProdutos.OverrideDefault.Border.Width = 1;
            this.btnProdutos.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnProdutos.Size = new System.Drawing.Size(190, 30);
            this.btnProdutos.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnProdutos.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnProdutos.StateCommon.Back.ColorAngle = 45F;
            this.btnProdutos.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnProdutos.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnProdutos.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnProdutos.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnProdutos.StateCommon.Border.Rounding = 1;
            this.btnProdutos.StateCommon.Border.Width = 1;
            this.btnProdutos.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnProdutos.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnProdutos.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdutos.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnProdutos.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnProdutos.StatePressed.Back.ColorAngle = 135F;
            this.btnProdutos.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnProdutos.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnProdutos.StatePressed.Border.ColorAngle = 135F;
            this.btnProdutos.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnProdutos.StatePressed.Border.Rounding = 1;
            this.btnProdutos.StatePressed.Border.Width = 1;
            this.btnProdutos.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnProdutos.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnProdutos.StateTracking.Back.ColorAngle = 45F;
            this.btnProdutos.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnProdutos.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnProdutos.StateTracking.Border.ColorAngle = 45F;
            this.btnProdutos.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnProdutos.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnProdutos.StateTracking.Border.Rounding = 1;
            this.btnProdutos.StateTracking.Border.Width = 1;
            this.btnProdutos.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnProdutos.TabIndex = 558;
            this.btnProdutos.Values.ImageStates.ImageCheckedNormal = null;
            this.btnProdutos.Values.ImageStates.ImageCheckedPressed = null;
            this.btnProdutos.Values.ImageStates.ImageCheckedTracking = null;
            this.btnProdutos.Values.ImageStates.ImageNormal = global::SisControl.Properties.Resources.caixas;
            this.btnProdutos.Values.Text = "Produtos";
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnContasPagar
            // 
            this.btnContasPagar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnContasPagar.Location = new System.Drawing.Point(9, 247);
            this.btnContasPagar.Name = "btnContasPagar";
            this.btnContasPagar.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnContasPagar.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasPagar.OverrideDefault.Back.ColorAngle = 45F;
            this.btnContasPagar.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasPagar.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasPagar.OverrideDefault.Border.ColorAngle = 45F;
            this.btnContasPagar.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnContasPagar.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnContasPagar.OverrideDefault.Border.Rounding = 1;
            this.btnContasPagar.OverrideDefault.Border.Width = 1;
            this.btnContasPagar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnContasPagar.Size = new System.Drawing.Size(190, 30);
            this.btnContasPagar.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnContasPagar.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnContasPagar.StateCommon.Back.ColorAngle = 45F;
            this.btnContasPagar.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnContasPagar.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasPagar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnContasPagar.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnContasPagar.StateCommon.Border.Rounding = 1;
            this.btnContasPagar.StateCommon.Border.Width = 1;
            this.btnContasPagar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasPagar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasPagar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContasPagar.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasPagar.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnContasPagar.StatePressed.Back.ColorAngle = 135F;
            this.btnContasPagar.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnContasPagar.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnContasPagar.StatePressed.Border.ColorAngle = 135F;
            this.btnContasPagar.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnContasPagar.StatePressed.Border.Rounding = 1;
            this.btnContasPagar.StatePressed.Border.Width = 1;
            this.btnContasPagar.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasPagar.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnContasPagar.StateTracking.Back.ColorAngle = 45F;
            this.btnContasPagar.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnContasPagar.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnContasPagar.StateTracking.Border.ColorAngle = 45F;
            this.btnContasPagar.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnContasPagar.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnContasPagar.StateTracking.Border.Rounding = 1;
            this.btnContasPagar.StateTracking.Border.Width = 1;
            this.btnContasPagar.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnContasPagar.TabIndex = 560;
            this.btnContasPagar.Values.ImageStates.ImageCheckedNormal = null;
            this.btnContasPagar.Values.ImageStates.ImageCheckedPressed = null;
            this.btnContasPagar.Values.ImageStates.ImageCheckedTracking = null;
            this.btnContasPagar.Values.ImageStates.ImageNormal = global::SisControl.Properties.Resources.Pagar24;
            this.btnContasPagar.Values.Text = "Pagar";
            this.btnContasPagar.Click += new System.EventHandler(this.btnContasPagar_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnVendas.Location = new System.Drawing.Point(9, 211);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnVendas.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnVendas.OverrideDefault.Back.ColorAngle = 45F;
            this.btnVendas.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnVendas.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnVendas.OverrideDefault.Border.ColorAngle = 45F;
            this.btnVendas.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnVendas.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnVendas.OverrideDefault.Border.Rounding = 1;
            this.btnVendas.OverrideDefault.Border.Width = 1;
            this.btnVendas.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnVendas.Size = new System.Drawing.Size(190, 30);
            this.btnVendas.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnVendas.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnVendas.StateCommon.Back.ColorAngle = 45F;
            this.btnVendas.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnVendas.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnVendas.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnVendas.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnVendas.StateCommon.Border.Rounding = 1;
            this.btnVendas.StateCommon.Border.Width = 1;
            this.btnVendas.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnVendas.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnVendas.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendas.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnVendas.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnVendas.StatePressed.Back.ColorAngle = 135F;
            this.btnVendas.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnVendas.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnVendas.StatePressed.Border.ColorAngle = 135F;
            this.btnVendas.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnVendas.StatePressed.Border.Rounding = 1;
            this.btnVendas.StatePressed.Border.Width = 1;
            this.btnVendas.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnVendas.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnVendas.StateTracking.Back.ColorAngle = 45F;
            this.btnVendas.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnVendas.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnVendas.StateTracking.Border.ColorAngle = 45F;
            this.btnVendas.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnVendas.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnVendas.StateTracking.Border.Rounding = 1;
            this.btnVendas.StateTracking.Border.Width = 1;
            this.btnVendas.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnVendas.TabIndex = 559;
            this.btnVendas.Values.ImageStates.ImageCheckedNormal = null;
            this.btnVendas.Values.ImageStates.ImageCheckedPressed = null;
            this.btnVendas.Values.ImageStates.ImageCheckedTracking = null;
            this.btnVendas.Values.ImageStates.ImageNormal = global::SisControl.Properties.Resources.Venda24;
            this.btnVendas.Values.Text = "Vendas";
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnFerramentas
            // 
            this.btnFerramentas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFerramentas.Location = new System.Drawing.Point(9, 355);
            this.btnFerramentas.Name = "btnFerramentas";
            this.btnFerramentas.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnFerramentas.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFerramentas.OverrideDefault.Back.ColorAngle = 45F;
            this.btnFerramentas.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFerramentas.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFerramentas.OverrideDefault.Border.ColorAngle = 45F;
            this.btnFerramentas.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFerramentas.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFerramentas.OverrideDefault.Border.Rounding = 1;
            this.btnFerramentas.OverrideDefault.Border.Width = 1;
            this.btnFerramentas.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnFerramentas.Size = new System.Drawing.Size(190, 30);
            this.btnFerramentas.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnFerramentas.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnFerramentas.StateCommon.Back.ColorAngle = 45F;
            this.btnFerramentas.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnFerramentas.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFerramentas.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFerramentas.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFerramentas.StateCommon.Border.Rounding = 1;
            this.btnFerramentas.StateCommon.Border.Width = 1;
            this.btnFerramentas.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFerramentas.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFerramentas.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFerramentas.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFerramentas.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnFerramentas.StatePressed.Back.ColorAngle = 135F;
            this.btnFerramentas.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnFerramentas.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnFerramentas.StatePressed.Border.ColorAngle = 135F;
            this.btnFerramentas.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFerramentas.StatePressed.Border.Rounding = 1;
            this.btnFerramentas.StatePressed.Border.Width = 1;
            this.btnFerramentas.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFerramentas.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnFerramentas.StateTracking.Back.ColorAngle = 45F;
            this.btnFerramentas.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnFerramentas.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFerramentas.StateTracking.Border.ColorAngle = 45F;
            this.btnFerramentas.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFerramentas.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFerramentas.StateTracking.Border.Rounding = 1;
            this.btnFerramentas.StateTracking.Border.Width = 1;
            this.btnFerramentas.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnFerramentas.TabIndex = 559;
            this.btnFerramentas.Values.Image = global::SisControl.Properties.Resources.Ferramentas24;
            this.btnFerramentas.Values.Text = "Ferramentas";
            this.btnFerramentas.Click += new System.EventHandler(this.btnFerramentas_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedor.Location = new System.Drawing.Point(205, 27);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1023, 617);
            this.panelContenedor.TabIndex = 555;
            // 
            // FrmTelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 666);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.MenuVertical);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmTelaPrincipal";
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Text = "SISCONTROL - Sistema de Controle de Contas a Pagar e Receber - ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuVertical)).EndInit();
            this.MenuVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContenedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel lblEstação;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel10;
        private System.Windows.Forms.ToolStripStatusLabel lblData;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel11;
        private System.Windows.Forms.ToolStripStatusLabel lblHoraAtual;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornecedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manutençãoDeCadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fornecedorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fabricanteToolStripMenuItem;
        private System.Windows.Forms.StatusStrip miniToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusData;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusHora;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusExecutablePath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLocation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCommonAppDataPath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioLogado;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel MenuVertical;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUsuarios;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFornecedor;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCadClientes;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnProdutos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRelatorio;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnContasReceber;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnContasPagar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnVendas;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSair;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFerramentas;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelContenedor;
        private System.Windows.Forms.ToolStripMenuItem telaUiToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

