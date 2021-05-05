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
        public string Page;           // 頁碼
        public string Field;             // 欄
        public string Line;               // 行

        public CLineHead(string s) {
            LineHead = s;
            AnalysisLineHead();
        }

        public void AnalysisLineHead() {
            // 標準行首格式 T01n0001_p0001a01

            Regex regex = new Regex(@"([A-Z]+)(\d+)n(.{5})p(.\d{3})([a-z]?)(\d{2,3})?");

            Match m = regex.Match(LineHead);
            if (m.Success) {
                ID = m.Groups[1].Value;
                Vol = m.Groups[2].Value;
                Sutra = m.Groups[3].Value;
                Page = m.Groups[4].Value;
                Field = m.Groups[5].Value;
                Line = m.Groups[6].Value;
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
            string pageRange = GetPageRange();      // 130 頁 => 101-200
            path = path.Replace("{id}", ID);
            path = path.Replace("{vol}", Vol);
            path = path.Replace("{page3}", page3);
            path = path.Replace("{page4}", page4);
            path = path.Replace("{vol}", Vol);
            path = path.Replace("{pagerange}", pageRange);
            Path = path;
        }

        // 由頁碼算出範圍
        // 138 => 101-200
        string GetPageRange() {
            int page = Convert.ToInt32(Page);
            page = (int)((page - 1) / 100) * 100 + 1;
            string pageRange = String.Format("{0:000}-{1:000}", page, page + 99);
            return pageRange;
        }
    }
}
