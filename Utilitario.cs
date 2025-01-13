using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SisControl
{
    public static class Utilitario
    { 
        // Método que retorna a string de conexão
        public static string GetConnectionString()
        {
            // Substitua com a sua string de conexão real
            return "Data Source=NOTEBOOK-DELL\\SQLEXPRESS;Initial Catalog=bdsiscontrol;Integrated Security=True;";                   
        }
        // Método global para remover zeros à esquerda
        public static string RemoverZerosAEsquerda(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return valor;

            return valor.TrimStart('0');
            // Remover zeros à esquerda do valor do TextBox
            // string valorComZeros = txtNumeroComZeros.Text;
            // string valorSemZeros = Utilitario.RemoverZerosAEsquerda(valorComZeros);

        }

        // Método que gera o próximo código
        public static int GerarProximoCodigo(string query)
        {
            int proximoCodigo = 1; // Valor inicial padrão

            string connectionString = GetConnectionString(); // Obtém a string de conexão
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            proximoCodigo = Convert.ToInt32(result) + 1;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    // Tratar exceção de SQL
                    Console.WriteLine($"Erro de SQL: {sqlEx.Message}");
                }
                catch (InvalidOperationException invOpEx)
                {
                    // Tratar exceção de operação inválida
                    Console.WriteLine($"Erro de Operação Inválida: {invOpEx.Message}");
                }
                catch (Exception ex)
                {
                    // Tratar outras exceções
                    Console.WriteLine($"Erro: {ex.Message}");
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return proximoCodigo;
        }
        public static decimal RemoverFormatoMoeda(System.Windows.Forms.TextBox textBox)
        {
            // Obtém o texto do TextBox
            string valorMonetario = textBox.Text;

            // Remove símbolos de moeda e espaços, mantendo os pontos e vírgulas
            string valorSemFormato = valorMonetario.Replace("R$", "")  // Remover símbolo de moeda brasileiro
                                                   .Replace("$", "")   // Remover símbolo de dólar, se necessário
                                                   .Replace("€", "")   // Remover símbolo de euro, se necessário
                                                   .Replace("£", "")   // Remover símbolo de libra, se necessário
                                                   .Trim();            // Remover espaços adicionais

            // Converte a string para decimal considerando a cultura local
            if (decimal.TryParse(valorSemFormato, NumberStyles.Any, new CultureInfo("pt-BR"), out decimal valorDecimal))
            {
                return valorDecimal;
            }

            return 0;
        }



        // Método para validar CPF
        public static bool ValidarCPF(string cpf)
        {
            if (cpf.Length != 11 || cpf.All(c => c == cpf[0])) return false;

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        // Método para preencher ComboBox
        public static void PreencherComboBox(ComboBox comboBox, string query)
        {
            string connectionString = GetConnectionString(); // Obtém a string de conexão
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        
                        comboBox.DisplayMember = "Nome";  // Substitua "Nome" pela coluna que deseja exibir
                        comboBox.ValueMember = "ID";      // Substitua "ID" pela coluna de valor
                        comboBox.DataSource = dt;
                    }
                }
            }
        }
        // Método para tornar todos os textos dos TextBox em maiúsculas
        public static void TornarTextosMaiusculas(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = textBox.Text.ToUpper();
                }

                // Se o controle possuir filhos, aplica recursivamente
                if (control.HasChildren)
                {
                    TornarTextosMaiusculas(control);
                }
            }
            /*
private void FrmMeuFormulario_Load(object sender, EventArgs e)
    {
        Utilitario.TornarTextosMaiusculas(this); // Converte textos já presentes para maiúsculas

        // Atribui o evento TextChanged para todos os TextBox
        foreach (Control control in this.Controls)
        {
            if (control is TextBox textBox)
            {
                textBox.TextChanged += textBox_TextChanged;
            }
        }
    }

    private void textBox_TextChanged(object sender, EventArgs e)
    {
        if (sender is TextBox textBox)
        {
            int posicaoCursor = textBox.SelectionStart;
            textBox.Text = textBox.Text.ToUpper();
            textBox.SelectionStart = posicaoCursor;
        }
    }
            */
        }
        // Método para localizar dados e preencher DataGridView
        public static void LocalizarGeral(DataGridView dataGridView, string query)
        {
            string connectionString = GetConnectionString(); // Obtém a string de conexão
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        // Verifica se a conexão está aberta
                        if (conn.State != ConnectionState.Open)
                        {
                            throw new Exception("Não foi possível abrir a conexão com o banco de dados.");
                        }

                        // Configuração do DataAdapter
                        SqlDataAdapter da = new SqlDataAdapter
                        {
                            SelectCommand = comando
                        };

                        // Preenchimento do DataTable
                        DataTable dtGeral = new DataTable();
                        da.Fill(dtGeral);

                        // Verifica se o DataTable tem dados
                        if (dtGeral.Rows.Count == 0)
                        {
                            throw new Exception("Nenhum dado foi encontrado.");
                        }

                        // Atribuição dos dados ao DataGridView
                        dataGridView.DataSource = dtGeral;
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Erro de SQL: {sqlEx.Message}", "Erro de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidOperationException invOpEx)
                    {
                        MessageBox.Show($"Erro de Operação Inválida: {invOpEx.Message}", "Erro de Operação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Verifica se a conexão está aberta antes de tentar fechá-la
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }
        // Método para limpar campos
        public static void LimpaCampo(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (c is MaskedTextBox maskedTextBox)
                {
                    maskedTextBox.Clear();
                }
                else if (c is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now;
                }
                else if (c is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
                else if (c is Panel panel)
                {
                    LimpaCampo(panel); // Recursivamente limpar os controles dentro do painel
                }
                else if (c is GroupBox groupBox)
                {
                    LimpaCampo(groupBox); // Recursivamente limpar os controles dentro do groupBox
                }
            }

            /*

            ******IMPLEMENTAÇÃO DO MÉTODO LimpaCampo*******
private void btnLimpar_Click(object sender, EventArgs e)
{
    Utilitario.LimpaCampo(this); // Chama o método global para limpar todos os campos do formulário
    MessageBox.Show("Todos os campos foram limpos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
            */
        }

        // Método para somar valores no DataGridView
        public static decimal SomarValoresDataGridView(DataGridView dataGridView, string columnName)
        {
            decimal soma = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[columnName].Value != null)
                {
                    soma += Convert.ToDecimal(row.Cells[columnName].Value);
                }
            }
            return soma;
        }

        // Método para somar valores do banco de dados
        public static decimal SomarValoresBancoDados(string query)
        {
            decimal soma = 0;
            string connectionString = GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        soma = Convert.ToDecimal(comando.ExecuteScalar());
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Erro de SQL: {sqlEx.Message}", "Erro de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidOperationException invOpEx)
                    {
                        MessageBox.Show($"Erro de Operação Inválida: {invOpEx.Message}", "Erro de Operação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
            return soma;
        }
        public static bool VerificarDuplicidade(string query, Dictionary<string, object> parametros)
        {
            string connectionString = "Data Source=NOTEBOOK-DELL\\SQLEXPRESS;Initial Catalog=bdsiscontrol;Integrated Security=True"; // Substitua com sua string de conexão

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    foreach (var parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                    }

                    try
                    {
                        conn.Open();
                        var result = comando.ExecuteScalar();
                        return result != null && result != DBNull.Value;
                    }
                    catch (SqlException sqlEx)
                    {
                        // Trate a exceção de SQL conforme necessário
                        Console.WriteLine($"Erro de SQL: {sqlEx.Message}");
                        return false;
                    }
                    catch (InvalidOperationException invOpEx)
                    {
                        // Trate a exceção de operação inválida conforme necessário
                        Console.WriteLine($"Erro de Operação Inválida: {invOpEx.Message}");
                        return false;
                    }
                    catch (Exception ex)
                    {
                        // Trate outras exceções conforme necessário
                        Console.WriteLine($"Erro: {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }

            /* COMO IMPLEMENTAR O MÉTODO EVIDA *** VerificarDuplicidade *****
             * 
             *  string query = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email";
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    { "@Email", "teste@exemplo.com" }
                };

                bool duplicado = VerificadorDuplicidade.VerificarDuplicidade(query, parametros);
                if (duplicado)
                {
                    MessageBox.Show("Registro já existe!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Continuar com o cadastro
                }

             * */
        }

        public static string AcrescentarZerosEsquerda(int valor, int comprimentoTotal)
        {
            return valor.ToString().PadLeft(comprimentoTotal, '0');
        }
        /*
          EXEMPLO DE IMPLEMENTAÇÃO DO MÉTODO AcrescentarZerosEsquerda

            public class Programa
            {
                public static void Main()
                {
                    int numeroOriginal = 1;
                    int comprimentoTotal = 4;

                    // Chama o método global para acrescentar zeros à esquerda
                    string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(numeroOriginal, comprimentoTotal);

                    Console.WriteLine($"Número com zeros à esquerda: {numeroComZeros}"); // Saída: 0001

                    numeroOriginal = 45;
                    numeroComZeros = Utilitario.AcrescentarZerosEsquerda(numeroOriginal, comprimentoTotal);

                    Console.WriteLine($"Número com zeros à esquerda: {numeroComZeros}"); // Saída: 0045
                }
            }

         * */
        public static void AcrescentarZerosEsquerda(TextBox txtResultado, int comprimentoTotal)
        {
            if (txtResultado == null)
            {
                throw new ArgumentNullException(nameof(txtResultado), "O parâmetro txtResultado não pode ser nulo.");
            }

            string texto = txtResultado.Text;
            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("DEVE SER DIGITADO ALGUM VALOR NO CAMPO CÓDIGO.", "INFORMAÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtResultado.Text = new string('0', comprimentoTotal);
                return;
            }

            if (texto.Length < comprimentoTotal)
            {
                txtResultado.Text = texto.PadLeft(comprimentoTotal, '0');
            }
        }
        // Método para remover parênteses e traços de números
        public static string RemoverParentesesETraços(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
            {
                return numero;
            }

            return numero.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
        }

        public static bool EvitarDuplicado(string tabela, string campo, string valor)
        {
            string connectionString = "Data Source=NOTEBOOK-DELL\\SQLEXPRESS;Initial Catalog=bdsiscontrol;Integrated Security=True;"; // Substitua com sua string de conexão

            string query = $"SELECT COUNT(*) FROM {tabela} WHERE {campo} = @valor";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.AddWithValue("@valor", valor);

                    try
                    {
                        conn.Open();
                        var result = comando.ExecuteScalar();
                        return result != null && Convert.ToInt32(result) > 0;
                    }
                    catch (SqlException sqlEx)
                    {
                        // Trate a exceção de SQL conforme necessário
                        Console.WriteLine($"Erro de SQL: {sqlEx.Message}");
                        return false;
                    }
                    catch (InvalidOperationException invOpEx)
                    {
                        // Trate a exceção de operação inválida conforme necessário
                        Console.WriteLine($"Erro de Operação Inválida: {invOpEx.Message}");
                        return false;
                    }
                    catch (Exception ex)
                    {
                        // Trate outras exceções conforme necessário
                        Console.WriteLine($"Erro: {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }
        // Método para concatenar textos dos TextBoxes e adicionar ao DataGridView
        public static void AddConcatenatedTextToDataGridView(TextBox textBox1, TextBox textBox2, TextBox textBox3, DataGridView dataGridView)
        {
            // Concatenar textos dos TextBoxes
            string concatenatedString = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;

            // Adicionar a string concatenada ao DataGridView em uma única coluna
            dataGridView.Rows.Add(concatenatedString);
        }

        // Método para restaurar textos aos TextBoxes a partir do DataGridView
        public static void RestoreTextBoxesFromDataGridView(TextBox textBox1, TextBox textBox2, TextBox textBox3, DataGridView dataGridView, int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dataGridView.Rows.Count)
            {
                // Obter o valor da célula clicada
                string concatenatedString = dataGridView.Rows[rowIndex].Cells[0].Value.ToString();

                // Dividir a string concatenada de volta aos valores originais
                string[] splitStrings = concatenatedString.Split(' ');

                // Restaurar os valores aos TextBoxes, considerando que existem três partes
                if (splitStrings.Length == 3)
                {
                    textBox1.Text = splitStrings[0];
                    textBox2.Text = splitStrings[1];
                    textBox3.Text = splitStrings[2];
                }
                else
                {
                    MessageBox.Show("O formato do texto concatenado está incorreto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Exemplo de uso
            /*
             *  private void btnSave_Click(object sender, EventArgs e)
                {
                    AddConcatenatedTextToDataGridView(textBox1, textBox2, textBox3, dataGridView1);
                }

                private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
                {
                    RestoreTextBoxesFromDataGridView(textBox1, textBox2, textBox3, dataGridView1, e.RowIndex);
                }

             * */
        }

    }
}
/*
            COMO IMPLEMENTAR EM QUALQUER FORMULÁRIO
            using SisControl.Utils;  // Certifique-se de importar o namespace correto

            // ...

            private void FrmGerarParcelas_Load(object sender, EventArgs e)
            {
                string query = "SELECT MAX(ParcelaID) FROM Parcelas";
                int codigoVenda = Utilitario.GerarProximoCodigo(query); // Chama o método global

                // Atribui o código gerado ao TextBox
                txtVendaID.Text = codigoVenda.ToString();    
            }

*/