using Generics;

Pair<int> numbers = new Pair<int>(5, 10);
numbers.Swap();
Console.WriteLine($"{numbers.First}, {numbers.Second}"); // 10, 5

Pair<string> words = new Pair<string>("cat", "dog");
words.Swap();
Console.WriteLine($"{words.First}, {words.Second}"); // dog, cat


StringContainer container = new StringContainer();
container.Add("hello");
container.Add("Ewa");
Console.WriteLine(container.GetAt(1));

Container<int> digits = new Container<int>();
digits.Add(1);
digits.Add(2);
digits.Add(3);
digits.PrintAll();

Container<string> text = new Container<string>();
text.Add("Ewa");
text.Add("jest");
text.Add("piekna");
text.PrintAll();

Container2<int> cyfry  = new Container2<int>();
for (int i = 1; i <= 4; i++)
{
    cyfry.Add(i);
    Console.WriteLine($"Dodano: {i}, Count: {cyfry.Count}");
}

