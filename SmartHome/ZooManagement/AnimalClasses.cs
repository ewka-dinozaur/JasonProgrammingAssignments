using System;
using System.Collections.Generic;
using System.Text;


namespace ZooManagement
{


    internal class Lion : Mammal, IPredator
    {

        // konstruktor
        public Lion(string name, int age, bool isYoung) : base(name, age, isYoung)
        {

        }

        public void Hunt() 
        {
            Console.WriteLine($"{Name}: is predator so it is fed with meat");

        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: Roar");
        }

    }

    internal class Parrot : Animal, IFlyable, IHerbivore
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
            Console.WriteLine($"{Name} is a parrot so it eats fruits and grains.");
        }


        // konstruktor
        public Parrot(string name, int age, bool isYoung) : base(name, age, isYoung)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: chce krakersa");
        }

        // override of parrot training
        public override void Train()
        {
            if (!IsYoung)
                Console.WriteLine("Don't train adult animals!");
            else 
                Console.WriteLine($"{Name} is trained to talk");
        }
    }

    internal class Snake : Animal, IAquatic, IPredator
    {

        public bool Aquatic { get; set; } //can be set because different snakes are or aren't venomous

        private bool _isVenomous;
        
        //Is Venomous can be set because different snakes are or aren't venomous
        public bool IsVenemous { 
            get { return _isVenomous; }
            set {
                if (value)
                {
                    _isVenomous = value;
                    Console.WriteLine($"Be careful, {Name} is venomous");
                }
                else
                    _isVenomous = value;
                }
        } 

        // konstruktor
        public Snake(string name, int age, bool isYoung) : base(name, age, isYoung)
        {
            
        }

        public void Hunt()
        {
            Console.WriteLine($"{Name}: is predator so it is fed with meat");

        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: ssssssssssss");
        }
        public void Swim()
        {
            if (Aquatic == true)
                Console.WriteLine($"{Name}: can swim");
            else
                Console.WriteLine($"{Name}: can't swim");
        }
    }

    internal class Elephant : Mammal, IHerbivore
    {

        // konstruktor
        public Elephant(string name, int age, bool isYoung) : base(name, age, isYoung)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: BRAAAAHHRRRRRRRRHH ");
        }

        public void Graze()
        {
            Console.WriteLine($"{Name} is an elephant and eats plants");
        }


        // Elephant is trained to be around people
        public override void Train()
        {
            if (!IsYoung)
                Console.WriteLine("Don't train adult animals!");
            else
                Console.WriteLine($"{Name} is trained be fed and bathed by visitors");
        }


    }
}
