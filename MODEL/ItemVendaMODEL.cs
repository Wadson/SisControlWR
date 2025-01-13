using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    public class ItemVendaModel
    {
        //public int ItemVendaID { get; set; }
        public Guid ItemVendaID { get; set; } // Usando GUID como chave primária
        public int VendaID { get; set; }
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public VendaModel Venda { get; set; }
    }
}
