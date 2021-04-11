using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace Chat1
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            var db = redis.GetDatabase(0);
            while (Console.ReadLine() != "end")
            {
                int x1 = Convert.ToInt32(Console.ReadLine());
                int x2 = Convert.ToInt32(Console.ReadLine());
                var list = new RedisValue[]{ x1, x2 };
                db.ListRightPush("numbers", list);

            }
        }
    }
}
