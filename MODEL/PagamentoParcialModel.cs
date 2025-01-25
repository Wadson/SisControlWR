using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SisControl.View.FrmContaReceberr;

namespace SisControl.MODEL
{
    internal class PagamentoParcialModel
    {
        public int PagamentoParcialID { get; set; } // ID do pagamento parcial, chave primária
        public int ParcelaID { get; set; } // ID da parcela associada
        public decimal ValorPago { get; set; } // Valor pago na parcela
        public DateTime DataPagamento { get; set; } // Data do pagamento

        // Propriedade de navegação opcional para a Parcela
        public Parcela Parcela { get; set; }
    }
}
