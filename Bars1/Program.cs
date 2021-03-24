using System;
using System.Collections.Generic;
using System.IO;

namespace Bars1
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            Dictionary<object, object> directory = new Dictionary<object, object>();
            directory.Add(1, 5);
            directory.Add(2, 5);
            directory.Add(3, 5);
            logger.SystemInfo("System Info",directory);

        }

    }
}

