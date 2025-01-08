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
    public partial class FrmCadCategoria : SisControl.FrmBaseGeral
    {
        public FrmCadCategoria()
        {
            InitializeComponent();
        }
        public void SalvarRegistro()
        {
            try
            {
                CategoriaMODEL objetoCategoria = new CategoriaMODEL();

                //objetoCliente.ClienteID = Convert.ToInt32(txtClienteID.Text);
                objetoCategoria.NomeCategoria = txtNome.Text;
                //objetoCategoria.CategoriaID = Convert.ToInt32(txtCodigo.Text);
               

                CategoriaBLL categoriaBll = new CategoriaBLL();
                categoriaBll.Salvar(objetoCategoria);

                MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutCategoria)Application.OpenForms["FrmManutCategoria"]).HabilitarTimer(true);

                LimpaCampo();
                txtNome.Focus();

                txtCodigo.Text = RetornaCodigoContaMaisUm(QueryCategoria).ToString();
                CategoriaID = RetornaCodigoContaMaisUm(QueryCategoria);
                AcrescenteZero_a_Esquerda2(txtCodigo);                
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
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (StatusOperacao == "NOVO")
            {
                EvitarDuplicado("Cliente", "NomeCliente", txtNome.Text);
                if (RetornoEvitaDuplicado == "0")
                {
                    SalvarRegistro();
                }
            }
            else if (StatusOperacao == "ALTERAR")
            {
                AlterarRegistro();
            }
            else if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Cliente: " + txtNome.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }
        }
        public void AlterarRegistro()
        {
            try
            {
                CategoriaMODEL objetoCategoria = new CategoriaMODEL();

                objetoCategoria.CategoriaID = Convert.ToInt32(txtCodigo.Text);
                objetoCategoria.NomeCategoria = txtNome.Text;

                CategoriaBLL categoriaBll = new CategoriaBLL();
                categoriaBll.Alterar(objetoCategoria);

                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                LimpaCampo();
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

                objetocategoria.CategoriaID = Convert.ToInt32(txtCodigo.Text);
                CategoriaBLL categoriaBll = new CategoriaBLL();

                categoriaBll.Excluir(objetocategoria);
                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                LimpaCampo();
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Excluir o registro!!! " + erro);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampo();
            txtCodigo.Text = RetornaCodigoContaMaisUm(QueryCategoria).ToString();
            AcrescenteZero_a_Esquerda2(txtNome);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void FrmCadCategoria_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                UsuarioID = RetornaCodigoContaMaisUm(QueryCategoria);
                txtCodigo.Text = RetornaCodigoContaMaisUm(QueryCategoria).ToString();
                AcrescenteZero_a_Esquerda2(txtCodigo);
                txtNome.Focus();
            }            
        }
    }
}
