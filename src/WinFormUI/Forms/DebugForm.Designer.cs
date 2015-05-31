namespace SocanCode
{
    partial class DebugForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labDbJson = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDbJson = new System.Windows.Forms.TextBox();
            this.txtSetJson = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labDbJson, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDbJson, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSetJson, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(976, 274);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labDbJson
            // 
            this.labDbJson.AutoSize = true;
            this.labDbJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDbJson.Location = new System.Drawing.Point(3, 0);
            this.labDbJson.Name = "labDbJson";
            this.labDbJson.Padding = new System.Windows.Forms.Padding(8);
            this.labDbJson.Size = new System.Drawing.Size(482, 30);
            this.labDbJson.TabIndex = 0;
            this.labDbJson.Text = "databaseJson（数据库的JSON格式）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(491, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8);
            this.label1.Size = new System.Drawing.Size(482, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "settingJson（设置项的JSON格式）";
            // 
            // txtDbJson
            // 
            this.txtDbJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDbJson.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDbJson.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtDbJson.Location = new System.Drawing.Point(3, 33);
            this.txtDbJson.Multiline = true;
            this.txtDbJson.Name = "txtDbJson";
            this.txtDbJson.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDbJson.Size = new System.Drawing.Size(482, 238);
            this.txtDbJson.TabIndex = 1;
            // 
            // txtSetJson
            // 
            this.txtSetJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSetJson.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSetJson.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtSetJson.Location = new System.Drawing.Point(491, 33);
            this.txtSetJson.Multiline = true;
            this.txtSetJson.Name = "txtSetJson";
            this.txtSetJson.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSetJson.Size = new System.Drawing.Size(482, 238);
            this.txtSetJson.TabIndex = 1;
            // 
            // DebugForm
            // 
            this.AutoHidePortion = 0.5D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 274);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DebugForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.TabText = "调拭";
            this.Text = "调拭 function main(databaseJson, settingJson)";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labDbJson;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtDbJson;
        public System.Windows.Forms.TextBox txtSetJson;
    }
}