using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Core
{
    public class ZipHelper
    {
        /// <summary>
        /// 解压缩一个 zip 文件。
        /// </summary>
        /// <param name="zipedFile">压缩包路径</param>
        /// <param name="strDirectory">解压路径</param>
        /// <param name="password">zip 文件的密码。</param>
        /// <param name="overWrite">是否覆盖已存在的文件。</param>
        public static void UnZipFile(string zipedFile, string strDirectory, string password, bool overWrite)
        {

            if (strDirectory == "")
                strDirectory = Directory.GetCurrentDirectory();
            if (!strDirectory.EndsWith("\\"))
                strDirectory = strDirectory + "\\";
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipedFile)))
            {
                s.Password = password;
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = "";
                    string pathToZip = "";
                    pathToZip = theEntry.Name;

                    if (pathToZip != "")
                        directoryName = Path.GetDirectoryName(pathToZip) + "\\";

                    string fileName = Path.GetFileName(pathToZip);

                    Directory.CreateDirectory(strDirectory + directoryName);

                    if (fileName != "")
                    {
                        if ((File.Exists(strDirectory + directoryName + fileName) && overWrite) || (!File.Exists(strDirectory + directoryName + fileName)))
                        {
                            using (FileStream streamWriter = File.Create(strDirectory + directoryName + fileName))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);

                                    if (size > 0)
                                        streamWriter.Write(data, 0, size);
                                    else
                                        break;
                                }
                                streamWriter.Close();
                            }
                        }
                    }
                }
                s.Close();
            }
        }

        /// <summary>
        /// 压缩文件夹
        /// </summary>
        /// <param name="sourceList">源文件/文件夹路径列表</param>
        /// <param name="zipFilePath">压缩文件路径</param>
        /// <param name="comment">注释信息</param>
        /// <param name="password">压缩密码</param>
        /// <param name="compressionLevel">压缩等级，范围从0到9，可选，默认为6</param>
        /// <returns></returns>
        public static bool CompressFile(string sourceList, string zipFilePath,
             string comment = null, string password = null, int compressionLevel = 6)
        {
            return CompressFile(new List<string> { sourceList }, zipFilePath, comment, password, compressionLevel);
        }
        /// <summary>
        /// 压缩文件夹
        /// </summary>
        /// <param name="sourceList">源文件/文件夹路径列表</param>
        /// <param name="zipFilePath">压缩文件路径</param>
        /// <param name="comment">注释信息</param>
        /// <param name="password">压缩密码</param>
        /// <param name="compressionLevel">压缩等级，范围从0到9，可选，默认为6</param>
        /// <returns></returns>
        public static bool CompressFile(IEnumerable<string> sourceList, string zipFilePath,
         string comment = null, string password = null, int compressionLevel = 6)
        {
            bool result = false;

            try
            {
                //检测目标文件所属的文件夹是否存在，如果不存在则建立
                string zipFileDirectory = Path.GetDirectoryName(zipFilePath);
                if (!Directory.Exists(zipFileDirectory))
                {
                    Directory.CreateDirectory(zipFileDirectory);
                }

                var dictionaryList = PrepareFileSystementities(sourceList);

                using (ZipOutputStream zipStream = new ZipOutputStream(File.Create(zipFilePath)))
                {
                    zipStream.Password = password;//设置密码
                    zipStream.SetComment(comment);//添加注释
                    zipStream.SetLevel(compressionLevel);//设置压缩等级

                    foreach (var file in dictionaryList)//从字典取文件添加到压缩文件
                    {
                        if (!file.IsDirectory)//判断是文件还是文件夹
                        {
                            FileInfo fileItem = new FileInfo(file.Path);
                            using (FileStream readStream = fileItem.Open(FileMode.Open,
                                FileAccess.Read, FileShare.Read))
                            {
                                ZipEntry zipEntry = new ZipEntry(file.Name);
                                zipEntry.DateTime = fileItem.LastWriteTime;
                                zipEntry.Size = readStream.Length;
                                zipStream.PutNextEntry(zipEntry);
                                int readLength = 0;
                                byte[] buffer = new byte[2048];
                                do
                                {
                                    readLength = readStream.Read(buffer, 0, 2048);
                                    zipStream.Write(buffer, 0, readLength);
                                } while (readLength == 2048);

                                readStream.Close();
                            }
                        }
                        else//对文件夹的处理
                        {
                            ZipEntry zipEntry = new ZipEntry(file.Name + "/");
                            zipStream.PutNextEntry(zipEntry);
                        }
                    }

                    zipStream.Flush();
                    zipStream.Finish();
                    zipStream.Close();
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception("压缩文件失败", ex);
            }
            return result;
        }
        /// <summary>
        /// 获取路径下文件
        /// </summary>
        /// <param name="sourceList">路径集合</param>
        /// <returns></returns>
        private static List<FileInformation> PrepareFileSystementities(IEnumerable<string> sourceList)
        {
            List<FileInformation> list = new List<FileInformation>();
            foreach (var path in sourceList)
            {
                var files = FileHelper.FindAllFiles(path);
                list.AddRange(files);
                foreach (var item in files)
                {
                    item.Name = item.Path.Replace(path, "");
                }
            }
            return list.OrderBy(t=>t.Path).ToList();
        }
    }
}
