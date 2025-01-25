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
        public string Referencia { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal Lucro { get; set; }
        public decimal PrecoDeVenda { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public DateTime DataDeEntrada { get; set; } 
        public string Status { get; set; }
        public byte[] Imagem { get; set; }
       
        
    }
}
