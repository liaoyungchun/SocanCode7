using System;
using System.Collections.Generic;
using System.IO;

namespace Generator
{
    public delegate void ProcessChanged(int process, int maxProcess);

    /// <summary>
    /// 代码生成类
    /// </summary>
    public class Template
    {
        public event ProcessChanged OnProcessChanged;

        public string TemplateFolder { get; set; }

        public string GenerateFolder { get; set; }

        public Model.Database Database { get; set; }

        public List<Setting> Settings { get; set; }

        public string DatabaseJson { get; private set; }

        public string SettingJson { get; private set; }

        public Jurassic.ScriptEngine Debug()
        {
            Jurassic.ScriptEngine engine = new Jurassic.ScriptEngine();

            foreach (string item in Directory.GetFiles(TemplateFolder, "*.js"))
                engine.Evaluate(new Jurassic.FileScriptSource(item));

            DatabaseJson = Newtonsoft.Json.JsonConvert.SerializeObject(Database, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter());
            SettingJson = Newtonsoft.Json.JsonConvert.SerializeObject(Settings, Newtonsoft.Json.Formatting.Indented);

            return engine;
        }

        public List<IJSResult> GetJSResults()
        {
            Jurassic.ScriptEngine engine = Debug();

            object dbJson = Jurassic.Library.JSONObject.Parse(engine, DatabaseJson);
            object setJson = Jurassic.Library.JSONObject.Parse(engine, SettingJson);

            object result = engine.CallGlobalFunction("main", dbJson, setJson);

            if (result == null || result.GetType() != typeof(Jurassic.Library.ArrayInstance))
                return null;

            List<IJSResult> jsResults = new List<IJSResult>();

            Jurassic.Library.ArrayInstance array = (Jurassic.Library.ArrayInstance)result;
            foreach (Jurassic.Library.ObjectInstance obj in array.ElementValues)
            {
                IJSResult r = GetJSResult(obj);
                if (r != null)
                    jsResults.Add(r);
            }

            return jsResults;
        }

        private IJSResult GetJSResult(Jurassic.Library.ObjectInstance obj)
        {
            object type = obj.GetPropertyValue("type");
            if (type == null || type.ToString().ToLower() == "code")
            {
                Codes code = new Codes(TemplateFolder);
                object title = obj.GetPropertyValue("title");
                if (title != null) code.Title = title.ToString();
                code.Path = obj.GetPropertyValue("path").ToString();
                code.Code = obj.GetPropertyValue("code").ToString();
                return code;
            }
            else if (type.ToString().ToLower() == "copy")
            {
                Copy copy = new Copy(TemplateFolder);
                copy.IsFolder = (bool)obj.GetPropertyValue("isfolder");
                copy.Source = obj.GetPropertyValue("source").ToString();
                copy.Target = obj.GetPropertyValue("target").ToString();
                return copy;
            }

            return null;
        }

        public void Generate()
        {
            List<IJSResult> jsResults = GetJSResults();
            int maxProcess = jsResults.Count + 1;

            if (OnProcessChanged != null)
                OnProcessChanged(1, maxProcess);

            for (int i = 0; i < jsResults.Count; i++)
            {
                jsResults[i].Generate(GenerateFolder);
                if (OnProcessChanged != null)
                    OnProcessChanged(i + 2, maxProcess);
            }
        }
    }

    public class Codes : IJSResult
    {
        public Codes(string templateFolder)
        {
            this.TemplateFolder = templateFolder;
        }

        public string TemplateFolder { get; set; }

        /// <summary>
        /// 获取标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取生成文件路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 获取生成的代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 获取生成的文件名
        /// </summary>
        public string FileName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Path))
                    return string.Empty;
                return Path.Substring(Path.LastIndexOf('\\') + 1);
            }
        }

        /// <summary>
        /// 获取生成文件的后缀
        /// </summary>
        public string Ext
        {
            get
            {
                if (string.IsNullOrEmpty(Path))
                    return string.Empty;
                return Path.Substring(Path.LastIndexOf('.') + 1);
            }
        }

        public void Generate(string genFolder)
        {
            if (string.IsNullOrWhiteSpace(Path) || string.IsNullOrWhiteSpace(Code))
                return;

            string path = genFolder;
            if (false == genFolder.EndsWith(@"\"))
                path += @"\";

            path = path + this.Path;
            IOHelper.WriteFile(path, Code);
        }
    }

    public class Copy : IJSResult
    {
        public Copy(string templateFolder)
        {
            this.TemplateFolder = templateFolder;
        }

        public string TemplateFolder { get; set; }

        public bool IsFolder { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }

        public void Generate(string genFolder)
        {
            string source = TemplateFolder.EndsWith(@"\") ? TemplateFolder + this.Source : TemplateFolder + @"\" + this.Source;
            string target = genFolder.EndsWith(@"\") ? genFolder + this.Target : genFolder + @"\" + this.Target;

            if (this.IsFolder)
            {
                IOHelper.CopyFolder(source, target);
            }
            else
            {
                File.Copy(source, target, true);
            }
        }
    }

    public interface IJSResult
    {
        string TemplateFolder { get; set; }

        void Generate(string genFolder);
    }
}
