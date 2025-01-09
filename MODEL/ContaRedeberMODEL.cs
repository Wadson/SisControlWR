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
        public int ParcelaID { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }

    }   
}
