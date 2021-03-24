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
            WriteMessageEx(message, debugPath, e);
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
            WriteMessage(message, debugPath);
        }

        public void Error(string message, Exception e)
        {
            CheckOrCreateFolder();
            string debugPath = Path.Combine(path, "error.txt");
            CheckOrCreateFile(debugPath);
            ErrorUnique(message,e);
        }

        public void Error(Exception ex)
        {
            CheckOrCreateFolder();
            string errorPath = Path.Combine(path, "error.txt");
            CheckOrCreateFile(errorPath);
            WriteEx(ex, errorPath);
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
            WriteMessage(message, fatalPath);
        }
        public void Fatal(string message, Exception e)
        {
            CheckOrCreateFolder();
            string fatalPath = Path.Combine(path, "fatal.txt");
            CheckOrCreateFile(fatalPath);
            WriteMessageEx(message, fatalPath, e);
        }
        public void Info(string message)
        {
            CheckOrCreateFolder();
            string infoPath = Path.Combine(path, "info.txt");
            CheckOrCreateFile(infoPath);
            WriteMessage(message, infoPath);

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
            WriteParams(message, args,infoPath);
        }

        public void SystemInfo(string message, Dictionary<object, object> properties = null)
        {
            CheckOrCreateFolder();
            string systemInfo = Path.Combine(path, "systemInfo.txt");
            CheckOrCreateFile(systemInfo);
            WriteDictionary(message, systemInfo, properties);
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
            WriteMessageEx(message, warning, e);
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


        public static void WriteDictionary(string message, string path, Dictionary<object, object> dictionary = null)
        {
            FileStream fileStream = new FileStream(path, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fileStream))
            {
                sw.WriteLine(message);
                foreach (var item in dictionary)
                {
                    sw.WriteLine(item + " ");
                }
                sw.WriteLine("");
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

        private static void WriteMessage(string message, string path)
        {
            FileStream Dic = new FileStream(path, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(Dic))
            {
                sw.Write(message);
            }
        }
        private static void WriteMessageEx(string message, string path, Exception ex)
        {
            FileStream Dic = new FileStream(path, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(Dic))
            {
                sw.WriteLine(message);
                sw.WriteLine(ex.Message);
            }
        }

        private static void WriteEx(Exception ex,string path)
        {
            FileStream Dic = new FileStream(path, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(Dic))
            {
                sw.WriteLine(ex.Message);
                sw.WriteLine(ex.StackTrace);
            }
        }
    }
}
