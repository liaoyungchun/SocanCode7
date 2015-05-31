namespace SocanCode
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOutputCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menufrmDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCodeToTemplateForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCodeClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpTopic = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGuestbook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labNewVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.cmsDockPanel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseOther = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cSharp转换VBNETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cmsDockPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCode,
            this.menuView,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(672, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuCode
            // 
            this.menuCode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreateCode,
            this.menuOutputCode});
            this.menuCode.Name = "menuCode";
            this.menuCode.Size = new System.Drawing.Size(41, 20);
            this.menuCode.Text = "代码";
            // 
            // menuCreateCode
            // 
            this.menuCreateCode.Name = "menuCreateCode";
            this.menuCreateCode.Size = new System.Drawing.Size(118, 22);
            this.menuCreateCode.Text = "生成代码";
            this.menuCreateCode.Click += new System.EventHandler(this.menuCreateCode_Click);
            // 
            // menuOutputCode
            // 
            this.menuOutputCode.Name = "menuOutputCode";
            this.menuOutputCode.Size = new System.Drawing.Size(118, 22);
            this.menuOutputCode.Text = "输出代码";
            this.menuOutputCode.Click += new System.EventHandler(this.menuOutputCode_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menufrmDatabase,
            this.menuTemplate,
            this.menuShowDebug});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(41, 20);
            this.menuView.Text = "视图";
            // 
            // menufrmDatabase
            // 
            this.menufrmDatabase.Name = "menufrmDatabase";
            this.menufrmDatabase.Size = new System.Drawing.Size(106, 22);
            this.menufrmDatabase.Text = "数据库";
            this.menufrmDatabase.Click += new System.EventHandler(this.menufrmDatabase_Click);
            // 
            // menuTemplate
            // 
            this.menuTemplate.Name = "menuTemplate";
            this.menuTemplate.Size = new System.Drawing.Size(106, 22);
            this.menuTemplate.Text = "模板";
            this.menuTemplate.Click += new System.EventHandler(this.menuTemplate_Click);
            // 
            // menuShowDebug
            // 
            this.menuShowDebug.Name = "menuShowDebug";
            this.menuShowDebug.Size = new System.Drawing.Size(106, 22);
            this.menuShowDebug.Text = "调拭";
            this.menuShowDebug.Click += new System.EventHandler(this.menuShowDebug_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCodeToTemplateForm,
            this.menuCodeClear,
            this.cSharp转换VBNETToolStripMenuItem});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(41, 20);
            this.menuTools.Text = "工具";
            // 
            // menuCodeToTemplateForm
            // 
            this.menuCodeToTemplateForm.Name = "menuCodeToTemplateForm";
            this.menuCodeToTemplateForm.Size = new System.Drawing.Size(166, 22);
            this.menuCodeToTemplateForm.Text = "代码转模板";
            this.menuCodeToTemplateForm.Click += new System.EventHandler(this.menuCodeToTemplateForm_Click);
            // 
            // menuCodeClear
            // 
            this.menuCodeClear.Name = "menuCodeClear";
            this.menuCodeClear.Size = new System.Drawing.Size(166, 22);
            this.menuCodeClear.Text = "代码去行号空行";
            this.menuCodeClear.Click += new System.EventHandler(this.menuCodeClear_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpTopic,
            this.menuWebsite,
            this.menuGuestbook,
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(41, 20);
            this.menuHelp.Text = "帮助";
            // 
            // menuHelpTopic
            // 
            this.menuHelpTopic.Name = "menuHelpTopic";
            this.menuHelpTopic.Size = new System.Drawing.Size(118, 22);
            this.menuHelpTopic.Text = "帮助主题";
            this.menuHelpTopic.Click += new System.EventHandler(this.menuHelpTopic_Click);
            // 
            // menuWebsite
            // 
            this.menuWebsite.Name = "menuWebsite";
            this.menuWebsite.Size = new System.Drawing.Size(118, 22);
            this.menuWebsite.Text = "官方网站";
            this.menuWebsite.Click += new System.EventHandler(this.menuWebsite_Click);
            // 
            // menuGuestbook
            // 
            this.menuGuestbook.Name = "menuGuestbook";
            this.menuGuestbook.Size = new System.Drawing.Size(118, 22);
            this.menuGuestbook.Text = "给我留言";
            this.menuGuestbook.Click += new System.EventHandler(this.menuGuestbook_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(118, 22);
            this.menuAbout.Text = "关于";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labNewVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 348);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(672, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labNewVersion
            // 
            this.labNewVersion.IsLink = true;
            this.labNewVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.labNewVersion.Name = "labNewVersion";
            this.labNewVersion.Size = new System.Drawing.Size(95, 17);
            this.labNewVersion.Tag = "http://www.socansoft.com/downloads/SocanCode/SocanCode.rar";
            this.labNewVersion.Text = "正在检测版本...";
            this.labNewVersion.Click += new System.EventHandler(this.labNewVersion_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel1.DockBottomPortion = 0.2D;
            this.dockPanel1.DockLeftPortion = 0.2D;
            this.dockPanel1.DockRightPortion = 0.2D;
            this.dockPanel1.DockTopPortion = 0.2D;
            this.dockPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(672, 324);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel1.Skin = dockPanelSkin1;
            this.dockPanel1.TabIndex = 6;
            this.dockPanel1.ContentAdded += new System.EventHandler<WeifenLuo.WinFormsUI.Docking.DockContentEventArgs>(this.dockPanel1_ContentAdded);
            // 
            // cmsDockPanel
            // 
            this.cmsDockPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClose,
            this.mnuCloseOther,
            this.mnuCloseAll});
            this.cmsDockPanel.Name = "contextMenuStrip1";
            this.cmsDockPanel.Size = new System.Drawing.Size(149, 70);
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(148, 22);
            this.mnuClose.Text = "关闭标签";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // mnuCloseOther
            // 
            this.mnuCloseOther.Name = "mnuCloseOther";
            this.mnuCloseOther.Size = new System.Drawing.Size(148, 22);
            this.mnuCloseOther.Text = "关闭其他标签";
            this.mnuCloseOther.Click += new System.EventHandler(this.mnuCloseOther_Click);
            // 
            // mnuCloseAll
            // 
            this.mnuCloseAll.Name = "mnuCloseAll";
            this.mnuCloseAll.Size = new System.Drawing.Size(148, 22);
            this.mnuCloseAll.Text = "关闭全部标签";
            this.mnuCloseAll.Click += new System.EventHandler(this.mnuCloseAll_Click);
            // 
            // cSharp转换VBNETToolStripMenuItem
            // 
            this.cSharp转换VBNETToolStripMenuItem.Name = "cSharp转换VBNETToolStripMenuItem";
            this.cSharp转换VBNETToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cSharp转换VBNETToolStripMenuItem.Text = "CSharp转换VB.NET";
            this.cSharp转换VBNETToolStripMenuItem.Click += new System.EventHandler(this.cSharp转换VBNETToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 370);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SocanCode代码生成器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmsDockPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuWebsite;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labNewVersion;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menufrmDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuCodeToTemplateForm;
        private System.Windows.Forms.ToolStripMenuItem menuGuestbook;
        private System.Windows.Forms.ToolStripMenuItem menuCode;
        private System.Windows.Forms.ContextMenuStrip cmsDockPanel;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseOther;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAll;
        private System.Windows.Forms.ToolStripMenuItem menuHelpTopic;
        private System.Windows.Forms.ToolStripMenuItem menuCreateCode;
        private System.Windows.Forms.ToolStripMenuItem menuOutputCode;
        private System.Windows.Forms.ToolStripMenuItem menuTemplate;
        private System.Windows.Forms.ToolStripMenuItem menuCodeClear;
        private System.Windows.Forms.ToolStripMenuItem menuShowDebug;
        private System.Windows.Forms.ToolStripMenuItem cSharp转换VBNETToolStripMenuItem;
    }
}