using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio01
{
    public partial class FrmArchivoAsync : Form
    {
        public ConvertAsync convertAsync;
        public FrmArchivoAsync()
        {
            InitializeComponent();
        }

        private void btnAbrirFile_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;

            using (var fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false;
                result= fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }
            if(result == DialogResult.OK)
            {
                if(string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Nombre invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);    
                }
                else
                {
                    try
                    {
                        convertAsync = new ConvertAsync(fileName);
                        convertAsync.OpenOrCreateFile();
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            convertAsync.Convert();
        }
    }
}
