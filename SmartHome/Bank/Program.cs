using Bank;

ILogger logger = new ConsoleLogger();

List<BankAccount> accounts = new List<BankAccount>();

SavingAccount savings = new SavingAccount("PL001", 1000, 30, 3, logger);
CheckingAccount checking = new CheckingAccount("PL002", 500, 200, logger);
FixedDepositAccount deposit = new FixedDepositAccount("PL003", 8000, 7, 12, logger);

accounts.Add(savings);
accounts.Add(checking);
accounts.Add(deposit);


savings.Status();


// polimorfizm - odsetki dla każdego konta, każde liczy inaczej
foreach (BankAccount acc in accounts)
{
    Console.WriteLine($"{acc.AccountNumber} interest: {acc.CalculateInterest()}");
}

// Deposit/Withdraw - zwykłe operacje
savings.Deposit(200);
savings.Withdraw(50);

checking.Deposit(10);
checking.Withdraw(600); // powinno zadziałać - w debecie

//deposit.Withdraw(100); // powinno wyrzucić błąd - zablokowane do daty

// ITransferable - przelew między kontami
bool success = savings.TransferTo(checking, 100);
Console.WriteLine($"Transfer success: {success}");

// downcasting przez interfejs - kto może przelewać
foreach (BankAccount acc in accounts)
{
    if (acc is ITransferable)
        Console.WriteLine($"{acc.AccountNumber} can transfer money");
    else
        Console.WriteLine($"{acc.AccountNumber} cannot transfer money");
}

// walidacja
try { savings.Withdraw(-50); }
catch (ArgumentException ex) { Console.WriteLine($"Caught: {ex.Message}"); }

try { savings.Withdraw(10000); } // przekracza limit
catch (ArgumentException ex) { Console.WriteLine($"Caught: {ex.Message}"); }


// Genercs 
AccountManager<SavingAccount> savingsManager = new AccountManager<SavingAccount>();
savingsManager.Add(new SavingAccount("PL001", 1000, 20, 3, logger));
savingsManager.Add(new SavingAccount("PL002", 5000, 30, 4, logger));

SavingAccount best = savingsManager.FindHighestInterest();
Console.WriteLine($"Najlepsze konto: {best.AccountNumber}, Limit: {best.Limit}");

// Generics covariance
List<CheckingAccount> checkingAccounts= new List<CheckingAccount>
{
    new CheckingAccount("PL001",1000,300,logger),
    new CheckingAccount("PL002", 500, 600, logger),
    new CheckingAccount("PL002", 5000, 10000, logger)

};

BankAccount.SumaSald(checkingAccounts);

