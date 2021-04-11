using StackExchange.Redis;
using System;

namespace Chat2
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            var db = redis.GetDatabase(0);
            while (Console.ReadLine() != "end")
            {
                int x1 = (int)db.ListRightPop("numbers");
                Console.WriteLine("Число 1 "+x1);
                int x2 = (int)db.ListRightPop("numbers");
                Console.WriteLine("Число 2 " + x2);
                Console.WriteLine($"Результат {x1+x2}");
                

            }
        }
    }
}
