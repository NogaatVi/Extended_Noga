using System;
using MonsterClass;
using PlayerClass;
using DungeonClass;
//using Loot;
namespace DungeonCrawler;
class Program
{
    public class Room
    {
        List<Loot> monsterList = new List<Loot> { };
        List<Loot> lootList = new List<Loot> { };
        public string Name { get; set;}
        public Room(string name)
        {
            Name = name;
        }
    }
    static void Main(string[] args)
    {
        Dungeon thisDungeon = new Dungeon();
        thisDungeon.InitializePlayer();
        thisDungeon.InitializeRooms();
        Console.ReadLine();
    }
}
