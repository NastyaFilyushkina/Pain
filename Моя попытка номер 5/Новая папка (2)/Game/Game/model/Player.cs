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
        public int Mana { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public IList <Card> CardArena1 { get; set; }
        public IList<Card> CardArena2 { get; set; }
        public IList <Card> Deck { get; set;}
        public IList <Card> CardHand { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusGamer Status { set; get; }
        public bool IsHod { set; get; }

        public Player(string name, int mana, int health)
        {
            this.Mana = mana;
            this.Name = name;
            this.Health = health;
        }
        public Player(string name)
        {
            this.Name = name;
        }
        static public bool operator ==(Player a, Player b)
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
            if (a.Name != b.Name || a.Health != b.Health) { return true; } else return false;
        }
    }
}
