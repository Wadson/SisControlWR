using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SisControl
{
    public partial class PhoneFormat : UserControl
    {
        public PhoneFormat()
        {
            InitializeComponent();
            txtTelefone.TextChanged += txtTelefone_TextChanged;
            txtTelefone.KeyPress += txtTelefone_KeyPress;
        }
        public string Text
        {
            get => txtTelefone.Text; // textBox1 é o controle interno do tipo TextBox
            set => txtTelefone.Text = value;
        }
        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar entrada não numérica
            }
        }
       
        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            if (_isFormatting) return;

            _isFormatting = true;

            var text = txtTelefone.Text;
            var selectionStart = txtTelefone.SelectionStart;
            var textWithoutFormatting = new string(text.Where(char.IsDigit).ToArray());

            try
            {
                var formattedText = FormatPhoneNumber(textWithoutFormatting);

                if (text != formattedText)
                {
                    txtTelefone.Text = formattedText;
                    selectionStart = AdjustCursorPosition(formattedText, selectionStart);
                    txtTelefone.SelectionStart = selectionStart;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao formatar o número de telefone: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _isFormatting = false;
        }
        private int AdjustCursorPosition(string formattedText, int selectionStart)
        {
            // Adjust cursor position to account for formatting characters
            int digitIndex = 0;
            for (int i = 0; i < formattedText.Length; i++)
            {
                if (char.IsDigit(formattedText[i]))
                {
                    digitIndex++;
                }
                if (digitIndex >= selectionStart)
                {
                    return i + 1;
                }
            }
            return formattedText.Length;
        }

        private string FormatPhoneNumber(string number)
        {
            number = new string(number.Where(char.IsDigit).ToArray()); // Remover caracteres não numéricos
            int length = number.Length;

            if (length > 11) number = number.Substring(0, 11);

            if (length == 0)
            {
                return string.Empty;
            }
            if (length == 1)
            {
                return $"({number}";
            }
            if (length == 2)
            {
                return $"({number})";
            }
            if (length <= 3)
            {
                return $"({number.Substring(0, 2)}) {number.Substring(2)}";
            }
            if (length <= 7)
            {
                return $"({number.Substring(0, 2)}) {number.Substring(2, 1)} {number.Substring(3)}";
            }
            if (length <= 10)
            {
                return $"({number.Substring(0, 2)}) {number.Substring(2, 1)} {number.Substring(3, 4)}-{number.Substring(7)}";
            }
            if (length == 11)
            {
                return $"({number.Substring(0, 2)}) {number.Substring(2, 1)} {number.Substring(3, 4)}-{number.Substring(7, 4)}";
            }
            return number;
        }


        //private string FormatPhoneNumber(string number)
        //{
        //    number = new string(number.Where(char.IsDigit).ToArray()); // Remover caracteres não numéricos
        //    int length = number.Length;

        //    if (length > 11) number = number.Substring(0, 11);

        //    if (length == 0)
        //    {
        //        return string.Empty;
        //    }
        //    if (length <= 2)
        //    {
        //        return $"({number}";
        //    }
        //    if (length <= 6)
        //    {
        //        return $"({number.Substring(0, 2)}) {number.Substring(2)}";
        //    }
        //    if (length <= 11)
        //    {
        //        return $"({number.Substring(0, 2)}) {number.Substring(2, 5)}-{number.Substring(7)}";
        //    }
        //    return number;
        //}

        private bool _isFormatting;
    }
}
