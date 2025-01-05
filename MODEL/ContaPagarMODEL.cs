using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    internal class ContaPagarMODEL
    {
        public int ContaPagarID { get; set; }
        public int FornecedorID { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
