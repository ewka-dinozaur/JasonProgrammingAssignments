using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome
{
    interface IPowerConsuming
    {
        double WattsUsed { get; }
    }
}
