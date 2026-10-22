using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Bank
{
    public interface ILogger
    {
        public void Log(string message);
    }


    internal interface ITransferable
    {
        bool TransferTo(BankAccount target, double amount);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }


    internal abstract class BankAccount 
    {
        public string AccountNumber { get; set; } // walidacja: nie puste
        protected readonly ILogger _logger; // 

        private double _balance;
        public double Balance
        {
            get { return _balance; }
            protected set { _balance = value; } // private set - tylko klasa sama może zmieniać
        }

        public BankAccount(string accountNumber, double initialBalance, ILogger logger)
        {
            AccountNumber = accountNumber;
            _balance = initialBalance; // bezpośrednio do pola, bo setter jest private i konstruktor jest "wewnątrz" klasy więc może
            _logger = logger;
        }

        public abstract double CalculateInterest();

        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");
            _balance += amount;
            _logger.Log($"Deposited {amount}. New balance: {_balance}");
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");
            if (amount > _balance)
                throw new ArgumentException("Insufficient funds");
            _balance -= amount;
           _logger.Log($"Withdrew {amount}. New balance: {_balance}");
        }

        public virtual void Status()
        {
            _logger.Log($"Current Account balance: {Balance}");
        }

        public static void SumaSald (IEnumerable<BankAccount> konta)
        {
            double total = 0;
            foreach (var k in konta)
                total = total + k.Balance;
            Console.WriteLine($"Calkowite saldo  {total}");
        }



    }

    internal class SavingAccount : BankAccount, ITransferable
    {

        private double _interest;
        public double Interest
        {
            get { return _interest; }
            private set {
                if (value <= 0) 
                    throw new ArgumentException("Interest cannot be negative");
                else 
                    _interest= value; } 
        }

        private double _limit;

        
        public double Limit
        {
            get { return _limit; }
            private set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("You can only set the limit as percentage of the balance");
                else
                    _limit = value;
            } 
        }

        public SavingAccount(string accountNumber, double initialBalance, double limit, double interest, ILogger logger): base( accountNumber, initialBalance, logger)
        {
            Interest = interest/100;
            Limit = limit/100;
        }

        public override double CalculateInterest()
        {
            double interest_monthly = Balance * Interest;
            return interest_monthly;
        }

        public override void Withdraw(double amount)
        {
            
            
            if (amount <= 0)
                    throw new ArgumentException("Withdrawal amount must be positive");
            if (amount >  Balance * Limit)
                throw new ArgumentException("The amount is over allowed limit. Change limits or adjust amount.");
            else 
                Balance -= amount;
            _logger.Log($"Withdrew {amount}. New balance: {Balance}");
        }


        public bool TransferTo(BankAccount target, double amount)
        {
              try
              {
                  Withdraw(amount);   // wypłać z siebie - użyje TWOJEGO override z limitem
                  target.Deposit(amount); // wpłać na docelowe konto
                  _logger.Log($"Transferred {amount} to {target.AccountNumber}");
                  return true;
              }
              catch (ArgumentException ex)
              {
                _logger.Log($"Transfer failed: {ex.Message}");
                 return false;
              }
            }
        }


    internal class CheckingAccount : BankAccount, ITransferable
    {

        public double Debet { get; set; }


        public CheckingAccount(string accountNumber, double initialBalance, double debet, ILogger logger) : base(accountNumber, initialBalance, logger)
        {
            Debet = debet;
        }

        public override double CalculateInterest()
        {
            double interest_monthly  = Balance * 0.005; // rigid low interest for this type of account
            return interest_monthly;
        }

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");
            if (amount > Balance + Debet)
                throw new ArgumentException("You cannot withdraw more then you debet limit: 50% of your current balance.");
            Balance -= amount;
            _logger.Log($"Withdrew {amount}. New balance: {Balance}");
        }


        public bool TransferTo(BankAccount target, double amount)
        {
            try
            {
                Withdraw(amount);   // wypłać z siebie - użyje TWOJEGO override z limitem
                target.Deposit(amount); // wpłać na docelowe konto
                _logger.Log($"Transferred {amount} to {target.AccountNumber}");
                return true;
            }
            catch (ArgumentException ex)
            {
                _logger.Log($"Transfer failed: {ex.Message}");
                return false;
            }
        }

    }

    internal class FixedDepositAccount : BankAccount
    {

        public DateTime UnlockDate { get; set; }
        public double Interest { get; set; }

        public FixedDepositAccount(string accountNumber, double initialBalance, double interest, int monthsLocked , ILogger logger)
            : base(accountNumber, initialBalance, logger)
        {
            UnlockDate = DateTime.UtcNow.AddMonths(monthsLocked); // np. za 12 miesięcy
            Interest = interest;
        }


        public override double CalculateInterest()
        {
            double interest_monthly = Balance * Interest; // rigid low interest for this type of account
            return interest_monthly;
        }

        public override void Withdraw(double amount)
        {
            if (DateTime.Now < UnlockDate)
                throw new ArgumentException("Cannot withdraw before unlock date");
            base.Withdraw(amount); // jeśli data minęła, użyj normalnej logiki z BankAccount
        }

    }


}
