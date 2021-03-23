using System;
using System.IO;

namespace Bars1
{
    class Program
    {
        static void Main(string[] args)
        {

            Logger logger = new Logger();
            logger.DebugFormat("Дебаг", 1, 3, 4, 5, 6);
            
        }
    }
}
