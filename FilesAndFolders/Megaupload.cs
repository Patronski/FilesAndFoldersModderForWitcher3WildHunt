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

        public static void DownloadFolder(string downloadFolder, string urlMega, RichTextBox reportBox)
        {
            try
            {
                MegaApiClient mega = new MegaApiClient();
                mega.LoginAnonymous();
                reportBox.Text += Environment.NewLine + "Connecting to the host ...";

                Uri folderLink = new Uri(urlMega);
                IEnumerable<INode> nodes = mega.GetNodesFromLink(folderLink);
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
                        mega.DownloadFile(node, downloadedFile);
                        reportBox.Text += Environment.NewLine + $"downloaded file - {node.Name}";
                    }
                }

                mega.Logout();
            }
            catch(Exception ex)
            {
                reportBox.Text += Environment.NewLine + "Error: " + ex.Message;
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
