using System;
using System.Collections.Generic;


namespace SmartHome
{

    abstract class SmartDevice
    {
        // Pola klasy - zmienne prywatne i chronione
        private string deviceName;
        protected bool isOn;
        public static int TotalDevicesCreated = 0; // pole statyczne do zliczania utworzonych urządzeń jedno na klase zeby zliczac wszystkie urzadzenia - public zbey byl dostep z main
        protected readonly ILogger _logger; // zależność

        public string DeviceName // property publiczne z walidacją
        {
            get { return deviceName; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                else
                    deviceName = value;
            }
        }

        // Konstruktor
        public SmartDevice(string name, ILogger logger) // <- dodany parametr

        {
            DeviceName = name; // wywolaj setter property DeviceName zeby sprawdzic walidacje
            isOn = false; // domyślnie urządzenie jest wyłączone
            TotalDevicesCreated++; // dodaje 1 do licznika przy tworzeniu nowego urządzenia czyli przy wywołaniu konstruktora
            _logger = logger; // wstrzykniecie interfejs
        }

        public abstract void TurnOn(); // Metoda abstrakcyjna do włączania urządzenia

        public void PrintStatus()  // normalna metoda, może mieć implementację
        {
            _logger.Log($"DeviceName: {DeviceName} is on: {isOn}");
        }

        // Downcasting example : Napisz metodę, która przechodzi przez listę urządzeń i przyciemnia wszystkie światła o 20%, ignorując inne typy urządzeń:
        public static void DimAllLights(List<SmartDevice> devices)
        {
            foreach (SmartDevice d in devices)
            {
                if (d is IDimmable dimmable)  // pattern matching: sprawdza typ I rzutuje w jednej linii
                {
                    dimmable.SetBrightness(25);
                    Console.WriteLine($"{d.DeviceName} dimmed to {dimmable.Brightness}%");
                }
                // SmartThermostat i SmartLock są po prostu pomijane - if się nie wykonuje
            }
        }

        // generics
        public static T FindHighestPowerConsumer<T>(List<T> devices) where T : SmartDevice, IPowerConsuming
        {
            T highest = devices[0];
            foreach (var device in devices)
                if (device.WattsUsed > highest.WattsUsed)
                    highest = device;
            return highest;
        }

        public static double TotalPowerConsumption<T>(List<T> devices) where T : IPowerConsuming
        {
            double total = 0;
            for (int i = 0; i < devices.Count; i++)
                total += devices[i].WattsUsed;
            Console.WriteLine($"The total power consumption is {total}");
            return total;

        }

        // genercis IEnumerable - out uzyj szczegolu w ogole
        public static void PrintAllNames(IEnumerable<SmartDevice> devices)
        {
            foreach (var d in devices)
                Console.WriteLine(d.DeviceName);
        }

        // Generics Action - in: uzyj ogolu do szczegolu
        public static Action<SmartDevice> turnOnAndPrint = (device) =>
        {
            device.TurnOn();
            device.PrintStatus();
        };



    }
}
