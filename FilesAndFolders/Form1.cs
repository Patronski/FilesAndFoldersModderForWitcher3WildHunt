using DriveV3Snippets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesAndFolders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to continue?",
                                     "Confirm!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Megaupload.DownloadFolder(this.textBox1.Text, richTextBox1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            
            
            {
                textBox1.Text = dialog.SelectedPath;
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}


//WebClient Client = new WebClient();
//Client.DownloadFile("https://drive.google.com/file/d/0B9Sf0dabv094cUR0bmcxQVdCNUE/view?usp=drive_link&resourcekey=0-5knRjsTHmQbsUhDBZ0zU1Q",
//    @"C:\Users\donst\Downloads\soham.mp3");

//var ms = DownloadFile.DriveDownloadFile("https://drive.google.com/file/d/0B9Sf0dabv094cUR0bmcxQVdCNUE/view?usp=drive_link&resourcekey=0-5knRjsTHmQbsUhDBZ0zU1Q");
//using (FileStream file = new FileStream("file.bin", FileMode.Create, System.IO.FileAccess.Write))
//{
//    ms.CopyTo(file);
//    byte[] bytes = new byte[ms.Length];
//    ms.Read(bytes, 0, (int)ms.Length);
//    file.Write(bytes, 0, bytes.Length);
//    ms.Close();
//}
