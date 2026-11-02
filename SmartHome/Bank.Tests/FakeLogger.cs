using System;
using System.Collections.Generic;
using System.Text;


namespace Bank.Tests
{
    public class FakeLogger : ILogger
    {
        public List<string> Messages = new List<string>(); // list of messages to store log messages

        public void Log(String message)
        {
            Messages.Add(message);
        }

    }
}
