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

            using (StreamWriter sw = new StreamWriter(debugPath))
            {
                sw.Write(message);
            }
        }

        public void Debug(string message, Exception e)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "debug.txt");
            CheckOrCreateFile(debugPath);
            using (StreamWriter sw = new StreamWriter(debugPath))
            {
                sw.Write(message,e.StackTrace);
            }
        }

        public void DebugFormat(string message, params object[] args)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "debug.txt");
            CheckOrCreateFile(debugPath);
            using (StreamWriter sw = new StreamWriter(debugPath))
            {
                sw.Write(message, args);
            }
        }

        public void Error(string message)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "error.txt");
            CheckOrCreateFile(debugPath);
            using (StreamWriter sw = new StreamWriter(debugPath))
            {
                sw.Write(message);
            }
        }

        public void Error(string message, Exception e)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "error.txt");
            CheckOrCreateFile(debugPath);
            using (StreamWriter sw = new StreamWriter(debugPath))
            {
                sw.Write(message,e.Message);
            }
        }

        public void Error(Exception ex)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "error.txt");
            CheckOrCreateFile(debugPath);
            using (StreamWriter sw = new StreamWriter(debugPath))
            {
                sw.Write(ex.Message);
            }
        }

        public void ErrorUnique(string message, Exception e)
        {
            CheckOrCreateFolder();
           
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
                sw.Write(message,e.Data);
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
        }

        public void Warning(string message, Exception e)
        {
            CheckOrCreateFolder();
            string warning = Path.Combine(path, "warning.txt");
            CheckOrCreateFile(warning);
        }

        public void WarningUnique(string message)
        {
            CheckOrCreateFolder();
            string warning = Path.Combine(path, "warning.txt");
            CheckOrCreateFile(warning);
        }

        private static void CheckOrCreateFile(string pathFile)
        {
            if (!File.Exists(pathFile))
            {
                File.Create(pathFile);
            }
        }

        private static void CheckOrCreateFolder()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
