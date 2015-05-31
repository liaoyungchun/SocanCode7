namespace SocanCode
{
    partial class CodeClearForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveLineNum = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnRemoveLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "在网上摘录一段代码，经常会碰到前面带有行号，代码行之间有空格行，删起来挺费劲，用此工具可快速去除。";
            // 
            // btnRemoveLineNum
            // 
            this.btnRemoveLineNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveLineNum.Location = new System.Drawing.Point(649, 8);
            this.btnRemoveLineNum.Name = "btnRemoveLineNum";
            this.btnRemoveLineNum.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveLineNum.TabIndex = 1;
            this.btnRemoveLineNum.Text = "去除行号";
            this.btnRemoveLineNum.UseVisualStyleBackColor = true;
            this.btnRemoveLineNum.Click += new System.EventHandler(this.btnRemoveLineNum_Click);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(12, 37);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCode.Size = new System.Drawing.Size(793, 397);
            this.txtCode.TabIndex = 2;
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyUp);
            // 
            // btnRemoveLine
            // 
            this.btnRemoveLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveLine.Location = new System.Drawing.Point(730, 8);
            this.btnRemoveLine.Name = "btnRemoveLine";
            this.btnRemoveLine.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveLine.TabIndex = 1;
            this.btnRemoveLine.Text = "去除空行";
            this.btnRemoveLine.UseVisualStyleBackColor = true;
            this.btnRemoveLine.Click += new System.EventHandler(this.btnRemoveLine_Click);
            // 
            // CodeClearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 446);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnRemoveLine);
            this.Controls.Add(this.btnRemoveLineNum);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CodeClearForm";
            this.Text = "代码去行号空行";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveLineNum;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnRemoveLine;
    }
}