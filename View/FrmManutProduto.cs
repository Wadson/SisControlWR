using SisControl.BLL;
using SisControl.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SisControl.View
{
    public partial class FrmManutProduto : SisControl.FrmBaseManutencao
    {
        private new string StatusOperacao;
        public FrmManutProduto()
        {            
            InitializeComponent();
        }

        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
        }
        public void ListarProduto()
        {
            ProdutoBLL objetoBll = new ProdutoBLL();
            dataGridPesquisar.DataSource = objetoBll.Listar();
            PersonalizarDataGridView(dataGridPesquisar);
        }
        public void PersonalizarDataGridView(DataGridView dgv)
        {
            // Configuração dos cabeçalhos das colunas
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false; // Necessário para aplicar as cores personalizadas no cabeçalho

            // Estilo alternado das linhas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Alinhamento e fonte das células
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Font = new Font("Arial", 10);

            //Alinhar o as colunas

            dgv.Columns["ProdutoID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgv.Columns["QuantidadeEmEstoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            // Ajustar colunas automaticamente
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Tornar o grid somente leitura
            dgv.ReadOnly = true;

            // Estilo das bordas das células

            //Adiciona Dock para expandir o DataGridView
            dgv.Dock = DockStyle.Fill;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Estilo da seleção das células
            dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            // Esconder a coluna de cabeçalho de linha
            //dgv.RowHeadersVisible = false;

            // Cor do grid
            dgv.GridColor = Color.Black;

            dgv.Columns[0].Name = "ProdutoID";
            dgv.Columns[1].Name = "NomeProduto";
            dgv.Columns[2].Name = "Descricao";
            dgv.Columns[3].Name = "PrecoCusto";
            dgv.Columns[4].Name = "Lucro";
            dgv.Columns[5].Name = "PrecoDeVenda";
            dgv.Columns[6].Name = "QuantidadeEmEstoque";
            dgv.Columns[7].Name = "DataDeEntrada";
            dgv.Columns[8].Name = "CategoriaID";
            dgv.Columns[9].Name = "FabricanteID";
            dgv.Columns[10].Name = "UnidadeDeMedida";
            dgv.Columns[11].Name = "Status";
            dgv.Columns[12].Name = "DataDeVencimento";
            dgv.Columns[13].Name = "Imagem";
            dgv.Columns[14].Name = "FornecedorID";
            dgv.Columns[15].Name = "Referencia";

            // Centralizar colunas de IDs e Quantidade
            dgv.Columns["ProdutoID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["QuantidadeEmEstoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["CategoriaID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["FabricanteID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["FornecedorID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        private void CarregaDados()
        {
            FrmCadProdutos frm = new  FrmCadProdutos(StatusOperacao);

            if (StatusOperacao == "NOVO")
            {
                frm.Text = "SISCONTROL - NOVO CADASTRO DE PRODUTOS";
                StatusOperacao = "NOVO";
                frm.ShowDialog();

                ((FrmManutProduto)System.Windows.Forms.Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
            }
            if (StatusOperacao == "ALTERAR")
            {
                try
                {
                    // Verificar se a DataGridView contém alguma linha
                    if (dataGridPesquisar.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                    else
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        frm.txtProdutoID.Text = dataGridPesquisar.CurrentRow.Cells["ProdutoID"].Value.ToString();
                        frm.txtNomeProduto.Text = dataGridPesquisar.CurrentRow.Cells["NomeProduto"].Value.ToString();
                        frm.txtDescricao.Text = dataGridPesquisar.CurrentRow.Cells["Descricao"].Value.ToString();
                        frm.txtPrecoCusto.Text = dataGridPesquisar.CurrentRow.Cells["PrecoCusto"].Value.ToString();
                        frm.txtLucro.Text = dataGridPesquisar.CurrentRow.Cells["Lucro"].Value.ToString();
                        frm.txtPrecoDeVenda.Text = dataGridPesquisar.CurrentRow.Cells["PrecoDeVenda"].Value.ToString();
                        frm.txtQuantidadeEmEstoque.Text = dataGridPesquisar.CurrentRow.Cells["QuantidadeEmEstoque"].Value.ToString();
                        frm.dtpDataDeEntrada.Text = dataGridPesquisar.CurrentRow.Cells["DataDeEntrada"].Value.ToString();
                        frm.CategoriaID = int.Parse(dataGridPesquisar.CurrentRow.Cells["CategoriaID"].Value.ToString());
                        frm.FabricanteID = int.Parse(dataGridPesquisar.CurrentRow.Cells["FabricanteID"].Value.ToString());
                        frm.cmbUnidadeDeMedida.Text = dataGridPesquisar.CurrentRow.Cells["UnidadeDeMedida"].Value.ToString();
                        frm.cmbStatus.Text = dataGridPesquisar.CurrentRow.Cells["Status"].Value.ToString();
                        frm.dtpDataDeVencimento.Text = dataGridPesquisar.CurrentRow.Cells["DataDeVencimento"].Value.ToString();
                        frm.txtFornecedorID.Text = dataGridPesquisar.CurrentRow.Cells["FornecedorID"].Value.ToString();
                        frm.txtReferência.Text = dataGridPesquisar.CurrentRow.Cells["Referencia"].Value.ToString();

                        frm.Text = "SISCONTROL - ALTERAR REGISTRO";
                        StatusOperacao = "ALTERAR";
                        frm.btnSalvar.Text = "Alterar";
                        frm.btnNovo.Enabled = false;
                        frm.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        frm.btnSalvar.Image = Properties.Resources.Alterar;
                        frm.ShowDialog();
                        ((FrmManutProduto)System.Windows.Forms.Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
                    }

                    //// Execução do código desejado
                    //foreach (DataGridViewRow row in dataGridPesquisar.Rows)
                    //{


                    //}
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                try
                {
                    // Verificar se a DataGridView contém alguma linha
                    if (dataGridPesquisar.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        frm.txtProdutoID.Text = dataGridPesquisar.CurrentRow.Cells["ProdutoID"].Value.ToString();
                        frm.txtNomeProduto.Text = dataGridPesquisar.CurrentRow.Cells["NomeProduto"].Value.ToString();
                        frm.txtDescricao.Text = dataGridPesquisar.CurrentRow.Cells["Descricao"].Value.ToString();
                        frm.txtPrecoCusto.Text = dataGridPesquisar.CurrentRow.Cells["PrecoCusto"].Value.ToString();
                        frm.txtLucro.Text = dataGridPesquisar.CurrentRow.Cells["Lucro"].Value.ToString();
                        frm.txtPrecoDeVenda.Text = dataGridPesquisar.CurrentRow.Cells["PrecoDeVenda"].Value.ToString();
                        frm.txtQuantidadeEmEstoque.Text = dataGridPesquisar.CurrentRow.Cells["QuantidadeEmEstoque"].Value.ToString();
                        frm.dtpDataDeEntrada.Text = dataGridPesquisar.CurrentRow.Cells["DataDeEntrada"].Value.ToString();
                        frm.CategoriaID = int.Parse(dataGridPesquisar.CurrentRow.Cells["CategoriaID"].Value.ToString());
                        frm.FabricanteID = int.Parse(dataGridPesquisar.CurrentRow.Cells["FabricanteID"].Value.ToString());
                        frm.cmbUnidadeDeMedida.Text = dataGridPesquisar.CurrentRow.Cells["UnidadeDeMedida"].Value.ToString();
                        frm.cmbStatus.Text = dataGridPesquisar.CurrentRow.Cells["Status"].Value.ToString();
                        frm.dtpDataDeVencimento.Text = dataGridPesquisar.CurrentRow.Cells["DataDeVencimento"].Value.ToString();
                        frm.txtFornecedorID.Text = dataGridPesquisar.CurrentRow.Cells["FornecedorID"].Value.ToString();
                        frm.txtReferência.Text = dataGridPesquisar.CurrentRow.Cells["Referencia"].Value.ToString();

                        frm.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";                        
                        frm.btnSalvar.Text = "Excluir";
                        frm.btnNovo.Enabled = false;
                        frm.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        frm.btnSalvar.Image = Properties.Resources.Excluir2;

                        // Desabilitar os campos
                        frm.txtProdutoID.Enabled = false;
                        frm.txtNomeProduto.Enabled = false;
                        frm.txtDescricao.Enabled = false;
                        frm.txtPrecoCusto.Enabled = false;
                        frm.txtLucro.Enabled = false;
                        frm.txtPrecoDeVenda.Enabled = false;
                        frm.txtQuantidadeEmEstoque.Enabled = false;
                        frm.dtpDataDeEntrada.Enabled = false;                        
                        frm.cmbUnidadeDeMedida.Enabled = false;
                        frm.cmbStatus.Enabled = false;
                        frm.dtpDataDeVencimento.Enabled = false;
                        frm.txtFornecedorID.Enabled = false;

                        frm.ShowDialog();
                        ((FrmManutProduto)System.Windows.Forms.Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
                    }
                    // Execução do código desejado
                    //foreach (DataGridViewRow row in dataGridPesquisar.Rows)
                    //{
                    //}
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            ProdutosDALL objetoDal = new ProdutosDALL();

            dataGridPesquisar.DataSource = objetoDal.PesquisarPorNome(nome);
            PersonalizarDataGridView(dataGridPesquisar);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            StatusOperacao = "NOVO";
            CarregaDados();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            StatusOperacao = "ALTERAR";
            CarregaDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            StatusOperacao = "EXCLUSÃO";
            CarregaDados();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ListarProduto();
            timer1.Enabled = false;
        }

        private void FrmManutProduto_Load(object sender, EventArgs e)
        {
            ListarProduto();
        }

        private void dataGridPesquisar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dataGridPesquisar.Columns[e.ColumnIndex].Name == "PrecoCusto" || dataGridPesquisar.Columns[e.ColumnIndex].Name == "PrecoVenda") && e.Value != null)
            {
                decimal valor = (decimal)e.Value;
                e.Value = valor.ToString("C", CultureInfo.CurrentCulture);
                e.FormattingApplied = true;
            }
        }
    }
}
