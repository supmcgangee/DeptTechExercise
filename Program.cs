using System;

namespace DeptTechExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = Server.Instance();
            var writer = new Writer();

            while(server.IsRunning())
            {
                writer.Display();
            }

            Console.WriteLine("\nServer Closed, Press any key");
            Console.ReadKey();
        }
    }
}
