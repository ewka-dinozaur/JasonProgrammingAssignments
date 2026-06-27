using Queue;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        MyQueue queue = new MyQueue();

        while (true)
        {
            Console.Write("Podaj liczbę do dodania (lub 'stop'): ");
            string input = Console.ReadLine();

            if (input == "stop")
                break;

            if (int.TryParse(input, out int value))
            {
                queue.Enqueue(value);
                Console.WriteLine("Dodano!");
            }
            else
            {
                Console.WriteLine("To nie jest liczba.");
            }
        }

        Console.WriteLine("Kolejka przed usunięciem:");
        queue.Print();

        Console.Write("Czy chcesz usunąć pierwszy element? y/n: ");
        string input2 = Console.ReadLine();

        if (input2 == "y")
        {
            int removed = queue.Dequeue();
            Console.WriteLine($"Usunięto element: {removed}");
        }

        Console.WriteLine("Kolejka po usunięciu:");
        queue.Print();
    }
}

//class Program
//{
//    public static void Main(string[] args)
//    {

//        LinkedList list = new LinkedList();


//        while (true) // petla nieskonczona bo warunek true jest zawsze prawdziwy! wyjdzie z petli tylko poprzez break 
//        {
//            Console.Write("Podaj liczbę do dodania (lub 'stop'): ");
//            string input = Console.ReadLine();

//            if (input == "stop")
//                break;

//            if (int.TryParse(input, out int value)) // oznacza,ze wez input i sprobuj z niego zrobic output jako zmienna value typu integer i wyjdz a jesli sie nie uda to daj informacje na konsole
//            {
//                list.Add(value);
//                Console.WriteLine("Dodano!");
//            }
//            else
//            {
//                Console.WriteLine("To nie jest liczba.");
//            }
//        }

//        Console.WriteLine("Lista przed usunięciem:");
//        list.Print();

//        Console.Write("Czy chcesz usunac element: y/n?");
//        string input2 = Console.ReadLine();

//        if (input2 == "y")
//        { 
//        int removed = list.RemoveFirst();
//        Console.WriteLine($"Usunieto element: {removed}");


//        Console.WriteLine("Lista po usunięciu:");
//         list.Print();

//        }
//    }
//}



