using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gurkan
{
    public class Logger
    {
        private StreamWriter sw;
        private const string FILE_NAME = "log.txt";
        private string rootPath;

        public Logger(string AppRootPath)
        {
            createOpenFile(AppRootPath);
        }

        private void createOpenFile(string AppRootPath)
        {
            rootPath = AppRootPath;

            // Dosya var mý?
            bool fileExists = false;
            DirectoryInfo di = new DirectoryInfo(rootPath);
            FileInfo[] fi = di.GetFiles();
            if (fi != null) for (int n = 0; n < fi.Length; n++) if (fi[n].Name == FILE_NAME) fileExists = true;

            // Dosya varsa açacaðýz, yoksa yaratacaðýz
            if (fileExists)
            {
                sw = File.CreateText(fullPath);
            }
            else
            {
                sw = File.AppendText(fullPath);
            }
        }

        public void appendLog(string Text)
        {
            // TimeStamp al
            DateTime now = DateTime.Now;
            string date = "";
            string time = "";
            SAP.parseDateTime(now, out date, out time);

            // Dosyaya yazdýr
            sw.WriteLine("[" + date + time + "] " + Text);
            sw.Flush();
        }

        public string fullPath
        {
            get { return rootPath + "\\" + FILE_NAME; }
        }

        public void displayLog()
        {
            System.Diagnostics.Process.Start(fullPath);
        }
    }
}
