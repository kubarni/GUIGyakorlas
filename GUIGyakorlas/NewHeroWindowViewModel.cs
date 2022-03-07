using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIGyakorlas
{
    public class NewHeroWindowViewModel
    {
        public Hero Actual { get; set; }

        public void Setup(Hero hero)
        {
            this.Actual = hero;
        }
        public NewHeroWindowViewModel()
        {

        }
    }
}
