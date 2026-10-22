using System.Text.RegularExpressions;

bool isAllDigits = Regex.IsMatch("12345", @"^\d+$"); 
Console.WriteLine(isAllDigits); // True

bool isAllDigits2 = Regex.IsMatch("123a5", @"^\d+$");
Console.WriteLine(isAllDigits2); // False - bo jest litera "a"


bool isValidAccount = Regex.IsMatch("PL123456", @"^PL\d{6}$");
Console.WriteLine(isValidAccount); // True

bool isValidAccount2 = Regex.IsMatch("PL12345", @"^PL\d{6}$"); // tylko 5 cyfr
Console.WriteLine(isValidAccount2); // False

string result = Regex.Replace("Cola (mediun)", "mediun", "medium");
Console.WriteLine(result); // "Cola (medium)" - naprawia Twoją literówkę z Menu!

// Zadanie 1 sprawdz haslo
bool PasswordCorrect = Regex.IsMatch("12345ewalas34", @"\d{5}");
Console.WriteLine(PasswordCorrect);

bool PasswordCorrect2 = Regex.IsMatch("hello123world", @"\d{5}");
Console.WriteLine(PasswordCorrect2);

// Zadanie 2: Wyodrębnianie numeru konta z Twojego Banku
Match m = Regex.Match("PL123456", @"\d+");
Console.WriteLine(m.Value); // powinno wypisać "123456", bez "PL"