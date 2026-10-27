using Exceptions;

class Program
{
    static void Main()
    {
        var report = new Report();

        Console.WriteLine("Main: start");

        double avg = report.Average(10, 0);
        Console.WriteLine("Main: średnia = " + avg);

        Console.WriteLine("Main: koniec");
    }
}
