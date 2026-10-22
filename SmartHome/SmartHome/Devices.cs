using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome
{
    internal class SmartLight : SmartDevice, IDimmable, IPowerConsuming
    {

        public int Brightnesss { get; set; }


        // public void SetBrightness(int value);

        private int _brightnes = 0; // default brightness


        // konstruktor klasy SmartLight, wywołuje konstruktor klasy bazowej SmartDevice
        // Overload  Wariant 1: pełna kontrola - podajesz nazwę i jasność - overload na konstruktorze
        public SmartLight(string name, int brightnes, ILogger logger) : base(name, logger)
        {
            Brightness = brightnes;
        }

        // Wariant 2 (OVERLOAD): tylko nazwa, jasność domyślna 50% -overload na konstruktorze 
        public SmartLight(string name, ILogger logger) : base(name, logger)
        {
            Brightness = 50;
        }

        // Wariant 3 (OVERLOAD):  overload na metodzie wersja normalna - przypisuje wartosc do settera
        public void SetBrightness(int value)
        {
            Brightness = value;  // <- to WOŁA property/setter, który już masz!
            Console.WriteLine($"{DeviceName} brightness set to {value}%");
        }

        // OVERLOAD na metodzie SetBrightness - przyjmuje string as input 
        public void SetBrightness(string level)
        {
            int value = level switch
            {
                "low" => 20,
                "medium" => 50,
                "high" => 100,
                _ => throw new ArgumentException("Unknown level")
            };
            SetBrightness(value);  // wywołuje wariant z int
        }
        public int Brightness
        {
            get { return _brightnes; }

            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Brightness must be between 0 and 100");
                else
                    _brightnes = value;
            }
        }
        public override void TurnOn()
        {
            _logger.Log($"SmartLight is on, brightness:  {Brightness}%");
            isOn = true;
        }

        public double WattsUsed => Brightness * 0.6; // np. proporcjonalnie do jasności
    }


    internal class SmartThermostat : SmartDevice, IPowerConsuming
    {

        private double _targetTemperature;
        public double WattsUsed => 15.0; // stałe zużycie
                                         
        // konstruktor klasy SmartThermostat, wywołuje konstruktor klasy bazowej SmartDevice
        public SmartThermostat(string name, double temperature, ILogger logger) : base(name, logger)
        {
            TargetTemperature = temperature;
        }

        public double TargetTemperature
        {
            get { return _targetTemperature; }

            set
            {
                if (value < 0)
                    throw new ArgumentException("Target temperature has to be positive");
                else
                    _targetTemperature = value;
            }
        }
        public override void TurnOn()
        {
            _logger.Log($"Thermostat is on, tmeperature:   {TargetTemperature}%");
            isOn = true;
        }

    }


    internal class SmartLock : SmartDevice, ILockable
    {

        private bool _isLocked; // backing field — realne miejsce w pamięci
        public bool IsLocked
        {

            get { return _isLocked; }
            set
            {
                if (!isOn)
                {
                    Console.WriteLine("Cannot change lock state while device is off");
                    return; // ignorujemy próbę zmiany, _isLocked zostaje bez zmian
                }
                _isLocked = value;
                Console.WriteLine($"Lock state changed to: {_isLocked}");
            }
        }


        // konstruktor klasy SmartLock, wywołuje konstruktor klasy bazowej SmartDevice
        public SmartLock(string name, ILogger logger) : base(name, logger)
        {
        }

        public bool Lock()
        {
            return IsLocked = true;
        }
        public bool Unlock()
        {
            return IsLocked = false;
        }

        public override void TurnOn()
        {
            _logger.Log($"Lock is On {IsLocked}");
            isOn = true;
        }

    }

    internal class SmartBlinds : SmartDevice, IDimmable, IPowerConsuming

    {

        private int _openness = 0; // % otwarcia, 0 = zamknięte, 100 = całkowicie otwarte

        public SmartBlinds(string name, ILogger logger) : base(name, logger) // konstruktor
        {
        }

        public int Brightness // nazwa z interfejsu, tu reprezentuje % otwarcia
        {
            get { return _openness; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Openness must be between 0 and 100");
                _openness = value;
            }
        }

        public void SetBrightness(int value)
        {
            Brightness = value;
            Console.WriteLine($"{DeviceName} openness set to {value}%");
        }

        public override void TurnOn()
        {
            _logger.Log($"{DeviceName} blinds motor is on, openness: {Brightness}%");
            isOn = true;
        }

        public double WattsUsed => 5.0; // stałe zużycie

    }

}