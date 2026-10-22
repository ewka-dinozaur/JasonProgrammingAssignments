using ZooManagement;

List<Animal> zoo = new List<Animal>();

zoo.Add(new Lion("Simba", 2, true));
zoo.Add(new Parrot("Polly", 3, true) { CanFly = true, MaxAltitude = 200 });
zoo.Add(new Snake("Kaa", 3, false) { Aquatic = false });
zoo.Add(new Snake("Waz", 7, false) {Aquatic = true });
zoo.Add(new Elephant("Dumbo", 2, false));
zoo.Add(new Bat("Dracula", 1, true));
zoo.Add(new Platypus("Dziobak", 4, false));

// sprawdzenie dzwieku dla wszystkich zwierzat
foreach (Animal a in zoo)
    a.MakeSound();

// zywienie kazdego zwierzaka w zoo
zoo[0].Feed(5); // wariant 1 ale bedzie override 
zoo[1].Feed("grains", 0.5); // papuga zje 0.5kg ziaren ale moglabym zjesc 1kg owocow np ona sie zywi roznie - wariant 3
zoo[2].Feed("mice"); // waz ktory zywi sie myszami - wariant 2
zoo[3].Feed(2); //waz wodny zywi sie czyms innym - wariant 1
zoo[4].Feed("fruits"); // slon zywi sie owocami - wariant 2
zoo[5].Feed("fruits and insects", 0.3); // nietoperz ma swoj spowob zywienia - wariant 3
zoo[6].Feed("frogs, fish and insects", 0.8); // dziobak ma swoj sposob zywienia - wariant 3

var maybeMammal = (Mammal) zoo[4]; // downcasting
maybeMammal.GetPregnant();

var zaskroniec = (Snake)zoo[3];
zaskroniec.Aquatic = true;

Animal zmija = new Snake("ZmijaZygzakowata", 3, false) { Aquatic = false, IsVenemous = true};
zoo.Add(zmija);

Animal Padalec = new Snake("Grzesio", 45, false) {Aquatic = false, IsVenemous = true };
zoo.Add(Padalec);

Animal Kea = new Parrot(zoo[1].Name, zoo[1].Age, zoo[1].IsYoung)
{
    Name = "Kiwi",
    CanFly = true,
    MaxAltitude = 300,
  
};
zoo.Add(Kea);


// uzycie interfacu zeby pokazac ktore zwierze ma jakis styl zywienia i w jakim srodowisku zyje
foreach (Animal a in zoo)
    if (a is IPredator p) p.Hunt();

foreach (Animal a in zoo)
    if (a is IHerbivore h) h.Graze();

foreach (Animal a in zoo)
    if (a is IFlyable f) f.Fly();

foreach (Animal a in zoo)
    if (a is IAquatic aq) aq.Swim();

// Downcasting 

zoo[1].Train();
zoo[2].Train();

// try- catch validation
try { new Lion("", 5, false); }
catch (ArgumentException ex) { Console.WriteLine($"Caught: {ex.Message}"); }

try { new Snake("Kaa", -3, false); }
catch (ArgumentException ex) { Console.WriteLine($"Caught: {ex.Message}"); }

