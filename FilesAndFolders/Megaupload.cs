using CG.Web.MegaApiClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace FilesAndFolders
{
    internal class Megaupload
    {
        public const string pass = "QwErTy123";
        public const string user = "donstz@yahoo.com";
        public const string key = "5iTGba9EYEPaRG9vIgiGwQ";

        public const string FileToSaveInDocumentsFolder = "TW3 Settings.zip";

        public static void DownloadFile(string downloadPath)
        {
            MegaApiClient mega = new MegaApiClient();
            mega.Login(user, pass);

            IEnumerable<INode> nodes = mega.GetNodes();
            List<INode> allFiles = nodes.Where(n => n.Type == NodeType.File).ToList();
            INode myFile = allFiles.FirstOrDefault();

            mega.DownloadFile(myFile, downloadPath);
        }

        public static void DownloadFolder(string gameDirectory, string downloadFolder, string documentsDirectory, RichTextBox reportBox)
        {
            try
            {
                MegaApiClient client = new MegaApiClient();
                client.LoginAnonymous();
                reportBox.Text += Environment.NewLine + "Connected to the host";

                Uri folderLink = new Uri(@"https://mega.nz/folder/jBVmXRTB#T10xQsr3QRGccbmKCcDs5w");
                IEnumerable<INode> nodes = client.GetNodesFromLink(folderLink);
                reportBox.Text += Environment.NewLine + "received information";

                foreach (INode node in nodes.Where(x => x.Type == NodeType.File))
                {
                    string parents = GetParents(node, nodes);
                    var downloadSubFolder = downloadFolder + "\\" + parents;
                    Directory.CreateDirectory(downloadSubFolder);
                    Console.WriteLine($"Downloading {downloadSubFolder}\\{node.Name}");

                    var downloadedFile = Path.Combine(downloadSubFolder, node.Name);
                    if (!File.Exists(downloadedFile))
                    {
                        client.DownloadFile(node, downloadedFile);
                        reportBox.Text += Environment.NewLine + $"downloaded file - {node.Name}";
                    }

                    ExtractZipFile(gameDirectory, documentsDirectory, reportBox, node, downloadedFile);
                }

                client.Logout();
                reportBox.Text += Environment.NewLine + $"The installation process is complete!";
            }
            catch(Exception ex)
            {
                reportBox.Text += Environment.NewLine + "Error: " + ex.Message;
                reportBox.Text += Environment.NewLine + "Please choose valid directory";

            }
        }

        private static void ExtractZipFile(string gameDirectory, string documentsDirectory, RichTextBox reportBox, INode node, string downloadedFile)
        {
            using (ZipArchive source = ZipFile.Open(downloadedFile, ZipArchiveMode.Read, null))
            {
                string extractDirectory; ;
                if (node.Name == FileToSaveInDocumentsFolder)
                {
                    extractDirectory = documentsDirectory;
                }
                else
                {
                    extractDirectory = gameDirectory;
                }
                foreach (ZipArchiveEntry entry in source.Entries)
                {
                    string fullPath = Path.GetFullPath(Path.Combine(extractDirectory, entry.FullName));

                    if (Path.GetFileName(fullPath).Length != 0)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                        entry.ExtractToFile(fullPath, true);
                    }
                }
                reportBox.Text += Environment.NewLine + $"extracted - {node.Name}";
            }
        }

        private static string GetParents(INode node, IEnumerable<INode> nodes)
        {
            List<string> parents = new List<string>();
            while (node.ParentId != null)
            {
                INode parentNode = nodes.Single(x => x.Id == node.ParentId);
                parents.Insert(0, parentNode.Name);
                node = parentNode;
            }

            return string.Join("\\", parents);
        }
    }
}
