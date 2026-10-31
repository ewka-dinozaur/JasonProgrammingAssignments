using Newtonsoft.Json.Linq;
using SensorDemo;
using SensorDemo.Tests;

namespace SensorDemo.Tests
{
    public class SensorTests
    {

        //// SENSOR TESTS USING FACT ATTRIBUTE

        //[Fact]
        //public void SmokeLevel_Set7_StoresValue()
        //{

        //    // Arrange
        //    var sensor = new SmokeSensor("Kitchen");

        //    // Act
        //    sensor.SmokeLevel = 7;

        //    //Assert
        //    Assert.Equal(7, sensor.SmokeLevel);

        //}

        //[Fact]

        //public void SmokeLevel_Set11_ThrowsArgumentException()
        //{
        //    // Arrange
        //    var sensor = new SmokeSensor("LivingRoom");

        //    // Act and Assert using lambda expression to test for exception
        //    var ex =  Assert.Throws<ArgumentException>(() => sensor.SmokeLevel = 11);

        //    Assert.Contains("between 0 and 10", ex.Message );

        //}

        //[Fact]
        //public void Temperature_Set10_ThrowsArgumentException()
        //{

        //    // Arrange
        //    var sensor = new TemperatureSensor("Bathroom");

        //    // Act and Assert using lambda expression to test for exception
        //    var ex = Assert.Throws<ArgumentException>(() => sensor.Temperature = 10);

        //    Assert.Contains("between 15 and 30", ex.Message);

        //}

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


        // Equivalent test using Theory and InlineData attributes 

        // SMOKE SENSOR TESTS

        [Theory]
        [InlineData(0)]  // brzeg dolny
        [InlineData(5)]  // przedstawiciel klasy
        [InlineData(10)] // brzeg górny
        public void SmokeLevel_ValidValue_StoresValue(int value)
        {

            // Arrange
            var sensor = new SmokeSensor("garage", new ConsoleAlertChannel());

            // Act
            sensor.SmokeLevel = value;

            // Assert
            Assert.Equal(value, sensor.SmokeLevel);

        }

        [Theory]
        [InlineData(-1)] // brzeg dolny
        [InlineData(11)] // brzeg gorny
        [InlineData(-5)] // przed wartosci ponizej zakresu
        [InlineData(15)] // przed wartosci powyzej zakresu
        public void SmokeLevel_InvalidValue_ThrowsArgumentException(int value)
        {

            // Arrange
            var sensor = new SmokeSensor("basement", new ConsoleAlertChannel());

            // Act and Assert using lambda expression to test for exception
            var ex = Assert.Throws<ArgumentException>(() => sensor.SmokeLevel = value);

            Assert.Contains("between 0 and 10", ex.Message);

        }

        // TEMPERATURE SENSOR TESTS

        [Theory]
        [InlineData(15)] // brzeg dolny
        [InlineData(20)] // przedstawiciel klasy
        [InlineData(30)] // brzeg górny
        public void Temperature_ValidValue_StoresValue(int value)
        {

            // Arrange
            var sensor = new TemperatureSensor("bedroom");

            // Act
            sensor.Temperature = value;

            // Assert
            Assert.Equal(value, sensor.Temperature);

        }


        [Theory]
        [InlineData(14)] // brzeg dolny
        [InlineData(31)] // brzeg gorny
        [InlineData(10)] // przedstawiciel wartości poniżej zakresu
        [InlineData(40)] // przedstawiciel wartości powyżej zakresu
        public void Temperature_InvalidValue_ThrowsArgumentException(int value)
        {

            // Arrange
            var sensor = new TemperatureSensor("toilet");

            // Act and Assert using lambda expression to test for exception
            var ex = Assert.Throws<ArgumentException>(() => sensor.Temperature = value);

            Assert.Contains("between 15 and 30", ex.Message);

        }

        // MOCKING using spy test with fake alert channel to verify that SendAlert is called when SmokeLevel exceeds threshold

        [Fact]
        public void SmokeLevel_AboveThreshold_SendsAlert()
        {
            // Arrange
            var fake = new FakeAlertChannel();
            var sensor = new SmokeSensor("Kitchen", fake);

            // Act
            sensor.SmokeLevel = 8;

            // Assert
            Assert.Single(fake.Messages); // Verify that one alert message was sent - that there is one element in Messages list
            Assert.Contains("8", fake.Messages[0]); // verified that the alert message contains the expected smoke level value
        }


        [Fact]
        public void SmokeLevel_BelowThreshold_SendsNoAlert()
        {
            // Arrange
            var fake = new FakeAlertChannel();
            var sensor = new SmokeSensor("Kitchen", fake);

            // Act
            sensor.SmokeLevel = 3;

            // Assert
            Assert.Empty(fake.Messages); // Verify that the list of alert messages is empty - that no alert message was sent

        }

        [Theory]
        [InlineData(6, 0)] // below threshold, no alert
        [InlineData(7, 1)] // at threshold, one alert
        public void SmokeLevel_AtThreshold_SendsExpectedAlerts(int value, int expectedCount)
        {

            // Arrange
            var fake = new FakeAlertChannel();
            var sensor = new SmokeSensor("toilet", fake);

            // Act and Assert using lambda expression to test for exception
            sensor.SmokeLevel = value;

            // Assert
            Assert.Equal(expectedCount, fake.Messages.Count);

        }
    }
}







