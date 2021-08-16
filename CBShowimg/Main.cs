using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Reflection;

namespace CBShowimg
{
    public partial class MainForm : Form
    {
        public List<CLineHead> LineHeads = new List<CLineHead>();  // 存放符合行首格式的陣列
        public MainForm()
        {
            InitializeComponent();
            // 註冊熱鍵
            SetupHotKey();
            Size = Properties.Settings.Default.FormSize;
            // 載入 XML 設定檔
            LoadXMLFile();
            string ver = typeof(MainForm).Assembly.GetName().Version.ToString();
            Text = Text + " - v" + ver.Replace(".0.0", "");
        }

        // T01,p.1
        Regex regexIDVP = new Regex(@"[A-Z]+\d+[,\.\s]*p[p,\.\s]*[a-z]?\d+[a-z]?(\d+)?");
        // T01, no. 1, p. 1a5-7
        Regex regexCopy = new Regex(@"[A-Z]+\d+,\s*no\.\s*.*?,\s*pp?\.\s*[a-z]?\d+[a-z]?(\d+)?");
        // T01n0001_p0001a01
        Regex regex = new Regex(@"[A-Z]+\d+n.{5}p.\d{3}[a-z]?(\d{2,3})?");
        // K0647V17P0815a01
        Regex regexK = new Regex(@"K\d{4}V\d\dP\d{4}[a-z]?(\d{2,3})?");
        // JC-001-02-0003 , JC-A002-03_04-0005 , JC-B003_004-05-0006 (東大版嘉興藏)
        // JD-001-01-0001 (民族版嘉興藏)
        Regex regexJC = new Regex(@"(?<id>J[CD])\-?(?<casetype>[AB]?)(?<case>[\d_Aab]+)\-(?<vol>[\d_]+)\-(?<page>\d{4})");
        // AC5309-003-0002 (中國國圖版金藏)
        Regex regexAC = new Regex(@"(?<id>AC)(?<sutra>\d{4})\-(?<juan>\d{3})\-(?<page>\d{4})");

        Regex regexCB = new Regex(@"CB\d{5}");
        Regex regexSDRJ = new Regex(@"((SD)|(RJ))\-[A-F][0-9A-F]{3}");

        // 分析傳 TextBox 上的資料
        private void btRun_Click(object sender, EventArgs e)
        {
            if (tbLineHead.Text == "") return;
            // 找到的行首資料都放到 LineHeads List 中
            // 標準行首
            foreach(Match m in regex.Matches(tbLineHead.Text)) {
                ListBoxAddLineHead(m);
            }
            // 引用複製
            foreach(Match m in regexCopy.Matches(tbLineHead.Text)) {
                ListBoxAddLineHead(m);
            }
            // 只有 ID Vol page
            foreach(Match m in regexIDVP.Matches(tbLineHead.Text)) {
                ListBoxAddLineHead(m);
            }
            // 舊版高麗藏, K0647V17P0815a01
            foreach (Match m in regexK.Matches(tbLineHead.Text)) {
                ListBoxAddLineHead(m);
            }
            foreach (Match m in regexCB.Matches(tbLineHead.Text)) {
                ListBoxAddLineHead(m);
            }
            foreach(Match m in regexSDRJ.Matches(tbLineHead.Text)) {
                ListBoxAddLineHead(m);
            }
            foreach(Match m in regexJC.Matches(tbLineHead.Text)) {
                ListBoxAddLineHead(m);
            }
            foreach(Match m in regexAC.Matches(tbLineHead.Text)) {
                ListBoxAddLineHead(m);
            }

            void ListBoxAddLineHead(Match m) {
                CLineHead item = new CLineHead(m.Value);
                LineHeads.Add(item);
                lbLineHeads.Items.Add(item.LineHead);
                // 有第一筆資料時，設定 selectindex
                if (LineHeads.Count == 1) {
                    lbLineHeads.SelectedIndex = 0;
                }
            }
        }

        private void lbLineHeads_SelectedIndexChanged(object sender, EventArgs e) {
            int i = lbLineHeads.SelectedIndex;
            if(i == -1) {
                return;
            }
            string sutraName = "";
            if (Option.LineHeadItems.ContainsKey(LineHeads[i].ID)) {
                sutraName = Option.LineHeadItems[LineHeads[i].ID].Name;
            }
            if (LineHeads[i].Type == ItemType.Tripitaka) {
                string message = "";
                if(!Option.LineHeadItems.ContainsKey(LineHeads[i].ID)) {
                    message = $"【設定檔中沒有 {LineHeads[i].ID} 此藏經的資料】\r\n\r\n";
                }
                message += $"行首：{LineHeads[i].LineHead}\r\n\r\n";
                message += $"藏經：{LineHeads[i].ID} ({sutraName})\r\n";
                message += $"冊數：{LineHeads[i].Vol}\r\n";
                message += $"經號：{LineHeads[i].Sutra.Replace("_", "")}\r\n";
                message += $"頁數：{LineHeads[i].Page}\r\n";
                message += $"欄位：{LineHeads[i].Field}\r\n";
                message += $"行數：{LineHeads[i].Line}\r\n\r\n";
                message += $"圖檔：\r\n";
                if(Option.LineHeadItems.ContainsKey(LineHeads[i].ID)) {
                    foreach(string path in LineHeads[i].Paths) {
                        string sFileExist = "(O)";
                        if(!File.Exists(path)) {
                            sFileExist = "(X)";
                        }
                        message += $"　　　{path} {sFileExist}\r\n";
                    }
                }
                message += "\r\n";
                message += $"Online網址：\r\nhttps://cbetaonline.dila.edu.tw/{LineHeads[i].OnlineUrl}";
                tbDetail.Text = message;
            } else if(LineHeads[i].Type == ItemType.Gaiji) {
                string message = "";
                switch(LineHeads[i].ID) {
                    case "CB":
                        message = "缺字"; break;
                    case "SD":
                        message = "悉曇"; break;
                    case "RJ":
                        message = "蘭扎"; break;
                }
                message += $"：{LineHeads[i].LineHead}\r\n\r\n";
                message += $"圖檔：\r\n";
                foreach(string path in LineHeads[i].Paths) {
                    string sFileExist = "(O)";
                    if(!File.Exists(path)) {
                        sFileExist = "(X)";
                    }
                    message += $"　　　{path} {sFileExist}\r\n";
                }
                message += "\r\n";
                if (LineHeads[i].ID == "CB") {
                    message += $"缺字網址：\r\nhttps://dict.cbeta.org/word/search.php?op=search&cb={LineHeads[i].Num}";
                }
                tbDetail.Text = message;
            }
            ChangeButtonState(i);   // 改變按鈕的情況
        }

        // 改變按鈕的情況
        void ChangeButtonState(int i) {
            if(LineHeads[i].Type == ItemType.Tripitaka) {
                btWebSite.Enabled = (!(LineHeads[i].OnlineUrl == ""));
                btWebSite.Text = "CBETAOnline";
            } else if (LineHeads[i].ID == "CB") {
                btWebSite.Enabled = true;
                btWebSite.Text = "CBETA Dict";
            } else {
                btWebSite.Enabled = false;
                btWebSite.Text = "...";
            }
        }

        // 秀圖
        private void btShowImage_Click(object sender, EventArgs e) {
            ShowImage();
        }

        void ShowImage() {
            if (lbLineHeads.Items.Count == 0) {
                MessageBox.Show("左邊沒有資料");
                return;
            }
            int i = lbLineHeads.SelectedIndex;
            if (i == -1) {
                i = 0;
                lbLineHeads.SelectedIndex = 0;
            }
            if (LineHeads[i].Paths.Count > 0) {
                try {
                    int showCount = 0;
                    foreach(string file in LineHeads[i].Paths) {
                        if(File.Exists(file)) {
                            Process.Start(file);
                            showCount++;
                        }
                    }
                    if(showCount == 0) {
                        MessageBox.Show("沒有一個圖檔是存在的。 😔");
                    }
                } catch (Exception err) {
                    MessageBox.Show($"出問題了：{err.Message}\n檔案：{LineHeads[i].Path}");
                }
            } else {
                MessageBox.Show("無法順利查到圖檔檔名");
                return;
            }
        }

        private void btOpenImagePath_Click(object sender, EventArgs e) {
            if (lbLineHeads.Items.Count == 0) {
                MessageBox.Show("左邊沒有資料");
                return;
            }
            int i = lbLineHeads.SelectedIndex;
            if (i == -1) {
                i = 0;
                lbLineHeads.SelectedIndex = 0;
            }
            if (LineHeads[i].Path != "") {
                string path = LineHeads[i].Path;
                try {
                    path = Path.GetDirectoryName(path);
                    Process.Start(path);
                } catch (Exception err) {
                    MessageBox.Show($"出問題了：{err.Message}\n目錄：{path}");
                }
            } else {
                MessageBox.Show("無法順利查到圖檔檔名");
                return;
            }
        }
        // 開啟 CBETAOnline
        // https://cbetaonline.dila.edu.tw/T01n0001_p0001a01
        private void btWebSite_Click(object sender, EventArgs e) {
            if (lbLineHeads.Items.Count == 0) {
                MessageBox.Show("左邊沒有資料");
                return;
            }
            int i = lbLineHeads.SelectedIndex;
            if (i == -1) {
                i = 0;
                lbLineHeads.SelectedIndex = 0;
            }

            string url = "";
            if (LineHeads[i].Type == ItemType.Tripitaka) {
                url = $"https://cbetaonline.dila.edu.tw/{LineHeads[i].OnlineUrl}";
            } else if(LineHeads[i].ID == "CB") {
                url = $"https://dict.cbeta.org/word/search.php?op=search&cb={LineHeads[i].Num}";
            }

            try {
                Process.Start(url);
            } catch (Exception err) {
                MessageBox.Show($"出問題了：{err.Message}\n網址：{url}");
            }
        }

        private void btSetup_Click(object sender, EventArgs e) {
            LoadXMLFile();
            // 重新設定 path
            for (int i=0; i<LineHeads.Count; i++) {
                LineHeads[i].SetPath();
            }
            // 重新呈現右邊的詳細資料
            lbLineHeads_SelectedIndexChanged(sender, e);
        }

        void LoadXMLFile() {
            string XMLFile = System.Windows.Forms.Application.StartupPath;
            XMLFile += "\\CBCallImage.xml";
            if(File.Exists(XMLFile)) {
                Option.LoadFromXML(XMLFile);
            } else {
                MessageBox.Show($"找不到設定檔 {XMLFile}");
            }
            
        }

        private void lbLineHeads_DoubleClick(object sender, EventArgs e) {
            if (lbLineHeads.Items.Count == 0) return;
            btShowImage_Click(sender, e);
        }

        private void btOpenSetupXML_Click(object sender, EventArgs e) {

            string XMLFile = System.Windows.Forms.Application.StartupPath;
            XMLFile += "\\CBCallImage.xml";
            try {
                Process.Start(XMLFile);
            } catch (Exception err) {
                MessageBox.Show($"出問題了：{err.Message}\n檔案：{XMLFile}");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            // 取消註冊熱鍵
            DisableHotKey();
            Properties.Settings.Default.FormSize = Size;
            Properties.Settings.Default.Save();
        }

        // 將程式移至前景
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        // 處理熱鍵需要覆寫 WndProc
        protected override void WndProc(ref Message m) {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg) {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32()) {
                        case 100:
                            SendKeys.Send("^c");
                            IDataObject data = Clipboard.GetDataObject();
                            if (data.GetDataPresent(DataFormats.Text)) {
                                tbLineHead.Text = data.GetData(DataFormats.Text).ToString();
                                btRun_Click(this, null);
                                if (WindowState == FormWindowState.Minimized) {
                                    WindowState = FormWindowState.Normal;
                                }
                                SetForegroundWindow(Handle);
                                //this.TopMost = true;
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void tbLineHead_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btRun_Click(sender, null);
            }
        }

        private void lbLineHeads_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                ShowImage();
            } else if(e.KeyCode == Keys.Delete) {
                ListBoxRemoveItem();
            }
        }

        // 移除左邊 ListBox 所在的那一筆
        void ListBoxRemoveItem() {
            int i = lbLineHeads.SelectedIndex;
            if (i == -1) {
                return;
            }
            lbLineHeads.Items.RemoveAt(i);
            LineHeads.RemoveAt(i);

            if(lbLineHeads.Items.Count == 0) {
                return;
            }
            if(i<lbLineHeads.Items.Count) {
                lbLineHeads.SelectedIndex = i;
            } else {
                lbLineHeads.SelectedIndex = i - 1;
            }
        }

        private void btListBoxRemoveAll_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("確定清空左邊視窗嗎？", "清空視窗", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes) {
                lbLineHeads.Items.Clear();
                LineHeads.Clear();
            }
        }

        private void cbSetupHotKey_SelectedIndexChanged(object sender, EventArgs e) {
            // 取消註冊熱鍵
            DisableHotKey();
            SetupHotKey();
        }

        void SetupHotKey() {
            // 註冊熱鍵
            Keys hotkey;
            switch (cbSetupHotKey.Text) {
                case "F1": hotkey = Keys.F1; break;
                case "F2": hotkey = Keys.F2; break;
                case "F3": hotkey = Keys.F3; break;
                case "F4": hotkey = Keys.F4; break;
                case "F5": hotkey = Keys.F5; break;
                case "F6": hotkey = Keys.F6; break;
                case "F7": hotkey = Keys.F7; break;
                case "F8": hotkey = Keys.F8; break;
                case "F9": hotkey = Keys.F9; break;
                case "F10": hotkey = Keys.F10; break;
                case "F11": hotkey = Keys.F11; break;
                case "F12": hotkey = Keys.F12; break;
                default: hotkey = Keys.F7; break;
            }
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, hotkey);
        }
        void DisableHotKey() {
            // 取消註冊熱鍵
            HotKey.UnregisterHotKey(Handle, 100);
        }

        private void btClearTextBox_Click(object sender, EventArgs e)
        {
            tbLineHead.Text = "";
            tbLineHead.Focus();
        }

    }
}
