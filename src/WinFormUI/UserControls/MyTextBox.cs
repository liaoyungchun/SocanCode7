using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SocanCode
{
    public partial class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            InitializeComponent();
        }

        public MyTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (!base.ReadOnly || ((m.Msg != 0xa1) && (m.Msg != 0x201)))
            {
                base.WndProc(ref m);
            }
        }
    }
}
