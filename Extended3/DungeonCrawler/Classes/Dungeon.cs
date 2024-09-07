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
        public void InitializeRooms()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You feel the dungeon shift, dust and rubble falling from the ceiling as new doors appear.");
            Random random = new Random();
            int roomAmount = random.Next(1, 13);
            for (int i = 0; i < roomAmount; i++)
            {
                roomList.Add(new Room($"Room{i + 1}"));
                Console.WriteLine(roomList[i].Name);
            }
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------");
        }
        public void EnterRoom() 
        {
        }
    }
}

