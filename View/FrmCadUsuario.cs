using SisControl.BLL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisControl
{
    public partial class FrmCadUsuario : SisControl.FrmBaseGeral
    {
        private string QueryUsuario = "SELECT MAX(UsuarioID) FROM Usuario";

        private string StatusOperacao;
        private int UsuarioID;
        public FrmCadUsuario(string statusOperacao)
        {
            this.StatusOperacao = statusOperacao;
            InitializeComponent();
        }
        public void SalvarRegistro()
        {
            try
            {
                if (UsuarioID != 0 && txtNomeUsuario.Text != string.Empty && cmbTipoUsuario.Text != string.Empty && txtSenha.Text == txtRepitaSenha.Text)
                {
                    UsuarioMODEL objusuario = new UsuarioMODEL();

                    objusuario.UsuarioID = Convert.ToInt32(txtUsuarioID.Text);
                    objusuario.NomeUsuario = txtNomeUsuario.Text;
                    objusuario.Email = txtEmail.Text;
                    objusuario.Senha = Convert.ToString(txtSenha.Text);
                    objusuario.TipoUsuario = cmbTipoUsuario.Text;

                    UsuarioBLL usuariobll = new UsuarioBLL();

                    usuariobll.Salvar(objusuario);
                    MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
                }
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
        public void ExcluirRegistro()
        {
            try
            {
                UsuarioMODEL objetoUsuario = new UsuarioMODEL();

                objetoUsuario.UsuarioID = Convert.ToInt32(txtUsuarioID.Text);
                UsuarioBLL usuarioBll = new UsuarioBLL();

                usuarioBll.Excluir(objetoUsuario);
                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampo(groupBox1);
                this.Close(); 
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Excluir o registro!!! " + erro);
            }
        }


        public void AlterarRegistro()
        {
            try
            {
                UsuarioMODEL objetoUsuario = new UsuarioMODEL();

                objetoUsuario.UsuarioID = Convert.ToInt32(txtUsuarioID.Text);
                objetoUsuario.NomeUsuario = txtNomeUsuario.Text;
                objetoUsuario.Email = txtEmail.Text;
                objetoUsuario.Senha = Convert.ToString(txtSenha.Text);
                objetoUsuario.TipoUsuario = cmbTipoUsuario.Text;

                UsuarioBLL usuarioBll = new UsuarioBLL();
                usuarioBll.Alterar(objetoUsuario);

                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampo(groupBox1);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Alterar o registro!!! " + erro);
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            FrmManutUsuario pesquisausuario = new FrmManutUsuario();

            if (StatusOperacao == "ALTERAR")
            {
                AlterarRegistro();
            }
            if (StatusOperacao == "NOVO")
            {
                SalvarRegistro();
                Utilitario.LimpaCampo(this);
                txtNomeUsuario.Focus();

                UsuarioID = Utilitario.GerarProximoCodigo(QueryUsuario);
                int codigo = UsuarioID;
                txtUsuarioID.Text = Utilitario.AcrescentarZerosEsquerda(codigo, 6);

                ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Usuário: " + txtNomeUsuario.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }                    
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {            
            Utilitario.LimpaCampo(groupBox1);

            int NovoCodigo = Utilitario.GerarProximoCodigo(QueryUsuario);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
            UsuarioID = NovoCodigo;
            txtUsuarioID.Text = numeroComZeros;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadUsuario_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryUsuario);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                UsuarioID = NovoCodigo;
                txtUsuarioID.Text = numeroComZeros;

                txtNomeUsuario.Focus();
            }            
        }
    }
}
