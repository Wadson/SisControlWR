using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FormPersonalizado : Form
    {
        public FormPersonalizado()
        {
            // Chamar o método para configurar os eventos ao inicializar o formulário
            PersonalizarTextBoxes(this);
        }
        public static void PersonalizarTextBoxes(Control control)
        {
            // Itera por todos os controles dentro do container
            foreach (Control child in control.Controls)
            {
                // Se o controle for um TextBox, adiciona os eventos
                if (child is TextBox textBox)
                {
                    textBox.Enter += (sender, e) => textBox.BackColor = Color.LightBlue; // Fundo azul claro no foco
                    textBox.Leave += (sender, e) => textBox.BackColor = Color.White;    // Fundo branco ao perder o foco
                }

                // Caso o controle tenha filhos, aplica recursivamente
                if (child.HasChildren)
                {
                    PersonalizarTextBoxes(child);
                }
            }
        }

    }
}