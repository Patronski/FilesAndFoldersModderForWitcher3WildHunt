using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modpackinstaller
{
    internal class FileModificator
    {
        public string MyProperty { get; set; }
        //WitcherScriptMerger.exe.config

        public static void ModifyWitcherScriptMerger(string gameDirectory)
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
    }
}
