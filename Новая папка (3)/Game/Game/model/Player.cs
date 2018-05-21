using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.model
{
    public enum StatusGamer { sleeping, playing, lookforgame }
    public class Player
    {
        public int NumRoom { get; set; }
        public int Mana { get; set; } = 9999;

        public string Name { get; set; }

        public int Health { get; set; } = 4564;
        
        public List <CardHeroes> CardArena1 { get; set; }
      
        public List<CardHeroes> CardArena2 { get; set; }
    
        public List <CardHeroes> Deck { get; set;}
        
        public List <CardHeroes> CardHand { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusGamer Status { set; get; }
      
        public bool IsHod { set; get; }

        public Player(string name, int mana, int health)
        {
            this.Mana = mana;
            this.Name = Name;
            this.Health = health;
        }
        public Player(string name)
        {
            this.Name = name;
        }

    }
}
