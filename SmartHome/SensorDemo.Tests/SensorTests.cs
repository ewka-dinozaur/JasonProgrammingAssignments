namespace SensorDemo.Tests
{
    public class SensorTests
    {
        [Fact]
        public void SmokeLevel_Set7_StoresValue()
        {

            // Arrange
            var sensor = new SmokeSensor("Kitchen");

            // Act
            sensor.SmokeLevel = 7;

            //Assert
            Assert.Equal(7, sensor.SmokeLevel);

        }

        [Fact]

        public void SmokeLevel_Set11_ThrowsArgumentException()
        {
            // Arrange
            var sensor = new SmokeSensor("LivingRoom");

            // Act and Assert using lambda expression to test for exception
            var ex =  Assert.Throws<ArgumentException>(() => sensor.SmokeLevel = 11);

            Assert.Contains("between 0 and 10", ex.Message );

        }

        [Fact]
        public void Temperature_Set10_ThrowsArgumentException()
        {

            // Arrange
            var sensor = new TemperatureSensor("Bathroom");

            // Act and Assert using lambda expression to test for exception
            var ex = Assert.Throws<ArgumentException>(() => sensor.Temperature = 10);

            Assert.Contains("between 15 and 30", ex.Message);

        }

        [Fact]

        public void CelsiusToKelvin_Zero_Returns273_15()
        {

            // Arrange – no object needed, static method
            double celsius = 0;

            // Act
            var result = TemperatureSensor.CelsiusToKelvin(celsius);

            // Assert 
            Assert.Equal(273.15, result);

        }
    }
}

