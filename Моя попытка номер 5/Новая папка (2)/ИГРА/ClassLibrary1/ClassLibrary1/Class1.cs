using Game.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public enum PacketsToServer
    {
        RegPacket,StartWindowPacket, WaitGamePacket, StartGamePacket, ChooseEnemyPacket, ChoosenCardListPacket,
        StepPacket,StepIsNull, EndGamePacket, ResultRegPacket, ResultChooseEnemyPacketSuccess, ResultChooseEnemyPacketFailed, WinnerPaclet, ResultChooseCardList,
        EnemyLeftGamePacket, ResultStepPacket, AllCardsPacket, ListOfAllClients, ListOfWaitingClients,
        SendDataToUsers,PacketArenaCardNow,Error, AskGamePacket
    }
    public enum Status { success, fail }
    /// <summary>
    /// Серверные
    /// </summary>
   public class Error
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public string ErrorToUser { set; get; }
    }
     public class ListOfWaitingClients
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
         public List<string> ListWaitingClients { set; get; }
    }
public class ListOfAllClients
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public List<string> ListAllClients { set; get; }
    }
    public class StartWindowPacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public List<string> ListAllClients { set; get; }
    }
    public class ResultRegPacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status StatusOfRegistr{ set; get; }
    }
    public class ResultChooseEnemyPacketSuccess
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status StatusOfChoseEnemy { set; get; }
        public List<Card> listAllCards { set; get; }
        public string enemylogin { set; get; }
    }
    public class ResultChooseEnemyPacketFailed
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status StatusOfChoseEnemy { set; get; }
    }
    public class WinnerPaclet
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public Player Winner { set; get; }
    }
    public class ResultChooseCardList
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status ResultOfChooseCard { set; get; }
    }
    public class EnemyLeftGamePacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public string login { set; get; }
    }
    public class AllCardsPacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public List<Card> Koloda { set; get; }
        
    }
    public class ResultStepPacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status ResultOfChooseCard { set; get; }
    }
    public class SendDataToUsersFirstTime: SendDataToUsers
    {
        public List<Card> ListCard { set; get; }
    }
    public class SendDataToUsers
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public Player Player1 { set; get; }
        public Player Player2 { set; get; }
        public Player WhoIsFirst { set; get; }
    }
    /// <summary>
    /// Клиентские
    /// </summary>
    public class RegPacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public string Name { set; get; }

    }
    public class AskGamePacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
       
    }
    public class WaitGamePacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public string login { set; get; }
    }
    public class ChooseEnemyPacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public string EnemyLogin { set; get; }
    }
    public class StartGamePacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public Player Me { set; get; }
        public Player Enemy { set; get; }
        public List<Card> Koloda { set; get; }

    }
    public class ChoosenCardListPacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public List<Card> Koloda { set; get; }
    }
    public class StepPacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public Card MyCard { set; get; }
        public Card EnemyCard { set; get; }
        public Player Enemy { set; get; }

    }
     public class PacketArenaCardNow
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public Card MyCard { set; get; }
    }
    public class StepIsNull
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        

    }
    public class EndGamePacket
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PacketsToServer Command { set; get; }
        public string login { set; get; }
        public Player Enemy { set; get; }
    }

}
