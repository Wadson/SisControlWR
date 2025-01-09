using System;
using System.Linq;
using System.Windows.Forms;

public class ValidadorCPF : Form
{
    private TextBox campoCpf;
    private Button botaoValidar;
    private Label resultado;

    public ValidadorCPF()
    {
        campoCpf = new TextBox { Left = 50, Top = 20, Width = 150 };
        botaoValidar = new Button { Text = "Validar", Left = 210, Width = 75, Top = 20 };
        resultado = new Label { Left = 50, Top = 50, Width = 300 };

        botaoValidar.Click += new EventHandler(BotaoValidar_Click);

        Controls.Add(campoCpf);
        Controls.Add(botaoValidar);
        Controls.Add(resultado);
    }

    private void BotaoValidar_Click(object sender, EventArgs e)
    {
        string cpf = campoCpf.Text;

        if (ValidarCPF(cpf))
        {
            resultado.Text = "CPF válido!";
        }
        else
        {
            resultado.Text = "CPF inválido!";
        }
    }

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

    [STAThread]
    public static void Main()
    {
        Application.Run(new ValidadorCPF());
    }
}
