using PlayerClass;
using System;
using roomClass;
using static DungeonCrawler.Program;

namespace DungeonClass
{
    public class Dungeon
    {
        List<Room> roomList = new List<Room> { };
        public Player MyPlayer { get; set; }
        public Dungeon(Player player)
        {
            MyPlayer = player;
        }

        public void InitializePlayer()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome, dear adventurer, you are now at the gates of the Mystic Dungeon!");
            Console.WriteLine("Be wary, for inside great treasure and even greater danger awaits...");
            MyPlayer.playerNamer();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Ahh, {MyPlayer.name}, delve carefully, or the master of the Dungeon will get you!");
            Console.WriteLine("Now get ready, and go!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------");
        }

        public void InitializeRooms()// minimum 3 rooms
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You feel the dungeon shift, dust and rubble fall from the ceiling as new doors appear.");
            Random random = new Random();
            int roomAmount = random.Next(3, 8);
            for (int i = 0; i <= roomAmount; i++)//set dynamic room names 
            {
                if (i==0) 
                {
                    roomList.Add(new Room("Entrance Hall"));
                }
                else if (i == roomAmount) 
                {
                    roomList.Add(new Room("Boss Room"));
                }
                else 
                {
                    roomList.Add(new Room($"Room {i}"));
                }
            }
            PrintRooms();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------");
        }

        public void PrintRooms()//works :) 
        {
            Console.WriteLine("The rooms available to you are:");
            Console.WriteLine(string.Join(", ", roomList.Select(room => room.Name)));
        }

        public void ExploreRoom() //get a room, get the ball rolling- initialaize and encounter CHECK IF ROOM EXPLORED
        {
            Room selectedRoom = null;
            string roomName = "";

            while (selectedRoom == null)//name looper- give me propper name!
            {
                Console.WriteLine("What room would you like to explore?");
                roomName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(roomName))
                {
                    Console.WriteLine("Invalid room. Please try again.");
                    continue;
                }
                selectedRoom = roomList.FirstOrDefault(room => room.Name == roomName);
                if (selectedRoom== null)
                {
                    Console.WriteLine("Room not found. Please try again.");
                }
            }
            //Special rooms
            if (roomName.Equals("Entrance Hall", StringComparison.OrdinalIgnoreCase))
            {
                selectedRoom.EntranceRoomEncounter(MyPlayer);
            }
            else if (roomName.Equals("Boss Room", StringComparison.OrdinalIgnoreCase))
            {
            }
            else 
            {
                selectedRoom.Encounter(MyPlayer); //if not special room just reg encounter
            }
            
        }
    }
}

