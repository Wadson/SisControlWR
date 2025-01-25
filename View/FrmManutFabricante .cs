using SisControl.BLL;
using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;

namespace SisControl.View
{
    public partial class FrmManutFabricante : SisControl.FrmBaseManutencao
    {
        private new string StatusOperacao;
        private FabricanteDal fabricanteDal;
        public FrmManutFabricante(string statusOperacao)
        {
            this.StatusOperacao = statusOperacao;
            InitializeComponent();
        }
        public void ListarFabricante()
        {
            FabricanteDal dao = new FabricanteDal();
            dataGridPesquisar.DataSource = dao.listarFabricante();

            PersonalizarDataGridView(dataGridPesquisar);
        }

        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
        }
       
        public void PersonalizarDataGridView(DataGridView dgv)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            // Esconder a coluna de cabeçalho de linha
            //dgv.RowHeadersVisible = false;

            //this.dataGridPesquisar.Columns[0].Name = "FabricanteID"   ;
            //this.dataGridPesquisar.Columns[1].Name = "NomeFabricante" ;            
            //this.dataGridPesquisar.Columns[2].Name = "Endereco"      ;
            //this.dataGridPesquisar.Columns[3].Name = "Telefone"    ;
            // Ocultar a coluna, mas ainda manter o acesso aos valores
            dataGridPesquisar.Columns["FabricanteID"].Visible = false;
        }

        private void CarregaDados()
        {
            FrmCadFabricante frm = new  FrmCadFabricante(StatusOperacao);

            if (StatusOperacao == "NOVO")
            {
                frm.Text = "SISCONTROL - NOVO CADASTRO DE CLIENTE";
                StatusOperacao = "NOVO";
                frm.ShowDialog();

                ((FrmManutFabricante)Application.OpenForms["FrmManutFabricante"]).HabilitarTimer(true);
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
                        frm.txtFabricanteID.Text = dataGridPesquisar.CurrentRow.Cells["FabricanteID"].Value.ToString();
                        frm.txtNomeFabricante.Text = dataGridPesquisar.CurrentRow.Cells["NomeFabricante"].Value.ToString();
                        //frm.txtEndereco.Text = dataGridViewFabricantes.CurrentRow.Cells["Endereco"].Value.ToString();


                        //string NumeroFormatoTelefone = dataGridViewFabricantes.SelectedRows[0].Cells["Telefone"].Value.ToString();
                        //frm.txtTelefone. = Utilitario.FormatPhoneNumber(NumeroFormatoTelefone);

                        string NumeroFormatoTelefone = dataGridPesquisar.CurrentRow.Cells["Telefone"].Value.ToString();
                        frm.txtTelefone.Text = NumeroFormatoTelefone;

                        // Suponha que dataGridView1 é seu DataGridView e a coluna "Endereco" contém o endereço concatenado
                        if (dataGridPesquisar.SelectedRows.Count > 0)
                        {
                            string enderecoCompleto = dataGridPesquisar.SelectedRows[0].Cells["Endereco"].Value.ToString();

                            // Separar a string do endereço utilizando a vírgula como delimitador
                            string[] partesEndereco = enderecoCompleto.Split(new[] { ", " }, StringSplitOptions.None);

                            // Preencher os TextBox com as partes separadas do endereço
                            frm.txtEndereco.Text = partesEndereco.Length > 0 ? partesEndereco[0] : "";
                            frm.txtNumero.Text = partesEndereco.Length > 1 ? partesEndereco[1] : "";
                            frm.txtBairro.Text = partesEndereco.Length > 2 ? partesEndereco[2] : "";
                            frm.txtCidade.Text = partesEndereco.Length > 3 ? partesEndereco[3] : "";
                            frm.txtEstado.Text = partesEndereco.Length > 4 ? partesEndereco[4] : "";
                        }
                        else
                        {
                            MessageBox.Show("Por favor, selecione uma linha no DataGridView para alterar.");
                        }

                        frm.Text = "SISCONTROL - ALTERAR REGISTRO";
                        StatusOperacao = "ALTERAR";
                        frm.btnSalvar.Text = "Alterar";
                        frm.btnNovo.Enabled = false;
                        
                        
                        frm.ShowDialog();                        
                    }
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
                        frm.txtFabricanteID.Text = dataGridPesquisar.CurrentRow.Cells["FabricanteID"].Value.ToString();
                        frm.txtNomeFabricante.Text = dataGridPesquisar.CurrentRow.Cells["NomeFabricante"].Value.ToString();
                        //frm.txtEndereco.Text = dataGridViewFabricantes.CurrentRow.Cells["Endereco"].Value.ToString();
                        frm.txtTelefone.Text = dataGridPesquisar.CurrentRow.Cells["Telefone"].Value.ToString();

                        // Suponha que dataGridView1 é seu DataGridView e a coluna "Endereco" contém o endereço concatenado
                        if (dataGridPesquisar.SelectedRows.Count > 0)
                        {
                            string enderecoCompleto = dataGridPesquisar.SelectedRows[0].Cells["Endereco"].Value.ToString();

                            // Separar a string do endereço utilizando a vírgula como delimitador
                            string[] partesEndereco = enderecoCompleto.Split(new[] { ", " }, StringSplitOptions.None);

                            // Preencher os TextBox com as partes separadas do endereço
                            frm.txtEndereco.Text = partesEndereco.Length > 0 ? partesEndereco[0] : "";
                            frm.txtNumero.Text = partesEndereco.Length > 1 ? partesEndereco[1] : "";
                            frm.txtBairro.Text = partesEndereco.Length > 2 ? partesEndereco[2] : "";
                            frm.txtCidade.Text = partesEndereco.Length > 3 ? partesEndereco[3] : "";
                            frm.txtEstado.Text = partesEndereco.Length > 4 ? partesEndereco[4] : "";
                        }
                        else
                        {
                            MessageBox.Show("Por favor, selecione uma linha no DataGridView para alterar.");
                        }
                        frm.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                        StatusOperacao = "EXCLUSÃO";
                        frm.btnSalvar.Text = "Excluir";
                        frm.btnNovo.Enabled = false;
                       
                        frm.txtFabricanteID.Enabled = false;
                        frm.txtNomeFabricante.Enabled = false;
                        frm.txtEndereco.Enabled = false;                        
                        frm.txtTelefone.Enabled = false; 
                        frm.txtEstado.Enabled = false;
                        frm.txtCidade.Enabled = false;
                        frm.txtBairro.Enabled = false;
                        frm.txtNumero.Enabled = false;

                        frm.ShowDialog();
                        ((FrmManutFabricante)Application.OpenForms["FrmManutFabricante"]).HabilitarTimer(true);
                    }                  
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }       
            }
            ListarFabricante();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            ListarFabricante();
            timer1.Enabled = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {            
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            FabricanteDal dao = new FabricanteDal();
            dataGridPesquisar.DataSource = dao.PesquisarPorNome(nome);
        }

        private void FrmManutCliente_Load(object sender, EventArgs e)
        {
            ListarFabricante();
        }
    }
}
