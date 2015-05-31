using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Generator
{
    public class IOHelper
    {
        /// <summary>
        /// 写入文件（会检测目录是否存在，不存在则自动创建目录）
        /// </summary>
        public static void WriteFile(string filePath, string content)
        {
            string dir = filePath.Substring(0, filePath.LastIndexOf(@"\"));
            if (false == Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(filePath, false, Encoding.UTF8);
                sw.Write(content);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sw.Close();
            }
        }

        /// <summary>
        /// 在文件尾追加内容，如果文件不存在，则创建
        /// </summary>
        /// <param name="context">追加内容</param>
        /// <param name="filePath">文件路径</param>
        public static void AppendFile(string filePath, string context)
        {
            System.IO.FileStream stream;
            System.IO.StreamReader reader;
            System.IO.StreamWriter writer;

            stream = new System.IO.FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            reader = new System.IO.StreamReader(stream);
            string old = reader.ReadToEnd();

            writer = new System.IO.StreamWriter(stream);
            writer.Write(context);
            writer.Flush();
            writer.Close();

            reader.Close();
            stream.Close();
        }

        /// <summary>
        /// 从指定路径中读取文件
        /// </summary>
        public static string ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string str = sr.ReadToEnd();
            sr.Close();
            return str;
        }

        /// <summary>
        /// 拷贝文件
        /// </summary>
        public static void CopyFolder(string sourceDirName, string destDirName)
        {
            Directory.CreateDirectory(destDirName);

            if (!Directory.Exists(sourceDirName)) return;

            string[] directories = Directory.GetDirectories(sourceDirName);

            if (directories.Length > 0)
            {
                foreach (string d in directories)
                {
                    CopyFolder(d, destDirName + d.Substring(d.LastIndexOf(@"\")));
                }
            }

            string[] files = Directory.GetFiles(sourceDirName);

            if (files.Length > 0)
            {
                foreach (string s in files)
                {
                    string destFile = destDirName + s.Substring(s.LastIndexOf(@"\"));
                    if (!File.Exists(destFile))
                    {
                        File.Copy(s, destDirName + s.Substring(s.LastIndexOf(@"\")), true);
                    }
                }
            }
        }

        /// <summary>
        /// 移动目录
        /// </summary>
        /// <param name="sourceDirName">原目录</param>
        /// <param name="destDirName">新目录</param>
        public static void MoveFolder(string sourceDirName, string destDirName)
        {
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            FileSystemInfo[] sfiles = dir.GetFileSystemInfos();
            if (sfiles != null && sfiles.Length > 0)
            {
                for (int i = 0; i < sfiles.Length; i++)
                {
                    if (sfiles[i].Attributes == FileAttributes.Directory)
                    {
                        MoveFolder(sfiles[i].FullName, destDirName + "\\" + sfiles[i].Name);
                    }
                    else
                    {
                        FileInfo file = (FileInfo)sfiles[i];
                        file.CopyTo(destDirName + "\\" + file.Name, true);
                        file.Delete();
                    }
                }
            }

            Directory.Delete(sourceDirName);
        }

        /// <summary>
        /// 获取一个目录下所有的文件，包括子文件
        /// </summary>
        public static List<string> GetAllFiles(string dirPath)
        {
            List<string> lst = new List<string>();
            FindFile(dirPath, lst);
            return lst;
        }

        private static void FindFile(string dirPath, List<string> files)
        {
            //在指定目录及子目录下查找文件,放入List<string>中
            DirectoryInfo Dir = new DirectoryInfo(dirPath);
            foreach (FileInfo f in Dir.GetFiles()) //查找文件
            {
                files.Add(Dir + "\\" + f.ToString()); //填加文件名
            }

            foreach (DirectoryInfo d in Dir.GetDirectories()) //查找子目录 
            {
                FindFile(Dir + "\\" + d.ToString() + "\\", files);
            }
        }
    }
}
