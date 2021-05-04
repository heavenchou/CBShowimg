
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btShowImage = new System.Windows.Forms.Button();
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
            this.tbLineHead.Location = new System.Drawing.Point(86, 41);
            this.tbLineHead.Name = "tbLineHead";
            this.tbLineHead.Size = new System.Drawing.Size(335, 25);
            this.tbLineHead.TabIndex = 0;
            // 
            // btSetup
            // 
            this.btSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSetup.Location = new System.Drawing.Point(327, 12);
            this.btSetup.Name = "btSetup";
            this.btSetup.Size = new System.Drawing.Size(94, 23);
            this.btSetup.TabIndex = 1;
            this.btSetup.Text = "載入設定檔";
            this.btSetup.UseVisualStyleBackColor = true;
            // 
            // btRun
            // 
            this.btRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRun.Location = new System.Drawing.Point(427, 41);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(39, 23);
            this.btRun.TabIndex = 2;
            this.btRun.Text = "GO";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "行首資訊";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(16, 72);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbLineHeads);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbDetail);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.btShowImage);
            this.splitContainer1.Size = new System.Drawing.Size(450, 366);
            this.splitContainer1.SplitterDistance = 149;
            this.splitContainer1.TabIndex = 4;
            // 
            // lbLineHeads
            // 
            this.lbLineHeads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLineHeads.FormattingEnabled = true;
            this.lbLineHeads.ItemHeight = 15;
            this.lbLineHeads.Location = new System.Drawing.Point(0, 0);
            this.lbLineHeads.Name = "lbLineHeads";
            this.lbLineHeads.Size = new System.Drawing.Size(149, 366);
            this.lbLineHeads.TabIndex = 0;
            // 
            // tbDetail
            // 
            this.tbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDetail.Location = new System.Drawing.Point(86, 4);
            this.tbDetail.Multiline = true;
            this.tbDetail.Name = "tbDetail";
            this.tbDetail.Size = new System.Drawing.Size(208, 359);
            this.tbDetail.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 94);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btShowImage
            // 
            this.btShowImage.Location = new System.Drawing.Point(4, 4);
            this.btShowImage.Name = "btShowImage";
            this.btShowImage.Size = new System.Drawing.Size(75, 23);
            this.btShowImage.TabIndex = 0;
            this.btShowImage.Text = "秀圖";
            this.btShowImage.UseVisualStyleBackColor = true;
            this.btShowImage.Click += new System.EventHandler(this.btShowImage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.btSetup);
            this.Controls.Add(this.tbLineHead);
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btShowImage;
    }
}

