using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SocanCode
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        public ErrorForm(string content)
            : this()
        {
            txtError.Text = content;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
