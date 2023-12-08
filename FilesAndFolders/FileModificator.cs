using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Modpackinstaller
{
    internal class FileModificator
    {
        public static void ModifyWitcherScriptMerger(string gameDirectory, RichTextBox reportBox)
        {
            var fileName = gameDirectory + @"\Witcher Script Merger\WitcherScriptMerger.exe.config";
            var isSuccess = TryEditFile(gameDirectory, fileName);
            if (!isSuccess)
            {
                fileName = gameDirectory + @"\Witcher Script Merger\WitcherScriptMerger.dll.config";
                isSuccess = TryEditFile(gameDirectory, fileName);
                if (!isSuccess)
                {
                    reportBox.Text += $"WitcherScriptMerger file was not edited - " + Environment.NewLine;
                }
            }
        }

        private static bool TryEditFile(string gameDirectory, string fileName)
        {
            try
            {
                var doc = XDocument.Load(fileName);

                var child = doc.Root.Element("appSettings").FirstNode as XElement;
                if (child != null)
                {
                    child.SetAttributeValue("value", gameDirectory);
                    doc.Save(fileName);

                    return true;
                }

            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}
