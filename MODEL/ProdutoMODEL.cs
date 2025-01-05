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
        public string Descricao { get; set; }
        public decimal PrecoProduto { get; set; }
        public int Estoque { get; set; }
        public int CategoriaID { get; set; }
        public int SubCategoriaID { get; set; }
    }
}
