using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace CBShowimg
{
    static public class Option
    {
        static public Dictionary<string, CLineHeadItem> LineHeadItems = new Dictionary<string, CLineHeadItem>();

        // 載入 XML
        static public void LoadFromXML(string XMLFile)
        {
            // 設定 settings

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreWhitespace = true;

            // 建立 XmlReader 物件

            XmlReader reader = XmlReader.Create(XMLFile, settings);
            reader.MoveToContent();
            // Parse the file and display each of the nodes.

            string sID = "";
            string tagName = "";
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        tagName = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        switch (tagName) {
                            case "id": 
                                sID = reader.Value;
                                LineHeadItems[sID] = new CLineHeadItem(sID);
                                break;
                            case "name": 
                                LineHeadItems[sID].Name = reader.Value; 
                                break;
                            case "path": 
                                LineHeadItems[sID].PathRegular = reader.Value; 
                                break;
                        }
                        break;
                }
            }
        }
    }
}
