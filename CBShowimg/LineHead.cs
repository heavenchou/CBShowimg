using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CBShowimg {

    // 項目總類
    enum ItemType : ushort {
        Tripitaka = 0,  // 藏經
        Gaiji = 1,      // 缺字
        Siddam = 2,     // 悉曇
        Ranjana = 3     // 蘭扎
    }

    public class CLineHeadItem {
        ItemType Type;              // 種類
        string ID;                  // T
        public string Name;         // 大正藏
        // public int VolNum;          // 冊數的位數 2 代表 2 位數
        public string PathRegular;  // 圖檔目錄的正規式

        public CLineHeadItem(string id) {
            ID = id;
        }
    }

    public class CLineHead {
        public string ID;          // T
        public string Path;        // 圖檔目錄
        public string LineHead;
        public string Vol;
        public string Sutra;       // 經號
        public string Page;        // 頁碼
        public string Field;       // 欄
        public string Line;        // 行

        public CLineHead(string s) {
            LineHead = s;
            AnalysisLineHead();
        }

        // T01n0001_p0001a01
        Regex regex = new Regex(@"(?<id>[A-Z]+)(?<vol>\d+)n(?<sutra>.{5})p(?<page>.\d{3})(?<field>[a-z]?)(?<line>\d{2,3})?");
        // K0647V17P0815a01
        Regex regexK = new Regex(@"(?<id>K)(?<sutra>\d{4})V(?<vol>\d\d)P(?<page>\d{4})(?<field>[a-z]?)(?<line>\d{2,3})?");


        public void AnalysisLineHead() {
            // 標準行首格式 T01n0001_p0001a01
            Match m = regex.Match(LineHead);
            if (!m.Success) {
                m = regexK.Match(LineHead);
            }
            if (m.Success) {
                ID = m.Groups["id"].Value;
                Vol = m.Groups["vol"].Value;
                Sutra = m.Groups["sutra"].Value;
                Page = m.Groups["page"].Value;
                Field = m.Groups["field"].Value;
                Line = m.Groups["line"].Value;
                SetPath();
            }
        }

        // 由行首算出圖檔路徑
        public void SetPath() {
            if(!Option.LineHeadItems.ContainsKey(ID)) {
                Path = "";
                return;
            }
            string path = Option.LineHeadItems[ID].PathRegular;
            string page3 = String.Format("{0:000}", Convert.ToInt32(Page));
            string page4 = String.Format("{0:0000}", Convert.ToInt32(Page));
            string pageRange3 = GetPageRange(3);      // 130 頁 => 101-200
            string pageRange4 = GetPageRange(4);      // 130 頁 => 101-200
            path = path.Replace("{id}", ID);
            path = path.Replace("{path}", Option.ImageRootPath);
            path = path.Replace("{vol}", Vol);
            path = path.Replace("{sutra}", Sutra.Replace("_",""));
            path = path.Replace("{page3}", page3);
            path = path.Replace("{page4}", page4);
            path = path.Replace("{pagerange3}", pageRange3);
            path = path.Replace("{pagerange4}", pageRange4);
            path = path.Replace("{field}", Field);
            Path = path;
        }

        // 由頁碼算出範圍
        // x = 3 , 138 => 101-200
        // x = 4 , 138 => 0101-0200
        string GetPageRange(int x) {
            int page = Convert.ToInt32(Page);
            page = (int)((page - 1) / 100) * 100 + 1;
            string pageRange = "";
            if (x == 3) {
                pageRange = String.Format("{0:000}-{1:000}", page, page + 99);
            } else if(x == 4 ) {
                pageRange = String.Format("{0:0000}-{1:0000}", page, page + 99);
            }
            return pageRange;
        }
    }
}
