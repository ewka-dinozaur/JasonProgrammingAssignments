using System;
using System.Collections.Generic;
using System.Text;

namespace Kalkulator
{
    public class Calculation
    {
        public double A { get; set; }
        public double B { get; set; }
        public string Op { get; set; } = "";
        public double Result { get; set; }
        public byte[] Log { get; set; } = new byte[10_000];   // balast - ok. 10 KB, żeby wyciek był widoczny
    }

    public static class History
    {
        public static List<Calculation> All = new List<Calculation>();
    }

 
}
