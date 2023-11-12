
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FilesAndFolders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start button
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Fill all missing directories correctly!", "Confirm!", MessageBoxButtons.OK);
            }
            else
            {
                var checkResult = CheckDirectoriesAreFilledCorrectly();
                if (checkResult != "")
                {
                    MessageBox.Show(checkResult, "Confirm!", MessageBoxButtons.OK);
                    return;
                }

                var confirmResult = MessageBox.Show("Are you sure you want to continue?", "Confirm!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    Megaupload.DownloadFolder(this.textBox1.Text, this.textBox2.Text, textBox3.Text, richTextBox1);
                }
            }
        }

        private string CheckDirectoriesAreFilledCorrectly()
        {
            var startingFileOfWitcher3 = textBox1.Text + @"\bin\x64\witcher3.exe";
            if (!File.Exists(startingFileOfWitcher3))
            {
                return $"Wrong path to you Witcher 3 game!";
            }

            return "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(477, 500);
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

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)


            {
                textBox2.Text = dialog.SelectedPath;
            }
            else
            {
                textBox2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)


            {
                textBox3.Text = dialog.SelectedPath;
            }
            else
            {
                textBox3.Text = "";
            }
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
