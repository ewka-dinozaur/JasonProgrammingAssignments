using System;
using System.Collections.Generic;
using System.Text;

namespace ZooManagement
{
    internal class Bat : Mammal, IFlyable, IPredator, IHerbivore
    {
        public bool CanFly { get; set; } //can be set because different parrots may or may not fly

        public double MaxAltitude { get; set; }

        public void Fly()
        {
            if (CanFly == true)
                Console.WriteLine($"{Name} can fly {MaxAltitude}");
            else
                Console.WriteLine($"{Name} can't fly");
        }

        public void Graze()
        {
            Console.WriteLine($"{Name} is a bat and it often eats fruits and flowers' nectar.");
        }

        public void Hunt()
        {
            Console.WriteLine($"{Name} is a bat and it eats insects or blood of birds and other mammals.");
        }

        // konstruktor
        public Bat(string name, int age, bool isYoung) : base(name, age, isYoung)
        {
            CanFly = true;
            MaxAltitude = 100;
        }

    }


    internal class Platypus : Mammal, IAquatic, IPredator
    {
        public void Hunt()
        {
            Console.WriteLine($"{Name} is a platypus and eats worms, small fish and other small things from water.");
        }

        // konstruktor
        public Platypus(string name, int age, bool isYoung) : base(name, age, isYoung)
        {
        }

        public void Swim()
        {
               Console.WriteLine($"{Name}: is one of very few special mammals which lives in the water so it can swim");
        }
    }


}
