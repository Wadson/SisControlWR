using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisControl
{
    internal class PersonalizarControles
    {
        private static HashSet<TextBox> TextBoxesPersonalizados = new HashSet<TextBox>();

        public static void PersonalizarTextBoxes(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    if (!TextBoxesPersonalizados.Contains(textBox))
                    {
                        textBox.KeyDown += TextBox_KeyDown;
                        TextBoxesPersonalizados.Add(textBox);
                    }
                }
                else
                {
                    PersonalizarTextBoxes(control.Controls);
                }
            }
        }

        private static void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.BackColor = Color.LightBlue;
            }
        }

        private static void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.BackColor = Color.White;
            }
        }

        private static void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var nextControl = textBox.Parent.GetNextControl(textBox, true);
                    if (nextControl is TextBox)
                    {
                        nextControl.Focus();
                        e.Handled = true;
                    }
                }
                else if (e.KeyCode == Keys.Tab)
                {
                    var nextControl = textBox.Parent.GetNextControl(textBox, true);
                    if (nextControl is TextBox)
                    {
                        nextControl.Focus();
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
