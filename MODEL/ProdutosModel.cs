using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    internal class ProdutosModel
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal Lucro { get; set; }
        public decimal PrecoDeVenda { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public DateTime DataDeEntrada { get; set; }
        public int CategoriaID { get; set; }
        public int FabricanteID { get; set; }
        public string UnidadeDeMedida { get; set; }
        public string Status { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public byte[] Imagem { get; set; }
        public int FornecedorID { get; set; }
        public string Referencia { get; set; }
    }
}
