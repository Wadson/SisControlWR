using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    public class VendaModel
    {
        //public int VendaID { get; set; }
        public int VendaID { get; set; } // Usando GUID como chave primária
        public DateTime DataVenda { get; set; }
        public int ClienteID { get; set; }
        public decimal ValorTotal { get; set; }
        public int FormaPgtoID { get; set; }

        public List<ItemVendaModel> ItensVendidos { get; set; }
        public List<ParcelaModel> Parcelas { get; set; }

        public VendaModel()
        {
            ItensVendidos = new List<ItemVendaModel>();
            Parcelas = new List<ParcelaModel>();
        }
    }
}
