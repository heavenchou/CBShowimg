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
        static public string ImageRootPath = "";    // 圖檔的根目錄

        // 載入 XML
        static public void LoadFromXML(string XMLFile)
        {
            LineHeadItems.Clear();

            // 設定 settings

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreWhitespace = true;

            // 建立 XmlReader 物件

            XmlReader reader = XmlReader.Create(XMLFile, settings);
            reader.MoveToContent();
            // Parse the file and display each of the nodes.

            while (reader.Read()) {
                if(reader.IsStartElement()) {
                    switch (reader.Name) {
                        case "rootpath":
                            reader.Read();
                            ImageRootPath = reader.Value;
                            break;
                        case "path":
                            if(reader.HasAttributes) {
                                // 有 id 屬性
                                if (reader.MoveToAttribute("id")) {
                                    string sID = reader.Value;
                                    if(!LineHeadItems.ContainsKey(sID)) {
                                        LineHeadItems[sID] = new CLineHeadItem(sID);
                                    }
                                    // 取得名字
                                    if (reader.MoveToAttribute("name")) {
                                        LineHeadItems[sID].Name = reader.Value;
                                    }
                                    // 取得目錄
                                    reader.MoveToElement();
                                    reader.Read();
                                    LineHeadItems[sID].PathRegular = reader.Value;
                                    LineHeadItems[sID].PathRegulars.Add(reader.Value);
                                }
                            }
                            break;
                    }
                }
            }
            reader.Dispose();
        }
    }
}
