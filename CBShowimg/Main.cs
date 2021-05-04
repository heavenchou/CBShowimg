using System;
using System.Collections.Generic;
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
            string XMLFile = System.Windows.Forms.Application.StartupPath;
            XMLFile += "\\setup.xml";
            Option.LoadFromXML(XMLFile);
        }

        // 分析傳 TextBox 上的資料
        private void btRun_Click(object sender, EventArgs e)
        {
            if (tbLineHead.Text == "") return;

            Regex regex = new Regex(@"[A-Z]+\d+n.{5}p.\d{3}[a-z]?(\d{2,3})?");

            // 找到的行首資料都放到 LineHeads List 中
            foreach (Match m in regex.Matches(tbLineHead.Text)) {
                CLineHead item = new CLineHead(m.Value);
                LineHeads.Add(item);
                lbLineHeads.Items.Add(item.LineHead);
            }
        }

        // 秀圖
        private void btShowImage_Click(object sender, EventArgs e) {
            if(lbLineHeads.Items.Count == 0) {
                MessageBox.Show("左邊沒有資料");
                return;
            }
            int i = lbLineHeads.SelectedIndex;
            if(i == -1) {
                i = 0;
                lbLineHeads.SelectedIndex = 0;
            }
            Process.Start(LineHeads[i].Path);
        }
    }
}
