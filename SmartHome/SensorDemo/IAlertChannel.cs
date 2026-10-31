using System;
using System.Collections.Generic;
using System.Text;

namespace SensorDemo
{
    public interface IAlertChannel
    {
        void Send(string message);

    }
}
