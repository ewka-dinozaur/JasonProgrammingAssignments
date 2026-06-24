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
