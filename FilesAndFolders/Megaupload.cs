using CG.Web.MegaApiClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesAndFolders
{
    internal class Megaupload
    {
        public const string pass = "QwErTy123";
        public const string user = "donstz@yahoo.com";
        public const string key = "5iTGba9EYEPaRG9vIgiGwQ";

        public static void DownloadFile(string downloadPath)
        {
            MegaApiClient mega = new MegaApiClient();
            mega.Login(user, pass);

            IEnumerable<INode> nodes = mega.GetNodes();
            List<INode> allFiles = nodes.Where(n => n.Type == NodeType.File).ToList();
            INode myFile = allFiles.FirstOrDefault();

            mega.DownloadFile(myFile, downloadPath);
        }

        public static void DownloadFolder(string gameDirectory, RichTextBox reportBox)
        {
            try
            {
                MegaApiClient client = new MegaApiClient();
                client.LoginAnonymous();

                reportBox.Text += "Connected Anonymoysly";

                Uri folderLink = new Uri(@"https://mega.nz/folder/7ZdGyJ5A#YrBfMwra6oGqTqxG7fNcMg");
                IEnumerable<INode> nodes = client.GetNodesFromLink(folderLink);

                reportBox.Text += System.Environment.NewLine + "received information";

                foreach (INode node in nodes.Where(x => x.Type == NodeType.File))
                {
                    string parents = GetParents(node, nodes);
                    var saveDirectory = gameDirectory + "\\" + parents;
                    Directory.CreateDirectory(saveDirectory);
                    Console.WriteLine($"Downloading {saveDirectory}\\{node.Name}");

                    var outputFilePath = Path.Combine(saveDirectory, node.Name);
                    if (!File.Exists(outputFilePath))
                    {
                        client.DownloadFile(node, outputFilePath);
                        reportBox.Text += System.Environment.NewLine + $"downloaded file - {node.Name}";
                    }

                    //ExtrACT FILE
                    ZipFile.ExtractToDirectory(outputFilePath, gameDirectory);
                    reportBox.Text += System.Environment.NewLine + $"extracted to game directory - {node.Name}";
                }

                client.Logout();
            }
            catch(Exception ex)
            {
                reportBox.Text += System.Environment.NewLine + "Error: " + ex.Message;
                reportBox.Text += System.Environment.NewLine + "Please choose valid directory";

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
