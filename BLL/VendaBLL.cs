using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.BLL
{
    internal class VendaBLL
    {
        VendaDALL vendaDALL = null;
        public void Salvar(VendaMODEL vendas)
        {
            vendaDALL = new VendaDALL();
            vendaDALL.SalvarVenda(vendas);
            try
            {

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public void Excluir(VendaMODEL vendas)
        {
            try
            {
                vendaDALL = new VendaDALL();
                vendaDALL.excluirVenda(vendas);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public void Alterar(VendaMODEL vendas)
        {
            try
            {
                vendaDALL = new VendaDALL();
                vendaDALL.atualizaVenda(vendas);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

    }
}
