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
        public bool ismhod { get; set; }
        Board board;
        int hod;



        public Controller()
        {
           // this.board = board;
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
            hod++;
            player1.Mana = hod;
            player2.Mana = hod;
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
            if (n == 1) return player1;
            else return player2;
        }
        /// <summary>
        /// начало игры
        /// </summary>
        /// <param name="Player1"></param>
        /// <param name="Player2"></param>
        public void GameStart(Player Player1, Player Player2)
        {
            Player1.Health = 30;
            Player2.Health = 30;
            DistrOfCards(Player1);
            DistrOfCards(Player2);
            Player1.Mana = 1;
            Player2.Mana = 1;
        }
        /// <summary>
        /// Раздача карт в начале игры
        /// </summary>
        /// <param name="Player"></param>
        public void DistrOfCards(Player Player)//Раздача карт в начале
        {
            Random R = new Random(0);
            Card card;
            int j = 30;
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
                    player.Deck.Remove(player.Deck[R.Next(player.Deck.Count)]);
                }
            }
        }
        
        /// <summary>
        /// Выставить карты на арену
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        public void ToArena(Player player,  Card card)
        {
            if (player.CardHand.Contains(card))
            {
                if (ismhod)
                {
                    
                    int i = 0;
                    while (i < player.CardArena1.Count)
                    {
                        player.CardArena2.Add(player.CardArena1.ElementAt(i));
                        i++;
                    }
                    player.CardArena1.Clear();
                    player.CardHand.Remove(card);
                    player.CardArena1.Add(card);
                }

                //перерисовка
            }
        }

        /// <summary>
        /// атака на карту противника
        /// </summary>
        /// <param name="playeragressor"></param>
        /// <param name="playervinctim"></param>
        /// <param name="CardAgressor"></param>
        /// <param name="CardVinctim"></param>
        public void AttackCard(Player playeragressor,Player playervinctim, CardHeroes CardAgressor, CardHeroes CardVinctim)
        {
            if (CardAgressor.Price <= playeragressor.Mana)
            {
                CardVinctim.Health -= CardAgressor.Power;
                playeragressor.Mana -= CardAgressor.Price;
                playeragressor.CardArena2.Remove(CardAgressor);
                if (CardVinctim.Health <= 0)
                {
                    playervinctim.CardHand.Remove(CardVinctim);
                }

                //перерисовка
            }
            else
            {
                throw new Exception("Вы не можете ходить этой картой");
            }
        }
        /// <summary>
        /// Атака на лицо противника
        /// </summary>
        /// <param name="playeragressor"></param>
        /// <param name="playervinctim"></param>
        /// <param name="CardAgressor"></param>
        public void AttackLico(Player playeragressor, Player playervinctim, CardHeroes CardAgressor)
        {
            if (CardAgressor.Price <= playeragressor.Mana)
            {
                playervinctim.Health -= CardAgressor.Power;
                playeragressor.CardArena2.Remove(CardAgressor);
                if (playervinctim.Health <= 0)
                {
                    GameOver(playeragressor);
                }
            }
            else
            {
                throw new Exception("Вы не можете ходить этой картой");
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
