using StackExchange.Redis;
using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();

            db.StringSet("mykey", "Zekiri Abdelali");
            string result = db.StringGet("mykey");
            Console.WriteLine(result);
            Console.ReadLine();
            db.KeyDelete("mykey");
        }
    }
}
