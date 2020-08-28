using DeptTechExercise.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeptTechExercise
{
    public class Server
    {
        private bool isRunning = true;

        private static Server instance = null;
        private APIHandler handler;


        private Server() 
        {
            handler = new APIHandler();
        }

        public string TestResponse()
        {
            return handler.TestResponse();
        }

        public QueryResponseModel GetMeasurementsForCity(string city)
        {
            return handler.GetMeasurementsForCity(city);
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
