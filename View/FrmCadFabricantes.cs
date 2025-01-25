using SisControl.BLL;
using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SisControl.View
{
    public partial class FrmCadFabricantes : SisControl.FrmBaseGeral
    {
        private string QueryFabricante = "SELECT MAX(FabricanteID) FROM Fabricantes";
        
        private int FornecedorID;        
        private string StatusOperacao;
        private FabricanteDal fabricanteDal;
        public FrmCadFabricantes(string statusOperacao)
        {
            this.StatusOperacao = statusOperacao;
            InitializeComponent();
            fabricanteDal = new FabricanteDal();
        }
        public void SalvarRegistro()
        {           
            try
            {
                if (txtFabricanteID.Text != string.Empty && txtNomeFabricante.Text != string.Empty)
                {
                    FabricanteModel objetomodel = new FabricanteModel();

                    objetomodel.FabricanteID =       int.Parse(txtFabricanteID.Text);
                    objetomodel.NomeFabricante =    txtNomeFabricante.Text;
                    objetomodel.Endereco =          txtEndereco.Text;
                    objetomodel.Telefone = txtTelefone.Text;


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
            string endereco = txtEndereco.Text;
            string telefone = txtTelefone.Text;

            FabricanteModel fabricante = new FabricanteModel
            {
                FabricanteID = fabricanteID,
                NomeFabricante = nomeFabricante,
                Endereco = endereco,
                Telefone = telefone
            };

            try
            {
                fabricanteDal.AtualizarFabricante(fabricante);
                MessageBox.Show("Fabricante atualizado com sucesso!");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir fabricante: " + ex.Message);
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
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryFabricante);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 4);                
                txtFabricanteID.Text = numeroComZeros;
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {            
            FrmLocalizarCidade frmLocalizarCidade = new FrmLocalizarCidade();
            frmLocalizarCidade.Text = "Localizar Fornecedor...";
            VariavelGlobal.NomeFormulario = "FrmCadFornecedor";
            frmLocalizarCidade.ShowDialog();
            
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(FornecedorID, 6);
            FornecedorID = int.Parse(numeroComZeros);
            txtFabricanteID.Text = FornecedorID.ToString();
        }
    }
}
