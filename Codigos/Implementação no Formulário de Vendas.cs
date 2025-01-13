using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

public class VendaForm : Form
{
    private TextBox txtClienteId, txtTotal;
    private DateTimePicker dtpDataVenda;
    private DataGridView dgvItensVenda, dgvParcelas;
    private Button btnSalvar;

    public VendaForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.txtClienteId = new System.Windows.Forms.TextBox();
        this.txtTotal = new System.Windows.Forms.TextBox();
        this.dtpDataVenda = new System.Windows.Forms.DateTimePicker();
        this.dgvItensVenda = new System.Windows.Forms.DataGridView();
        this.dgvParcelas = new System.Windows.Forms.DataGridView();
        this.btnSalvar = new System.Windows.Forms.Button();

        // Configurar controles
        this.txtClienteId.Location = new System.Drawing.Point(15, 15);
        this.txtClienteId.PlaceholderText = "Cliente ID";

        this.txtTotal.Location = new System.Drawing.Point(15, 45);
        this.txtTotal.PlaceholderText = "Total";

        this.dtpDataVenda.Location = new System.Drawing.Point(15, 75);
        
        this.dgvItensVenda.Location = new System.Drawing.Point(15, 105);
        this.dgvItensVenda.Size = new System.Drawing.Size(400, 150);
        
        this.dgvParcelas.Location = new System.Drawing.Point(15, 265);
        this.dgvParcelas.Size = new System.Drawing.Size(400, 150);
        
        this.btnSalvar.Location = new System.Drawing.Point(15, 425);
        this.btnSalvar.Text = "Salvar";
        this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);

        // Adicionar controles ao formulário
        this.Controls.Add(this.txtClienteId);
        this.Controls.Add(this.txtTotal);
        this.Controls.Add(this.dtpDataVenda);
        this.Controls.Add(this.dgvItensVenda);
        this.Controls.Add(this.dgvParcelas);
        this.Controls.Add(this.btnSalvar);

        // Configurar colunas dos DataGridViews
        this.dgvItensVenda.Columns.Add("ProdutoId", "Produto ID");
        this.dgvItensVenda.Columns.Add("Quantidade", "Quantidade");
        this.dgvItensVenda.Columns.Add("Preco", "Preço");

        this.dgvParcelas.Columns.Add("NumeroParcela", "Número da Parcela");
        this.dgvParcelas.Columns.Add("DataVencimento", "Data de Vencimento");
        this.dgvParcelas.Columns.Add("Valor", "Valor");

        // Configurações do formulário
        this.ClientSize = new System.Drawing.Size(450, 500);
        this.Text = "Formulário de Vendas";
    }

    private void BtnSalvar_Click(object sender, EventArgs e)
    {
        // Capturar dados do formulário
        var venda = new Venda
        {
            VendaId = Guid.NewGuid(),
            DataVenda = dtpDataVenda.Value,
            ClienteId = int.Parse(txtClienteId.Text),
            Total = decimal.Parse(txtTotal.Text),
            ItensVenda = new List<ItemVenda>(),
            Parcelas = new List<Parcela>()
        };

        foreach (DataGridViewRow row in dgvItensVenda.Rows)
        {
            if (row.Cells["ProdutoId"].Value != null)
            {
                var itemVenda = new ItemVenda
                {
                    ItemVendaId = Guid.NewGuid(),
                    VendaId = venda.VendaId,
                    ProdutoId = int.Parse(row.Cells["ProdutoId"].Value.ToString()),
                    Quantidade = int.Parse(row.Cells["Quantidade"].Value.ToString()),
                    Preco = decimal.Parse(row.Cells["Preco"].Value.ToString())
                };
                venda.ItensVenda.Add(itemVenda);
            }
        }

        foreach (DataGridViewRow row in dgvParcelas.Rows)
        {
            if (row.Cells["NumeroParcela"].Value != null)
            {
                var parcela = new Parcela
                {
                    ParcelaId = Guid.NewGuid(),
                    VendaId = venda.VendaId,
                    NumeroParcela = int.Parse(row.Cells["NumeroParcela"].Value.ToString()),
                    DataVencimento = DateTime.Parse(row.Cells["DataVencimento"].Value.ToString()),
                    Valor = decimal.Parse(row.Cells["Valor"].Value.ToString()),
                    ValorRecebido = 0,
                    SaldoRestante = decimal.Parse(row.Cells["Valor"].Value.ToString()),
                    Pago = false
                };
                venda.Parcelas.Add(parcela);
            }
        }

        // Inserir venda no banco de dados
        var vendaService = new VendaService();
        vendaService.InserirVenda(venda);

        MessageBox.Show("Venda inserida com sucesso!");
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new VendaForm());
    }
}
