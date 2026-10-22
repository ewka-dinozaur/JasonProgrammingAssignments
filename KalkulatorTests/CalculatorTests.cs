using Kalkulator;

namespace Kalkulator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_TwoPositiveNumbers_ReturnsSum()
        {
            // Arrange - tworzy nowa instancje klasy Calculator
            var calc = new Calculator();

            // Act - wywołuje metodę Add z dwoma liczbami dodatnimi
            double result = calc.Add(2, 3);

            // Assert - sprawdza, czy wynik jest równy oczekiwanej sumie
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_PositiveAndNegativeNumbers_ReturnsSum()
        {
            // Arrange - tworzy nowa instancje klasy Calculator
            var calc = new Calculator();

            // Act - wywołuje metodę Add z dwoma liczbami dodatnimi
            double result = calc.Add(4, -3);

            // Assert - sprawdza, czy wynik jest równy oczekiwanej sumie
            Assert.Equal(1, result);
        }

        [Fact]
        public void Subtract_TwoNumbers_ReturnsSubstraction()
        {
            // Arrange - tworzy nowa instancje klasy Calculator
            var calc = new Calculator();

            // Act - wywołuje metodę Add z dwoma liczbami dodatnimi
            double result = calc.Sub(2, 3);

            // Assert - sprawdza, czy wynik jest równy oczekiwanej sumie
            Assert.Equal(-1, result);
        }


        [Fact]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            // Arrange - tworzy nowa instancje klasy Calculator
            var calc = new Calculator();

            // Act - wywołuje metodę Add z dwoma liczbami dodatnimi
            double result = calc.Mul(2, 3);

            // Assert - sprawdza, czy wynik jest równy oczekiwanej sumie
            Assert.Equal(6, result);
        }


        [Fact]
        public void Multiply_ByZero_ReturnsProduct()
        {
            // Arrange - tworzy nowa instancje klasy Calculator
            var calc = new Calculator();

            // Act - wywołuje metodę Add z dwoma liczbami dodatnimi
            double result = calc.Mul(0, 3);

            // Assert - sprawdza, czy wynik jest równy oczekiwanej sumie
            Assert.Equal(0, result);
        }


    }
}