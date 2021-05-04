using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CBShowimg
{
    static public class Option
    {
        static public Dictionary<string, CLineHeadItem> LineHeadItems = new Dictionary<string, CLineHeadItem>();

        static public void LoadFromXML(string XMLFile)
        {
            // 載入 XML
            LineHeadItems["T"] = new CLineHeadItem("T");
            LineHeadItems["X"] = new CLineHeadItem("X");

            LineHeadItems["T"].Name = "大正藏";
            LineHeadItems["T"].PathRegular = @"d:\_封存\大藏經圖檔\大正新脩大藏經原版\{id}{vol}-g4\{pagerange}\{vol}-{page}.TIF";
            
            LineHeadItems["X"].Name = "卍新纂續藏經";
            LineHeadItems["X"].PathRegular = @"d:\_封存\大藏經圖檔\卍新纂續藏經\{id}{vol}-g4\{pagerange}\{vol}-{page}.TIF";
        }
    }
}
