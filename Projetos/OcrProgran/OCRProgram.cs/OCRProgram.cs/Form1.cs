using IronOcr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
//using Patagames.Ocr;
using Tesseract;

namespace OCRProgram.cs
{
    public partial class Form1 : Form
    {
       
        private Bitmap image;
        private object result_text;
     
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                image = new Bitmap(file.FileName);
                pictureBox1.Image = image;
            }
        
        }
        //Botão Abrir
        public void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = false;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)

            {
                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                string ocrimage = System.IO.Path.GetFileName(file.FileName);
                File.Copy(file.FileName, paths + "\\IMG\\" + ocrimage);
                image = new Bitmap(file.FileName);
                pictureBox1.Image = image;
                   
            }
        }
        //Botão sair
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }
        //Botão OCR
        [Obsolete]
        private async void button2_Click(object sender, EventArgs e)

        {

                Bitmap img = new Bitmap(pictureBox1.Image);
                var ocr = new TesseractEngine("./tessdata", "por", EngineMode.Default);
                var page = ocr.Process(img);
                textBox1.Text = page.GetText();


            // var ocr = new AutoOcr();
            //textBox1.Text = ocr.Read(image).ToString();
            /*using (var objocr = OcrApi.Create())
            {
                objocr.Init(Patagames.Ocr.Enums.Languages.English);
                string plaintext = objocr.GetTextFromImage(pictureBox1.ImageLocation);
                textBox1.Text = plaintext;
           } 
          */
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
