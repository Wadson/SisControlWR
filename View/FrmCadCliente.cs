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
    public partial class FrmCadCliente : SisControl.FrmBaseGeral
    {
        public FrmCadCliente()
        {
            InitializeComponent();
        }
        public void AlterarRegistro()
        {
            try
            {
                ClienteMODEL objetoCliente = new ClienteMODEL();

               objetoCliente.ClienteID = Convert.ToInt32(txtCidadeID.Text);
               objetoCliente.NomeCliente = txtNomeCliente.Text;
               objetoCliente.CpfCnpj = txtCpfCnpj.Text;
               objetoCliente.Endereco = txtEndereco.Text;
               objetoCliente.Telefone = txtTelefone.Text;
               objetoCliente.Email = txtEmail.Text;
               objetoCliente.CidadeID = Convert.ToInt32(txtCidadeID.Text);

                ClienteBLL clienteBll = new ClienteBLL();
                clienteBll.Alterar(objetoCliente);
                
                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                LimpaCampo();
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Alterar o registro!!! " + erro);
            }
        }
        public void SalvarRegistro()
        {
            try
            {
                if (ClienteID != 0 && txtCidadeID.Text!= string.Empty && txtNomeCidade.Text != string.Empty)
                {
                    ClienteMODEL objetoCliente = new ClienteMODEL();

                    objetoCliente.ClienteID = Convert.ToInt32(txtCidadeID.Text);
                    objetoCliente.NomeCliente = txtNomeCliente.Text;
                    objetoCliente.CpfCnpj = txtCpfCnpj.Text;
                    objetoCliente.Endereco = txtEndereco.Text;
                    objetoCliente.Telefone = txtTelefone.Text;
                    objetoCliente.Email = txtEmail.Text;
                    objetoCliente.CidadeID = Convert.ToInt32(txtCidadeID.Text);
                    

                    ClienteBLL clienteBll = new ClienteBLL();
                    clienteBll.Salvar(objetoCliente);

                    MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
                    
                    LimpaCampo();
                    txtNomeCliente.Focus();

                    txtClienteID.Text = RetornaCodigoContaMaisUm(QueryClientes).ToString();
                    UsuarioID = RetornaCodigoContaMaisUm(QueryUsuario);
                    AcrescenteZero_a_Esquerda2(txtClienteID);
                    
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
                ClienteMODEL objetoUsuario = new ClienteMODEL();

                objetoUsuario.ClienteID = Convert.ToInt32(txtClienteID.Text);
                ClienteBLL clienteBll = new ClienteBLL();

                clienteBll.Excluir(objetoUsuario);
                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                LimpaCampo();
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Excluir o registro!!! " + erro);
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
                EvitarDuplicado("Usuario", "NomeUsuario", txtNomeCliente.Text);
                if (RetornoEvitaDuplicado == "0")
                {
                    SalvarRegistro();
                }
            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Usuário: " + txtNomeCliente.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampo();
            txtClienteID.Text = RetornaCodigoContaMaisUm(QueryClientes).ToString();
            AcrescenteZero_a_Esquerda2(txtClienteID);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadCliente_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                AcrescenteZero_a_Esquerda2(txtCidadeID);
            }
            if (StatusOperacao == "NOVO")
            {
                UsuarioID = RetornaCodigoContaMaisUm(QueryClientes);
                txtClienteID.Text = RetornaCodigoContaMaisUm(QueryClientes).ToString();
                txtNomeCliente.Focus();
            }
            AcrescenteZero_a_Esquerda2(txtClienteID);
        }

        private void FrmCadCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            FrmLocalizarCidade frmLocalizarCidade = new FrmLocalizarCidade();
            frmLocalizarCidade.Text = "Localizar Cidade...";
            frmLocalizarCidade.ShowDialog();
            AcrescenteZero_a_Esquerda2(txtCidadeID);
        }
    }
}
