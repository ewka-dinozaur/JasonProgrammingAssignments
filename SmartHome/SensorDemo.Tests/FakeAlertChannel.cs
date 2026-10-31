using SensorDemo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SensorDemo.Tests
{
    public class FakeAlertChannel : IAlertChannel
    {
        public List<string> Messages = new List<string>();

        public void Send(String message)
        {
            Messages.Add(message);
        }

    }
}

