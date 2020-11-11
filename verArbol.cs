using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201731241_EditorDeTexto
{
    public partial class verArbol : Form
    {
        public verArbol()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("arbol.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            string nombre = null;
            guardar.AddExtension = true;
            guardar.DefaultExt = ".png";
            guardar.FileName = "arbol.png";
            guardar.OverwritePrompt = true;
            guardar.Filter = "PNG|*.png";
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                nombre = guardar.FileName;
            }
            if (!String.IsNullOrEmpty(nombre))
            {
                File.Copy("arbol.png", nombre,true);
            }

        }
    }
}
