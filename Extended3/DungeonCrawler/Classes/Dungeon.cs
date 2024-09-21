using PlayerClass;
using System;
using roomClass;
using static DungeonCrawler.Program;
using System.Security.Cryptography.X509Certificates;

namespace DungeonClass
{
    public class Dungeon
    {
        public List<Room> roomList = new List<Room> { };
        public List<Room> exploredRooms = new List<Room>();
        public Player MyPlayer { get; set; }
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
            Console.WriteLine($"--------------------------{yourStringHere}--------------------------");
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

        public void InitializeRooms()// minimum 3 rooms
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

        public void PrintRooms() 
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
        

        public void ExploreRoom() //get a room, initialaize and encounter CHECK IF ROOM EXPLORED
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

        public void FightBoss() 
        {
            Room bossRoom = new Room("Boss Room");
            bossRoom.EncounterBossRoom(MyPlayer);
        }
    }
}

