using PlayerClass;
using System;
using roomClass;
using static DungeonCrawler.Program;
using System.Security.Cryptography.X509Certificates;

namespace DungeonClass
{
    public class Dungeon
    {
        public Player MyPlayer { get; set; }
        public List<Room> roomList = new List<Room> { };
        public List<Room> exploredRooms = new List<Room>();
        public List<List<Room>> dungeonGrid = new List<List<Room>>{};
        int rows = 3;
        int cols = 3;
        int playerRow = 0;
        int playerCol = 0;
        
        public Dungeon(Player player)
        {
            MyPlayer = player;
        }

        static int delay = 40;

        static void PrintEffect(string text)
        {
            foreach (char letter in text)
            {
                Console.Write(letter); // Print each letter
                Thread.Sleep(delay); // Wait for the specified delay
            }
            Console.WriteLine(); // Move to the next line after finishing
        }

        public void MakeItPurple(string yourStringHere) 
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            PrintEffect(yourStringHere);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void BracketPutter(string yourStringHere)//i want a bracket here
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n--------------------------{yourStringHere}--------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void InitializePlayer()
        {
            PrintEffect("Welcome, dear adventurer! \nYou are now at the gates of the Mystic Dungeon!");
            PrintEffect("Be wary, for inside great treasure and even greater danger awaits...");
            Console.ForegroundColor = ConsoleColor.Red;
            MyPlayer.playerNamer();
            Console.ForegroundColor = ConsoleColor.White;
            PrintEffect($"Ahh, {MyPlayer.name}, delve carefully. \nThe Master of the Dungeon is crafty and vicious!");
            BracketPutter("Enter the Dungeon!");
        }

        public void InitializaDungeonGrid() 
        {
            PrintEffect("Something crakles in the air. \nYou feel the dungeon shift as the doors slam shut. \nDust and rubble fall from the ceiling as new doors appear, sprouting for a previously solid wall.");
            for (int i = 0; i < rows; i++)
            {
                List<Room> row = new List<Room>();

                for (int j = 0; j < cols; j++)
                {
                    if (j == 0 && i == 0) //first room is entrance hall
                    {
                        Room EntranceHall = new Room($"Entrance Hall");
                        row.Add(EntranceHall);
                    }
                    else if (j == cols && i == rows) 
                    {
                        Room BossRoom = new Room($"Boss Room");
                        row.Add(BossRoom);
                    }
                    Room newRoom = new Room($"Room ({i}.{j})");
                    row.Add(newRoom);
                }

                dungeonGrid.Add(row);
            }
        }

        public void ExploreDungeonGrid(Player player)
        {
            Room selectedRoom = null;
            string direction = "";

            while (player.alive)
            {
                BracketPutter("Time to Explore");
                PrintEffect("Where would you like to go?");
                PrintEffect("Use commands: up, down, left, right , here.");
                direction = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(direction))//gimmie proper answer
                {
                    PrintEffect("Please enter a direction.");
                    continue;
                }

                // Calculate the new position based on the direction
                int newRow = playerRow, newColumn = playerCol;

                switch (direction)
                {
                    case "up":
                        newRow -= 1; 
                        break;
                    case "down":
                        newRow += 1; 
                        break;
                    case "left":
                        newColumn -= 1; 
                        break;
                    case "right":
                        newColumn += 1; 
                        break;
                    case "here": //for entrance hall
                        newRow = playerRow;
                        newColumn = playerCol;
                        break;
                    default:
                        PrintEffect("Invalid direction. Please use up, down, left, or right.");
                        continue;
                }

                // Check if the new position is within the bounds of the grid
                if (newRow < 0 || newRow >= dungeonGrid.Count || newColumn < 0 || newColumn >= dungeonGrid[0].Count)
                {
                    PrintEffect("You can't go that way. Try another direction.");
                    continue;
                }

                // Move to the new position
                playerRow = newRow;
                playerCol = newColumn;
                selectedRoom = dungeonGrid[playerRow][playerCol];

                // Check if the room has been explored
                if (!selectedRoom.hasBeenExplored)//SHOULD I ADD BOSS ROOM HERE?
                {
                    if (selectedRoom.Name.Equals("Entrance Hall", StringComparison.OrdinalIgnoreCase))
                    {
                        selectedRoom.EntranceRoomEncounter(MyPlayer);
                    }
                    else
                    {
                        selectedRoom.Encounter(MyPlayer);
                    }

                    if (selectedRoom.hasBeenExplored)
                    {
                        exploredRooms.Add(selectedRoom);
                    }
                }
                else
                {
                    PrintEffect($"You have already explored {selectedRoom.Name}. Nothing new to see here.");
                }

                // After exploring, print the current state of the grid to show player position
                PrintDungeonGrid();
            }
        }

        public void PrintDungeonGrid()
        {
            BracketPutter("Rooms Available");
            MakeItPurple("The rooms available to you are:\n");
            for (int i = 0; i < dungeonGrid.Count; i++)
            {
                for (int j = 0; j < dungeonGrid[i].Count; j++)
                {
                    var room = dungeonGrid[i][j];
                    if (i == playerRow && j == playerCol)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen; // Highlight player position
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"{room.Name}");
                        Console.ResetColor();
                    }
                    else if (exploredRooms.Contains(room))
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Color for explored rooms
                        Console.Write($"{room.Name}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Color for unexplored rooms
                        Console.Write($"{room.Name}");
                        Console.ResetColor();
                    }

                    if (j != dungeonGrid[i].Count - 1)
                    {
                        Console.Write(" | "); // Separator between rooms
                    }
                }
                Console.WriteLine(); // New line after each row
            }
        }

        public void FightBoss() 
        {
            rows = 4;
            List<Room> bossHallList = new List<Room>();
            Room bossRoom = new Room("Boss Room");
            bossHallList.Add( bossRoom );
            bossRoom.EncounterBossRoom(MyPlayer);
        }
    }
}

