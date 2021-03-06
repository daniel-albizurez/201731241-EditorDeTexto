﻿using System;
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
    public partial class editor : Form
    {
        AFD automata = new AFD();
        bool documentoAbierto;
        string nombreDocumento;
        bool cambios;
        public editor()
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
            lstErrores.Items.Clear();
            foreach (string[] item in automata.Analizar(txtCodigo.Text))
            {
               int posicion = txtCodigo.SelectionStart;
                txtCodigo.Select(Convert.ToInt32(item[5]), item[0].Length);
                txtCodigo.SelectionColor = Color.FromName(item[4]);
                txtCodigo.Select(posicion, 0);

                if (item[1] == "Error")
                {
                    lstErrores.Items.Add(item[0] + ' ' + item[1] + " Linea: " + item[2] + " Columna: " + item[3]);
                }
                cambios = documentoAbierto;
            }

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
            newDocument();
            if (dialogAbrirArchivo.ShowDialog() != DialogResult.Cancel)
            {
                txtCodigo.Clear();
                try
                {
                    using (StreamReader sr = new StreamReader(dialogAbrirArchivo.FileName))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            txtCodigo.AppendText(line + "\n");
                        }
                        documentoAbierto = true;
                        nombreDocumento = dialogAbrirArchivo.FileName;
                        this.Text += ": " + dialogAbrirArchivo.SafeFileName;
                    }
                }
                catch (Exception)
                {
                    lstErrores.Items.Add("Error al abrir el archivo: " + dialogAbrirArchivo.SafeFileName);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*            string nombre = null;
                        if (documentoAbierto)
                        {
                            nombre = nombreDocumento;
                        }
                        else if (dialogGuardarArchivo.ShowDialog() == DialogResult.OK)
                        {
                            nombre = dialogGuardarArchivo.FileName;
                        }

                        if (!String.IsNullOrEmpty(nombre))
                        {
                            string[] lines = txtCodigo.Lines;
                            using (StreamWriter sw = new StreamWriter(nombre))
                            {
                                foreach (string line in lines)
                                {
                                    if (!String.IsNullOrEmpty(line))
                                    {
                                        sw.WriteLine(line);
                                    }
                                }
                            }
                        }*/
            Guardar(false);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDocument();
        }

        private void newDocument()
        {
            if (cambios)
            {
                DialogResult resultado =  MessageBox.Show("Desea guardar los cambios a " + nombreDocumento, "Guardar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    Guardar(false);
                }
            }
            txtCodigo.Clear();
            nombreDocumento = "";
            documentoAbierto = false;
            cambios = false;
            this.Text = "Editor de archivos GT";
        }

        private void Guardar(bool Error)
        {
            SaveFileDialog dialog = (Error) ? dialogExportarErrores : dialogGuardarArchivo ;

            string[] lines = (Error) ? lstErrores.Items.OfType<string>().ToArray() : txtCodigo.Lines;

            string nombre = null;
            if (documentoAbierto && !Error)
            {
                nombre = nombreDocumento;
            }
            else if (dialog.ShowDialog() == DialogResult.OK)
            {
                nombre = dialog.FileName;
            }

            if (!String.IsNullOrEmpty(nombre))
            {
                using (StreamWriter sw = new StreamWriter(nombre))
                {
                    foreach (string line in lines)
                    {
                        /*if (!String.IsNullOrEmpty(line))
                        {*/
                            sw.WriteLine(line);
                        /*}*/
                    }
                }
            }
        }

        private void exportarErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*            string nombre = "";
                        if (dialogExportarErrores.ShowDialog() == DialogResult.OK)
                        {
                            nombre = dialogExportarErrores.FileName;
                        }

                        if (!String.IsNullOrEmpty(nombre))
                        {
                            string[] lines = lstErrores.Items.OfType<string>().ToArray();
                            using (StreamWriter sw = new StreamWriter(nombre))
                            {
                                foreach (string line in lines)
                                {
                                    if (!String.IsNullOrEmpty(line))
                                    {
                                        sw.WriteLine(line);
                                    }
                                }
                            }
                        }*/
            Guardar(true);
        }
    }
}
