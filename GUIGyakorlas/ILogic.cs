using System.Collections.Generic;

namespace GUIGyakorlas
{
    public interface ILogic
    {
        double AvgPower { get; }
        double AvgSpeed { get; }

        void AddHero(Hero h);
        void NewHero();
        void RemoveHero(Hero h);
        void SetUpCollections(IList<Hero> hs, IList<Hero> t);
        void WriteOutCollections();
    }
}