using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.MODEL
{
    internal class ClienteMODEL
    {
        public int ClienteID { get; set; }
        public string NomeCliente { get; set; }
        public string CpfCnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CidadeID { get; set; }
    }
}
