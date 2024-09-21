using System;
using MonsterClass;
using PlayerClass;
using lootClass;
using roomClass;
using DungeonClass;
using System.Numerics;

namespace DungeonCrawler;
class Program
{
    public bool isPlaying = false;
    public void NewDungeon() 
    {
    }
    public void RunDungeon(string starterText) 
    {
        isPlaying = true;
        Console.WriteLine(starterText);
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
            Console.WriteLine("Another victim has been claimed by the devious Dungeon's Master!");
            Console.WriteLine("I shall bury the dead...\nBut as always, a new, brave adventurer will come...\nThey always do.");
            isPlaying = false;
        }
        else
        {
            Console.WriteLine("You have done it!\nTheDungeon's doors swing open,\nGathering your loot, you run out.\nYou are free!");
            isPlaying= false;
        }
    }
    static void Main(string[] args)
    {
        Program newProgram = new Program();
        int num = 1;
        
        if (!newProgram.isPlaying)
        {
            Console.WriteLine("Welcome to...\nThe Mystical Dungeon!");
            string action = "";
            while (string.IsNullOrWhiteSpace(action))
            {
                Console.WriteLine("Would you like to play?\nY/N");
                action = Console.ReadLine();
                if ("Y".Equals(action, StringComparison.OrdinalIgnoreCase))
                {
                    newProgram.RunDungeon($"--Run {num}--\nThe Mystical Dungeon!");
                }
                else if ("N".Equals(action, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Unrecognized.\nPlease Try Again");
                    continue;
                }
            }
            Console.WriteLine("End of program");//FOR TEST
            Console.ReadLine();
        }
    }
}
