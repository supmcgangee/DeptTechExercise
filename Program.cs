using System;

namespace DeptTechExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server();
            while(server.IsRunning())
            {

            }

            Console.WriteLine("Server Closed");
            Console.ReadKey();
        }
    }
}
