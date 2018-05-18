using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.model
{
   public class CardHeroes:Card
    {
        public string Name { get; set; }//имя
        public int Power { get; set; }//сила
        public int Health { get; set; }//здоровье
        public string Ability { get; set; }//способность

        public CardHeroes (int Power, int Health, string Name, string Ability=null)
        {
            this.Power = Power;
            this.Health = Health;
            this.Ability = Ability;
            this.Name = Name;
        }



    }
}
