using System;
using System.Collections.Generic;
using System.Text;

namespace DeptTechExercise
{
    public class Server
    {
        private static Server instance = null;

        private bool isRunning = true;

        private Server() { }

        public string TestResponse()
        {
            return "TODO";
        }

        public bool IsRunning()
        {
            return isRunning;
        }

        public void CloseApp()
        {
            isRunning = false;
        }

        public static Server Instance()
        {
            if(instance == null)
            {
                instance = new Server();
            }

            return instance;
        }
    }
}
