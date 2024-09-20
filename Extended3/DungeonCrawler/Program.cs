using System;
using MonsterClass;
using PlayerClass;
using lootClass;
using roomClass;
using DungeonClass;

namespace DungeonCrawler;
class Program
{
    public void NewDungeon() 
    {
    }
    static void Main(string[] args)
    {
        Player newPlayer = new Player(1, 15, 35);
        Dungeon thisDungeon = new Dungeon(newPlayer);
        thisDungeon.InitializePlayer();
        thisDungeon.InitializeRooms();
        if (newPlayer.isAlive())
        {
            while (Room.roomsVisited != thisDungeon.roomList.Count)
            {
                thisDungeon.PrintRooms();
                thisDungeon.ExploreRoom();
                Console.WriteLine($"FOR TEST {Room.roomsVisited}");
                Console.WriteLine(thisDungeon.roomList.Count);
            }
          Console.WriteLine("BOSS TIME");
          thisDungeon.FightBoss();
        }
        else 
        {
            Console.WriteLine("Another victim has been claimed by the devious dungeon's master!");
            Console.WriteLine("I shall bury the dead, but as always, a new, brave adventurer will come... They always do.");
        }
        Console.WriteLine("End of program");//FOR TEST
        Console.ReadLine();
    }
}
