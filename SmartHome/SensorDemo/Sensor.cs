using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Channels;

namespace SensorDemo

{
    interface INotifiable
    {
        void SendAlert(string message);
    }

    public abstract class Sensor
    {

        protected string Location;
        public Sensor(string location)
        {
            Location = location;
        }
        public abstract void Measure();

    }


    // Class for SmokeSensor with appliec interface and abstract Measure method override 
    public class SmokeSensor : Sensor, INotifiable
    {
        private int _smokeLevel;
        private IAlertChannel _channel; // prywatne pole typu interface do wysylania alertow do roznych kanalow (Console, Email, SMS, itp.)



        // konstruktor
        public SmokeSensor(string location, IAlertChannel channel) : base(location)

        {
            _channel = channel;
        }

        public int SmokeLevel

        {
            get { return _smokeLevel; }

            set
            {
                if (value < 0 || value > 10)
                { 
                    throw new ArgumentException("Smoke level must be between 0 and 10 ");
                }

                else
                {
                    _smokeLevel = value;
                    if (_smokeLevel >= 7)
                    {
                        SendAlert($"High smoke level: {value}");
                    }
                 
                }
              
            }
        }

        public void SendAlert(string message)
        {
            // Console.WriteLine($"  >> ALERT from {Location}: {message}"); // original hard coded alert message to console
            _channel.Send($"from {Location}: {message}");
        }

        public override void Measure()
        {
            Console.WriteLine($"[{Location}] Detected smoke level: {SmokeLevel}");
        }
    }





    // Class for TemperatureSensore with abstract Measure method override but without interface
    public class TemperatureSensor : Sensor
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


