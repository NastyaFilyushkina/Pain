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

            int hodPlayer1, hodPlayer2;



        public Controller()
        {
            //this.board = board;
            hodPlayer1 = 1;
            hodPlayer2 = 1;
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
                hodPlayer2 += 1;
                player1.IsHod = true;
                int i = 0;
                while (i < player2.CardArena1.Count)
                {
                    player2.CardArena2.Add(player2.CardArena1.ElementAt(i));
                    i++;
                }
                player2.CardArena1.Clear();
                player2.IsHod = false;
                player2.Mana = hodPlayer2;
                for (int j = 0; j < player2.CardArena2.Count; i++)
                {
                    if (!player2.CardArena2[j].IsHod) player2.CardArena2[j].IsHod = true;
                }
            }
            else
            {
                hodPlayer1 += 1;
                player1.IsHod = false;
                int i = 0;
                while (i < player1.CardArena1.Count)
                {
                    player1.CardArena2.Add(player1.CardArena1.ElementAt(i));
                    i++;
                }
                player1.CardArena1.Clear();
                player2.IsHod = true;
                player1.Mana = hodPlayer1;
                for (int j = 0; j < player1.CardArena1.Count; i++)
                {
                    if (!player1.CardArena2[j].IsHod) player1.CardArena2[j].IsHod = true;
                }
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
            Player FirstPl = null;
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
                foreach (CardHeroes a in CardHand)
                {
                    if (a == card) { flag = true; }
                }
                if (player.Mana >= card.Price && flag)
                {
                    if (card.Ability != null)
                    {
                        Applicationability(player, card.Ability);
                    }
                    player.CardArena1.Add(card);
                    player.CardHand.Remove(card);
                    player.Mana = player.Mana - card.Price;


                    //перерисовка
                }
                else
                {
                    throw new Exception("Недостаточно маны");
                }

            }

            private void Applicationability(Player player, string Ability)
            {
                switch (Ability)
                {
                    case "plusHP"://+5hp к лицу
                        {
                            player.Health += 5;
                            break;
                        }
                    case "plusmana"://+2mana, если mana<=8
                        {
                            if (player.Mana <= 8)
                                player.Mana += 2;
                            else if (player.Mana < 10)
                                player.Mana += 1;
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
            {
            if (CardAgressor.Power == 0 && CardAgressor.Health == 0)
            {
                Spell(playeragressor, playervinctim, CardAgressor, CardVinctim);
                if (CardVinctim.Health <= 0) playervinctim.CardArena2.Remove(CardVinctim);

            }
            else
            {
                if (CardAgressor.IsHod && playeragressor.CardArena2.Contains(CardAgressor))
                {
                    CardVinctim.Health -= CardAgressor.Power;
                    CardAgressor.Health -= CardAgressor.Power;
                    if (CardAgressor.Health <= 0)
                    {
                        playeragressor.CardArena2.Remove(CardAgressor);
                    }
                    if (CardVinctim.Health <= 0)
                    {
                        CardAgressor.IsHod = false;
                        if (playervinctim.CardArena1.Contains(CardVinctim))
                            playervinctim.CardArena1.Remove(CardVinctim);
                        else if (playervinctim.CardArena2.Contains(CardVinctim))
                            playervinctim.CardArena2.Remove(CardVinctim);
                        playervinctim.CardHand.Remove(CardVinctim);
                    }
                }

            }

                //перерисовка

            }
        /// <summary>
        /// Атака на лицо противника
        /// </summary>
        /// <param name="playeragressor"></param>
        /// <param name="playervinctim"></param>
        /// <param name="CardAgressor"></param>
        public void AttackLico(Player playeragressor, Player playervictim, CardHeroes CardAgressor)
        {
            if (CardAgressor.Power == 0 && CardAgressor.Health == 0)
            {
                Spell(playeragressor, playervictim, CardAgressor);
                if (playervictim.Health <= 0)
                {
                    GameOver(playeragressor);
                }
            }
            else
            {
                if (CardAgressor.IsHod && playeragressor.CardArena2.Contains(CardAgressor))
                {
                    playervictim.Health -= CardAgressor.Power;
                    if (playervictim.Health <= 0)
                    {
                        GameOver(playeragressor);
                    }
                    playeragressor.Mana -= CardAgressor.Price;
                    CardAgressor.IsHod = false;
                }
            }
        }

            /// <summary>
            /// Применение карт способностей
            /// </summary>
            /// <param name="playeragressor"></param>
            /// <param name="playervinctim"></param>
            /// <param name="CardAgressor"></param>
            private void Spell(Player playeragressor, Player playervinctim, CardHeroes CardAgressor, CardHeroes CardVinctim = null)
            {
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
                                    //if (playervinctim.Health <= 0)
                                    //    result = GameOver(playeragressor);
                                    playeragressor.CardHand.Remove(CardAgressor);
                                    playeragressor.Mana -= CardAgressor.Price;
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
                                    playeragressor.Mana -= CardAgressor.Price;
                                    playeragressor.CardHand.Remove(CardAgressor);
                                }
                                else
                                {
                                    throw new Exception("Недостаточно маны!");
                                }
                            }
                            break;
                        }
                    //оппонент сбрасывает одну рандомную карту
                    case "opponentdiscardscard":
                        {
                            Random R = new Random();
                            playervinctim.CardHand.RemoveAt(R.Next(playervinctim.CardHand.Count));
                            playeragressor.CardHand.Remove(CardAgressor);
                            break;
                        }
                    case "plushp3":
                        {
                            playeragressor.Health += 3;
                            playeragressor.CardHand.Remove(CardAgressor);
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
