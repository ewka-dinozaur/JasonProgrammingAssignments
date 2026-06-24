using BinarySearchTreeEx;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Tworzymy drzewo
        BinarySearchTree bst = new BinarySearchTree();

        // Dodajemy wartości
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);
        bst.Insert(7);
        bst.Insert(3);

        // Sprawdzamy Contains
        Console.WriteLine("Czy 7 istnieje? " + bst.Contains(7));   // true
        Console.WriteLine("Czy 15 istnieje? " + bst.Contains(15)); // true
        Console.WriteLine("Czy 100 istnieje? " + bst.Contains(100)); // false

        Console.WriteLine("Koniec testu.");
    }
}
