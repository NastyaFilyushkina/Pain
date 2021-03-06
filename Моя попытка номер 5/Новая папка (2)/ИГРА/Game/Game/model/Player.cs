﻿using Newtonsoft.Json;
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

        public int Mana { get; set; } = 9999;

        public string Name { get; set; }

        public int Health { get; set; } = 4564;
        
        public IList <Card> CardArena1 { get; set; }
    
        public IList<Card> CardArena2 { get; set; }
        
        public IList <Card> Deck { get; set;}
     
        public IList <Card> CardHand { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusGamer Status { set; get; }
      
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
