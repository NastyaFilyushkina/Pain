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
        public int Mana { get; set; } 

        public string Name { get; set; }

        public int Health { get; set; }
        
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
        static public bool operator==(Player a,Player b)
        {
            try
            {
                if (a.Name == b.Name && a.Health == b.Health) { return true; } else return false;
            }
            catch
            {
                return true;
            }
        }
        static public bool operator !=(Player a, Player b)
        {
            try
            {
                
                if (a.Name != b.Name || a.Health != b.Health) { return true; } else return false;
            }
            catch
            {


                return true;
            }

        }
    }
}
