using Game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Controller
    {
        bool ismhod = false;
     
        int hod;



        public Controller()
        {
            //this.board = board;
            hod = 1;
        }

        //событие изменение хода
        /// <summary>
        /// ход передан другому
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public void IsmHoda(Player player1, Player player2)
        {
            if (player1.IsHod == false)
            {
                player1.IsHod = true;
                int i = 0;
                while (i < player2.CardArena1.Count)
                {
                    player2.CardArena2.Add(player2.CardArena1.ElementAt(i));
                    i++;
                }
                player2.CardArena1.Clear();
                player2.IsHod = false;
                player2.Mana += 1;
            }
            else
            {
                player1.IsHod = false;
                int i = 0;
                while (i < player1.CardArena1.Count)
                {
                    player1.CardArena2.Add(player1.CardArena1.ElementAt(i));
                    i++;
                }
                player1.CardArena1.Clear();
                player2.IsHod = true;
                player1.Mana += 1;
            }
            //ismhod = true;
        }

        /// <summary>
        /// кто первый ходит?
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        public Player First(Player player1, Player player2)
        {
            Random R = new Random();
            int n = R.Next(1, 3);
            if (n == 1)
            {
                player1.IsHod = true;
                player2.IsHod = false;
                return player1;
            }
            else
            {
                player1.IsHod = false;
                player2.IsHod = true;
                return player2;
            }
        }
        /// <summary>
        /// начало игры
        /// </summary>
        /// <param name="Player1"></param>
        /// <param name="Player2"></param>
        Player FirstPl=null ;
        public Player GameStart(Player Player1, Player Player2)
        {
            Player1.Health = 30;
            Player2.Health = 30;
            DistrOfCards(Player1);
            DistrOfCards(Player2);
            
                Player1.Mana = 1;
                Player2.Mana = 1;
            
            Player1.CardArena1 = Cardarena11;
            Player1.CardArena2 = Cardarena12;
            Player2.CardArena1 = Cardarena21;
            Player2.CardArena2 = Cardarena22;
            if (FirstPl == null)
            { FirstPl = First(Player1, Player2); }
            return FirstPl;
        }
        /// <summary>
        /// Раздача карт в начале игры
        /// </summary>
        /// <param name="Player"></param>
        List<CardHeroes> list;
        List<CardHeroes> Cardarena11 = new List<CardHeroes>();
        List<CardHeroes> Cardarena12 = new List<CardHeroes>();
        List<CardHeroes> Cardarena21 = new List<CardHeroes>();
        List<CardHeroes> Cardarena22 = new List<CardHeroes>();
        List<CardHeroes> CardHand = new List<CardHeroes>();
        private void DistrOfCards(Player Player)
        {
            Player.CardHand = CardHand;
            Random R = new Random(0);
            CardHeroes card;
            int j = 15;
            for (int i = 0; i < 7; i++)
            {
                card = Player.Deck[R.Next(j)];
                Player.CardHand.Add(card);
                j--;
            }
        }

        /// <summary>
        /// Добавление карт в руки
        /// </summary>
        /// <param name="player"></param>
        public void AddCardHand(Player player)
        {
            if (player.CardHand.Count < 7)
            {
                Random R = new Random();
                while (player.CardHand.Count < 7)
                {
                    player.CardHand.Add(player.Deck[R.Next(player.Deck.Count)]);
                    //player.Deck.Remove(player.Deck[R.Next(player.Deck.Count)]);
                }
            }
        }

        /// <summary>
        /// Выставить карты на арену
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        public void ToArena(Player player, CardHeroes card)
        {
            bool flag = false;
            foreach(CardHeroes a in CardHand)
            {
                if (a == card) { flag = true; }
            }
            if (player.Mana >= card.Price && flag)
            {
                if (card.Ability != null)
                {

                }
                player.CardArena1.Add(card);
                player.CardHand.Remove(card);
                player.Mana=player.Mana-card.Price;


                //перерисовка
            }
            else
            {
                throw new Exception("Недостаточно маны");
            }

        }

        private void Applicationability(string Ability)
        {
            switch (Ability)
            {
                case "":
                    {

                        break;
                    }
            }
        }

        /// <summary>
        /// атака на карту противника
        /// </summary>
        /// <param name="playeragressor"></param>
        /// <param name="playervinctim"></param>
        /// <param name="CardAgressor"></param>
        /// <param name="CardVinctim"></param>
        public void AttackCard(Player playeragressor, Player playervinctim, CardHeroes CardAgressor, CardHeroes CardVinctim)
        {if (playeragressor.CardArena2.Contains(CardAgressor))
            {
                CardVinctim.Health -= CardAgressor.Power;
                CardAgressor.Health -= CardVinctim.Power;
                if (CardAgressor.Health <= 0)
                {
                    playeragressor.CardArena2.Remove(CardAgressor);
                }
                if (CardVinctim.Health <= 0)
                {
                    if (playervinctim.CardArena1.Contains(CardVinctim))
                        playervinctim.CardArena1.Remove(CardVinctim);
                    else if (playervinctim.CardArena2.Contains(CardVinctim))
                        playervinctim.CardArena2.Remove(CardVinctim);
                    playervinctim.CardHand.Remove(CardVinctim);
                }
            }
            else
            {
              
            }
            //перерисовка

        }
        /// <summary>
        /// Атака на лицо противника
        /// </summary>
        /// <param name="playeragressor"></param>
        /// <param name="playervinctim"></param>
        /// <param name="CardAgressor"></param>
        public void AttackLico(Player playeragressor, Player playervinctim, CardHeroes CardAgressor)
        {
            playervinctim.Health -= CardAgressor.Power;
            if (playervinctim.Health <= 0)
            {
                GameOver(playeragressor);
            }
        }

        /// <summary>
        /// Применение карт способностей
        /// </summary>
        /// <param name="playeragressor"></param>
        /// <param name="playervinctim"></param>
        /// <param name="CardAgressor"></param>
        public void Spell(Player playeragressor, Player playervinctim, CardHeroes CardAgressor, CardHeroes CardVinctim = null)
        {
            string result = "";
            switch (CardAgressor.Ability)
            {
                case "damage2":
                    {
                        //если атакуем лицо
                        if (CardVinctim == null)
                        {
                            if (playeragressor.Mana <= CardAgressor.Price)
                            {
                                playervinctim.Health -= 2;
                                if (playervinctim.Health <= 0)
                                    result = GameOver(playeragressor);
                                playeragressor.CardHand.Remove(CardAgressor);
                            }
                            else
                            {
                                throw new Exception("Недостаточно маны!");
                            }
                        }
                        //если атакуем карту
                        else
                        {
                            if (playeragressor.Mana <= CardAgressor.Price)
                            {
                                CardVinctim.Health -= 2;
                                if (CardVinctim.Health <= 0)
                                {
                                    playervinctim.CardArena2.Remove(CardVinctim);
                                }
                                playeragressor.CardHand.Remove(CardAgressor);
                            }
                            else
                            {
                                throw new Exception("Недостаточно маны!");
                            }
                        }
                        break;
                    }
                //возьмите X карт
                case "take1cards":
                    {
                        Random R = new Random();
                        playeragressor.CardHand.Add(playeragressor.Deck[R.Next(playeragressor.Deck.Count)]);
                        break;
                    }
                //оппонент сбрасывает одну карту
                case "opponentdiscardscard":
                    {
                        Random R = new Random();
                        playervinctim.CardHand.RemoveAt(R.Next(playervinctim.CardHand.Count));
                        break;
                    }
                case "plushp3":
                    {
                        playeragressor.Health += 3;
                        break;
                    }
            }
        }


        /// <summary>
        /// Конец игры
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public string GameOver(Player player)
        {
            return "Победил " + player.Name;
        }
    }
}
