using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome
{
    internal interface IDimmable
    {

        int Brightness { get; set; }
        void SetBrightness(int value);

    }
}
