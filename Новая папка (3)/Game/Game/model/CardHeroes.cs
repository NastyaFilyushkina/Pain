namespace Game.model
{
    public class CardHeroes
    {
        public int Price { get; set; }
        public string Name { set; get; }//имя
        public int Power { get; set; }//сила
        public int Health { get; set; }//здоровье
        public string Ability { get; set; }//способность

        public CardHeroes(string Name, int Price, int Power = 0, int Health = 0, string Ability = null)
        {
            this.Name = Name;
            this.Price = Price;
            this.Power = Power;
            this.Health = Health;
            this.Ability = Ability;
        }
        public static bool operator ==(CardHeroes a, CardHeroes b)
        {
            if (a.Health == b.Health && a.Name == b.Name && a.Power == b.Power && a.Price == b.Price && a.Ability == b.Ability)
            {
                return true;
            }
            else return false;
        }

        public static bool operator !=(CardHeroes a, CardHeroes b)
        {
            if (a.Health != b.Health || a.Name != b.Name || a.Power != b.Power || a.Price != b.Price || a.Ability != b.Ability)
            {
                return true;
            }
            else return false;
        }
    }
}
