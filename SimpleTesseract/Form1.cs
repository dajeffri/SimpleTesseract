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
using Tesseract;

namespace SimpleTesseract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void Browse_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Image|*.bmp;*.pnm;*.png;*.jfif;*.jpg;*.tiff";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileNameTextBox.Text = ofd.FileName;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            String fileName = fileNameTextBox.Text;
            if (File.Exists(fileNameTextBox.Text))
            {
                Bitmap img = new Bitmap(fileName);
                TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
                Page page = engine.Process(img, PageSegMode.Auto);
                String Text = page.GetText();
                Text = Text.Replace("\n", Environment.NewLine);
                outputTextBox.Text = Text;
                img.Dispose();
            }
            else
            {
                outputTextBox.Text = "Invalid File";
            }
            
        }
    }
}
