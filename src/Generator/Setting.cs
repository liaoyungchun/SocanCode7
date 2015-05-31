using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Generator
{
    public class Setting
    {
        public Setting()
        {
            Options = new List<SettingOption>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public List<SettingOption> Options { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Description))
            {
                return this.Name;
            }

            return this.Description;
        }

        public static List<Setting> GetSettings(string templateFolder)
        {
            List<Setting> settings = new List<Setting>();

            //遍历所有的xml文件
            foreach (string settingFilePath in Directory.GetFiles(templateFolder, "*.xml"))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(settingFilePath);
                XmlNode root = xml.SelectSingleNode("settings");

                if (root == null) //根节点不是settings,则表示不是配置文件
                    continue;

                foreach (XmlNode settingNode in root.ChildNodes)
                {
                    //settings根节点下,每个setting节点为一个配置项
                    if (settingNode.Name.Equals("setting", StringComparison.CurrentCultureIgnoreCase))
                    {
                        #region get property
                        Setting setting = new Setting();
                        setting.Name = settingNode.Attributes["name"].Value;
                        if (settingNode.Attributes["description"] != null)
                        {
                            setting.Description = settingNode.Attributes["description"].Value;
                        }

                        if (settingNode.ChildNodes.Count == 0) //不存在option子节点,是文本框,value即为值
                        {
                            setting.Value = settingNode.Attributes["value"].Value;
                        }
                        else //存在option子节点,则是下拉框,子节点的selected属性为true的则为选中内容
                        {
                            foreach (XmlNode optionNode in settingNode.ChildNodes)
                            {
                                string name = optionNode.Attributes["name"].Value;
                                string description = string.Empty;
                                if (optionNode.Attributes["description"] != null)
                                {
                                    description = optionNode.Attributes["description"].Value;
                                }
                                setting.Options.Add(new SettingOption() { Name = name, Description = description });
                                if (optionNode.Attributes["selected"] != null && optionNode.Attributes["selected"].Value.Equals("true", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    setting.Value = name;
                                }
                            }
                        } 
                        #endregion
                        settings.Add(setting);
                    }
                }
            }

            return settings;
        }

        public static void SaveSettings(string templateFolder, List<Setting> settings)
        {
            foreach (string settingFilePath in Directory.GetFiles(templateFolder, "*.xml"))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(settingFilePath);
                XmlNode root = xml.SelectSingleNode("settings");
                if (root == null)
                {
                    return;//根节点不是Settings
                }

                foreach (XmlNode settingNode in root.ChildNodes)
                {
                    if (false == settingNode.Name.Equals("setting", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return; //节点名不是setting
                    }

                    foreach (Setting setting in settings)
                    {
                        //找到对应的控件uc
                        if (setting.Name.Equals(settingNode.Attributes["name"].Value, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (setting.Options.Count == 0) //是文本框直接赋value值
                            {
                                settingNode.Attributes["value"].Value = setting.Value;
                            }
                            else //是下拉框
                            {
                                foreach (XmlNode optionNode in settingNode.ChildNodes)
                                {
                                    if (optionNode.Attributes["name"].Value.Equals(setting.Value, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        if (optionNode.Attributes["selected"] == null)
                                        {
                                            XmlAttribute attr = xml.CreateAttribute("selected");
                                            attr.Value = "true";
                                            optionNode.Attributes.Append(attr);
                                        }
                                        else
                                        {
                                            optionNode.Attributes["selected"].Value = "true";
                                        }
                                    }
                                    else
                                    {
                                        if (optionNode.Attributes["selected"] != null)
                                        {
                                            optionNode.Attributes.Remove(optionNode.Attributes["selected"]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                xml.Save(settingFilePath);
            }
        }
    }

    public class SettingOption
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Description))
            {
                return this.Name;
            }

            return this.Description;
        }
    }
}
