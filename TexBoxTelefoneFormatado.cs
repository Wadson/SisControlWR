using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SisControl
{
    public partial class TexBoxTelefoneFormatado : UserControl
    {
        public TexBoxTelefoneFormatado()
        {
            InitializeComponent();            
            txtTelefone.TextChanged += txtTelefone_TextChanged;
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            var oldText = txtTelefone.Text;
            var selectionStart = txtTelefone.SelectionStart;
            var selectionLength = txtTelefone.SelectionLength;

            txtTelefone.TextChanged -= txtTelefone_TextChanged;

            txtTelefone.Text = FormatPhoneNumber(oldText);
            var newText = txtTelefone.Text;

            // Calcular a nova posição do cursor, ajustando para caracteres especiais adicionados
            var newSelectionStart = selectionStart + (newText.Length - oldText.Length);
            if (newSelectionStart < 0) newSelectionStart = 0;
            if (newSelectionStart > newText.Length) newSelectionStart = newText.Length;

            txtTelefone.SelectionStart = newSelectionStart;
            txtTelefone.SelectionLength = selectionLength;

            txtTelefone.TextChanged += txtTelefone_TextChanged;
        }

        public string FormatPhoneNumber(string number)
        {
            number = new string(number.Where(char.IsDigit).ToArray()); // Remover caracteres não numéricos

            if (number.Length == 11)
            {
                return string.Format("({0}) {1}-{2}",
                    number.Substring(0, 2),
                    number.Substring(2, 5),
                    number.Substring(7));
            }
            else if (number.Length == 10)
            {
                return string.Format("({0}) {1}-{2}",
                    number.Substring(0, 2),
                    number.Substring(2, 4),
                    number.Substring(6));
            }
            else
            {
                return number;
            }
        }
        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            txtTelefone.BackColor = Color.AliceBlue;
        }

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            txtTelefone.BackColor= Color.White;
        }
    }
}
