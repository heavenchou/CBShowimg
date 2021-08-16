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
        // public int VolNum;       // 冊數的位數 2 代表 2 位數
        public string PathRegular;  // 圖檔目錄的正規式
        public List<string> PathRegulars = new List<string>();

        public CLineHeadItem(string id) {
            ID = id;
        }
    }

    public class CLineHead {
        public ItemType Type;
        public string ID;          // T
        public string Path;        // 圖檔目錄
        public List<string> Paths = new List<string>();        // 圖檔目錄
        public string LineHead;
        public string CaseType;     // 函(帙)的總類, JC 有 A 和 B 二種特例
        public string Case;         // 函(帙), 嘉興藏有用到
        public string Vol;          // 冊
        public string Sutra;        // 經號
        public string Juan;         // 卷
        public string Page;         // 頁碼
        public string Field;        // 欄
        public string Line;         // 行
        public string Num;          // CB, SD, RJ 的 4~5 碼
        public string OnlineUrl = "";    // cbetaonline 的網址, 通常為行首資訊

        // T01,p.1
        Regex regexIDVP = new Regex(@"(?<id>[A-Z]+)(?<vol>\d+)[,\.\s]*p[p,\.\s]*(?<page>[a-z]?\d+)(?<field>[a-z]?)(?<line>\d{2,3})?");
        // T01, no. 1, p. 1a5-7
        Regex regexCopy = new Regex(@"(?<id>[A-Z]+)(?<vol>\d+),\s*no\.\s*(?<sutra>.*?),\s*pp?\.\s*(?<page>[a-z]?\d+)(?<field>[a-z]?)(?<line>\d{2,3})?");
        // T01n0001_p0001a01
        Regex regex = new Regex(@"(?<id>[A-Z]+)(?<vol>\d+)n(?<sutra>.{5})p(?<page>.\d{3})(?<field>[a-z]?)(?<line>\d{2,3})?");       
        // K0647V17P0815a01
        Regex regexK = new Regex(@"(?<id>K)(?<sutra>\d{4})V(?<vol>\d\d)P(?<page>\d{4})(?<field>[a-z]?)(?<line>\d{2,3})?");
        // JC-A001-01-0001 , JC-001_003-01-0001 , JC-B001-01_01-0001 , 東大版嘉興藏
        // JD-001-01-0001 (民族版嘉興藏)
        Regex regexJC = new Regex(@"(?<id>J[CD])\-?(?<casetype>[AB]?)(?<case>[\d_Aab]+)\-(?<vol>[\d_]+)\-(?<page>\d{4})");
        // AC5309-003-0002 (中國國圖版金藏)
        Regex regexAC = new Regex(@"(?<id>AC)(?<sutra>\d{4})\-(?<juan>\d{3})\-(?<page>\d{4})");

        Regex regexCB = new Regex(@"(?<id>CB)(?<num>\d{5})");
        Regex regexSDRJ = new Regex(@"(?<id>(SD)|(RJ))\-(?<num>[A-F][0-9A-F]{3})");

        public CLineHead(string s) {
            LineHead = s;
            AnalysisLineHead();
        }
        public void AnalysisLineHead() {

            // 標準行首格式 T01n0001_p0001a01
            string sType = "標準";
            Match m = regex.Match(LineHead);
            if (!m.Success) {
                sType = "麗藏（舊版）";
                m = regexK.Match(LineHead);
                if(!m.Success) {
                    sType = "嘉興（東大）";
                    m = regexJC.Match(LineHead);
                    if(!m.Success) {
                        sType = "金藏（中國國圖）";
                        m = regexAC.Match(LineHead);
                        if(!m.Success) {
                            sType = "引用複製";
                            m = regexCopy.Match(LineHead);
                            if(!m.Success) {
                                sType = "IDVP";
                                m = regexIDVP.Match(LineHead);
                            }
                        }
                    }
                }
            }
            if (m.Success) {
                Type = ItemType.Tripitaka;
                ID = m.Groups["id"].Value;
                CaseType = m.Groups["casetype"].Value;
                Case = m.Groups["case"].Value;
                Vol = m.Groups["vol"].Value;
                Sutra = m.Groups["sutra"].Value;
                Juan = m.Groups["juan"].Value;
                Page = m.Groups["page"].Value;
                Field = m.Groups["field"].Value;
                Line = m.Groups["line"].Value;
                SetPath();
                // 設定 OnlineUrl
                SetOnlineUrl(sType);
            } else {
                m = regexCB.Match(LineHead);
                if (!m.Success) {
                    m = regexSDRJ.Match(LineHead);
                }
                if (m.Success) {
                    Type = ItemType.Gaiji;
                    ID = m.Groups["id"].Value;
                    Num = m.Groups["num"].Value;
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

        // 設定 OnlineUrl
        void SetOnlineUrl(string sType)
        {
            switch(sType) {
                case "標準": OnlineUrl = LineHead; break;
                case "麗藏（舊版）":
                    // K0647V17P0815a01
                    OnlineUrl = ID + Vol + "n" + Sutra + "_p" + Page + Field + Line;
                    break;
                case "引用複製":
                    // T01, no. 1, pp. 1c28
                    OnlineUrl = ID + Vol + "n";
                    OnlineUrl += GetSutraStandardFormat(Sutra);
                    OnlineUrl += "p";
                    OnlineUrl += GetPageStandardFormat(Page, 4);
                    OnlineUrl += Field;
                    OnlineUrl += GetLineStandardFormat(Line);
                    break;
                case "IDVP": OnlineUrl = ID + Vol + "p" + Page; break;
            }
        }

        // 取得標準五字的經號
        string GetSutraStandardFormat(string sutra)
        {
            if(sutra.Length == 5) {
                return sutra;
            } else if(sutra.Length > 5) {
                return sutra.Substring(sutra.Length - 5);
            }
            if(sutra[sutra.Length - 1] <= '9') {
                sutra += "_";    // 經號結尾不英文字, 那就要加 "_" 了
            }
            int stringCount = 5;    // 標準經號為 5 個字
            string sBegin = "";
            if(sutra[0] > '9') {
                sBegin = sutra.Substring(0, 1);
                sutra = sutra.Substring(1);
                stringCount -= 1;
            }
            stringCount = stringCount - sutra.Length;
            while(stringCount > 0) {
                sutra = "0" + sutra;
                stringCount--;
            }
            sutra = sBegin + sutra;
            return sutra;
        }

        // 取得標準四字的頁碼
        // stringCount 標準頁碼, 基本上是 4 個字, 若要求 3 個字, 超過 3 個還是會傳回全部
        string GetPageStandardFormat(string page, int stringCount)
        {
            while(page[0] == '0') {
                page = page.Remove(0, 1);
            }
            if(page.Length >= stringCount) {
                return page;
            }

            string p0 = "";
            if(page[0] > '9') {
                p0 = page[0].ToString();
                page = page.Substring(1);
                stringCount -= 1;
            }
            stringCount = stringCount - page.Length;
            while(stringCount > 0) {
                page = "0" + page;
                stringCount--;
            }
            page = p0 + page;
            return page;
        }

        // 取得標準二字的行號
        string GetLineStandardFormat(string line)
        {
            if(line.Length > 2) {
                return line.Substring(line.Length - 2);
            } else if (line.Length < 2) {
                return "0" + line;
            }
            return line;
        }

        // 由行首算出圖檔路徑
        public void SetPath() {
            if(!Option.LineHeadItems.ContainsKey(ID)) {
                Path = "";
                Paths = null;
                return;
            }

            Paths.Clear();

            foreach (string reg in Option.LineHeadItems[ID].PathRegulars) {
                string path = reg;
                string newPage = Page;
                // N70 有特殊頁碼
                if(ID == "N" && Vol == "70" && newPage[0] <= '9') {
                    int iPage = Convert.ToInt32(newPage);
                    if (iPage >= 195) {
                        iPage -= 194;
                    } else if(iPage >= 107) {
                        iPage -= 106;
                    }
                    newPage = iPage.ToString("0000");
                }

                string page3 = GetPageStandardFormat(newPage,3);
                string page4 = GetPageStandardFormat(newPage, 4);
                string pageRange3 = GetPageRange(newPage, 3, 1);      // 130 頁 => 101-200
                string pageRange4 = GetPageRange(newPage, 4, 1);      // 130 頁 => 0101-0200
                string pageRange30 = GetPageRange(newPage, 3, 0);      // 130 頁 => 100-199
                string pageRange40 = GetPageRange(newPage, 4, 0);      // 130 頁 => 0100-0199
                string sutraRange40 = GetPageRange(Sutra, 4, 0);      // 130 頁 => 0100-0199
                string p0 = "";
                if(newPage[0] > '9') {
                    p0 = newPage[0].ToString();
                }

                string id_casetype = ID;
                // JC 有三種 casetype , "", "A", "B", 所以 id_casetype 有三種
                // "JC", "JC-A", "JC-B"
                if(CaseType != "") {
                    id_casetype = id_casetype + "-" + CaseType;
                }

                path = path.Replace("{path}", Option.ImageRootPath);
                path = path.Replace("{id}", ID);
                path = path.Replace("{vol}", Vol);
                path = path.Replace("{id_casetype}", id_casetype);
                path = path.Replace("{casetype}", CaseType);
                path = path.Replace("{case}", CaseType + Case);
                path = path.Replace("{sutrarange40}", sutraRange40);
                path = path.Replace("{sutra}", Sutra.Replace("_", ""));
                path = path.Replace("{juan}", Juan);
                path = path.Replace("{pa}", p0);
                path = path.Replace("{page3}", page3);
                path = path.Replace("{page4}", page4);
                path = path.Replace("{pagerange3}", pageRange3);
                path = path.Replace("{pagerange4}", pageRange4);
                path = path.Replace("{pagerange30}", pageRange30);
                path = path.Replace("{pagerange40}", pageRange40);
                path = path.Replace("{field}", Field);

                // 特殊圖檔要處理
                // 南傳有二種:
                // N00-gif\001-100\00-001.gif
                // N01-g4\001-100\01-001.TIF
                // N70 冊頁數 107~194 要-106 N70-2-gif , 195~ 要 -194, N70-3-gi5

                if (ID == "N"){
                    int iVol = Convert.ToInt32(Vol);
                    /*
                    if (iVol < 1 || iVol > 52) {
                        path = path.Replace("-g4", "-gif");
                        path = path.Replace(".TIF", ".gif");
                    }
                    */
                    if(Vol == "70") {
                        if(Page[0] <= '9') {
                            int iPage = Convert.ToInt32(Page);  // 原始的 Page
                            if(iPage >= 195) {
                                path = path.Replace("-gif", "-3-gif");
                                path = path.Replace("-g4", "-3-g4");
                            } else if(iPage >= 107) {
                                path = path.Replace("-gif", "-2-gif");
                                path = path.Replace("-g4", "-2-g4");
                            } else {
                                path = path.Replace("-gif", "-1-gif");
                                path = path.Replace("-g4", "-1-g4");
                            }
                        } else {
                            // 封面封底有英文開頭的特殊頁碼
                            if(Sutra.EndsWith("37")) {
                                path = path.Replace("-gif", "-2-gif");
                                path = path.Replace("-g4", "-2-g4");
                                path = path.Replace("N70Front", "N70-2-Front");
                                path = path.Replace("N70Back", "N70-2-Back");
                            } else if(Sutra.EndsWith("38")) {
                                path = path.Replace("-gif", "-3-gif");
                                path = path.Replace("-g4", "-3-g4");
                                path = path.Replace("N70Front", "N70-3-Front");
                                path = path.Replace("N70Back", "N70-3-Back");
                            } else {
                                path = path.Replace("-gif", "-1-gif");
                                path = path.Replace("-g4", "-1-g4");
                                path = path.Replace("N70Front", "N70-1-Front");
                                path = path.Replace("N70Back", "N70-1-Back");
                            }
                        }
                    }
                }

                // 國圖有 jpg 有 TIF，找不到就要換
                /*
                if(ID == "D") {
                    if (!System.IO.File.Exists(path)) {
                        path = path.Replace(".TIF", ".jpg");
                    }
                }
                */

                Path = path;
                Paths.Add(path);
            }
        }

        // 由行首算出圖檔路徑
        public void SetPath_orig()
        {
            if(!Option.LineHeadItems.ContainsKey(ID)) {
                Path = "";
                return;
            }
            string path = Option.LineHeadItems[ID].PathRegular;

            string newPage = Page;
            // N70 有特殊頁碼
            if(ID == "N" && Vol == "70") {
                int iPage = Convert.ToInt32(newPage);
                if(iPage >= 195) {
                    iPage -= 194;
                } else if(iPage >= 107) {
                    iPage -= 106;
                }
                newPage = iPage.ToString("0000");
            }

            string page3 = GetPageStandardFormat(newPage, 3);
            string page4 = GetPageStandardFormat(newPage, 4);
            string pageRange3 = GetPageRange(newPage, 3, 1);      // 130 頁 => 101-200
            string pageRange4 = GetPageRange(newPage, 4, 1);      // 130 頁 => 0101-0200
            string pageRange30 = GetPageRange(newPage, 3, 0);      // 130 頁 => 100-199
            string pageRange40 = GetPageRange(newPage, 4, 0);      // 130 頁 => 0100-0199
            path = path.Replace("{id}", ID);
            path = path.Replace("{path}", Option.ImageRootPath);
            path = path.Replace("{vol}", Vol);
            path = path.Replace("{sutra}", Sutra.Replace("_", ""));
            path = path.Replace("{page3}", page3);
            path = path.Replace("{page4}", page4);
            path = path.Replace("{pagerange3}", pageRange3);
            path = path.Replace("{pagerange4}", pageRange4);
            path = path.Replace("{pagerange30}", pageRange30);
            path = path.Replace("{pagerange40}", pageRange40);
            path = path.Replace("{field}", Field);

            // 特殊圖檔要處理
            // 南傳有二種:
            // N00-gif\001-100\00-001.gif
            // N01-g4\001-100\01-001.TIF
            // N70 冊頁數 107~194 要-106 N70-2-gif , 195~ 要 -194, N70-3-gi5

            if(ID == "N") {
                int iVol = Convert.ToInt32(Vol);
                if(iVol < 1 || iVol > 52) {
                    path = path.Replace("-g4", "-gif");
                    path = path.Replace(".TIF", ".gif");
                }
                if(Vol == "70") {
                    int iPage = Convert.ToInt32(Page);  // 原始的 Page
                    if(iPage >= 195) {
                        path = path.Replace("-gif", "-3-gif");
                    } else if(iPage >= 107) {
                        path = path.Replace("-gif", "-2-gif");
                    } else {
                        path = path.Replace("-gif", "-1-gif");
                    }
                }
            }

            // 國圖有 jpg 有 TIF，找不到就要換

            if(ID == "D") {
                if(!System.IO.File.Exists(path)) {
                    path = path.Replace(".TIF", ".jpg");
                }
            }

            Path = path;
        }

        // 由頁碼算出範圍
        // x = 3 , 138 => 101-200
        // x = 4 , 138 => 0101-0200
        string GetPageRange(int x, int shift) {
            return GetPageRange(Page, x, shift);
        }

        // 123 =>  101-200 (x = 3 位數, shift = 1 頁數由 1 開始)
        // 123 =>  100-199 (x = 3 位數, shift = 0 頁數由 0 開始)
        // 123 => 0101-0200 (x = 4 位數, shift = 1 頁數由 1 開始)
        // 123 => 0100-0199 (x = 4 位數, shift = 0 頁數由 0 開始)
        string GetPageRange(string p, int x, int shift) {
            if(p == "") {
                return "";
            }
            string p0 = ""; // 用來判斷 page 第一個字母是不是英文字
            if(p[0] > '9') {
                p0 = p[0].ToString();
                p = p.Substring(1);
            }

            int page = Convert.ToInt32(p);
            page = (int)((page - shift) / 100) * 100 + shift;
            string pageRange = "";

            if(p0.Length == 1 && x == 4) {
                x = 3;
            }
            if (x == 3) {
                pageRange = p0 + String.Format("{0:000}-", page);
                pageRange += p0 + String.Format("{0:000}", page + 99);
            } else if(x == 4 ) {
                pageRange = String.Format("{0:0000}-{1:0000}", page, page + 99);
            }
            return pageRange;
        }
    }
}
