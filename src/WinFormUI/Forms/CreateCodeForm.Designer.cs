namespace SocanCode
{
    partial class CreateCodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcCodes = new System.Windows.Forms.TabControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.selectTemplateUserControl1 = new SocanCode.SelectTemplateUserControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnSaveCurrentTab = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnViewDebug = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCodes
            // 
            this.tcCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCodes.Location = new System.Drawing.Point(0, 0);
            this.tcCodes.Multiline = true;
            this.tcCodes.Name = "tcCodes";
            this.tcCodes.SelectedIndex = 0;
            this.tcCodes.Size = new System.Drawing.Size(279, 410);
            this.tcCodes.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcCodes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.selectTemplateUserControl1);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(583, 410);
            this.splitContainer1.SplitterDistance = 279;
            this.splitContainer1.TabIndex = 5;
            // 
            // selectTemplateUserControl1
            // 
            this.selectTemplateUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectTemplateUserControl1.Location = new System.Drawing.Point(0, 73);
            this.selectTemplateUserControl1.Name = "selectTemplateUserControl1";
            this.selectTemplateUserControl1.Size = new System.Drawing.Size(300, 337);
            this.selectTemplateUserControl1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnSaveAll, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveCurrentTab, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnViewDebug, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 73);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveAll.Enabled = false;
            this.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveAll.Location = new System.Drawing.Point(153, 39);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Padding = new System.Windows.Forms.Padding(5);
            this.btnSaveAll.Size = new System.Drawing.Size(144, 31);
            this.btnSaveAll.TabIndex = 38;
            this.btnSaveAll.Text = "保存所有代码";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnSaveCurrentTab
            // 
            this.btnSaveCurrentTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveCurrentTab.Enabled = false;
            this.btnSaveCurrentTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveCurrentTab.Location = new System.Drawing.Point(3, 39);
            this.btnSaveCurrentTab.Name = "btnSaveCurrentTab";
            this.btnSaveCurrentTab.Padding = new System.Windows.Forms.Padding(5);
            this.btnSaveCurrentTab.Size = new System.Drawing.Size(144, 31);
            this.btnSaveCurrentTab.TabIndex = 38;
            this.btnSaveCurrentTab.Text = "保存当前页代码";
            this.btnSaveCurrentTab.UseVisualStyleBackColor = true;
            this.btnSaveCurrentTab.Click += new System.EventHandler(this.btnSaveCurrentTab_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerate.Location = new System.Drawing.Point(153, 3);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Padding = new System.Windows.Forms.Padding(5);
            this.btnGenerate.Size = new System.Drawing.Size(144, 30);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "生成代码";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnViewDebug
            // 
            this.btnViewDebug.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewDebug.Location = new System.Drawing.Point(3, 3);
            this.btnViewDebug.Name = "btnViewDebug";
            this.btnViewDebug.Padding = new System.Windows.Forms.Padding(5);
            this.btnViewDebug.Size = new System.Drawing.Size(144, 30);
            this.btnViewDebug.TabIndex = 5;
            this.btnViewDebug.Text = "查看调拭信息";
            this.btnViewDebug.UseVisualStyleBackColor = true;
            this.btnViewDebug.Click += new System.EventHandler(this.btnViewDebug_Click);
            // 
            // CreateCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 410);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CreateCodeForm";
            this.Text = "CreateCodeForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcCodes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnSaveCurrentTab;
        private System.Windows.Forms.Button btnGenerate;
        private SelectTemplateUserControl selectTemplateUserControl1;
        private System.Windows.Forms.Button btnViewDebug;
    }
}