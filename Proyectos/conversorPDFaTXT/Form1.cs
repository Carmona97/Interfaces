using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;


namespace conversorPDFaTXT
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            convertir.Enabled = false;
            persistir.Enabled = false;
        }

        private void abrirPdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ficheros PDF (*.pdf)|*.pdf|Ficheros Word (*.docx)|*.docx";
            if (ofd.ShowDialog() == DialogResult.OK) { 
                string path = ofd.FileName.ToString();
                ruta.Text = path;
                if (ruta.Text.Length > 0)
                {
                    convertir.Enabled = true;
                }
            } 
        }

        private void convertir_Click(object sender, EventArgs e)
        {
            PDDocument doc = PDDocument.load(ruta.Text);
            PDFTextStripper stripper = new PDFTextStripper();
            textoPlano.Text = (stripper.getText(doc));
            if(textoPlano.Text.Length > 0)
            {
                persistir.Enabled = true;
            }
        }

        private void persistir_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "Fichero de texto|*.txt";
            if(saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length > 0) {
                textoPlano.SaveFile(saveFileDialog1.FileName,RichTextBoxStreamType.PlainText);
            }
        }
    }
}
