using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using SocanCode.Config;

namespace SocanCode
{
    public class TextEditor : ICSharpCode.TextEditor.TextEditorControl
    {
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuParse;

        public TextEditor()
        {
            this.cms = new System.Windows.Forms.ContextMenuStrip();
            this.ContextMenuStrip = cms;

            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuParse = new System.Windows.Forms.ToolStripMenuItem();

            // 
            // contextMenuStrip1
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCut,
            this.mnuCopy,
            this.mnuParse});
            this.cms.Name = "contextMenuStrip1";
            this.cms.Size = new System.Drawing.Size(101, 70);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(152, 22);
            this.mnuCopy.Text = "复制";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuParse
            // 
            this.mnuParse.Name = "mnuParse";
            this.mnuParse.Size = new System.Drawing.Size(152, 22);
            this.mnuParse.Text = "粘贴";
            this.mnuParse.Click += new System.EventHandler(this.mnuParse_Click);
            // 
            // mnuCut
            // 
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Size = new System.Drawing.Size(152, 22);
            this.mnuCut.Text = "剪切";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
                DoEditAction(new ICSharpCode.TextEditor.Actions.Cut());
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
                DoEditAction(new ICSharpCode.TextEditor.Actions.Copy());
        }

        private void mnuParse_Click(object sender, EventArgs e)
        {
            DoEditAction(new ICSharpCode.TextEditor.Actions.Paste());
        }

        private bool HaveSelection()
        {
            return this.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected;
        }

        /// <summary>Performs an action encapsulated in IEditAction.</summary>
        /// <remarks>
        /// There is an implementation of IEditAction for every action that 
        /// the user can invoke using a shortcut key (arrow keys, Ctrl+X, etc.)
        /// The editor control doesn't provide a public funciton to perform one
        /// of these actions directly, so I wrote DoEditAction() based on the
        /// code in TextArea.ExecuteDialogKey(). You can call ExecuteDialogKey
        /// directly, but it is more fragile because it takes a Keys value (e.g.
        /// Keys.Left) instead of the action to perform.
        /// <para/>
        /// Clipboard commands could also be done by calling methods in
        /// editor.ActiveTextAreaControl.TextArea.ClipboardHandler.
        /// </remarks>
        private void DoEditAction(ICSharpCode.TextEditor.Actions.IEditAction action)
        {
            if (action != null)
            {
                TextArea area = this.ActiveTextAreaControl.TextArea;
                this.BeginUpdate();
                try
                {
                    lock (this.Document)
                    {
                        action.Execute(area);
                        if (area.SelectionManager.HasSomethingSelected && area.AutoClearSelection /*&& caretchanged*/)
                        {
                            if (area.Document.TextEditorProperties.DocumentSelectionMode == DocumentSelectionMode.Normal)
                            {
                                area.SelectionManager.ClearSelection();
                            }
                        }
                    }
                }
                finally
                {
                    this.EndUpdate();
                    area.Caret.UpdateCaretPosition();
                }
            }
        }

        /// <summary>
        /// 设置文本框样式
        /// </summary>
        /// <param name="textbox">文本框名称</param>
        /// <param name="language">语言:"ASP3/XHTML","BAT","Boo","Coco","C++.NET","C#","HTML",
        /// "Java","JavaScript","PHP","TeX","VBNET","XML","TSQL"</param>
        public void SetStyle(string language)
        {
            this.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(language);
            this.Encoding = System.Text.Encoding.UTF8;
        }

        /// <summary>
        /// 设置文本框样式
        /// </summary>
        /// <param name="textbox">文本框名称</param>
        /// <param name="ext">后缀</param>
        public void SetStyleByExt(string ext)
        {
            Language lang = Language.GetLanguageByExt(ext);
            if (lang != null)
            {
                this.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(lang.Name);
                this.Encoding = System.Text.Encoding.UTF8;
            }
        }
    }
}
