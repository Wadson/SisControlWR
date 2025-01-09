using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    internal class ProdutoMODEL
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int Estoque { get; set; }
    }
}
