using Bank;
using System.Security.Principal;

namespace Bank.Tests
{
    public class BankTests
    {

        [Fact]
        public void Deposit_ValidAmount_IncreasesBalance()
        {
            // Arrange
            var fake = new FakeLogger();
            var account = new SavingAccount("PL1001", 1000, 30, 2, fake);

            // Act
            account.Deposit(200);

            // Assert
            Assert.Equal(1200, account.Balance);
        }

        [Fact]
        public void Deposit_ValidAmount_LogsNewBalance()
        {
            // Arrange
            var fake = new FakeLogger();
            var account = new SavingAccount("PL1001", 1000, 30, 2, fake);
            int expectedCount = 1;


            // Act
            account.Deposit(200);

            // Assert
            Assert.Equal(expectedCount, fake.Messages.Count);
            Assert.Contains("1200", fake.Messages[0]);
          
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-50)]

        public void Deposit_InvalidAmount_ThrowsAndLogsNothing(double value)
        {
            // Arrange
            var fake = new FakeLogger();
            var account = new SavingAccount("PL1001", 1000, 30, 2, fake);


            // Act and Assert using lambda expression to test for exception
            Assert.Throws<ArgumentException>(() => account.Deposit(value));
            Assert.Empty(fake.Messages);
        }


        // Saving Account tests


        // Interest
        // test :  wartość ujemna rzuca wyjątek;
        [Fact]
        public void Interest_InvalidAmount_ThrowsArgumentExceptionAndLogsNothing()
        {
            // Arrange
            var fake = new FakeLogger();


            // Act and Assert using lambda expression to test for exception
            var ex =  Assert.Throws<ArgumentException>(() =>   new SavingAccount("PL1001", 1000, 30, -0.1, fake));
            Assert.Empty(fake.Messages);
            Assert.Contains("negative", ex.Message);
        }


        // test :  0 jest dozwolone;
        [Fact]
        public void Interest_ValidZero_InterestEqualZero()
        {
            // Arrange
            var fake = new FakeLogger();
            var account = new SavingAccount("PL1001", 1000, 30, 0, fake);

            // Act
            var interest = account.Interest;

            // Assert 
            Assert.Equal(0,interest);
 
        }

        // Limit
        // test :  wartości z zakresu są dozwolone;
        [Theory]
        [InlineData(0)]
        [InlineData(30)]
        [InlineData(100)]
        public void Limit_LimitedAllowed_ReturnsLimit(double value)
        {
            // Arrange
            var fake = new FakeLogger();
            var account = new SavingAccount("PL1001", 1000, value, 1, fake);

            // Act
            var limit = account.Limit;

            // Assert 
            Assert.Equal(value, limit); 

        }

        // test :  wartosci spoza zakresu daja wyjatek;
        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        [InlineData(150)]
        public void Limit_LimitedOutOfRange_ArgumentException(double value)
        {
            // Arrange
            var fake = new FakeLogger();

            // Act and Assert using lambda expression to test for exception
            var ex = Assert.Throws<ArgumentException>(() => new SavingAccount("PL1001", 1000, value, 1, fake)); // the limit is set as percentage of the balance, so 30% = 0.3
            Assert.Empty(fake.Messages);
            Assert.Contains("limit as percentage of the balance", ex.Message);
        }

        // Withdraw
        // test :  dokładnie na limicie przechodzi, odrobinę ponad
        [Theory]
        [InlineData(50)]  // przedstawiciel klasy
        [InlineData(100)] // wartość dokładnie na limicie
        public void Withdraw_AmountAllowed_ChecksAndLogsBalance(double value)
        {
            // Arrange
            var fake = new FakeLogger();
            var account = new SavingAccount("PL1001", 1000, 10, 1, fake);

            // Act
            account.Withdraw(value); // metoda void wiec nie ma zmiennej do sprawdzenia, ale logi powinny zawierać nowy stan konta

            // Assert 
            Assert.Equal(1000-value, account.Balance); // porownaj balance minus withdrawn amount do Balansu na koncie

        }

        // test :  wartosci spoza zakresu daja wyjatek;
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(100.01)]
        public void Withdraw_AmountNotAllowed_ThrowsNoLogs(double value)
        {
            // Arrange
            var fake = new FakeLogger();
            var account = new SavingAccount("PL1001", 1000, 10, 1, fake);

            // Act and Assert using lambda expression to test for exception
            var ex = Assert.Throws<ArgumentException>(() => account.Withdraw(value) ); // the limit is set as percentage of the balance, so 30% = 0.3
            Assert.Empty(fake.Messages);

        }

        // CalculateInterest
        // test :  oblicza odsetki;
        [Fact]
        public void CalculateInterest_ValidInterest_ReturnsMonthlyInterest()
        {
            // Arrange
            var fake = new FakeLogger();
            var account = new SavingAccount("PL1001", 1000, 10, 1, fake);

            // Act and Assert using lambda expression to test for exception
            Assert.Equal(10, account.CalculateInterest());

        }

        // Fixed account tests

        [Fact]
        public void Withdraw_BeforeUnlockDate_ThrowsArgumentException()
        {
            // Arrange
            var clock = new FakeClock();
            clock.UtcNow = new DateTime(2026, 1, 1);                       // "teraz" przy zakładaniu konta
            var account = new FixedDepositAccount("PL003", 8000, 7, clock, 12, new FakeLogger());
            clock.UtcNow = account.UnlockDate.AddSeconds(-1);              // przesuń czas: sekunda przed odblokowaniem

            // Act + Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(100));
        }

        [Fact]
        public void Withdraw_AtUnlockDate_DecreasesBalance()
        {
            // Arrange
            var clock = new FakeClock();
            clock.UtcNow = new DateTime(2026, 1, 1);                       // "teraz" przy zakładaniu konta
            var account = new FixedDepositAccount("PL003", 8000, 7, clock, 12, new FakeLogger());
            clock.UtcNow = account.UnlockDate;              // przesuń czas: w czasie odblokowania

            // Act
            account.Withdraw(100);

            // Assert
            Assert.Equal(7900, account.Balance);
        }
    }
}





