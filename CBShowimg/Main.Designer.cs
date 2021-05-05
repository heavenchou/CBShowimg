
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
            this.tbDetail = new System.Windows.Forms.TextBox();
            this.btCBETAOnline = new System.Windows.Forms.Button();
            this.btOpenImagePath = new System.Windows.Forms.Button();
            this.btShowImage = new System.Windows.Forms.Button();
            this.btOpenSetupXML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLineHead
            // 
            this.tbLineHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLineHead.Location = new System.Drawing.Point(107, 50);
            this.tbLineHead.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbLineHead.Name = "tbLineHead";
            this.tbLineHead.Size = new System.Drawing.Size(446, 29);
            this.tbLineHead.TabIndex = 0;
            // 
            // btSetup
            // 
            this.btSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSetup.Location = new System.Drawing.Point(398, 15);
            this.btSetup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btSetup.Name = "btSetup";
            this.btSetup.Size = new System.Drawing.Size(156, 28);
            this.btSetup.TabIndex = 1;
            this.btSetup.Text = "重新載入設定檔";
            this.btSetup.UseVisualStyleBackColor = true;
            this.btSetup.Click += new System.EventHandler(this.btSetup_Click);
            // 
            // btRun
            // 
            this.btRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRun.Location = new System.Drawing.Point(560, 50);
            this.btRun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(44, 28);
            this.btRun.TabIndex = 2;
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
            this.splitContainer1.Panel2.Controls.Add(this.tbDetail);
            this.splitContainer1.Panel2.Controls.Add(this.btCBETAOnline);
            this.splitContainer1.Panel2.Controls.Add(this.btOpenImagePath);
            this.splitContainer1.Panel2.Controls.Add(this.btShowImage);
            this.splitContainer1.Size = new System.Drawing.Size(587, 352);
            this.splitContainer1.SplitterDistance = 149;
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
            this.lbLineHeads.Size = new System.Drawing.Size(149, 352);
            this.lbLineHeads.TabIndex = 0;
            this.lbLineHeads.SelectedIndexChanged += new System.EventHandler(this.lbLineHeads_SelectedIndexChanged);
            this.lbLineHeads.DoubleClick += new System.EventHandler(this.lbLineHeads_DoubleClick);
            // 
            // tbDetail
            // 
            this.tbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDetail.Location = new System.Drawing.Point(131, 4);
            this.tbDetail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDetail.Multiline = true;
            this.tbDetail.Name = "tbDetail";
            this.tbDetail.ReadOnly = true;
            this.tbDetail.Size = new System.Drawing.Size(299, 343);
            this.tbDetail.TabIndex = 4;
            // 
            // btCBETAOnline
            // 
            this.btCBETAOnline.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btCBETAOnline.Location = new System.Drawing.Point(4, 76);
            this.btCBETAOnline.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btCBETAOnline.Name = "btCBETAOnline";
            this.btCBETAOnline.Size = new System.Drawing.Size(119, 28);
            this.btCBETAOnline.TabIndex = 2;
            this.btCBETAOnline.Text = "CBETAOnline";
            this.btCBETAOnline.UseVisualStyleBackColor = true;
            this.btCBETAOnline.Click += new System.EventHandler(this.btCBETAOnline_Click);
            // 
            // btOpenImagePath
            // 
            this.btOpenImagePath.Location = new System.Drawing.Point(4, 40);
            this.btOpenImagePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btOpenImagePath.Name = "btOpenImagePath";
            this.btOpenImagePath.Size = new System.Drawing.Size(121, 28);
            this.btOpenImagePath.TabIndex = 1;
            this.btOpenImagePath.Text = "開啟圖檔目錄";
            this.btOpenImagePath.UseVisualStyleBackColor = true;
            this.btOpenImagePath.Click += new System.EventHandler(this.btOpenImagePath_Click);
            // 
            // btShowImage
            // 
            this.btShowImage.Location = new System.Drawing.Point(4, 4);
            this.btShowImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btShowImage.Name = "btShowImage";
            this.btShowImage.Size = new System.Drawing.Size(119, 28);
            this.btShowImage.TabIndex = 0;
            this.btShowImage.Text = "開啟圖檔";
            this.btShowImage.UseVisualStyleBackColor = true;
            this.btShowImage.Click += new System.EventHandler(this.btShowImage_Click);
            // 
            // btOpenSetupXML
            // 
            this.btOpenSetupXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenSetupXML.Location = new System.Drawing.Point(278, 15);
            this.btOpenSetupXML.Name = "btOpenSetupXML";
            this.btOpenSetupXML.Size = new System.Drawing.Size(113, 28);
            this.btOpenSetupXML.TabIndex = 5;
            this.btOpenSetupXML.Text = "開啟設定檔";
            this.btOpenSetupXML.UseVisualStyleBackColor = true;
            this.btOpenSetupXML.Click += new System.EventHandler(this.btOpenSetupXML_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 453);
            this.Controls.Add(this.btOpenSetupXML);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.btSetup);
            this.Controls.Add(this.tbLineHead);
            this.Font = new System.Drawing.Font("新細明體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "CBETA 神秀圖";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btCBETAOnline;
        private System.Windows.Forms.Button btOpenImagePath;
        private System.Windows.Forms.Button btShowImage;
        private System.Windows.Forms.Button btOpenSetupXML;
    }
}

