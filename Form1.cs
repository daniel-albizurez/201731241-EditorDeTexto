using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201731241_EditorDeTexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private int[] GetCursorPosition(RichTextBox txtArea)
        {
            // Para conocer la posicion del cursor en la caja de texto
            // SelectionStart devuelve la posicion donde se encuentra el cursor, un entero 
            // dentro de todo el texto
            // GetLineFromCharIndex devuelve la linea donde se encuentra el indice enviado, 
            // en este caso donde se encuentra el cursor
            // GetFirstCharIndexOfCurrentLine, devuelve el indice del primer caracter dentro de la linea actual
            // Restandolo del indice general obtenemos la posicion del cursor dentro de la linea
            int index = txtArea.SelectionStart;
            int line = 1 + txtArea.GetLineFromCharIndex(index);
            int column = 1 + index - txtArea.GetFirstCharIndexOfCurrentLine();
            return new int[] { line, column };
        }

        private void txtCodigo_SelectionChanged(object sender, EventArgs e)
        {
            int[] posicion = GetCursorPosition(txtCodigo);
            lblLinea.Text = posicion[0].ToString();
            lblCol.Text = posicion[1].ToString();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtCodigo.Text = openFileDialog1.FileName;
            }
        }
    }
}
