using System;
using System.Diagnostics;
using MongoDB.Driver;

namespace MongoDB
{
    class Program
    {
        private static MongoDatabase DataBase;

        static void Main(string[] args)
        {
            Initialize();

            var collection = DataBase.GetCollection<Employee>("employee");

            Console.WriteLine("Start the process");

            Stopwatch ss = new Stopwatch();
            ss.Start();

            for (int i = 0; i < 10000; i++)
            {
                var funcionario = new Employee
                {
                    Name = string.Format("Employee {0} Last Name", i)
                };

                if(i%2 == 0)
                    funcionario.GoOut();

                collection.Insert(funcionario);
            }

            ss.Stop();

            Console.WriteLine("Stop the process.");
            Console.WriteLine("10000 inserted");
            Console.WriteLine("Time elapsed: " + ss.Elapsed);

            Console.ReadLine();
        }

        public static void Initialize()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);

            var server = client.GetServer();

            // Name database
            DataBase = server.GetDatabase("company");
        }
    }
}
