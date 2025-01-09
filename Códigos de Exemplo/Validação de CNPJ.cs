using System;
using System.Linq;
using System.Windows.Forms;

namespace CNPJValidation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxCNPJ.Leave += new EventHandler(textBoxCNPJ_Leave);
        }

        private void textBoxCNPJ_Leave(object sender, EventArgs e)
        {
            string cnpj = textBoxCNPJ.Text.Trim();
            if (IsValidCNPJ(cnpj))
            {
                labelResult.Text = "CNPJ válido.";
                labelResult.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                labelResult.Text = "CNPJ inválido.";
                labelResult.ForeColor = System.Drawing.Color.Red;
            }
        }

        public static bool IsValidCNPJ(string cnpj)
        {
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                return false;

            string[] invalidCNPJs = new string[]
            {
                "00000000000000", "11111111111111", "22222222222222",
                "33333333333333", "44444444444444", "55555555555555",
                "66666666666666", "77777777777777", "88888888888888",
                "99999999999999"
            };

            if (invalidCNPJs.Contains(cnpj))
                return false;

            int[] multi1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multi2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum = 0;
            for (int i = 0; i < 12; i++)
                sum += int.Parse(cnpj[i].ToString()) * multi1[i];
            int rest = (sum % 11);
            int digit1 = (rest < 2) ? 0 : 11 - rest;

            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(cnpj[i].ToString()) * multi2[i];
            rest = (sum % 11);
            int digit2 = (rest < 2) ? 0 : 11 - rest;

            return cnpj.EndsWith(digit1.ToString() + digit2.ToString());
        }
    }
}
