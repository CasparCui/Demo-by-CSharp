using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace FileBackupSystem
{
    abstract class Consumpt
    {
        public String SavePath = @"D:\c";
        abstract  public FileInfo ChangeFileName(FileInfo file);
        private XmlElement GetFileInfomation(FileInfo file,XmlElement xmle)
        {
            try
            {
                xmle.SetAttribute("File name", file.Name);
                xmle.SetAttribute("File Guid", file.GetType().GUID.ToString());
                xmle.SetAttribute("File type", Path.GetExtension(file.FullName));
                xmle.SetAttribute("File Path", file.FullName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return xmle;
        }
        private void WriteXml(FileInfo file)
        {
            try
            {

                XmlDocument xmldoc = new XmlDocument();
                String xmlPath = SavePath + "\\SaveXml.xml";
                if (!File.Exists(xmlPath))
                {
                    using (File.Create(xmlPath)) { }
                }
                xmldoc.Load(xmlPath);
                XmlElement xmle = xmldoc.CreateElement("File");
                xmle = GetFileInfomation(file, xmle);
                xmldoc.AppendChild(xmle as XmlNode);
                xmldoc.Save(xmlPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void GetAndSaveFileFromBuffer(FileInfo file,FileBuffer buffer)
        {
           
            DirectoryInfo dir = new DirectoryInfo(buffer.BufferPath);
            while (true)
            {
                file = this.ChangeFileName(file);
                var file1 = file.CopyTo(SavePath + "\\" + file.Name);
                file.Delete();
            }//WriteXml(file);
        }
    }
}
