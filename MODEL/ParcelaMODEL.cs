using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    internal class ParcelaMODEL
    {
        public int ParcelaID { get; set; }
        public int ContaReceberID { get; set; }
        public decimal ValorParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public int NumeroParcela { get; set; }
    }
}
