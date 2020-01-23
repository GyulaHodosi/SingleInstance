using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = null;
            string _mutexName = "RUNMEONLYONCE";

            while (true)
            {
                try
                {
                    mutex = Mutex.OpenExisting(_mutexName);
                    Console.WriteLine(mutex);
                    mutex.Close();
                    System.Environment.Exit(1);
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    mutex = new Mutex(false, _mutexName);
                    Console.WriteLine("Wait Handle Cannot Be Opened");
                }
            }
        }
    }
}
