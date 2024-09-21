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

        Player newPlayer = new Player(1, 10, 20);
        Dungeon thisDungeon = new Dungeon(newPlayer);
        
        thisDungeon.InitializePlayer();
        thisDungeon.InitializeRooms();
        
        while (newPlayer.isAlive())
        {
            if (thisDungeon.roomList.Count != thisDungeon.exploredRooms.Count)//if rooms existingin dungeon not equal to explored rooms
            {
                thisDungeon.PrintRooms();
                thisDungeon.ExploreRoom();
            }
            else
            {
                thisDungeon.FightBoss();
                break;
            }
        }

        if (!newPlayer.isAlive()) 
        { 
               Console.WriteLine("Another victim has been claimed by the devious dungeon's master!");
               Console.WriteLine("I shall bury the dead, but as always, a new, brave adventurer will come... They always do.");
        }

        Console.WriteLine("End of program");//FOR TEST
        Console.ReadLine();
    }
}
