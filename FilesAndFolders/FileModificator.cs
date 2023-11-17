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
            try
            {
                var fileName = gameDirectory + @"\Witcher Script Merger\WitcherScriptMerger.exe.config";
                var doc = XDocument.Load(fileName);

                var child = doc.Root.Element("appSettings").FirstNode as XElement;
                if (child != null)
                {
                    child.SetAttributeValue("value", gameDirectory);
                }

                doc.Save(fileName);
            }
            catch(Exception e)
            {
                reportBox.Text += Environment.NewLine + $"WitcherScriptMerger file was not edited - " + e.Message;
            }
        }
    }
}
