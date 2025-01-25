using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    public class ParcelaModel
    {        
        public int ParcelaID { get; set; } 
        public int VendaID { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorRecebido { get; set; }
        public decimal SaldoRestante { get; set; }
        public bool Pago { get; set; }
        public string FormaPagamento { get; set; }

        public VendaModel Venda { get; set; }
        public List<ContaReceberModel> ContasReceber { get; set; }

        public ParcelaModel()
        {
            ContasReceber = new List<ContaReceberModel>();
        }
    }
}
