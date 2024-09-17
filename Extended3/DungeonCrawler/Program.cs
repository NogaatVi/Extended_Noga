using System;
using MonsterClass;
using PlayerClass;
using lootClass;
using roomClass;
using DungeonClass;

namespace DungeonCrawler;
class Program
{
    static void Main(string[] args)
    {
        Player newPlayer = new Player(1, 15, 35);
        Dungeon thisDungeon = new Dungeon(newPlayer);
        thisDungeon.InitializePlayer();
        thisDungeon.InitializeRooms();
        thisDungeon.ExploreRoom();
        Console.ReadLine();
    }
}
