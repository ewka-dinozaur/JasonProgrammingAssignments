using System;
using System.Collections.Generic;
using System.Text;

namespace ZooManagement
{
    public interface IFlyable
    {
        public void Fly();
        double MaxAltitude { get; set; }
    }

    public interface IAquatic
    {
        public void Swim();
    }

    public interface IPredator
    {
        public void Hunt();
    }

    public interface IHerbivore
    {
        public void Graze();
    }
}
