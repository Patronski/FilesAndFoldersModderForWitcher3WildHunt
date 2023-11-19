
using Modpackinstaller;
using System;
using System.Diagnostics;
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
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            buttonDocumentsDirectory.Enabled = false;
            buttonDownloadDirectory.Enabled = false;
            buttonGameDIrectory.Enabled = false;
            textBoxUrl.Enabled = false;
            buttonStart.Enabled = false;
            buttonInfo.Enabled = false;

            try
            {
                if (textBoxGameDirectory.Text == "" || textBoxDownloadDirectory.Text == "" || textBoxDocumentsDirectory.Text == "")
                {
                    MessageBox.Show("Fill in all missing fields correctly!", "Confirm!", MessageBoxButtons.OK);
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
                        // downloading
                        richTextReport.Text += $"Starting download from Mega." + Environment.NewLine;
                        var result = await Megaupload.DownloadFolderAsync(textBoxDownloadDirectory.Text, textBoxUrl.Text, richTextReport);
                        if (!result) { return; }

                        // extracting
                        richTextReport.Text += $"Starting to extract files in game directory." + Environment.NewLine;
                        var zipExtractor = new ZipExtractor(textBoxGameDirectory.Text, textBoxDocumentsDirectory.Text, richTextReport);
                        zipExtractor.ExtractDirectory(Path.Combine(textBoxDownloadDirectory.Text, textBoxModDirectory.Text));

                        // adding game directory to WitcherScriptMerger.exe.config
                        FileModificator.ModifyWitcherScriptMerger(textBoxGameDirectory.Text, richTextReport);

                        richTextReport.Text += $"The installation process is complete!" + Environment.NewLine;
                    }
                }
            }
            catch (Exception exception)
            {
                richTextReport.Text += $"Unexpected error: {exception.Message}" + Environment.NewLine;
            }
            finally
            {
                buttonDocumentsDirectory.Enabled = true;
                buttonDownloadDirectory.Enabled = true;
                buttonGameDIrectory.Enabled = true;
                textBoxUrl.Enabled = true;
                buttonStart.Enabled = true;
                buttonInfo.Enabled = true;
            }
        }

        private string CheckDirectoriesAreFilledCorrectly()
        {
            var startingFileOfWitcher3 = textBoxGameDirectory.Text + @"\bin\x64\witcher3.exe";
            if (!File.Exists(startingFileOfWitcher3))
            {
                return $"Wrong path to you Witcher 3 game!";
            }

            return "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(477, 599);
            if (File.Exists("saveDownloadUri"))
            {
                textBoxUrl.Text = File.ReadAllText("saveDownloadUri");
            }
        }

        private void buttonDownloadDirectory_Click(object sender, EventArgs e)
        {
            setFolderToTextBox(textBoxDownloadDirectory);
        }

        private void buttonGameDIrectory_Click(object sender, EventArgs e)
        {
            setFolderToTextBox(textBoxGameDirectory);
        }

        private void buttonDocumentsDirectory_Click(object sender, EventArgs e)
        {
            setFolderToTextBox(textBoxDocumentsDirectory);
        }

        private void setFolderToTextBox(TextBox textBox)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox.Text = dialog.SelectedPath;
            }
            else
            {
                textBox.Text = "";
            }
        }

        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText("saveDownloadUri", textBoxUrl.Text);
        }

        private void richTextReport_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            richTextReport.SelectionStart = richTextReport.Text.Length;
            // scroll it automatically
            richTextReport.ScrollToCaret();
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            Process.Start("https://sites.google.com/view/the-witcher-3-teamy-mod-list");
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
