using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.BLL
{
    internal class PagamentoParcialBll
    {
        private PagamentoParcialDal _dal;

        public PagamentoParcialBll()
        {
            _dal = new PagamentoParcialDal();
        }

        public void RegistrarPagamentoParcial(PagamentoParcialModel pagamentoParcial)
        {
            // Lógica de negócios antes de inserir o pagamento parcial, se necessário
            _dal.InserirPagamentoParcial(pagamentoParcial);
        }

        public List<PagamentoParcialModel> ObterPagamentosParciaisPorParcela(int parcelaID)
        {
            // Lógica de negócios antes de obter os pagamentos parciais, se necessário
            return _dal.ObterPagamentosParciaisPorParcela(parcelaID);
        }
    }
}
