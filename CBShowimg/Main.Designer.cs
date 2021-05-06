
namespace CBShowimg
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLineHead = new System.Windows.Forms.TextBox();
            this.btSetup = new System.Windows.Forms.Button();
            this.btRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbLineHeads = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbDetail = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btShowImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btOpenImagePath = new System.Windows.Forms.Button();
            this.cbSetupHotKey = new System.Windows.Forms.ComboBox();
            this.btWebSite = new System.Windows.Forms.Button();
            this.btListBoxRemoveAll = new System.Windows.Forms.Button();
            this.btOpenSetupXML = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAlwaysOnTop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLineHead
            // 
            this.tbLineHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLineHead.Location = new System.Drawing.Point(107, 50);
            this.tbLineHead.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbLineHead.Name = "tbLineHead";
            this.tbLineHead.Size = new System.Drawing.Size(538, 29);
            this.tbLineHead.TabIndex = 0;
            this.tbLineHead.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLineHead_KeyDown);
            // 
            // btSetup
            // 
            this.btSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSetup.Location = new System.Drawing.Point(549, 15);
            this.btSetup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btSetup.Name = "btSetup";
            this.btSetup.Size = new System.Drawing.Size(97, 28);
            this.btSetup.TabIndex = 10;
            this.btSetup.Text = "重新設定";
            this.btSetup.UseVisualStyleBackColor = true;
            this.btSetup.Click += new System.EventHandler(this.btSetup_Click);
            // 
            // btRun
            // 
            this.btRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRun.Location = new System.Drawing.Point(652, 50);
            this.btRun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(44, 29);
            this.btRun.TabIndex = 1;
            this.btRun.Text = "GO";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "行首資訊";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::CBShowimg.Properties.Settings.Default, "ListBoxWidth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(18, 87);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbLineHeads);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(679, 352);
            this.splitContainer1.SplitterDistance = global::CBShowimg.Properties.Settings.Default.ListBoxWidth;
            this.splitContainer1.TabIndex = 4;
            // 
            // lbLineHeads
            // 
            this.lbLineHeads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLineHeads.FormattingEnabled = true;
            this.lbLineHeads.ItemHeight = 18;
            this.lbLineHeads.Location = new System.Drawing.Point(0, 0);
            this.lbLineHeads.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbLineHeads.Name = "lbLineHeads";
            this.lbLineHeads.Size = new System.Drawing.Size(160, 352);
            this.lbLineHeads.TabIndex = 2;
            this.lbLineHeads.SelectedIndexChanged += new System.EventHandler(this.lbLineHeads_SelectedIndexChanged);
            this.lbLineHeads.DoubleClick += new System.EventHandler(this.lbLineHeads_DoubleClick);
            this.lbLineHeads.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbLineHeads_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(143, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 352);
            this.panel2.TabIndex = 11;
            // 
            // tbDetail
            // 
            this.tbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDetail.Location = new System.Drawing.Point(0, 0);
            this.tbDetail.Margin = new System.Windows.Forms.Padding(150, 3, 4, 3);
            this.tbDetail.Multiline = true;
            this.tbDetail.Name = "tbDetail";
            this.tbDetail.ReadOnly = true;
            this.tbDetail.Size = new System.Drawing.Size(372, 352);
            this.tbDetail.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btShowImage);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btOpenImagePath);
            this.panel1.Controls.Add(this.cbSetupHotKey);
            this.panel1.Controls.Add(this.btWebSite);
            this.panel1.Controls.Add(this.btListBoxRemoveAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 352);
            this.panel1.TabIndex = 10;
            // 
            // btShowImage
            // 
            this.btShowImage.Location = new System.Drawing.Point(4, 3);
            this.btShowImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btShowImage.Name = "btShowImage";
            this.btShowImage.Size = new System.Drawing.Size(131, 28);
            this.btShowImage.TabIndex = 3;
            this.btShowImage.Text = "開啟圖檔";
            this.btShowImage.UseVisualStyleBackColor = true;
            this.btShowImage.Click += new System.EventHandler(this.btShowImage_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "設定熱鍵";
            // 
            // btOpenImagePath
            // 
            this.btOpenImagePath.Location = new System.Drawing.Point(4, 37);
            this.btOpenImagePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btOpenImagePath.Name = "btOpenImagePath";
            this.btOpenImagePath.Size = new System.Drawing.Size(131, 28);
            this.btOpenImagePath.TabIndex = 4;
            this.btOpenImagePath.Text = "開啟圖檔目錄";
            this.btOpenImagePath.UseVisualStyleBackColor = true;
            this.btOpenImagePath.Click += new System.EventHandler(this.btOpenImagePath_Click);
            // 
            // cbSetupHotKey
            // 
            this.cbSetupHotKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSetupHotKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CBShowimg.Properties.Settings.Default, "HotKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbSetupHotKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSetupHotKey.FormattingEnabled = true;
            this.cbSetupHotKey.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.cbSetupHotKey.Location = new System.Drawing.Point(4, 289);
            this.cbSetupHotKey.Name = "cbSetupHotKey";
            this.cbSetupHotKey.Size = new System.Drawing.Size(131, 26);
            this.cbSetupHotKey.TabIndex = 8;
            this.cbSetupHotKey.Text = global::CBShowimg.Properties.Settings.Default.HotKey;
            this.cbSetupHotKey.SelectedIndexChanged += new System.EventHandler(this.cbSetupHotKey_SelectedIndexChanged);
            // 
            // btWebSite
            // 
            this.btWebSite.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btWebSite.Location = new System.Drawing.Point(4, 71);
            this.btWebSite.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btWebSite.Name = "btWebSite";
            this.btWebSite.Size = new System.Drawing.Size(131, 28);
            this.btWebSite.TabIndex = 5;
            this.btWebSite.Text = "CBETAOnline";
            this.btWebSite.UseVisualStyleBackColor = true;
            this.btWebSite.Click += new System.EventHandler(this.btWebSite_Click);
            // 
            // btListBoxRemoveAll
            // 
            this.btListBoxRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btListBoxRemoveAll.Location = new System.Drawing.Point(4, 321);
            this.btListBoxRemoveAll.Name = "btListBoxRemoveAll";
            this.btListBoxRemoveAll.Size = new System.Drawing.Size(131, 28);
            this.btListBoxRemoveAll.TabIndex = 6;
            this.btListBoxRemoveAll.Text = "左邊清空";
            this.btListBoxRemoveAll.UseVisualStyleBackColor = true;
            this.btListBoxRemoveAll.Click += new System.EventHandler(this.btListBoxRemoveAll_Click);
            // 
            // btOpenSetupXML
            // 
            this.btOpenSetupXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenSetupXML.Location = new System.Drawing.Point(447, 16);
            this.btOpenSetupXML.Name = "btOpenSetupXML";
            this.btOpenSetupXML.Size = new System.Drawing.Size(95, 28);
            this.btOpenSetupXML.TabIndex = 9;
            this.btOpenSetupXML.Text = "開啟設定";
            this.btOpenSetupXML.UseVisualStyleBackColor = true;
            this.btOpenSetupXML.Click += new System.EventHandler(this.btOpenSetupXML_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(18, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 42);
            this.label2.TabIndex = 6;
            this.label2.Text = "CBETA 神秀圖";
            // 
            // cbAlwaysOnTop
            // 
            this.cbAlwaysOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAlwaysOnTop.AutoSize = true;
            this.cbAlwaysOnTop.Checked = global::CBShowimg.Properties.Settings.Default.AlwaysOnTop;
            this.cbAlwaysOnTop.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CBShowimg.Properties.Settings.Default, "AlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAlwaysOnTop.Location = new System.Drawing.Point(353, 19);
            this.cbAlwaysOnTop.Name = "cbAlwaysOnTop";
            this.cbAlwaysOnTop.Size = new System.Drawing.Size(88, 23);
            this.cbAlwaysOnTop.TabIndex = 8;
            this.cbAlwaysOnTop.Text = "最上層";
            this.cbAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 453);
            this.Controls.Add(this.cbAlwaysOnTop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btOpenSetupXML);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.btSetup);
            this.Controls.Add(this.tbLineHead);
            this.DataBindings.Add(new System.Windows.Forms.Binding("TopMost", global::CBShowimg.Properties.Settings.Default, "AlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::CBShowimg.Properties.Settings.Default, "FormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("新細明體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Location = global::CBShowimg.Properties.Settings.Default.FormLocation;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "CBETA 神秀圖";
            this.TopMost = global::CBShowimg.Properties.Settings.Default.AlwaysOnTop;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLineHead;
        private System.Windows.Forms.Button btSetup;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbLineHeads;
        private System.Windows.Forms.TextBox tbDetail;
        private System.Windows.Forms.Button btWebSite;
        private System.Windows.Forms.Button btOpenImagePath;
        private System.Windows.Forms.Button btShowImage;
        private System.Windows.Forms.Button btOpenSetupXML;
        private System.Windows.Forms.Button btListBoxRemoveAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbAlwaysOnTop;
        private System.Windows.Forms.ComboBox cbSetupHotKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}

