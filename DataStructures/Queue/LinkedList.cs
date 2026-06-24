
using System.ComponentModel;

class Node
{
    public int Value;
    public Node? Next; // because Next is of type Node it means it contains the reference (pointer) to another type of Node
}

class LinkedList
{
    // obiekty listy nody pierwszy if ostatni
    // nodes are prviate because there is no need for a user to know how the list works
    private Node? head;
    private Node? tail; 

    // methods of the LiknkedList class
    public void Add(int value)
    {
        Node newNode = new Node { Value = value };
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail!.Next = newNode;  // tail! - znaczy,ze tail na pewno nie jest pusty! 
            tail = newNode;
        }
    }

    public int RemoveFirst()
    {
        if (head == null)
            throw new InvalidOperationException("Lista jest pusta.");

        int value = head.Value;   // zapamiętujemy wartość pierwszego elementu
        head = head.Next;         // przesuwamy head na kolejny node

        if (head == null)         // jeśli lista się skończyła
            tail = null;

        return value;             // zwracamy wartość usuniętego elementu
    }

    public void Print()
    {
        Node? current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}