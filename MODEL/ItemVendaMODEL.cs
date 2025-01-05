using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    internal class ItemVendaMODEL
    {
        public int ItemVendaID { get; set; }
        public int VendaID { get; set; }
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
