using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Text;

namespace SensorDemo

{
    interface INotifiable
    {
        void SendAlert(string message);
    }

    internal abstract class Sensor
    {

        protected string Location;
        public Sensor(string location)
        {
            Location = location;
        }
        public abstract void Measure();

    }


    // Class for SmokeSensor with appliec interface and abstract Measure method override 
    internal class SmokeSensor : Sensor, INotifiable
    {
        private int _smokeLevel;

        // konstruktor
        public SmokeSensor(string location) : base(location)
        { 
        }

        public int SmokeLevel

        {
            get { return _smokeLevel; }

            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("Smoke level must be between 0 and 10 ");
                else
                    _smokeLevel = value;
            }
        }

        public void SendAlert(string message)
        {
            Console.WriteLine($"  >> ALERT from {Location}: {message}");
        }

        public override void Measure()
        {
            Console.WriteLine($"[{Location}] Detected smoke level: {SmokeLevel}");
        }
    }


    // Class for TemperatureSensore with abstract Measure method override but without interface
    internal class TemperatureSensor : Sensor
    {
        private int _temperature;

        // konstruktor
        public TemperatureSensor(string location) : base(location)
        {
            Location = location;
        }

        public int Temperature

        {
            get { return _temperature; }

            set
            {
                if (value < 15 || value > 30)
                    throw new ArgumentException("Temperature must be between 15 and 30 Celsius ");
                else
                    _temperature = value;
            }
        }

        public override void Measure()
        {
            Console.WriteLine($"[{Location}] Detected temperature level: {Temperature} ");
        }

        // uzycie static 

        public static double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }
        // GetKelvin jest metoda ktora upraszcza zycie bo mozna zawolac ja bezposrednio z obiektu sensor a nie trzeba odnosic sie do temperatury w srodku:
        // pozwala zrobic:  double k = sensor1.GetKelvin(); zamiast :  double k = TemperatureSensor.CelsiusToKelvin(sensor1.Temperature);

        public double GetKelvin()
        {
            Console.WriteLine($"[{Location}] temperature level in Kelvin: {CelsiusToKelvin(Temperature)}");
            return CelsiusToKelvin(Temperature);
        }




    }
}


