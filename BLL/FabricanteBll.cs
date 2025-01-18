using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.BLL
{
    internal class FabricanteBll
    {
        FabricanteDal fabricanteDal = null;
        
        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                fabricanteDal = new FabricanteDal ();
                dtable = fabricanteDal.listarFabricante();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }
        public void Salvar(FabricanteModel fabricantes)
        {
            try
            {
                fabricanteDal = new FabricanteDal();
                fabricanteDal.InserirFabricante(fabricantes);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<FabricanteModel> ObterFabricantesPorNome(string nome)
        {
            return fabricanteDal.ObterFabricantesPorNome(nome);
        }
    }
}
