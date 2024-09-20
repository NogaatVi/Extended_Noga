using System;
using MonsterClass;
using PlayerClass;
using lootClass;
using roomClass;
using DungeonClass;

namespace DungeonCrawler;
class Program
{
    public void NewDungeon() //try to make dungeons loopable?
    {
       Player newPlayer = new Player(1, 15, 35);
        Dungeon thisDungeon = new Dungeon(newPlayer);
        thisDungeon.InitializePlayer();
        thisDungeon.InitializeRooms();
        thisDungeon.ExploreRoom(); 
    }
    static void Main(string[] args)
    {
        Player newPlayer = new Player(1, 15, 35);
        Dungeon thisDungeon = new Dungeon(newPlayer);
        thisDungeon.InitializePlayer();
        thisDungeon.InitializeRooms();
        while (Room.roomsVisited != thisDungeon.roomList.Count -1) 
        {
            thisDungeon.PrintRooms();
            thisDungeon.ExploreRoom();
            Console.WriteLine($"FOR TEST {Room.roomsVisited}");
            Console.WriteLine(thisDungeon.roomList.Count);
        }
        Console.WriteLine("BOSS TIME");
        thisDungeon.FightBoss();
        Console.WriteLine("end of program");//FOR TEST
        Console.ReadLine();
    }
}
