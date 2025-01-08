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
    public partial class FrmCadFornecedor : SisControl.FrmBaseGeral
    {
        public FrmCadFornecedor()
        {
            InitializeComponent();
        }
        public void SalvarRegistro()
        {
            try
            {
                FornecedorMODEL objetoModel = new FornecedorMODEL();

                objetoModel.FornecedorID = Convert.ToInt32(txtFornecedorID.Text);
                objetoModel.NomeFornecedor = txtNomeFornecedor.Text;
                objetoModel.Cnpj = txtCnpjCpf.Text;
                objetoModel.Endereco = txtEndereco.Text;
                objetoModel.Telefone = txtTelefone.Text;
                objetoModel.Email = txtEmail.Text;
                objetoModel.CidadeID = Convert.ToInt32(txtCidadeID.Text);

                FornecedorBLL objetoBll = new FornecedorBLL();

                objetoBll.Salvar(objetoModel);
                MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutFornecedor)Application.OpenForms["FrmManutFornecedor"]).HabilitarTimer(true);
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
                FornecedorMODEL objetoModel = new FornecedorMODEL();

                objetoModel.FornecedorID = Convert.ToInt32(txtFornecedorID.Text);
                objetoModel.NomeFornecedor = txtNomeFornecedor.Text;
                objetoModel.Cnpj = txtCnpjCpf.Text;
                objetoModel.Endereco = txtEndereco.Text;
                objetoModel.Telefone = txtTelefone.Text;
                objetoModel.Email = txtEmail.Text;
                objetoModel.CidadeID = Convert.ToInt32(txtCidadeID.Text);

                FornecedorBLL objetoBll = new FornecedorBLL();
                objetoBll.Alterar(objetoModel);

                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutFornecedor)Application.OpenForms["FrmManutFornecedor"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
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
                FornecedorMODEL objetoModel = new FornecedorMODEL();

                objetoModel.FornecedorID = Convert.ToInt32(txtFornecedorID.Text);
                FornecedorBLL objetoBll = new FornecedorBLL();

                objetoBll.Excluir(objetoModel);
                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
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
            if (StatusOperacao == "ALTERAR")
            {
                AlterarRegistro();
            }
            if (StatusOperacao == "NOVO")
            {
                EvitarDuplicado("Fornecedor", "NomeFornecedor", txtNomeFornecedor.Text);
                if (RetornoEvitaDuplicado == "0")
                {
                    SalvarRegistro();
                    LimpaCampo();
                    txtNomeFornecedor.Focus();
                    
                    txtFornecedorID.Text = RetornaCodigoContaMaisUm(QueryFornecedor).ToString();
                    UsuarioID = RetornaCodigoContaMaisUm(QueryFornecedor);
                    AcrescenteZero_a_Esquerda2(txtFornecedorID);
                    ((FrmManutFornecedor)Application.OpenForms["FrmManutFornecedor"]).HabilitarTimer(true);
                }
            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Usuário: " + txtNomeFornecedor.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampo();
            txtFornecedorID.Text = RetornaCodigoContaMaisUm(QueryFornecedor).ToString();
            AcrescenteZero_a_Esquerda2(txtFornecedorID);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadFornecedor_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                txtFornecedorID.Text = RetornaCodigoContaMaisUm(QueryFornecedor).ToString();                
                txtNomeFornecedor.Focus();
                AcrescenteZero_a_Esquerda2(txtFornecedorID);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            
            FrmLocalizarCidade frmLocalizarCidade = new FrmLocalizarCidade();
            frmLocalizarCidade.Text = "Localizar Cidade...";
            VariavelGlobal.NomeFormulario = "FrmCadFornecedor";
            frmLocalizarCidade.ShowDialog();
            AcrescenteZero_a_Esquerda2(txtCidadeID);
        }
    }
}
