using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CBShowimg {

    // 項目總類
    public enum ItemType : ushort {
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
        public ItemType Type;
        public string ID;          // T
        public string Path;        // 圖檔目錄
        public string LineHead;
        public string Vol;
        public string Sutra;       // 經號
        public string Page;        // 頁碼
        public string Field;       // 欄
        public string Line;        // 行
        public string Num;         // CB, SD, RJ 的 4~5 碼

        public CLineHead(string s) {
            LineHead = s;
            AnalysisLineHead();
        }

        // T01n0001_p0001a01
        Regex regex = new Regex(@"(?<id>[A-Z]+)(?<vol>\d+)n(?<sutra>.{5})p(?<page>.\d{3})(?<field>[a-z]?)(?<line>\d{2,3})?");
        // K0647V17P0815a01
        Regex regexK = new Regex(@"(?<id>K)(?<sutra>\d{4})V(?<vol>\d\d)P(?<page>\d{4})(?<field>[a-z]?)(?<line>\d{2,3})?");
        Regex regexCB = new Regex(@"(?<id>CB)(?<num>\d{5})");
        Regex regexSDRJ = new Regex(@"(?<id>(SD)|(RJ))\-(?<num>[A-F][0-9A-F]{3})");

        public void AnalysisLineHead() {
            // 標準行首格式 T01n0001_p0001a01
            Match m = regex.Match(LineHead);
            if (!m.Success) {
                m = regexK.Match(LineHead);
            }
            if (m.Success) {
                Type = ItemType.Tripitaka;
                ID = m.Groups["id"].Value;
                Vol = m.Groups["vol"].Value;
                Sutra = m.Groups["sutra"].Value;
                Page = m.Groups["page"].Value;
                Field = m.Groups["field"].Value;
                Line = m.Groups["line"].Value;
                SetPath();
            } else {
                m = regexCB.Match(LineHead);
                if (!m.Success) {
                    m = regexSDRJ.Match(LineHead);
                }
                if (m.Success) {
                    Type = ItemType.Gaiji;
                    ID = m.Groups["id"].Value;
                    Num = m.Groups["num"].Value;
                    // SetPath();
                    if (Option.LineHeadItems.ContainsKey(ID)) {
                        string path = Option.LineHeadItems[ID].PathRegular;
                        path = path.Replace("{pre2}", Num.Substring(0, 2));
                        Path = path.Replace("{num}", Num);
                    } else {
                        Path = "";
                    }
                }
            }
        }

        // 由行首算出圖檔路徑
        public void SetPath() {
            if(!Option.LineHeadItems.ContainsKey(ID)) {
                Path = "";
                return;
            }
            string path = Option.LineHeadItems[ID].PathRegular;

            string newPage = Page;
            // N70 有特殊頁碼
            if(ID == "N" && Vol == "70") {
                int iPage = Convert.ToInt32(newPage);
                if (iPage >= 195) {
                    iPage -= 194;
                } else if(iPage >= 107) {
                    iPage -= 106;
                }
                newPage = iPage.ToString("0000");
            }

            string page3 = String.Format("{0:000}", Convert.ToInt32(newPage));
            string page4 = String.Format("{0:0000}", Convert.ToInt32(newPage));
            string pageRange3 = GetPageRange(3, newPage);      // 130 頁 => 101-200
            string pageRange4 = GetPageRange(4, newPage);      // 130 頁 => 101-200
            path = path.Replace("{id}", ID);
            path = path.Replace("{path}", Option.ImageRootPath);
            path = path.Replace("{vol}", Vol);
            path = path.Replace("{sutra}", Sutra.Replace("_",""));
            path = path.Replace("{page3}", page3);
            path = path.Replace("{page4}", page4);
            path = path.Replace("{pagerange3}", pageRange3);
            path = path.Replace("{pagerange4}", pageRange4);
            path = path.Replace("{field}", Field);

            // 特殊圖檔要處理
            // 南傳有二種:
            // N00-gif\001-100\00-001.gif
            // N01-g4\001-100\01-001.TIF
            // N70 冊頁數 107~194 要-106 N70-2-gif , 195~ 要 -194, N70-3-gi5

            if (ID == "N"){
                int iVol = Convert.ToInt32(Vol);
                if (iVol < 1 || iVol > 52) {
                    path = path.Replace("-g4", "-gif");
                    path = path.Replace(".TIF", ".gif");
                }
                if(Vol == "70") {
                    int iPage = Convert.ToInt32(Page);  // 原始的 Page
                    if (iPage >= 195) {
                        path = path.Replace("-gif", "-3-gif");
                    } else if (iPage >= 107) {
                        path = path.Replace("-gif", "-2-gif");
                    } else {
                        path = path.Replace("-gif", "-1-gif");
                    }
                }
            }

            // 國圖有 jpg 有 TIF，找不到就要換

            if(ID == "D") {
                if (!System.IO.File.Exists(path)) {
                    path = path.Replace(".TIF", ".jpg");
                }
            }

            Path = path;
        }

        // 由頁碼算出範圍
        // x = 3 , 138 => 101-200
        // x = 4 , 138 => 0101-0200
        string GetPageRange(int x) {
            return GetPageRange(x, Page);
        }
        string GetPageRange(int x, string p) {
            int page = Convert.ToInt32(p);
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
