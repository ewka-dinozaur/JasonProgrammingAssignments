using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Generics
{
    internal class Pair<T> // definiuje klase z type generic
    {
        public T First { get; set; }
        public T Second { get; set; }

        public Pair(T first, T second) // kosntruktor
        {
            First = first;
            Second = second;
        }

        public void Swap() // metoda generyczna operujaca na dowolnym typie
        {
            T temp = First;
            First = Second;
            Second = temp;
        }
    }

    class StringContainer
    {
        private List<string> _items = new List<string>();

        public void Add(string item)
        {
            _items.Add(item);
        }

        public string GetAt(int index)
        {
            return _items[index];
        }

        public void PrintAll()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(GetAt(i));
            }
        }
        public int Count => _items.Count;
    }

    class Container<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public T GetAt(int index)
        {
            
            return _items[index];
        }

        public void PrintAll()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(GetAt(i));
            }
        }
        public int Count => _items.Count;
    }


    // Sesja 3 Mechanika klasy

    class Container2<T>
    {

        private T[] _elements = new T[3]; // stworz zmienna typu pusta tablica i daj jej wstepna liczbe elementow
        private int _count = 0;             // zapoczatkuj licznik


        public void Add(T item)
        {
            if (_count == _elements.Length) // sprawdz czy obecny numer indeksu osiagnal dlugosc listy
            {
                Resize(); // jesli tak zmien rozmiar listy
            }
            _elements[_count] = item; // wrzuc item na indeks z numerem _count
            _count++; // zwieksz _count o 1
        }

        private void Resize()
        {
            Console.WriteLine($">>> RESIZE! Stara pojemność: {_elements.Length}, nowa: {_elements.Length * 2}");
            T[] newArray = new T[_elements.Length * 2];

            for (int i = 0; i < _elements.Length; i++)
                newArray[i] = _elements[i];
            _elements = newArray;

        }
        public int Count => _count;

    }



}
