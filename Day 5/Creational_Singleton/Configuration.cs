using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Singleton
{
    public class Configuration
    {
        private static Configuration _instance;
        private static readonly object _instanceLock = new object(); // It is used to reserve the space like reserve ticket who has logined 
        public string Setting { get; private set; }
        public Configuration()
        {
            Console.WriteLine("Configuration Loaded");
        }
      
        public static Configuration Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Configuration();
                    }
                }
                return _instance;
            }
        } 
    }
}
