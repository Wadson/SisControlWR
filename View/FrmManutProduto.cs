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

namespace SisControl.View
{
    public partial class FrmManutProduto : SisControl.FrmBaseManutencao
    {
        private new string StatusOperacao;
        public FrmManutProduto( string statusOperacao)
        {
            this.StatusOperacao = statusOperacao;
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
            dgv.Columns["Estoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

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
            dgv.Columns[2].Name = "PrecoCusto";
            dgv.Columns[3].Name = "Estoque";
            dgv.Columns[4].Name = "PrecoVenda";
        }       
        private void CarregaDados()
        {
            FrmCadProduto frm = new FrmCadProduto(StatusOperacao);

            if (StatusOperacao == "NOVO")
            {
                frm.Text = "SISCONTROL - NOVO CADASTRO DE PRODUTOS";
                StatusOperacao = "NOVO";
                frm.ShowDialog();

                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
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
                        frm.txtPrecoCusto.Text = dataGridPesquisar.CurrentRow.Cells["PrecoCusto"].Value.ToString();
                        frm.txtEstoque.Text = dataGridPesquisar.CurrentRow.Cells["Estoque"].Value.ToString();
                        frm.txtPrecoVenda.Text = dataGridPesquisar.CurrentRow.Cells["PrecoVenda"].Value.ToString();
                       

                        frm.Text = "SISCONTROL - ALTERAR REGISTRO";
                        StatusOperacao = "ALTERAR";
                        frm.btnSalvar.Text = "Alterar";
                        frm.btnNovo.Enabled = false;
                        frm.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        frm.btnSalvar.Image = Properties.Resources.Alterar;
                        frm.ShowDialog();
                        ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
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
                        frm.txtPrecoCusto.Text = dataGridPesquisar.CurrentRow.Cells["PrecoCusto"].Value.ToString();
                        frm.txtEstoque.Text = dataGridPesquisar.CurrentRow.Cells["Estoque"].Value.ToString();
                        frm.txtPrecoVenda.Text = dataGridPesquisar.CurrentRow.Cells["PrecoVenda"].Value.ToString();

                        frm.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";                        
                        frm.btnSalvar.Text = "Excluir";
                        frm.btnNovo.Enabled = false;
                        frm.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        frm.btnSalvar.Image = Properties.Resources.Excluir2;

                        frm.txtProdutoID.Enabled = false;
                        frm.txtNomeProduto.Enabled = false;
                        frm.txtProdutoID.Enabled = false;
                        frm.txtEstoque.Enabled = false;
                        frm.txtPrecoVenda.Enabled = false;
                        
                        frm.ShowDialog();
                        ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
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
