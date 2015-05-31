using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SocanCode
{
    public partial class SelectTableUserControl : UserControl
    {
        public SelectTableUserControl()
        {
            InitializeComponent();
        }

        private Model.Database db = null;
        public Model.Database DB
        {
            get
            {
                return this.db;
            }
            set
            {
                this.db = value;

                if (this.db != null)
                {
                    foreach (Model.Table table in this.db.Tables)
                    {
                        lstTables.Items.Add(table);
                    }
                    foreach (Model.Table view in this.db.Views)
                    {
                        lstTables.Items.Add(view);
                    }
                }
            }
        }

        public List<Model.Table> SelectedTables
        {
            get
            {
                List<Model.Table> tables = new List<Model.Table>();
                foreach (object obj in lstSelectedTables.Items)
                {
                    tables.Add(obj as Model.Table);
                }
                return tables;
            }
        }

        private void btnSelected_Click(object sender, EventArgs e)
        {
            List<object> objs = new List<object>();
            foreach (object obj in lstTables.SelectedItems)
            {
                objs.Add(obj);
            }
            foreach (object obj in objs)
            {
                lstSelectedTables.Items.Add(obj);
                lstTables.Items.Remove(obj);
            }
        }

        private void btnSelectedAll_Click(object sender, EventArgs e)
        {
            List<object> objs = new List<object>();
            foreach (object obj in lstTables.Items)
            {
                objs.Add(obj);
            }
            foreach (object obj in objs)
            {
                lstSelectedTables.Items.Add(obj);
                lstTables.Items.Remove(obj);
            }
        }

        private void btnUnSelected_Click(object sender, EventArgs e)
        {
            List<object> objs = new List<object>();
            foreach (object obj in lstSelectedTables.SelectedItems)
            {
                objs.Add(obj);
            }
            foreach (object obj in objs)
            {
                lstTables.Items.Add(obj);
                lstSelectedTables.Items.Remove(obj);
            }
        }

        private void btnUnSelectedAll_Click(object sender, EventArgs e)
        {
            List<object> objs = new List<object>();
            foreach (object obj in lstSelectedTables.Items)
            {
                objs.Add(obj);
            }
            foreach (object obj in objs)
            {
                lstTables.Items.Add(obj);
                lstSelectedTables.Items.Remove(obj);
            }
        }
    }
}
