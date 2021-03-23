using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bars1
{
    class Logger : ILog
    {
        private static readonly string path = Path.Combine(@"logs", DateTime.Today.ToShortDateString());

        public void Debug(string message)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "debug.txt");
            CheckOrCreateFile(debugPath);
            WriteMessage(message, debugPath);

        }

        public void Debug(string message, Exception e)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "debug.txt");
            CheckOrCreateFile(debugPath);
            using (StreamWriter sw = new StreamWriter(debugPath))
            {
                sw.WriteLine(message);
                sw.WriteLine($"Stack {e.TargetSite}");
            }
        }

        public void DebugFormat(string message, params object[] args)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "debug.txt");
            CheckOrCreateFile(debugPath);
            WriteParams(message, args, debugPath);
        }

        public void Error(string message)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "error.txt");
            CheckOrCreateFile(debugPath);
            
        }

        public void Error(string message, Exception e)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "error.txt");
            CheckOrCreateFile(debugPath);
            using (StreamWriter sw = new StreamWriter(debugPath))
            {
                sw.Write(message, e.Message);
            }
            ErrorUnique(message,e);
        }

        public void Error(Exception ex)
        {
            CheckOrCreateFolder();
            string errorPath = Path.Combine(path, "error.txt");
            CheckOrCreateFile(errorPath);
            using (StreamWriter sw = new StreamWriter(errorPath))
            {
                sw.Write(ex.Message);
            }
        }

        public void ErrorUnique(string message, Exception e)
        {
            string errorPath = Path.Combine(path, "error.txt");
            string[] lines = File.ReadAllLines(errorPath);
            if (!lines.Contains(message))
            {
                WriteMessage(message, errorPath);
            }

        }

        public void Fatal(string message)
        {
            CheckOrCreateFolder();
            string fatalPath = Path.Combine(path, "fatal.txt");
            CheckOrCreateFile(fatalPath);
            using (StreamWriter sw = new StreamWriter(fatalPath))
            {
                sw.Write(message);
            }
        }
        public void Fatal(string message, Exception e)
        {
            CheckOrCreateFolder();
            string fatalPath = Path.Combine(path, "fatal.txt");
            CheckOrCreateFile(fatalPath);
            using (StreamWriter sw = new StreamWriter(fatalPath))
            {
                sw.Write(message);
            }
        }
        public void Info(string message)
        {
            CheckOrCreateFolder();
            string infoPath = Path.Combine(path, "info.txt");
            CheckOrCreateFile(infoPath);
            using (StreamWriter sw = new StreamWriter(infoPath))
            {
                sw.Write(message);
            }

        }
        public void Info(string message, Exception e)
        {
            CheckOrCreateFolder();
            string infoPath = Path.Combine(path, "info.txt");
            CheckOrCreateFile(infoPath);
            using (StreamWriter sw = new StreamWriter(infoPath))
            {
                sw.Write(message, e.Data);
            }
        }
        public void Info(string message, params object[] args)
        {
            CheckOrCreateFolder();
            string infoPath = Path.Combine(path, "info.txt");
            CheckOrCreateFile(infoPath);
        }

        public void SystemInfo(string message, Dictionary<object, object> properties = null)
        {
            CheckOrCreateFolder();
            string systemInfo = Path.Combine(path, "systemInfo.txt");
            CheckOrCreateFile(systemInfo);
        }
        public void Warning(string message)
        {
            CheckOrCreateFolder();
            string warning = Path.Combine(path, "warning.txt");
            CheckOrCreateFile(warning);
            WarningUnique(message);
        }

        public void Warning(string message, Exception e)
        {
            CheckOrCreateFolder();
            string warning = Path.Combine(path, "warning.txt");
            CheckOrCreateFile(warning);
            
        }

        public void WarningUnique(string message)
        {
            string warning = Path.Combine(path, "warning.txt");
            string[] lines = File.ReadAllLines(warning);
            if (!lines.Contains(message))
            {
                WriteMessage(message,warning);
            }
        }


        private static void WriteParams(string message, object[] args, string debugPath)
        {
            FileStream Dic = new FileStream(debugPath, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(Dic))
            {
                sw.WriteLine(message);
                foreach (var item in args)
                {
                    sw.Write(item + " ");
                }
                sw.WriteLine("");
            }
        }

        private static void CheckOrCreateFile(string pathFile)
        {

            if (!File.Exists(pathFile))
                using (FileStream SourceStream = File.Open(pathFile, FileMode.Create)) ;
        }

        private static void CheckOrCreateFolder()
        {

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

        }

        private static void WriteMessage(string message, string debugPath)
        {
            FileStream Dic = new FileStream(debugPath, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(Dic))
            {
                sw.Write(message);
            }
        }
    }
}
