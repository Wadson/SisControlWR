 using SisControl.BLL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmCadSubCategoria : SisControl.FrmBaseGeral
    {
        private string QuerySubCat = "SELECT MAX(SubCategoriaID) FROM SubCategoria";
        private string QueryCategoria = "SELECT MAX(CategoriaID) FROM Categoria";
        private int CategoriaID;
        private int SubCategoriaID;

        private string StatusOperacao;

        public FrmCadSubCategoria()
        {
            InitializeComponent();
        }
        public void SalvarRegistro()
        {
            try
            {
                SubCategoriaMODEL objetoSubCategoria = new SubCategoriaMODEL();

                //objetoCliente.ClienteID = Convert.ToInt32(txtClienteID.Text);
                objetoSubCategoria.NomeSubCategoria = txtNomeSubCat.Text;
                objetoSubCategoria.CategoriaID = Convert.ToInt32(txtSubCatID.Text);


                SubCategoriaBLL SubcategoriaBll = new SubCategoriaBLL();
                SubcategoriaBll.Salvar(objetoSubCategoria);

                MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutSubCategoria)Application.OpenForms["FrmManutSubCategoria"]).HabilitarTimer(true);

                Utilitario.LimpaCampo(this);
                txtNomeSubCat.Focus();

                int NovoCodigo = Utilitario.GerarProximoCodigo(QuerySubCat);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                CategoriaID = NovoCodigo;
                txtSubCatID.Text = numeroComZeros;
            }
            catch (OverflowException ov)
            {
                MessageBox.Show("Overfow Exeção deu erro! " + ov);
            }
            catch (Win32Exception erro)
            {
                MessageBox.Show("Win32 Win32!!! \n" + erro);
            }
        }
        public void AlterarRegistro()
        {
            try
            {
                CategoriaMODEL objetoCategoria = new CategoriaMODEL();

                objetoCategoria.CategoriaID = Convert.ToInt32(txtSubCatID.Text);
                objetoCategoria.NomeCategoria = txtNomeSubCat.Text;

                CategoriaBLL categoriaBll = new CategoriaBLL();
                categoriaBll.Alterar(objetoCategoria);

                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampo(this);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Alterar o registro!!! " + erro);
            }
        }
        public void ExcluirRegistro()
        {
            try
            {
                CategoriaMODEL objetocategoria = new CategoriaMODEL();

                objetocategoria.CategoriaID = Convert.ToInt32(txtSubCatID.Text);
                CategoriaBLL categoriaBll = new CategoriaBLL();

                categoriaBll.Excluir(objetocategoria);
                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampo(this); this.Close();                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Excluir o registro!!! " + erro);
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (StatusOperacao == "NOVO")
            {
                SalvarRegistro();              
            }
            else if (StatusOperacao == "ALTERAR")
            {
                AlterarRegistro();
            }
            else if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Cliente: " + txtNomeSubCat.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Utilitario.LimpaCampo(this);

            int NovoCodigo = Utilitario.GerarProximoCodigo(QuerySubCat);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
            CategoriaID = NovoCodigo;
            txtSubCatID.Text = numeroComZeros;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            FrmLocalizarCategoria frmLocalizarCategoria = new FrmLocalizarCategoria();
            frmLocalizarCategoria.Text = "Localizar Categoria...";
            frmLocalizarCategoria.ShowDialog();            
        }

        private void FrmCadSubCategoria_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                int NovoCodigo = Utilitario.GerarProximoCodigo(QuerySubCat);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                CategoriaID = NovoCodigo;
                txtSubCatID.Text = numeroComZeros;

                txtNomeSubCat.Focus();
            }
        }
    }
}
