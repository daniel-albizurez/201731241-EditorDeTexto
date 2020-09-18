namespace _201731241_EditorDeTexto
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblCol = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLinea = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.RichTextBox();
            this.lstErrores = new System.Windows.Forms.ListBox();
            this.dialogAbrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.dialogGuardarArchivo = new System.Windows.Forms.SaveFileDialog();
            this.dialogExportarErrores = new System.Windows.Forms.SaveFileDialog();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoArchivo,
            this.abrirArchivo,
            this.guardarArchivo,
            this.exportarErroresToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // nuevoArchivo
            // 
            this.nuevoArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.proyectoToolStripMenuItem});
            this.nuevoArchivo.Name = "nuevoArchivo";
            this.nuevoArchivo.Size = new System.Drawing.Size(180, 22);
            this.nuevoArchivo.Text = "New";
            this.nuevoArchivo.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // abrirArchivo
            // 
            this.abrirArchivo.Name = "abrirArchivo";
            this.abrirArchivo.Size = new System.Drawing.Size(180, 22);
            this.abrirArchivo.Text = "Open";
            this.abrirArchivo.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // guardarArchivo
            // 
            this.guardarArchivo.Name = "guardarArchivo";
            this.guardarArchivo.Size = new System.Drawing.Size(180, 22);
            this.guardarArchivo.Text = "Save";
            this.guardarArchivo.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exportarErroresToolStripMenuItem
            // 
            this.exportarErroresToolStripMenuItem.Name = "exportarErroresToolStripMenuItem";
            this.exportarErroresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportarErroresToolStripMenuItem.Text = "Exportar Errores";
            this.exportarErroresToolStripMenuItem.Click += new System.EventHandler(this.exportarErroresToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblCol);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblLinea);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodigo);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstErrores);
            this.splitContainer1.Size = new System.Drawing.Size(780, 430);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblCol
            // 
            this.lblCol.AutoSize = true;
            this.lblCol.Location = new System.Drawing.Point(120, 235);
            this.lblCol.Name = "lblCol";
            this.lblCol.Size = new System.Drawing.Size(13, 13);
            this.lblCol.TabIndex = 7;
            this.lblCol.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Col/Ch:";
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Location = new System.Drawing.Point(40, 235);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(13, 13);
            this.lblLinea.TabIndex = 5;
            this.lblLinea.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ln:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(12, 3);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(756, 229);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "";
            this.txtCodigo.SelectionChanged += new System.EventHandler(this.txtCodigo_SelectionChanged);
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // lstErrores
            // 
            this.lstErrores.FormattingEnabled = true;
            this.lstErrores.Location = new System.Drawing.Point(12, 4);
            this.lstErrores.Name = "lstErrores";
            this.lstErrores.Size = new System.Drawing.Size(756, 147);
            this.lstErrores.TabIndex = 0;
            // 
            // dialogAbrirArchivo
            // 
            this.dialogAbrirArchivo.DefaultExt = "gt";
            this.dialogAbrirArchivo.Filter = "GT Files|*.gt";
            // 
            // dialogGuardarArchivo
            // 
            this.dialogGuardarArchivo.DefaultExt = "gt";
            this.dialogGuardarArchivo.Filter = "GT Files|*.gt";
            // 
            // dialogExportarErrores
            // 
            this.dialogExportarErrores.DefaultExt = "gte";
            this.dialogExportarErrores.Filter = "GTE Files|*.gte";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // proyectoToolStripMenuItem
            // 
            this.proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            this.proyectoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.proyectoToolStripMenuItem.Text = "Proyecto";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 454);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtCodigo;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoArchivo;
        private System.Windows.Forms.ToolStripMenuItem guardarArchivo;
        private System.Windows.Forms.ToolStripMenuItem abrirArchivo;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label lblCol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstErrores;
        private System.Windows.Forms.OpenFileDialog dialogAbrirArchivo;
        private System.Windows.Forms.SaveFileDialog dialogGuardarArchivo;
        private System.Windows.Forms.ToolStripMenuItem exportarErroresToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog dialogExportarErrores;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proyectoToolStripMenuItem;
    }
}

