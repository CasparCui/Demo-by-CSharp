using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Threading;

namespace FileBackupSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            FileBuffer buffer = new FileBuffer();
            String sourcePath = @"d:\a";
            String targetPath = @"d:\c";
            Thread Productor = new Thread(() =>
                {
                    Product productor = new Product();
                    productor.DirPath = sourcePath;
                    productor.SaveFile(buffer);
                });
            Thread Consumpt = new Thread(() =>
                {

                    FileInfo file = buffer.GetAFileAndMove();
                    if (Path.GetExtension(file.FullName).Equals(".doc") || Path.GetExtension(file.FullName).Equals(".docx"))
                    {
                        var doccopier = new DocCopyer();
                        doccopier.SavePath = targetPath;
                        doccopier.GetAndSaveFileFromBuffer(file, buffer);
                    }
                    else if (Path.GetExtension(file.FullName).Equals(".xls") || Path.GetExtension(file.FullName).Equals(".xlsx"))
                    {
                        var xmlcopier = new XlsCopyer();
                        xmlcopier.SavePath = targetPath;
                        xmlcopier.GetAndSaveFileFromBuffer(file, buffer);
                    }
                });
            Productor.Start();
            Productor.Join();
            Consumpt.Start();
            Consumpt.Join();
            //FileInfo file = buffer.GetAFileAndMove();
            //if (Path.GetExtension(file.FullName).Equals(".doc") || Path.GetExtension(file.FullName).Equals(".docs"))
            //{
            //    var doccopier = new DocCopyer();
            //    doccopier.SavePath = targetPath;
            //    doccopier.GetAndSaveFileFromBuffer(file, buffer);
            //}
            //else if (Path.GetExtension(file.FullName).Equals(".xls") || Path.GetExtension(file.FullName).Equals(".xlsx"))
            //{
            //    var xmlcopier = new XlsCopyer();
            //    xmlcopier.SavePath = targetPath;
            //    xmlcopier.GetAndSaveFileFromBuffer(file, buffer);
            //}
            Console.WriteLine("程序运行后请按任意键结束，并到指定路径查看结果。");
            Console.ReadKey();
        }
    }
}
