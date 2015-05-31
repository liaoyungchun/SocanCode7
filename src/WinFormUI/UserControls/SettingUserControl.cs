using System;
using System.Windows.Forms;
using Generator;

namespace SocanCode
{
    public partial class SettingUserControl : UserControl
    {
        public SettingUserControl(Setting setting)
        {
            InitializeComponent();
            this.Setting = setting;
        }

        private Setting _setting;
        public Setting Setting
        {
            get
            {
                Control c = tableLayoutPanel1.GetControlFromPosition(1, 0);
                if (c.GetType() == typeof(TextBox))
                    _setting.Value = (c as TextBox).Text.Trim();
                else
                    _setting.Value = ((c as ComboBox).SelectedItem as SettingOption).Name;

                return _setting;
            }
            set
            {
                _setting = value;
                label1.Text = value.ToString();
                if (value.Options.Count == 0)
                {
                    TextBox txt = new TextBox();
                    txt.Dock = DockStyle.Fill;
                    txt.Text = value.Value;
                    tableLayoutPanel1.Controls.Add(txt, 1, 0);
                }
                else
                {
                    ComboBox cob = new ComboBox();
                    cob.DropDownStyle = ComboBoxStyle.DropDownList;
                    cob.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(cob, 1, 0);

                    foreach (SettingOption item in value.Options)
                    {
                        cob.Items.Add(item);
                        if (item.Name.Equals(value.Value, StringComparison.CurrentCultureIgnoreCase))
                        {
                            cob.SelectedItem = item;
                        }
                    }
                }
            }
        }
    }


}
