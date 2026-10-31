using System;
using System.Collections.Generic;
using System.Text;

namespace SensorDemo
{
    public class ConsoleAlertChannel : IAlertChannel
    {
        public void Send (string message)
        {
            Console.WriteLine($"  >> ALERT: {message}");
        }
    }
}


