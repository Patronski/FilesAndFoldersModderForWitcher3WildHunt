
using Modpackinstaller;
using System;
using System.Drawing;
using System.IO;
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
                        //return;
                    }

                    var confirmResult = MessageBox.Show("Are you sure you want to continue?", "Confirm!", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        // downloading files from Mega to download directory
                        richTextReport.Text += Environment.NewLine + $"Starting download from Mega.";
                        var result = await Megaupload.DownloadFolderAsync(textBoxDownloadDirectory.Text, textBoxUrl.Text, richTextReport);
                        if (!result) { return; }

                        richTextReport.Text += Environment.NewLine + $"Starting to extract files in game directory.";
                        var dir = new DirectoryInfo(Path.Combine(textBoxDownloadDirectory.Text, "MOD PACK"));
                        var files = dir.GetFiles("*", SearchOption.AllDirectories);

                        // extracting files to game directory
                        foreach (var file in files)
                        {
                            if (file.Extension == ".zip")
                            {
                                var zipExtractor = new ZipExtractor(textBoxGameDirectory.Text, textBoxDocumentsDirectory.Text, richTextReport);
                                zipExtractor.ExtractZipFile(file.Name, file.FullName);
                            }
                        }

                        // adding game directory to WitcherScriptMerger.exe.config
                        FileModificator.ModifyWitcherScriptMerger(textBoxGameDirectory.Text, richTextReport);

                        richTextReport.Text += Environment.NewLine + $"The installation process is complete!";
                    }
                }
            }
            catch (Exception exception)
            {
                richTextReport.Text += Environment.NewLine + $"Unexpected error: {exception.Message}";
            }
            finally
            {
                buttonDocumentsDirectory.Enabled = true;
                buttonDownloadDirectory.Enabled = true;
                buttonGameDIrectory.Enabled = true;
                textBoxUrl.Enabled = true;
                buttonStart.Enabled = true;
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
            Size = new Size(477, 543);
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
