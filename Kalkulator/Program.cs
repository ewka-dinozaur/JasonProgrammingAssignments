using Kalkulator;

Console.WriteLine("Hello, I am your calculator");

Calculator calc = new Calculator();

Console.Write("Podaj pierwszą liczbę: ");
double a = double.Parse(Console.ReadLine());

Console.Write("Podaj drugą liczbę: ");
double b = double.Parse(Console.ReadLine());

Console.WriteLine("Wybierz operację: +, -, *, /");
string op = Console.ReadLine();

double result = 0;

switch (op)
{
    case "+":
        result = calc.Add(a, b);
        break;
    case "-":
        result = calc.Sub(a, b);
        break;
    case "*":
        result = calc.Mul(a, b);
        break;
    case "/":
        {
            try
            {
                result = calc.Div(a, b);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
        }
        break;


    default:
        Console.WriteLine("Nieznany operator.");
        break;
}

Console.WriteLine($"Wynik: {result}");


// MEMORY LEAK TEST

Calculator calc2 = new Calculator();

for (int i = 0; i < 10_000; i++)
{
    var c = new Calculation { A = i, B = 2, Op = "+", Result = calc2.Add(i, 2) }; // perform calculation and store result
    History.All.Add(c); // add to history to simulate memory leak
    if (History.All.Count > 10)
        History.All.RemoveAt(0); // remove oldest calculation to keep history size manageable

    if (i % 1000 == 0) // print memory usage every 1000 iterations
    {
        Console.WriteLine($"{i}: {GC.GetTotalMemory(true) / 1_000_000} MB"); // print memory usage in MB
        Console.WriteLine($"Generacja pierwszego obliczenia: {GC.GetGeneration(History.All[0])}");
        Console.WriteLine($"Sprzątania gen0: {GC.CollectionCount(0)}, gen1: {GC.CollectionCount(1)}, gen2: {GC.CollectionCount(2)}"); // how many time GC was cleaning each generation
        Console.ReadLine();
    }


}