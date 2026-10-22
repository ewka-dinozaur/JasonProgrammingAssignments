using SmartHome;

ILogger logger = new ConsoleLogger();

SmartLight kitchenLight = new SmartLight("Kitchen Light", 50, logger);
kitchenLight.TurnOn();
kitchenLight.PrintStatus();


List<SmartDevice> devices = new List<SmartDevice>();
devices.Add(new SmartLight("Kitchen Light", 50, logger)); // automatyczny upcasting bo Light jest tez SmartDevice 
devices.Add(new SmartThermostat("Living Room Thermostat", 21.5, logger));
SmartLock frontDoor = new SmartLock("Front Door", logger);

devices.Add(frontDoor);
devices.Add(new SmartLight("Hallway Light", logger));

SmartLight BedroomLight = new SmartLight("Bedroom Light", logger);
BedroomLight.SetBrightness("low");

devices.Add(BedroomLight);

// adding SmartBlinds which use IDimmable interface without being SmartLight
devices.Add(new SmartBlinds("Living Room Blinds", logger));



foreach (SmartDevice d in devices)
{
    d.TurnOn();
    d.PrintStatus();
}

Console.WriteLine($"Total devices: {SmartDevice.TotalDevicesCreated}");

frontDoor.Lock();

try
{
    var badLight = new SmartLight("", 50, logger);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Caught expected error: {ex.Message}");
}

SmartDevice.DimAllLights(devices);



// bad casting example:
SmartDevice someDevice = new SmartThermostat("Bedroom", 20, logger);
// To wybuchnie w runtime:
try
{
    SmartLight wrongCast = (SmartLight)someDevice;
}
catch (InvalidCastException ex)
{
    Console.WriteLine($"Cast failed as expected: {ex.Message}");
}


List<IPowerConsuming> powerConsumingDevices = new List<IPowerConsuming>();

foreach (SmartDevice d in devices)
{
    if (d is IPowerConsuming consuming)  // pattern matching - dokładnie jak w Twoim DimAllLights!
        powerConsumingDevices.Add(consuming);
}


SmartDevice.TotalPowerConsumption(powerConsumingDevices);


// IEnumerable


List<SmartLight> lights = new List<SmartLight>
{
    new SmartLight("Kitchen", 50, logger),
    new SmartLight("Bedroom", 30, logger)
};

SmartDevice.PrintAllNames(lights);

// Action
Action<SmartLight> turnOnLight =  SmartDevice.turnOnAndPrint; // czy to zadziała?
turnOnLight(new SmartLight("Hallway", 40, logger));