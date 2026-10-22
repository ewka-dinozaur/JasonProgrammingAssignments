using System;
using RestaurantOrderSystem;

Customer customer1 = new Customer("Ewa");

Waiter.TakeOrder(customer1);

double total = customer1.GetOrderTotal();
Console.WriteLine($"\nSuma zamówienia: {total} zł");

Console.WriteLine("Podaj procent napiwku (np. 10):");
double tipPercent = double.Parse(Console.ReadLine());
double tip = customer1.CalculateTip(tipPercent);

Console.WriteLine($"Napiwek: {tip} zł");
Console.WriteLine($"Do zapłaty razem: {total + tip} zł");