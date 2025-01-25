using SisControl.BLL;
using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace SisControl.View
{
    public partial class FrmCadFabricante : FrmModeloForm
    {
        private string QueryFabricante = "SELECT MAX(FabricanteID) FROM Fabricantes";

        private int FornecedorID;
        private string StatusOperacao;
        private FabricanteDal fabricanteDal;
        public FrmCadFabricante(string statusOperacao)
        {
            InitializeComponent();
            this.StatusOperacao = statusOperacao;
            this.fabricanteDal = new FabricanteDal(); // Inicialização do fabricanteDal
        }
        public void SalvarRegistro()
        {
            string Endereco = txtEndereco.Text + ", " + txtNumero.Text + ", " + txtBairro.Text + ", " + txtCidade.Text + ", " + txtEstado.Text;
            string Telefone = Utilitario.LimparNumeroTelefone(txtTelefone.Text);
            try
            {
                if (txtFabricanteID.Text != string.Empty )
                {
                    FabricanteModel objetomodel = new FabricanteModel();

                    objetomodel.FabricanteID = int.Parse(txtFabricanteID.Text);
                    objetomodel.NomeFabricante = txtNomeFabricante.Text;
                    objetomodel.Endereco = Endereco;
                    objetomodel.Telefone = Telefone;


                    FabricanteBll fabricantebll = new FabricanteBll();

                    fabricantebll.Salvar(objetomodel);
                    MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ((FrmManutFabricante)Application.OpenForms["FrmManutFabricante"]).HabilitarTimer(true);
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
        public void AlterarRegistro()
        {
            int fabricanteID = int.Parse(txtFabricanteID.Text);
            string nomeFabricante = txtNomeFabricante.Text;

            string Telefone = Utilitario.LimparNumeroTelefone(txtTelefone.Text);
            string Endereco = txtEndereco.Text + ", " + txtNumero.Text + ", " + txtBairro.Text + ", " + txtCidade.Text + ", " + txtEstado.Text;
            FabricanteModel fabricante = new FabricanteModel
            {
                FabricanteID = fabricanteID,
                NomeFabricante = nomeFabricante,
                Endereco = Endereco,
                Telefone = Telefone,
            };

            try
            {
                fabricanteDal.AtualizarFabricante(fabricante);
                MessageBox.Show("Fabricante atualizado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar fabricante: " + ex.Message);
            }
        }
        public void ExcluirRegistro()
        {
            int fabricanteID = int.Parse(txtFabricanteID.Text);

            try
            {
                fabricanteDal.RemoverFabricante(fabricanteID);
                MessageBox.Show("Fabricante excluído com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir fabricante: " + ex.Message);
            }
        }
      
        private void FrmCadFabricante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void FrmCadFabricante_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                txtNomeFabricante.Focus();
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryFabricante);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 4);
                txtFabricanteID.Text = numeroComZeros;
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
                SalvarRegistro();
                Utilitario.LimpaCampo(this);
                txtNomeFabricante.Focus();

                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryFabricante);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 4);
                txtFabricanteID.Text = numeroComZeros;

                ((FrmManutFabricante)Application.OpenForms["FrmManutFabricante"]).HabilitarTimer(true);

            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Fabricante: " + txtNomeFabricante.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Utilitario.LimpaCampo(this);

            int NovoCodigo = Utilitario.GerarProximoCodigo(QueryFabricante);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
            FornecedorID = NovoCodigo;
            txtFabricanteID.Text = numeroComZeros;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
