using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace Modpackinstaller
{
    internal class ZipExtractor
    {
        public ZipExtractor(string gameDirectory, string documentsDirectory, RichTextBox reportBox)
        {
            this.GameDirectory = gameDirectory;
            this.DocumentsDirectory = documentsDirectory;
            this.ReportBox = reportBox;
        }

        private string GameDirectory { get; }
        private string DocumentsDirectory { get; }
        private RichTextBox ReportBox { get; }

        public void ExtractDirectory(string path)
        {
            try
            {
                var dir = new DirectoryInfo(path);
                var firstDirectories = dir.GetDirectories("*", SearchOption.TopDirectoryOnly);

                var anonymouseDirObj = firstDirectories
                    .Select(s => new 
                    { 
                        dir = s,
                        substr = s.Name.Any(x => char.IsDigit(x)) ? int.Parse(s.Name.Substring(0, s.Name.IndexOf('.'))) : int.MaxValue
                    });

                var dirOrdered = anonymouseDirObj
                    .OrderBy(x => x.substr).Select(x => x.dir)
                    .ToList();

                foreach (var directory in dirOrdered)
                {
                    var files = directory.GetFiles("*", SearchOption.AllDirectories);
                    foreach (var file in files)
                    {
                        if (file.Extension == ".zip")
                        {
                            ExtractZipFile(file.Name, file.FullName);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                ReportBox.Text += $"Error extracting directory - {path} - {e.Message}" + Environment.NewLine;
            }
        }

        public void ExtractZipFile(string archiveName, string fullPathToArchive)
        {
            try
            {
                using (ZipArchive source = ZipFile.Open(fullPathToArchive, ZipArchiveMode.Read, null))
                {
                    string extractDirectory; ;
                    if (archiveName == "TW3 Settings.zip")
                    {
                        extractDirectory = DocumentsDirectory;
                    }
                    else
                    {
                        extractDirectory = GameDirectory;
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
                    ReportBox.Text += $"extracted - {archiveName}" + Environment.NewLine;
                }
            }
            catch(Exception e)
            {
                ReportBox.Text += $"Error extracting - {archiveName} - {e.Message}" + Environment.NewLine;
            }
        }
    }
}
