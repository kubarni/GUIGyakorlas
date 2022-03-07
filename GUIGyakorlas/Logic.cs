using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GUIGyakorlas
{
    public class Logic : ILogic
    {
        public IList<Hero> heroes;
        public IList<Hero> team;
        public IMessenger messenger;
        INewHeroService service;

        public Logic(IMessenger m, INewHeroService service)
        {
            this.messenger = m;
            this.service = service;
        }

        public void SetUpCollections(IList<Hero> hs, IList<Hero> t)
        {
            heroes = hs;
            team = t;
        }
        public void WriteOutCollections()
        {
            File.WriteAllText("heroes.json", JsonSerializer.Serialize(heroes));
            File.WriteAllText("team.json", JsonSerializer.Serialize(team));
        }

        public void AddHero(Hero h)
        {
            team.Add(h);
            messenger.Send("Added", "heroinfo");
        }
        public void RemoveHero(Hero h)
        {
            team.Remove(h);
            messenger.Send("Remove", "heroinfo");
        }
        public void NewHero()
        {
            Hero h = new Hero() { Name="default", Power=5,Speed=10,Behaviour=Side.neutral};
            heroes.Add(h);
            service.NewHero(h);
        }

        public double AvgSpeed
        {
            get
            {
                return team.Count() == 0 ? 0 : Math.Round(team.Average(x => x.Speed), 2);
            }
        }

        public double AvgPower
        {
            get
            {
                return team.Count == 0 ? 0 : Math.Round(team.Average(x => x.Power), 2);
            }
        }
    }
}
