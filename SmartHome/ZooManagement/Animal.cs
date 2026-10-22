using System;
using System.Collections.Generic;
using System.Text;

namespace ZooManagement
{

    internal abstract class Animal
    {
        private int _age;
        private string _name;
        public bool IsYoung { get; set; }

        public int Age

        {
            get { return _age; }

            set
            {
                if (value < 0)
                    throw new ArgumentException("Age must be positive");
                else
                    _age = value;
            }
        }
        public string Name // property publiczne z walidacją
        {
            get { return _name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                else
                    _name = value;
            }
        }


        public Animal(string name, int age, bool isYoung)
        {
            Name = name;
            Age = age;
            IsYoung = isYoung;
        }

        public abstract void MakeSound();

        public virtual void Train()
        {

            if (IsYoung == false)
                Console.WriteLine($"{Name} is not in training as he is adult.");
            else
                Console.WriteLine($"{Name} is trained");

        }

        // Overload
        public virtual void Feed(double kg) // wariant 1: tylko ilość
        {
            if (kg <= 0)
                throw new ArgumentException("Amount of food must be positive");
            Console.WriteLine($"{Name} was fed {kg}kg");
        }

        public virtual void Feed(string foodType) // OVERLOAD - inny parametr (string) 
        {
            double amount = foodType switch
            {
                "meat" => 5,
                "fruits" => 8,
                "insects" => 0.3,
                "mice" => 2.5,
                _ => throw new ArgumentException("Unknown food type")
            };
            Feed(amount); // woła wariant z double - dokładnie jak Twój SetBrightness(string) w SmartLight
        }

        public virtual void Feed(string foodName, double kg) // wariant 3: konkretny produkt + ilość - TO jest to co chcesz
        {
            if (kg <= 0)
                throw new ArgumentException("Amount of food must be positive");
            Console.WriteLine($"{Name} was fed {kg}kg of {foodName}");
        }

    }

    internal class Mammal : Animal
    {
        public Mammal(string name, int age, bool isYoung) : base(name, age, isYoung) { }

        public override void Feed(double kg) // nadpisuje wariant #1
        {
          if (IsYoung)
              Console.WriteLine($"{Name} is nursed by mother");
          else
              base.Feed(kg); // pozwala z wnętrza override zawołać oryginalną implementację z klasy rodzica, zamiast całkowicie ją zastępować
        }

        public override void Feed(string foodName, double kg) // nadpisuje wariant #1
        {
            if (IsYoung)
                Console.WriteLine($"{Name} is nursed by mother");
            else
                base.Feed(foodName, kg); // pozwala z wnętrza override zawołać oryginalną implementację z klasy rodzica, zamiast całkowicie ją zastępować
        }


        public override void MakeSound()
        {
            Console.WriteLine($"{Name} makes an unspecified mammal sound");
        }

        public void GetPregnant()
        {
            Console.WriteLine($"{Name} gets pregnant with some cute partner");
        }
    }


}
