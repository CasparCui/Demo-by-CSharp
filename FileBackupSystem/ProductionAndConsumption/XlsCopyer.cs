using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBackupSystem
{
    class XlsCopyer : Consumpt
    {
        public override FileInfo ChangeFileName(System.IO.FileInfo file)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.Append(file.DirectoryName);
            stringBuild.Append("\\");
            stringBuild.Append(DateTime.UtcNow.ToLongDateString());
            stringBuild.Append(Path.GetExtension(file.FullName));
            String newPath = stringBuild.ToString();
            return file;
        }
    }
}
