using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIGyakorlas
{
    public class HeroAddViaWindow : INewHeroService
    {
        public void NewHero(Hero h)
        {
            new NewHeroWindow(h).ShowDialog();
        }
    }
}
