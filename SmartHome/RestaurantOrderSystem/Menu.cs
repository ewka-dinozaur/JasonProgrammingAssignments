namespace RestaurantOrderSystem
{
    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; } // np. "main", "drink", "salad" - opcjonalnie

        public MenuItem(string name, string category)
        {
            Name = name;
            Category = category;
        }
        // pusty konstruktor i w obiekcie przy tworzenie nie daje argumentow tylko wpisuje wartosci do pol przez setter - patrz na liste u dolu
        public MenuItem()
        { }

    }

    static class Menu
    {
        // metoda statyczna zeby znac rozmiar i cene drinka po rozmiarze
        public static double GetDrinkPrice(string size) => size switch
        {
            "small" => 5.0,
            "medium" => 7.0,
            "large" => 9.0,
            _ => throw new ArgumentException("Unknown size")
        };


        public static List<MenuItem> AvailableMenuItems = new List<MenuItem>
        {
        new MenuItem ("Margharita", "main") { Price = 25 },
        new MenuItem { Name = "Hawaian", Price = 28.0, Category = "main" },
        new MenuItem { Name = "Capriciosa", Price = 28.0, Category = "main" },
        new MenuItem { Name = "Parma", Price = 30.0, Category = "main" },
        new MenuItem { Name = "Cesar Salad", Price = 18.0, Category = "salad" },
        new MenuItem { Name = "Garlic bread", Price = 9.0, Category = "starter" },
        new MenuItem { Name = "Cola (small)", Price = GetDrinkPrice("small"), Category = "drink" },
        new MenuItem { Name = "Cola (mediun)", Price = GetDrinkPrice("medium"), Category = "drink" },
        new MenuItem { Name = "Cola (large)", Price = GetDrinkPrice("large"), Category = "drink" },
        };
    }


    // struct MenuItem zeby przechowywac dane do zliczenia zamowienia, to sa kopie bo moze byc kilka takich samych zamowien gdzie jedno jest modyfikowane a inne nie
    struct OrderedItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

    class Customer
    {
        public string Name { get; set; }
        public List<OrderedItem> Order { get; set; } = new List<OrderedItem>();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddToOrder(MenuItem item)
        {
            Order.Add(new OrderedItem { Name = item.Name, Price = item.Price, Category = item.Category });
        }

        public double GetOrderTotal()
        {
            double total = 0;
            foreach (var ordered_item in Order)
                total += ordered_item.Price;
            return total;
        }

        public double CalculateTip(double percentage)
        {
            return GetOrderTotal() * (percentage / 100);
        }
    }
    static class Waiter
        {
            public static void TakeOrder(Customer customer)
            {
                Console.WriteLine($"Witaj {customer.Name}! Oto menu:");
                for (int i = 0; i < Menu.AvailableMenuItems.Count; i++)
                    Console.WriteLine($"{i}: {Menu.AvailableMenuItems[i].Name} - {Menu.AvailableMenuItems[i].Price} zł");

                while (true)
                {
                    Console.WriteLine("Podaj numer dania (albo 'koniec' żeby zakończyć):");
                    string input = Console.ReadLine();

                    if (input == "koniec")
                        break;

                    if (int.TryParse(input, out int choice) && choice >= 0 && choice < Menu.AvailableMenuItems.Count)
                    {
                        MenuItem chosen = Menu.AvailableMenuItems[choice];
                        customer.AddToOrder(chosen);
                        Console.WriteLine($"Dodano: {chosen.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
                    }
                }
            }
        }



    }








