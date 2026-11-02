using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    internal class SystemClock : IClock
    {
        public DateTime UtcNow // DateTime is data type, UtcNow is property name
        {
            get   // kod, który wykonuje się przy ODCZYCIE property
            {
                return DateTime.UtcNow;       // zwróć aktualny czas UTC z zegara systemowego
            }
        }

    }

}
