using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Generator;

namespace SocanCode
{
    public partial class SelectTemplateUserControl : UserControl
    {
        static string TemplateFolder = "templates";

        public event Action<string> ShowReadmeOfTemplate;

        public SelectTemplateUserControl()
        {
            InitializeComponent();
            LoadTemplates();
        }

        public void LoadTemplates()
        {
            int index = cobTemplates.SelectedIndex;

            cobTemplates.Items.Clear();

            string path = Application.StartupPath + @"\" + TemplateFolder;
            if (Directory.Exists(path))
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    DirectoryInfo d = new DirectoryInfo(dir);
                    cobTemplates.Items.Add(d.Name);
                }
            }

            if (index >= 0 && cobTemplates.Items.Count > index)
                cobTemplates.SelectedIndex = index;
            else if (cobTemplates.Items.Count > 0)
                cobTemplates.SelectedIndex = 0;
        }

        public string TemplateFolderName
        {
            get { return cobTemplates.Text; }
        }

        public string TemplateFolderPath
        {
            get
            {
                return Application.StartupPath + @"\" + TemplateFolder + @"\" + TemplateFolderName;
            }
        }

        public List<Setting> Settings
        {
            get
            {
                List<Setting> settings = new List<Setting>();
                foreach (SettingUserControl uc in panel1.Controls)
                {
                    settings.Add(uc.Setting);
                }
                return settings;
            }
        }

        private void cobTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            List<Setting> settings = Setting.GetSettings(TemplateFolderPath);
            for (int i = 0; i < settings.Count; i++)
            {
                Setting item = settings[settings.Count - 1 - i];
                SettingUserControl uc = new SettingUserControl(item);
                uc.Dock = DockStyle.Top;
                panel1.Controls.Add(uc);
            }

            string readme = null;
            string readmeFile = TemplateFolderPath.TrimEnd('\\', ' ') + @"\readme.txt";
            if (File.Exists(readmeFile))
            {
                readme = Generator.IOHelper.ReadFile(readmeFile);
            }

            if (ShowReadmeOfTemplate != null)
            {
                ShowReadmeOfTemplate(readme);
            }
        }

        public void SaveSetting()
        {
            Setting.SaveSettings(TemplateFolderPath, Settings);
        }
    }
}
