using CG.Web.MegaApiClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesAndFolders
{
    internal class Megaupload
    {
        public const string pass = "QwErTy123";
        public const string user = "donstz@yahoo.com";
        public const string key = "5iTGba9EYEPaRG9vIgiGwQ";

        public static async Task<bool> DownloadFolderAsync(string downloadFolder, string urlMega, RichTextBox reportBox)
        {
            try
            {
                MegaApiClient mega = new MegaApiClient();
                await mega.LoginAnonymousAsync();
                reportBox.Text += Environment.NewLine + "Connecting to the host ...";

                Uri folderLink = new Uri(urlMega);

                IEnumerable<INode> nodes = mega.GetNodesFromLink(folderLink);
                reportBox.Text += Environment.NewLine + "received information";

                foreach (INode node in nodes.Where(x => x.Type == NodeType.File))
                {
                    string parents = await GetParents(node, nodes);
                    var downloadSubFolder = downloadFolder + "\\" + parents;
                    Directory.CreateDirectory(downloadSubFolder);
                    Console.WriteLine($"Downloading {downloadSubFolder}\\{node.Name}");

                    var downloadedFile = Path.Combine(downloadSubFolder, node.Name);
                    if (!File.Exists(downloadedFile))
                    {
                        await mega.DownloadFileAsync(node, downloadedFile);
                        reportBox.Text += Environment.NewLine + $"downloaded file - {node.Name}";
                    }
                }

                await mega.LogoutAsync();
                return true;
            }
            catch(FormatException ex)
            {
                reportBox.Text += Environment.NewLine + "Error: Url is not correct!";
                return false;
            }
            catch(Exception ex)
            {
                reportBox.Text += Environment.NewLine + "Error: " + ex.Message;
                return false;
            }
        }

        private static async Task<string> GetParents(INode node, IEnumerable<INode> nodes)
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
