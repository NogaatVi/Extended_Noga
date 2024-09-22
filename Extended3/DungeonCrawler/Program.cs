using System;
using MonsterClass;
using PlayerClass;
using lootClass;
using roomClass;
using DungeonClass;
using System.Numerics;

namespace DungeonCrawler
{
    class Program
    {
        public bool isPlaying = true;

        public void NewDungeon()
        {
            
        }

        public void RunDungeon(string starterText)
        {
            Console.WriteLine(starterText);
            Player newPlayer = new Player(1, 10, 20);
            Dungeon thisDungeon = new Dungeon(newPlayer);

            thisDungeon.InitializePlayer();
            thisDungeon.InitializaDungeonGrid();

            while (newPlayer.isAlive())
            {
                if (thisDungeon.dungeonGrid.Count != thisDungeon.exploredRooms.Count) // If there are unexplored rooms
                {
                    thisDungeon.PrintDungeonGrid();
                    thisDungeon.ExploreDungeonGrid();
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
            }
            else
            {
                Console.WriteLine("You have done it!\nThe Dungeon's doors swing open,\nGathering your loot, you run out.\nYou are free!");
            }
        }

        public void BracketPutter(string yourStringHere)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n--------------------------{yourStringHere}--------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {
            Program newProgram = new Program();
            int runNumber = 1;
            bool playAgain = true;

            while (playAgain) // Main game loop
            {
                newProgram.BracketPutter("The Mystical Dungeon");
                Console.WriteLine("Welcome to...\nThe Mystical Dungeon!");
                string action = "";

                while (string.IsNullOrWhiteSpace(action))
                {
                    Console.WriteLine("Would you like to play?\n--Y/N--");
                    action = Console.ReadLine();

                    if ("Y".Equals(action, StringComparison.OrdinalIgnoreCase))
                    {
                        newProgram.BracketPutter("Let's Go!");
                        newProgram.RunDungeon($"--Run {runNumber}--\nThe Mystical Dungeon!");
                        runNumber++;//add to run
                    }
                    else if ("N".Equals(action, StringComparison.OrdinalIgnoreCase))
                    {
                        newProgram.BracketPutter("So this is goodbye...");
                        Console.WriteLine("Thank you for playing my game! \nI hope to see you soon.");
                        playAgain = false; // Exit the game loop
                    }
                    else
                    {
                        Console.WriteLine("Unrecognized input.\nPlease try again.");
                        action = ""; // Reset action to force re-entry
                    }
                }

                if (playAgain) // play again?
                {
                    Console.WriteLine("Would you like to play again? Y/N");
                    string playerAction = Console.ReadLine();

                    if (!"Y".Equals(playerAction, StringComparison.OrdinalIgnoreCase))
                    {
                        playAgain = false; // Exit the game loop
                        Console.WriteLine("Goodbye! Thanks for playing!");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
