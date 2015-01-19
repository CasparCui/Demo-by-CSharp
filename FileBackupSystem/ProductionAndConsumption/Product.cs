using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace FileBackupSystem
{
    class Product
    {
        public String DirPath { get; set; }
        private List<FileInfo> GetFileFromSource(String dirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            var files = dir.GetFiles().ToList<FileInfo>();
            foreach (DirectoryInfo tempDir in dir.GetDirectories())
            {
                var tempFiles = this.GetFileFromSource(tempDir.FullName);
                foreach (FileInfo file in tempFiles)
                {
                    files.Add(file);
                }
            }
            List<FileInfo> tempFiles_1 = new List<FileInfo>();
            foreach (FileInfo file in files)
            {

                if (
                    Path.GetExtension(file.FullName).Equals(".doc", StringComparison.OrdinalIgnoreCase)
                    || Path.GetExtension(file.FullName).Equals(".docx", StringComparison.OrdinalIgnoreCase)
                    || Path.GetExtension(file.FullName).Equals(".xls", StringComparison.OrdinalIgnoreCase)
                    || Path.GetExtension(file.FullName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    tempFiles_1.Add(file);
                }
            }
            return tempFiles_1;
        }

        public void SaveFile(FileBuffer buffer)
        {
            List<FileInfo> files = GetFileFromSource(DirPath);
            
            foreach (FileInfo file in files)
            {
                while(true)
                {
                    bool success = buffer.SaveFileInfoBuffer(file);
                    if(success)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("文件数量超过10个，等待中。");
                        Thread.Sleep(1500);
                    }
                }
            }
        }
    }
}
