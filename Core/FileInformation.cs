using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class FileInformation
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 新文件名称
        /// </summary>
        public string NewName { get; set; }
        /// <summary>
        /// 原始路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 保存路径
        /// </summary>
        public string SavePath { get; set; }
        /// <summary>
        /// 是否目录
        /// </summary>
        public bool IsDirectory { get; set; }
    }
}
