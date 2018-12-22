using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core
{
    public class FileHelper
    {
        public static List<FileInformation> list;
        /// <summary>
        /// 查找所有文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static List<FileInformation> FindAllFiles(string path)
        {
            list = new List<FileInformation>();
            if (IsDirectory(path))
            {
                GetDirectoryContent(path, list);
            }
            else if (IsFile(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                list.Add(new FileInformation
                {
                    Name = fileInfo.Name,
                    Path = path,
                    IsDirectory = false
                });
            }
            return list;
        }
        /// <summary>
        /// 创建新项目
        /// </summary>
        /// <param name="newProjectPath">新项目路径</param>
        /// <param name="newProjectName">新项目名称</param>
        /// <param name="path">模板所在路径</param>
        /// <param name="recursive">是否先清空目标文件夹及所有子文件</param>
        /// <param name="replaceName">要被替换的名称</param>
        /// <returns></returns>
        public static bool CreateNewProject(string newProjectPath, string newProjectName, string path, bool recursive = false, string replaceName = "ProjectName")
        {

            foreach (var file in list)
            {
                file.SavePath = newProjectPath + file.Path.Replace(path, "").Replace(replaceName, newProjectName);
            }
            if (recursive)
            {
                if (Directory.Exists(newProjectPath))
                {
                    Directory.Delete(newProjectPath, true);
                }
            }
            if (!Directory.Exists(newProjectPath))
            {
                Directory.CreateDirectory(newProjectPath);
            }
            DirectoryInfo di = new DirectoryInfo(newProjectPath);
            //生成项目路径下有文件或文件夹
            if (di.Exists && di.GetFiles().Length + di.GetDirectories().Length != 0)
            {
                return false;
            }
            var dirs = list.Where(t => t.IsDirectory == true).OrderBy(t => t.SavePath).ToList();
            foreach (var dir in dirs)
            {
                if (!Directory.Exists(dir.SavePath))
                {
                    Directory.CreateDirectory(dir.SavePath);
                }
            }
            var files = list.Where(t => t.IsDirectory == false).OrderBy(t => t.SavePath).ToList();
            foreach (var file in files)
            {
                var text = File.ReadAllText(file.Path, Encoding.UTF8);
                text = text.Replace(replaceName, newProjectName);
                File.WriteAllText(file.SavePath, text, Encoding.UTF8);
            }

            return true;
        }

        /// <summary>
        /// 是否是目录
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        private static bool IsDirectory(string path)
        {
            return Directory.Exists(path);
        }
        /// <summary>
        /// 是否是文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        private static bool IsFile(string path)
        {
            return File.Exists(path);
        }
        /// <summary>
        /// 获取目录内容
        /// </summary>
        /// <param name="path"></param>
        private static void GetDirectoryContent(string path, List<FileInformation> list)
        {
            var dirs = Directory.GetDirectories(path);
            if (dirs != null && dirs.Length > 0)
            {
                foreach (var dir in dirs)
                {
                    var name = dir.Substring(dir.LastIndexOf(@"\") + 1);
                    if (!IsIgnore(name))
                    {
                        list.Add(new FileInformation
                        {
                            Name = name,
                            Path = dir,
                            IsDirectory = true
                        });
                        if (IsDirectory(dir))
                        {
                            GetDirectoryContent(dir, list);
                        }
                    }
                }
            }
            var fileName = path.Substring(path.LastIndexOf(@"\") + 1);
            if (!IsIgnore(fileName))
            {
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);
                    list.Add(new FileInformation
                    {
                        Name = info.Name,
                        Path = file,
                        IsDirectory = false
                    });
                }
            }
        }
        /// <summary>
        /// 忽略文件名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static bool IsIgnore(string name)
        {
            string ignore = "packages|obj|bin|.vs";
            return ignore.Split('|').Contains(name);
        }
    }
}
