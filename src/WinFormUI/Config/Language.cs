using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

namespace SocanCode.Config
{
    public class Language
    {
        public Language()
        {
            Exts = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Exts { get; set; }

        private static List<Language> _allLanguage = null;
        public static List<Language> AllLanguage
        {
            get
            {
                if (_allLanguage == null)
                {
                    _allLanguage = new List<Language>();
                    XmlDocument xml = new XmlDocument();
                    xml.Load(Application.StartupPath + @"\Config\Language.xml");
                    XmlNode root = xml.SelectSingleNode("Languages");
                    foreach (XmlNode child in root.ChildNodes)
                    {
                        Language language = new Language();
                        language.Name = child.Attributes["Name"].Value.Trim();
                        foreach (string ext in child.Attributes["Ext"].Value.Split(','))
                        {
                            language.Exts.Add(ext.Trim());
                        }
                        _allLanguage.Add(language);
                    }
                }

                return _allLanguage;
            }
        }

        public static Language GetLanguageByExt(string ext)
        {
            ext = ext.Replace(".", "");
            foreach (Language lang in AllLanguage)
            {
                foreach (var item in lang.Exts)
                {
                    if (item.Equals(ext, System.StringComparison.CurrentCultureIgnoreCase))
                        return lang;
                }
            }
            //List<Language> langs = Language.AllLanguage.FindAll(m => m.Exts.Contains(ext));
            //if (langs.Count > 0)
            //    return langs[0];

            return null;
        }
    }
}
