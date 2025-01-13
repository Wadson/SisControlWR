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
        VendaDAL vendaDALL = null;
        public void Salvar(VendaDAL vendas)
        {
            
            try
            {
                //vendaDALL = new VendaDAL();
                //vendaDALL.SalvarVenda(vendas);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public void Excluir(VendaModel vendas)
        {
            try
            {
                //vendaDALL = new VendaDAL();
                //vendaDALL.excluirVenda(vendas);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public void Alterar(VendaModel vendas)
        {
            try
            {
                //vendaDALL = new VendaDALL();
                //vendaDALL.atualizaVenda(vendas);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

    }
}
