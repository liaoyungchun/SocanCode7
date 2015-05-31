namespace WebBrowser
{
    partial class BrowserForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGoBack = new System.Windows.Forms.ToolStripButton();
            this.btnGoFoward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cobURL = new System.Windows.Forms.ToolStripComboBox();
            this.btnGo = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuClearUrlHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnGoHome = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cobSearch = new System.Windows.Forms.ToolStripComboBox();
            this.btnSearch = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuGoogleSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaiduSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearSearchHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.imgStatus = new System.Windows.Forms.ToolStripDropDownButton();
            this.AxWebBrowser1 = new AxSHDocVw.AxWebBrowser();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxWebBrowser1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGoBack,
            this.btnGoFoward,
            this.toolStripSeparator2,
            this.cobURL,
            this.btnGo,
            this.toolStripSeparator1,
            this.btnRefresh,
            this.btnStop,
            this.btnGoHome,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.cobSearch,
            this.btnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(790, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.SizeChanged += new System.EventHandler(this.toolStrip1_SizeChanged);
            // 
            // btnGoBack
            // 
            this.btnGoBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGoBack.Image = global::WebBrowser.Properties.Resources.NavBack;
            this.btnGoBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(23, 22);
            this.btnGoBack.Text = "后退";
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnGoFoward
            // 
            this.btnGoFoward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGoFoward.Image = global::WebBrowser.Properties.Resources.NavForward;
            this.btnGoFoward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGoFoward.Name = "btnGoFoward";
            this.btnGoFoward.Size = new System.Drawing.Size(23, 22);
            this.btnGoFoward.Text = "前进";
            this.btnGoFoward.Click += new System.EventHandler(this.btnGoFoward_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cobURL
            // 
            this.cobURL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cobURL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cobURL.AutoSize = false;
            this.cobURL.Name = "cobURL";
            this.cobURL.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.cobURL.Size = new System.Drawing.Size(300, 25);
            this.cobURL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cobURL_KeyUp);
            // 
            // btnGo
            // 
            this.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClearUrlHistory});
            this.btnGo.Image = global::WebBrowser.Properties.Resources.GoLtrHS;
            this.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(32, 22);
            this.btnGo.Text = "转到";
            this.btnGo.ButtonClick += new System.EventHandler(this.btnGo_ButtonClick);
            this.btnGo.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.btnGo_DropDownItemClicked);
            // 
            // mnuClearUrlHistory
            // 
            this.mnuClearUrlHistory.Name = "mnuClearUrlHistory";
            this.mnuClearUrlHistory.Size = new System.Drawing.Size(164, 22);
            this.mnuClearUrlHistory.Text = "清除历史记录(&C)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WebBrowser.Properties.Resources.RepeatHS;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::WebBrowser.Properties.Resources.error;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(23, 22);
            this.btnStop.Text = "停止";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnGoHome
            // 
            this.btnGoHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGoHome.Image = global::WebBrowser.Properties.Resources.HomeHS;
            this.btnGoHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGoHome.Name = "btnGoHome";
            this.btnGoHome.Size = new System.Drawing.Size(23, 22);
            this.btnGoHome.Text = "主页";
            this.btnGoHome.Click += new System.EventHandler(this.btnGoHome_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "搜索：";
            // 
            // cobSearch
            // 
            this.cobSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cobSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cobSearch.AutoSize = false;
            this.cobSearch.Name = "cobSearch";
            this.cobSearch.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.cobSearch.Size = new System.Drawing.Size(100, 25);
            this.cobSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cobSearch_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGoogleSearch,
            this.mnuBaiduSearch,
            this.toolStripMenuItem2,
            this.mnuClearSearchHistory});
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 22);
            this.btnSearch.Text = "搜索";
            this.btnSearch.ButtonClick += new System.EventHandler(this.btnSearch_Click);
            // 
            // mnuGoogleSearch
            // 
            this.mnuGoogleSearch.Checked = true;
            this.mnuGoogleSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuGoogleSearch.Name = "mnuGoogleSearch";
            this.mnuGoogleSearch.Size = new System.Drawing.Size(164, 22);
            this.mnuGoogleSearch.Tag = "http://www.google.com/search?hl=zh-CN&q={0}";
            this.mnuGoogleSearch.Text = "&Google";
            this.mnuGoogleSearch.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // mnuBaiduSearch
            // 
            this.mnuBaiduSearch.Name = "mnuBaiduSearch";
            this.mnuBaiduSearch.Size = new System.Drawing.Size(164, 22);
            this.mnuBaiduSearch.Tag = "http://www.baidu.com/s?wd={0}&ie=utf-8";
            this.mnuBaiduSearch.Text = "百度(&B)";
            this.mnuBaiduSearch.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuClearSearchHistory
            // 
            this.mnuClearSearchHistory.Name = "mnuClearSearchHistory";
            this.mnuClearSearchHistory.Size = new System.Drawing.Size(164, 22);
            this.mnuClearSearchHistory.Text = "清除历史记录(&C)";
            this.mnuClearSearchHistory.Click += new System.EventHandler(this.mnuClearSearchHistory_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labStatus,
            this.pbStatus,
            this.imgStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 372);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(790, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.SizeChanged += new System.EventHandler(this.statusStrip1_SizeChanged);
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = false;
            this.labStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labStatus.Name = "labStatus";
            this.labStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.labStatus.Size = new System.Drawing.Size(500, 17);
            this.labStatus.Text = "就绪";
            this.labStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbStatus
            // 
            this.pbStatus.AutoSize = false;
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.pbStatus.Size = new System.Drawing.Size(100, 16);
            this.pbStatus.Visible = false;
            this.pbStatus.VisibleChanged += new System.EventHandler(this.tspbStatus_VisibleChanged);
            // 
            // imgStatus
            // 
            this.imgStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.imgStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imgStatus.Image = ((System.Drawing.Image)(resources.GetObject("imgStatus.Image")));
            this.imgStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imgStatus.Name = "imgStatus";
            this.imgStatus.ShowDropDownArrow = false;
            this.imgStatus.Size = new System.Drawing.Size(20, 20);
            this.imgStatus.Text = "toolStripDropDownButton1";
            this.imgStatus.Visible = false;
            // 
            // AxWebBrowser1
            // 
            this.AxWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxWebBrowser1.Enabled = true;
            this.AxWebBrowser1.Location = new System.Drawing.Point(0, 25);
            this.AxWebBrowser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxWebBrowser1.OcxState")));
            this.AxWebBrowser1.Size = new System.Drawing.Size(790, 347);
            this.AxWebBrowser1.TabIndex = 7;
            this.AxWebBrowser1.StatusTextChange += new AxSHDocVw.DWebBrowserEvents2_StatusTextChangeEventHandler(this.AxWebBrowser1_StatusTextChange);
            this.AxWebBrowser1.ProgressChange += new AxSHDocVw.DWebBrowserEvents2_ProgressChangeEventHandler(this.AxWebBrowser1_ProgressChange);
            this.AxWebBrowser1.CommandStateChange += new AxSHDocVw.DWebBrowserEvents2_CommandStateChangeEventHandler(this.AxWebBrowser1_CommandStateChange);
            this.AxWebBrowser1.DownloadComplete += new System.EventHandler(this.AxWebBrowser1_DownloadComplete);
            this.AxWebBrowser1.TitleChange += new AxSHDocVw.DWebBrowserEvents2_TitleChangeEventHandler(this.AxWebBrowser1_TitleChange);
            this.AxWebBrowser1.NewWindow2 += new AxSHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(this.AxWebBrowser1_NewWindow2);
            this.AxWebBrowser1.NavigateError += new AxSHDocVw.DWebBrowserEvents2_NavigateErrorEventHandler(this.AxWebBrowser1_NavigateError);
            this.AxWebBrowser1.NewWindow3 += new AxSHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(this.AxWebBrowser1_NewWindow3);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 394);
            this.Controls.Add(this.AxWebBrowser1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowserForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "about:blank";
            this.Text = "about:blank";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxWebBrowser1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cobURL;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnGoBack;
        private System.Windows.Forms.ToolStripButton btnGoFoward;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnGoHome;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public AxSHDocVw.AxWebBrowser AxWebBrowser1;
        private System.Windows.Forms.ToolStripProgressBar pbStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSplitButton btnSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuGoogleSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuBaiduSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuClearSearchHistory;
        private System.Windows.Forms.ToolStripComboBox cobSearch;
        private System.Windows.Forms.ToolStripSplitButton btnGo;
        private System.Windows.Forms.ToolStripMenuItem mnuClearUrlHistory;
        private System.Windows.Forms.ToolStripDropDownButton imgStatus;
    }
}