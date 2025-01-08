using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    internal class VendaMODEL
    {
        public int VendaID { get; set; }
        public int ClienteID { get; set; }
        public DateTime DataVenda { get; set; }
        public Decimal ValorTotal { get; set; }

        public List<int> ItemVendaID = new List<int>();
        public List<int> ParcelaID = new List<int>();
        public List<int> ContaReceberID = new List<int>();

        //public List<ItemVenda> ItensVenda { get; set; }
        //public List<Parcela> Parcelas { get; set; }
        //public List<ContaReceber> ContasReceber { get; set; }
    }
}
