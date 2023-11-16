using CG.Web.MegaApiClient;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modpackinstaller
{
    internal class ZipExtractor
    {
        public const string FileToSaveInDocumentsFolder = "TW3 Settings.zip";
        public ZipExtractor(string gameDirectory, string documentsDirectory, RichTextBox reportBox)
        {
            this.gameDirectory = gameDirectory;
            this.documentsDirectory = documentsDirectory;
            this.reportBox = reportBox;
        }

        private string gameDirectory { get; }
        private string documentsDirectory { get; }
        private RichTextBox reportBox { get; }

        public void ExtractZipFile(string archiveName, string fullPathToArchive)
        {
            try
            {
                using (ZipArchive source = ZipFile.Open(fullPathToArchive, ZipArchiveMode.Read, null))
                {
                    string extractDirectory; ;
                    if (archiveName == FileToSaveInDocumentsFolder)
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
                    reportBox.Text += Environment.NewLine + $"extracted - {archiveName}";
                }
            }
            catch(Exception e)
            {
                reportBox.Text += Environment.NewLine + $"Error extracting - {archiveName} - {e.Message}";
            }
        }
    }
}
