using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.BLL
{
    internal class ProdutosBll
    {
        private ProdutosDALL dal = new ProdutosDALL();

        public void SalvarProdutos(ProdutosModel produto)
        {
            dal.SalvarProduto(produto);
        }

        public void AtualizaProduto(ProdutosModel produto)
        {
            dal.AtualizaProduto(produto);
        }

        public DataTable PesquisarPorNome(string nome)
        {
            return dal.PesquisarPorNome(nome);
        }

        public DataTable ListaProduto()
        {
            return dal.ListaProduto();
        }
    }
}
/*
 * // Exemplo de uso em um formulário
public partial class FormProduto : Form
{
    private ProdutoBLL produtoBLL = new ProdutoBLL();

    public FormProduto()
    {
        InitializeComponent();
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
        // Criar uma nova instância de ProdutoMODEL e preencher com os dados do formulário
        ProdutoMODEL produto = new ProdutoMODEL
        {
            NomeProduto = txtNomeProduto.Text,
            Descricao = txtDescricao.Text,
            PrecoCusto = decimal.Parse(txtPrecoCusto.Text),
            Lucro = decimal.Parse(txtLucro.Text),
            PrecoDeVenda = decimal.Parse(txtPrecoDeVenda.Text),
            QuantidadeEmEstoque = int.Parse(txtQuantidadeEmEstoque.Text),
            DataDeEntrada = DateTime.Parse(txtDataDeEntrada.Text),
            CategoriaID = int.Parse(txtCategoriaID.Text),
            FabricanteID = int.Parse(txtFabricanteID.Text),
            UnidadeDeMedida = txtUnidadeDeMedida.Text,
            Status = txtStatus.Text,
            DataDeVencimento = DateTime.Parse(txtDataDeVencimento.Text),
            Imagem = (byte[])pictureBoxImagem.Image, // Exemplo de conversão para byte array
            FornecedorID = int.Parse(txtFornecedorID.Text)
        };

        // Chamar o método SalvarProduto da BLL
        produtoBLL.SalvarProduto(produto);
        MessageBox.Show("Produto salvo com sucesso!");
    }

    private void btnAtualizar_Click(object sender, EventArgs e)
    {
        // Criar uma nova instância de ProdutoMODEL e preencher com os dados do formulário
        ProdutoMODEL produto = new ProdutoMODEL
        {
            ProdutoID = int.Parse(txtProdutoID.Text),
            NomeProduto = txtNomeProduto.Text,
            Descricao = txtDescricao.Text,
            PrecoCusto = decimal.Parse(txtPrecoCusto.Text),
            Lucro = decimal.Parse(txtLucro.Text),
            PrecoDeVenda = decimal.Parse(txtPrecoDeVenda.Text),
            QuantidadeEmEstoque = int.Parse(txtQuantidadeEmEstoque.Text),
            DataDeEntrada = DateTime.Parse(txtDataDeEntrada.Text),
            CategoriaID = int.Parse(txtCategoriaID.Text),
            FabricanteID = int.Parse(txtFabricanteID.Text),
            UnidadeDeMedida = txtUnidadeDeMedida.Text,
            Status = txtStatus.Text,
            DataDeVencimento = DateTime.Parse(txtDataDeVencimento.Text),
            Imagem = (byte[])pictureBoxImagem.Image,
            FornecedorID = int.Parse(txtFornecedorID.Text)
        };

        // Chamar o método AtualizaProduto da BLL
        produtoBLL.AtualizaProduto(produto);
        MessageBox.Show("Produto atualizado com sucesso!");
    }

    private void btnPesquisar_Click(object sender, EventArgs e)
    {
        // Chamar o método PesquisarPorNome da BLL e preencher um DataGridView
        DataTable dt = produtoBLL.PesquisarPorNome(txtNomeProduto.Text);
        dgvProdutos.DataSource = dt;
    }

    private void btnListar_Click(object sender, EventArgs e)
    {
        // Chamar o método ListaProduto da BLL e preencher um DataGridView
        DataTable dt = produtoBLL.ListaProduto();
        dgvProdutos.DataSource = dt;
    }
}

 * */