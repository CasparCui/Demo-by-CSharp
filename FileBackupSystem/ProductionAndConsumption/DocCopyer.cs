using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBackupSystem
{
    class DocCopyer: Consumpt
    {
        public override FileInfo ChangeFileName(FileInfo file)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.Append(file.DirectoryName);
            stringBuild.Append("\\");
            stringBuild.Append(file.GetType().GUID.ToString());
            stringBuild.Append(Path.GetExtension(file.FullName));
            String newPath = stringBuild.ToString();
            //File.Move(file.FullName, newPath);
            return file;
        }
    }
}
