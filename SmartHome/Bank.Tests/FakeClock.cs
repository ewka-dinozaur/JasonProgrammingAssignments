using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Tests
{
        public class FakeClock : IClock
        {
            public DateTime UtcNow { get; set; }   // auto-property: test ustawia, konto odczytuje
        }

}

