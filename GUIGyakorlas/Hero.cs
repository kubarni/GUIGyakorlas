using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIGyakorlas
{
    public enum Side
    {
        good, evil, neutral
    }

    public class Hero : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { SetProperty(ref power, value); }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

        private Side behaviour;

        public Side Behaviour
        {
            get { return behaviour; }
            set { SetProperty(ref behaviour, value); }
        }

        public Hero GetCopy()
        {
            return new Hero() {Name=this.name, Speed=this.speed, Power=this.power, Behaviour=this.behaviour};
        }
    }
}
