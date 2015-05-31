using Model;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
namespace SocanCode.Config
{
	public class History
	{
		private static string xmlPath = Application.StartupPath + "\\Config\\History.xml";
		public DatabaseTypes DatabaseType
		{
			get;
			set;
		}
		public string AccessConn
		{
			get;
			set;
		}
		public string SqlServerConn
		{
			get;
			set;
		}
		public string MySqlConn
		{
			get;
			set;
		}
		public string OracleConn
		{
			get;
			set;
		}
		public string SQLiteConn
		{
			get;
			set;
		}
        public string AseConn
        {
            get;
            set;
        }
        public string DB2Conn
        {
            get;
            set;
        }
        public string PostgreSqlConn
        {
            get;
            set;
        }
		public History()
		{
			this.DatabaseType = DatabaseTypes.Sql2000;
			this.SqlServerConn = "Data Source=127.0.0.1;User ID=sa;Password=;Initial Catalog=;";
		}
		public static History Load()
		{
			History history = new History();
			XmlDocument xmlDocument = new XmlDocument();
			if (File.Exists(History.xmlPath))
			{
				try
				{
					xmlDocument.Load(History.xmlPath);
					XmlNode xmlNode = xmlDocument.SelectSingleNode("Config");
					PropertyInfo[] properties = history.GetType().GetProperties();
					for (int i = 0; i < properties.Length; i++)
					{
						PropertyInfo propertyInfo = properties[i];
						string value = xmlNode.SelectSingleNode(propertyInfo.Name).Attributes["value"].Value;
						if (propertyInfo.PropertyType.IsEnum)
						{
							propertyInfo.SetValue(history, Enum.Parse(propertyInfo.PropertyType, value), null);
						}
						else
						{
							propertyInfo.SetValue(history, value, null);
						}
					}
				}
				catch (Exception)
				{
					History.Save(history);
				}
			}
			else
			{
				History.Save(history);
			}
			return history;
		}
		public static void Save(History sys)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				XmlNode xmlNode = xmlDocument.CreateElement("Config");
				xmlDocument.AppendChild(xmlNode);
				PropertyInfo[] properties = typeof(History).GetProperties();
				for (int i = 0; i < properties.Length; i++)
				{
					PropertyInfo propertyInfo = properties[i];
					XmlNode xmlNode2 = xmlDocument.CreateElement(propertyInfo.Name);
					XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("value");
					xmlAttribute.Value = (propertyInfo.GetValue(sys, null) ?? string.Empty).ToString();
					xmlNode2.Attributes.Append(xmlAttribute);
					xmlNode.AppendChild(xmlNode2);
				}
				xmlDocument.Save(History.xmlPath);
			}
			catch (Exception)
			{
			}
		}
	}
}
