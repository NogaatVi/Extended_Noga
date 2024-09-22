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

        public void MakeItPurple(string yourStringHere) 
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(yourStringHere);
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
            Console.WriteLine("Welcome, dear adventurer! \nYou are now at the gates of the Mystic Dungeon!");
            Console.WriteLine("Be wary, for inside great treasure and even greater danger awaits...");
            Console.ForegroundColor = ConsoleColor.Red;
            MyPlayer.playerNamer();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Ahh, {MyPlayer.name}, delve carefully. \nThe Master of the Dungeon is crafty and vicious!");
            BracketPutter("Enter the Dungeon!");
        }

        public void InitializeRooms()//OLD OLD OLD
        {
            Console.WriteLine("Something crakles in the air. \nYou feel the dungeon shift as the doors slam shut. \nDust and rubble fall from the ceiling as new doors appear, sprouting for a previously solid wall.");
            Random random = new Random();
            int roomAmount = random.Next(3, 8);
            for (int i = 0; i <= roomAmount; i++)//set dynamic room names 
            {
                if (i==0) 
                {
                    roomList.Add(new Room("Entrance Hall"));
                }
                else 
                {
                    roomList.Add(new Room($"Room {i}"));
                }
            }
        }

        public void PrintRooms()//OLD OLD OLD 
        {
            BracketPutter("Rooms Available");
            MakeItPurple("The rooms available to you are:");
            foreach (var room in roomList)
            {
                if (exploredRooms.Contains(room))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(room.Name);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(room.Name);
                }

                if (room != roomList[^1]) 
                {
                    Console.Write(", ");
                }
            }

            // just to make sure
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ExploreRoom() //OLD OLD OLD
        {
            Room selectedRoom = null;
            string roomName = "";

            while (selectedRoom == null) 
            {
                BracketPutter("Time to Explore");
                Console.WriteLine("What room would you like to explore?");
                roomName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(roomName))
                {
                    Console.WriteLine("Please try again.");
                    continue;
                }
                selectedRoom = roomList.FirstOrDefault(room => room.Name == roomName);
                if (selectedRoom== null)
                {
                    Console.WriteLine("Room not found. Please try again.");
                }
            } //name looper- give me propper name!

            //Special rooms
            if (!selectedRoom.hasBeenExplored)
            {
                if (roomName.Equals("Entrance Hall", StringComparison.OrdinalIgnoreCase))
                {
                    selectedRoom.EntranceRoomEncounter(MyPlayer);
                    if (selectedRoom.hasBeenExplored) 
                    { 
                       exploredRooms.Add(selectedRoom);//if roomhas been explored (not fled)
                    }
                }
                else if (roomName.Equals("Boss Room", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{MyPlayer.name}, don't be hasty! The dungeon's master is crafty--Conserve your power!");
                }
                else
                {
                    selectedRoom.Encounter(MyPlayer); //if not special room just reg encounter
                    if (selectedRoom.hasBeenExplored) 
                    { 
                       exploredRooms.Add(selectedRoom);//if roomhas been explored (not fled)
                    }
                }
            }
            else 
            {
                if (roomName.Equals("Entrance Hall", StringComparison.OrdinalIgnoreCase)) 
                {
                    Console.WriteLine("You try pulling the exit's handles--But they will not budge.");
                }
                else 
                { 
                    Console.WriteLine($"This room has already been explored. \n{selectedRoom.monstersName} is lying dead on the ground.");
                }
            }
        }

        public void InitializaDungeonGrid() 
        {
            Console.WriteLine("Something crakles in the air. \nYou feel the dungeon shift as the doors slam shut. \nDust and rubble fall from the ceiling as new doors appear, sprouting for a previously solid wall.");
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
                Console.WriteLine("Where would you like to go?");
                Console.WriteLine("Use commands: up, down, left, right , here.");
                direction = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(direction))//gimmie proper answer
                {
                    Console.WriteLine("Please enter a direction.");
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
                        Console.WriteLine("Invalid direction. Please use up, down, left, or right.");
                        continue;
                }

                // Check if the new position is within the bounds of the grid
                if (newRow < 0 || newRow >= dungeonGrid.Count || newColumn < 0 || newColumn >= dungeonGrid[0].Count)
                {
                    Console.WriteLine("You can't go that way. Try another direction.");
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
                    Console.WriteLine($"You have already explored {selectedRoom.Name}. Nothing new to see here.");
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

