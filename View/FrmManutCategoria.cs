﻿using SisControl.BLL;
using SisControl.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmManutCategoria : SisControl.FrmBaseManutencao
    {
        private new string StatusOperacao;
        public FrmManutCategoria(string statusOperacao)
        {
            this.StatusOperacao = statusOperacao;
            InitializeComponent();            
        }
        private void CarregaDados()
        {
            FrmCadCategoria cadCategoria = new FrmCadCategoria(StatusOperacao);

            if (StatusOperacao == "NOVO")
            {
                cadCategoria.Text = "SISCONTROL - NOVO CADASTRO DE CATEGORIA";
                StatusOperacao = "NOVO";
                cadCategoria.ShowDialog();

                ((FrmManutCategoria)Application.OpenForms["FrmManutCategoria"]).HabilitarTimer(true);
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

                    // Execução do código desejado
                    foreach (DataGridViewRow row in dataGridPesquisar.Rows)
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        cadCategoria.txtCodigo.Text = dataGridPesquisar.CurrentRow.Cells["CategoriaID"].Value.ToString();
                        cadCategoria.txtNome.Text = dataGridPesquisar.CurrentRow.Cells["NomeCategoria"].Value.ToString();

                        cadCategoria.Text = "SISCONTROL - ALTERAR REGISTRO";
                        StatusOperacao = "ALTERAR";
                        cadCategoria.btnSalvar.Text = "Alterar";
                        cadCategoria.btnNovo.Enabled = false;
                       
                        cadCategoria.ShowDialog();
                        ((FrmManutCategoria)Application.OpenForms["FrmManutCategoria"]).HabilitarTimer(true);

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

                    // Execução do código desejado
                    foreach (DataGridViewRow row in dataGridPesquisar.Rows)
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        cadCategoria.txtCodigo.Text = dataGridPesquisar.CurrentRow.Cells["CategoriaID"].Value.ToString();
                        cadCategoria.txtNome.Text = dataGridPesquisar.CurrentRow.Cells["NomeCategoria"].Value.ToString();

                        cadCategoria.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                        StatusOperacao = "EXCLUSÃO";
                        cadCategoria.btnSalvar.Text = "Excluir";
                        cadCategoria.btnNovo.Enabled = false;                       

                        cadCategoria.txtCodigo.Enabled = false;
                        cadCategoria.txtNome.Enabled = false;

                        cadCategoria.ShowDialog();
                        ((FrmManutCategoria)Application.OpenForms["FrmManutCategoria"]).HabilitarTimer(true);

                    }
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
            }
            ListarCategoria();

           
        }
   
        public void PersonalizarDataGridView(DataGridView dgv)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            // Esconder a coluna de cabeçalho de linha
            //dgv.RowHeadersVisible = false;

            // Cor do grid
            dgv.GridColor = Color.Black;

            this.dataGridPesquisar.Columns[0].Name = "CategoriaID";
            this.dataGridPesquisar.Columns[1].Name = "NomeCategoria";

            // Definir largura fixa das colunas
            dgv.Columns["CategoriaID"].Width = 150;
            dgv.Columns["NomeCategoria"].Width = 350;
            
        }

        public void ListarCategoria()
        {
            CategoriaBLL categoriaBll = new CategoriaBLL();
            dataGridPesquisar.DataSource = categoriaBll.Listar();
            PersonalizarDataGridView(dataGridPesquisar);
        }
        private void FrmManutCategoria_Load(object sender, EventArgs e)
        {
            ListarCategoria();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            CategoriaDALL CategoriaDao = new CategoriaDALL();

            dataGridPesquisar.DataSource = CategoriaDao.PesquisarPorNome(nome);
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
        }
        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ListarCategoria();
            timer1.Enabled = false;
        }
    }
}
