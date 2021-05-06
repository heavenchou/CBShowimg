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

namespace CBShowimg
{
    public partial class MainForm : Form
    {
        public List<CLineHead> LineHeads = new List<CLineHead>();  // 存放符合行首格式的陣列
        public MainForm()
        {
            InitializeComponent();
            // 載入 XML 設定檔
            LoadXMLFile();
        }

        // T01n0001_p0001a01
        Regex regex = new Regex(@"[A-Z]+\d+n.{5}p.\d{3}[a-z]?(\d{2,3})?");
        // K0647V17P0815a01
        Regex regexK = new Regex(@"K\d{4}V\d\dP\d{4}[a-z]?(\d{2,3})?");

        // 分析傳 TextBox 上的資料
        private void btRun_Click(object sender, EventArgs e)
        {
            if (tbLineHead.Text == "") return;
            // 找到的行首資料都放到 LineHeads List 中
            foreach (Match m in regex.Matches(tbLineHead.Text)) {
                ListBoxAddLineHead(m);
            }
            foreach (Match m in regexK.Matches(tbLineHead.Text)) {
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

            string message = $"行首：{LineHeads[i].LineHead}\r\n\r\n";
            message += $"藏經：{LineHeads[i].ID} ({sutraName})\r\n";
            message += $"冊數：{LineHeads[i].Vol}\r\n";
            message += $"經號：{LineHeads[i].Sutra.Replace("_", "")}\r\n";
            message += $"頁數：{LineHeads[i].Page}\r\n";
            message += $"欄位：{LineHeads[i].Field}\r\n";
            message += $"行數：{LineHeads[i].Line}\r\n\r\n";
            message += $"圖檔：\r\n{LineHeads[i].Path}\r\n\r\n";
            message += $"Online網址：\r\nhttps://cbetaonline.dila.edu.tw/{LineHeads[i].LineHead}";
            tbDetail.Text = message;
        }

        // 秀圖
        private void btShowImage_Click(object sender, EventArgs e) {
            if (lbLineHeads.Items.Count == 0) {
                MessageBox.Show("左邊沒有資料");
                return;
            }
            int i = lbLineHeads.SelectedIndex;
            if(i == -1) {
                i = 0;
                lbLineHeads.SelectedIndex = 0;
            }
            if (LineHeads[i].Path != "") {
                try {
                    Process.Start(LineHeads[i].Path);
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
        private void btCBETAOnline_Click(object sender, EventArgs e) {
            if (lbLineHeads.Items.Count == 0) {
                MessageBox.Show("左邊沒有資料");
                return;
            }
            int i = lbLineHeads.SelectedIndex;
            if (i == -1) {
                i = 0;
                lbLineHeads.SelectedIndex = 0;
            }
            
            string url = "https://cbetaonline.dila.edu.tw/" + LineHeads[i].LineHead;
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
            XMLFile += "\\setup.xml";
            Option.LoadFromXML(XMLFile);
        }

        private void lbLineHeads_DoubleClick(object sender, EventArgs e) {
            if (lbLineHeads.Items.Count == 0) return;
            btShowImage_Click(sender, e);
        }

        private void btOpenSetupXML_Click(object sender, EventArgs e) {

            string XMLFile = System.Windows.Forms.Application.StartupPath;
            XMLFile += "\\setup.xml";
            try {
                Process.Start(XMLFile);
            } catch (Exception err) {
                MessageBox.Show($"出問題了：{err.Message}\n檔案：{XMLFile}");
            }
        }

        private void MainForm_Activated(object sender, EventArgs e) {
            // 註冊熱鍵
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, Keys.F7);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            // 取消註冊熱鍵
            HotKey.UnregisterHotKey(Handle, 100);
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
    }
}
