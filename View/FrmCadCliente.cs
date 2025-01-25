using SisControl.BLL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace SisControl.View
{
    public partial class FrmCadCliente : FrmModeloForm
    {

        private string QueryClientes = "SELECT MAX(ClienteID)  FROM Cliente";
        private string StatusOperacao;
        private int ClienteID;
        
        public FrmCadCliente( string statusOperação)
        {
            InitializeComponent();
            this.StatusOperacao = statusOperação;
            Utilitario.ConfigurarEventosDeFoco(this);// Texbox fundo amarelo quando em foco
        }
        public void AlterarRegistro()
        {
            try
            {
                ClienteMODEL objetoCliente = new ClienteMODEL();

                objetoCliente.ClienteID = Convert.ToInt32(txtClienteID.Text);
                objetoCliente.NomeCliente = txtNomeCliente.Text;
                objetoCliente.Cpf = txtCpf.Text;
                objetoCliente.Endereco = txtEndereco.Text;
                objetoCliente.Telefone = txtTelefone.Text;
                objetoCliente.Email = txtEmail.Text;
                objetoCliente.CidadeID = Convert.ToInt32(txtCidadeID.Text);

                ClienteBLL clienteBll = new ClienteBLL();
                clienteBll.Alterar(objetoCliente);

                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampoKrypton(this);
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
                // Supomos que você tenha três TextBoxes chamados textBox1, textBox2 e textBox3
                string enDereco = txtEndereco.Text +", " +txtNumero.Text +" - "+ txtBairro.Text;

                ClienteMODEL objetoCliente = new ClienteMODEL();

                objetoCliente.ClienteID = Convert.ToInt32(txtClienteID.Text);
                objetoCliente.NomeCliente = txtNomeCliente.Text;
                objetoCliente.Cpf = txtCpf.Text;
                objetoCliente.Endereco = enDereco;
                objetoCliente.Telefone = Utilitario.RemoverParentesesETraços(txtTelefone.Text).ToString();
                
                objetoCliente.Email = txtEmail.Text;
                objetoCliente.CidadeID = Convert.ToInt32(txtCidadeID.Text);

                ClienteBLL clienteBll = new ClienteBLL();
                clienteBll.Salvar(objetoCliente);

                MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);

                Utilitario.LimpaCampoKrypton(this);
                txtNomeCliente.Focus();

                txtClienteID.Text = Utilitario.GerarProximoCodigo(QueryClientes).ToString();
                //Utilitario.AcrescentarZerosEsquerda(txtClienteID.Text, 6);//();                                                                    

                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryClientes);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                ClienteID = NovoCodigo;
                txtClienteID.Text = numeroComZeros;

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
                Utilitario.LimpaCampoKrypton(this);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Excluir o registro!!! " + erro);
            }
        }

       
               
        private void FrmCadCliente_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryClientes);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                ClienteID = NovoCodigo;
                txtClienteID.Text = numeroComZeros;

                txtNomeCliente.Focus();
            }            
        }
             

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Utilitario.LimpaCampo(this);

            int NovoCodigo = Utilitario.GerarProximoCodigo(QueryClientes);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
            ClienteID = NovoCodigo;
            txtClienteID.Text = numeroComZeros;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (MessageBox.Show("Deseja Excluir? \n\n O Cliente: " + txtNomeCliente.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            FrmLocalizarCidade frmLocalizarCidade = new FrmLocalizarCidade();
            frmLocalizarCidade.Text = "Localizar Cidade...";
            VariavelGlobal.NomeFormulario = "FrmCadCliente";
            frmLocalizarCidade.ShowDialog();
        }
    }
}
