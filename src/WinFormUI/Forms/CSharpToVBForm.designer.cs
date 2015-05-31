namespace SocanCode
{
    partial class CSharpToVBForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSharpToVBForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_msg = new System.Windows.Forms.Label();
            this.btn_out = new System.Windows.Forms.Button();
            this.btn_conert = new System.Windows.Forms.Button();
            this.btn_imp = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_Csharp = new SocanCode.TextEditor();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_Vb = new SocanCode.TextEditor();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_msg);
            this.panel1.Controls.Add(this.btn_out);
            this.panel1.Controls.Add(this.btn_conert);
            this.panel1.Controls.Add(this.btn_imp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 55);
            this.panel1.TabIndex = 0;
            // 
            // txt_msg
            // 
            this.txt_msg.AutoSize = true;
            this.txt_msg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_msg.Location = new System.Drawing.Point(366, 22);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(0, 12);
            this.txt_msg.TabIndex = 4;
            // 
            // btn_out
            // 
            this.btn_out.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_out.Location = new System.Drawing.Point(242, 13);
            this.btn_out.Name = "btn_out";
            this.btn_out.Size = new System.Drawing.Size(106, 30);
            this.btn_out.TabIndex = 2;
            this.btn_out.Text = "导出数据";
            this.btn_out.UseVisualStyleBackColor = true;
            this.btn_out.Click += new System.EventHandler(this.btn_out_Click);
            // 
            // btn_conert
            // 
            this.btn_conert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_conert.Location = new System.Drawing.Point(131, 13);
            this.btn_conert.Name = "btn_conert";
            this.btn_conert.Size = new System.Drawing.Size(106, 30);
            this.btn_conert.TabIndex = 1;
            this.btn_conert.Text = "格式转换";
            this.btn_conert.UseVisualStyleBackColor = true;
            this.btn_conert.Click += new System.EventHandler(this.btn_conert_Click);
            // 
            // btn_imp
            // 
            this.btn_imp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_imp.Location = new System.Drawing.Point(21, 13);
            this.btn_imp.Name = "btn_imp";
            this.btn_imp.Size = new System.Drawing.Size(106, 30);
            this.btn_imp.TabIndex = 0;
            this.btn_imp.Text = "导入数据";
            this.btn_imp.UseVisualStyleBackColor = true;
            this.btn_imp.Click += new System.EventHandler(this.btn_imp_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(732, 586);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_Csharp);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(724, 560);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "C#.NET文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_Csharp
            // 
            this.txt_Csharp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Csharp.IsReadOnly = false;
            this.txt_Csharp.Location = new System.Drawing.Point(3, 3);
            this.txt_Csharp.Name = "txt_Csharp";
            this.txt_Csharp.Size = new System.Drawing.Size(718, 554);
            this.txt_Csharp.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_Vb);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(724, 560);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "VB.NET文件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_Vb
            // 
            this.txt_Vb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Vb.IsReadOnly = false;
            this.txt_Vb.Location = new System.Drawing.Point(3, 3);
            this.txt_Vb.Name = "txt_Vb";
            this.txt_Vb.Size = new System.Drawing.Size(718, 554);
            this.txt_Vb.TabIndex = 1;
            // 
            // CSharpToVB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 641);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CSharpToVB";
            this.Text = "C#转换VB.NET工具";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_out;
        private System.Windows.Forms.Button btn_conert;
        private System.Windows.Forms.Button btn_imp;
        private System.Windows.Forms.Label txt_msg;
        private TextEditor txt_Csharp;
        private TextEditor txt_Vb;

    }
}