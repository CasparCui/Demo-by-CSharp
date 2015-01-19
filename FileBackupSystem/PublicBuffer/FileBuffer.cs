using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBackupSystem
{
    public class FileBuffer
    {
        private readonly int maxFileBuffer = 10;
        public int FileCount { private set; get; }
        public String BufferPath = @"c:\temp";
        private object lockObj = new object();

        public FileBuffer()
        {
            Console.Write("请输入File Buffer Path，请注意输入的正确性，如c:\\temp：");
            BufferPath = Console.ReadLine();
        }

        public FileInfo GetAFileAndMove()
        {
            if (FileCount >= 1)
            {
                DirectoryInfo dirInfo = null;
                while (true)
                {
                    try
                    {
                        dirInfo = new DirectoryInfo(BufferPath);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("您之前输入的File Path 不合法或者文件夹不存在，请重新输入！！\nFile Path:");
                        BufferPath = Console.ReadLine();
                    }
                }
                List<FileInfo> files = dirInfo.GetFiles().ToList<FileInfo>();
                FileInfo file = null;
                lock (lockObj)
                {
                    file = files.Last();
                    FileCount--;
                }
                return file;
            }
            return null;
        }
        
        public bool SaveFileInfoBuffer(FileInfo file)
        {
            DirectoryInfo dirInfo = null;
            while (true)
            {
                try
                {
                    dirInfo = new DirectoryInfo(BufferPath);
                    break;
                }
                catch
                {
                    Console.WriteLine("您之前输入的File Path 不合法或者文件夹不存在，请重新输入！！\nFile Path:");
                    BufferPath = Console.ReadLine();
                }
            }
            lock (lockObj)
            {
                if (FileCount < 10)
                {
                    try
                    {
                        file.CopyTo(dirInfo + "\\" + file.Name);
                    }
                    catch
                    {
                        return false;
                    }
                    FileCount++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
