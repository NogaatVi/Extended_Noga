using System;
using MonsterClass;
using PlayerClass;
using lootClass;
using DungeonClass;
//using Loot;
namespace DungeonCrawler;
class Program
{
    public class Room
    {
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
        Room room1 = new Room("room1");
        Console.ReadLine();
    }
}
