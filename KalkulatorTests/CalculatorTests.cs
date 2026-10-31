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
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            // Arrange - tworzy nowa instancje klasy Calculator
            var calc = new Calculator();

            // Act - wywołuje metodę Sub 
            double result = calc.Sub(2, 3);

            // Assert - sprawdza, czy wynik jest równy oczekiwanej sumie
            Assert.Equal(-1, result);
        }


        [Fact]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            // Arrange - tworzy nowa instancje klasy Calculator
            var calc = new Calculator();

            // Act - wywołuje metodę Mul
            double result = calc.Mul(2, 3);

            // Assert - sprawdza, czy wynik jest równy oczekiwanej sumie
            Assert.Equal(6, result);
        }


        [Fact]
        public void Multiply_ByZero_Multiply_ByZero_ReturnsZero()
        {
            // Arrange - tworzy nowa instancje klasy Calculator
            var calc = new Calculator();

            // Act - wywołuje metodę Add z dwoma liczbami dodatnimi
            double result = calc.Mul(0, 3);

            // Assert - sprawdza, czy wynik jest równy oczekiwanej sumie
            Assert.Equal(0, result);
        }


        // Division tests - regular unit test and exception test

        [Fact]
        public void Div_TwoNumbers_ReturnsQuotient()
        {
            // Arrange - tworzy nowa instancje klasy Calculator
            var calc = new Calculator();

            // Act - wywołuje metodę Div z dwoma liczbami dodatnimi
            double result = calc.Div(6, 3);

            // Assert - sprawdza, czy wynik jest równy oczekiwanemu ilorazowi
            Assert.Equal(2, result);
        }

        [Fact]

        public void Div_ByZero_ThrowsDivideByZeroException()
        {

            //Arrange - tworzy nowa instancje klasy Calculator
            var calc = new Calculator();

            //Act & Assert - sprawdza, czy metoda Div rzuca wyjątek DivideByZeroException - w przypadku Throws act and assert sa razem bo potrzebna jest funkcja lambda
            var ex = Assert.Throws<DivideByZeroException>(() => calc.Div(5, 0)); // ()=>calc.Div(5, 0) - to wyrazenie lambda typu Action bo nie ma parametrow (puste nawiasy po lewej) a po prawej wywolanie metody Div z argumentami 5 i 0. 

            // Check message of exception
            Assert.Contains("zero", ex.Message);


        }

    }
}