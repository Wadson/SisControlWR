using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    internal class ContaRedeberMODEL
    {
        public int ContaReceberID { get; set; }
        public int VendaID { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
