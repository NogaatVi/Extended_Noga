using System;
using MonsterClass;
using PlayerClass;
using lootClass;
using roomClass;
using DungeonClass;
using System.Threading;
using System.Numerics;

namespace DungeonCrawler
{
    class Program
    {
        public bool isPlaying = true;
        static int delay = 20;

        static void PrintEffect(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (char letter in text)
            {
                Console.Write(letter); // Print each letter
                Thread.Sleep(delay); // Wait for the specified delay
            }
            Console.WriteLine(); // Move to the next line after finishing
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void NewDungeon()
        {
            
        }

        public void RunDungeon(string starterText)
        {
            PrintEffect(starterText , ConsoleColor.White);
            Player newPlayer = new Player(10, 20, 2);
            Dungeon thisDungeon = new Dungeon(newPlayer);

            thisDungeon.InitializePlayer();
            thisDungeon.InitializaDungeonGrid();

            while (newPlayer.isAlive())
            {
                if (thisDungeon.dungeonGrid.Count != thisDungeon.exploredRooms.Count) // If there are unexplored rooms
                {
                    thisDungeon.dungeonGrid[0][0].EntranceRoomEncounter(newPlayer);//forcing u to entrance hall event
                    thisDungeon.PrintDungeonGrid();
                    thisDungeon.ExploreDungeonGrid(newPlayer);
                }
                else
                {
                    thisDungeon.FightBoss();
                    break;
                }
            }

            if (!newPlayer.isAlive())
            {
                PrintEffect("Another victim has been claimed by the devious Dungeon's Master!", ConsoleColor.Magenta);
                PrintEffect("I shall bury the dead...\nBut as always, a new, brave adventurer will come...\nThey always do.", ConsoleColor.Magenta);
            }
            else
            {
                PrintEffect("You have done it!\nThe Dungeon's doors swing open,\nGathering your loot, you run out.\nYou are free!", ConsoleColor.Green);
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
                PrintEffect("Welcome to...\nThe Mystical Dungeon!", ConsoleColor.Magenta);
                string action = "";

                while (string.IsNullOrWhiteSpace(action))
                {
                    PrintEffect("Would you like to play?\n--Y/N--", ConsoleColor.Magenta);
                    action = Console.ReadLine();

                    if ("Y".Equals(action, StringComparison.OrdinalIgnoreCase))
                    {
                        newProgram.BracketPutter("Let's Go!");
                        newProgram.RunDungeon($"--Run {runNumber}--\n");
                        runNumber++;//add to run
                    }
                    else if ("N".Equals(action, StringComparison.OrdinalIgnoreCase))
                    {
                        newProgram.BracketPutter("So this is goodbye...");
                        PrintEffect("Thank you for playing my game! \nI hope to see you soon.", ConsoleColor.DarkBlue);
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
                    PrintEffect("Would you like to play again? Y/N", ConsoleColor.Magenta);
                    string playerAction = Console.ReadLine();

                    if (!"Y".Equals(playerAction, StringComparison.OrdinalIgnoreCase))
                    {
                        playAgain = false; // Exit the game loop
                        PrintEffect("Goodbye! Thanks for playing!", ConsoleColor.Green);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
