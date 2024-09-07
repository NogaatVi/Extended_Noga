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
        Player newPlayer = new Player(0, 10, 25);
        Dungeon thisDungeon = new Dungeon(newPlayer);
        thisDungeon.InitializePlayer();
        thisDungeon.InitializeRooms();
        thisDungeon.EnterRoom();
        Console.ReadLine();
    }
}
