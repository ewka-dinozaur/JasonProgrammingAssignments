namespace Attributes
{
    public class Player
    {

        public string Name { get; set; }
        public string Hero { get; set; }

        public int Level { get; set; }

        // Atrybut wbduowany
        [Obsolete("Use the new method for promotion", true)]
        public int Promote(int levels_up)
        {
            return Level + levels_up;
        }



        public int PromoteSafe(int levels_up)
        {
            if (Level + levels_up < 100)
            {
                Level += levels_up;
                return Level;
            }
            else
                throw new InvalidOperationException("You can't promote above 100.");
        }

        public Player(string name, string hero)
        {

            Name = name;
            Hero = hero;
            Level = 0;

        }

    }
}
