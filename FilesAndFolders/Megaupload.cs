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
                reportBox.Text += "Connecting to the host ..." + Environment.NewLine;

                Uri folderLink = new Uri(urlMega);

                IEnumerable<INode> nodes = await mega.GetNodesFromLinkAsync(folderLink);
                reportBox.Text += "received information" + Environment.NewLine;

                foreach (INode node in nodes.Where(x => x.Type == NodeType.File))
                {
                    string parents = GetParents(node, nodes);
                    var downloadSubFolder = downloadFolder + "\\" + parents;
                    Directory.CreateDirectory(downloadSubFolder);

                    var downloadedFile = Path.Combine(downloadSubFolder, node.Name);
                    if (!File.Exists(downloadedFile))
                    {
                        DateTime dt1 = DateTime.UtcNow;

                        await mega.DownloadFileAsync(node, downloadedFile);

                        DateTime dt2 = DateTime.UtcNow;
                        var dSpeed = Math.Round((node.Size / 1024) / (dt2 - dt1).TotalSeconds, 2);
                        dSpeed = (float)System.Math.Round(dSpeed, 1);
                        reportBox.Text += $"downloaded file - {node.Name} - ({node.Size / 1024}KB) ({String.Format("{0:0.0}", dSpeed)}KB/s)" + Environment.NewLine;
                    }
                }

                await mega.LogoutAsync();
                return true;
            }
            catch(FormatException ex)
            {
                reportBox.Text += "Error: Url is not correct!" + Environment.NewLine;
                return false;
            }
            catch(Exception ex)
            {
                reportBox.Text += "Error: " + ex.Message + Environment.NewLine;
                return false;
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

        private static async Task SaveFileStream(String path, Stream stream)
        {
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            await stream.CopyToAsync(fileStream);
            fileStream.Dispose();
        }
    }
}
