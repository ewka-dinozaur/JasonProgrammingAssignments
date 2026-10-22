using SensorDemo;

List<Sensor> sensors = new List<Sensor>();
sensors.Add(new SmokeSensor("LivingRoom") { SmokeLevel = 7 });
sensors.Add(new TemperatureSensor("Bedroom") { Temperature = 22 });

foreach (Sensor s in sensors)
{
    s.Measure();

    if (s is INotifiable notifiable)
        notifiable.SendAlert("Fire detected!");

}

TemperatureSensor kitchen_sensor = new TemperatureSensor("kitchen") { Temperature=20};
TemperatureSensor bedroom_sensor = new TemperatureSensor("bedroom") { Temperature = 25 };
TemperatureSensor bathroom_sensor = new TemperatureSensor("bathroom") { Temperature = 30 };

kitchen_sensor.GetKelvin();
bedroom_sensor.GetKelvin();
bathroom_sensor.GetKelvin();
