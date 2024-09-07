using System;
using Monsters;
using Players;
//using Loot;
namespace DungeonCrawler;
class Program
{
    public class Room
    {
        List<Monster> monsterList = new List<Monster> { };
        //List<Loot> lootList = new List<Loot> { };
        public Room()
        {

        }
    }

    public class Dungeon
    {
        List<Room> roomList = new List<Room>{};
        Player player = new Player(0 , 10 , 25);

        public Dungeon()//List<Room> roomList) 
        { 
            //this.roomList = roomList;
        }
        public void InitializeDungeon() 
        {
            Console.WriteLine("Welcome, dear adventurer, you are now at the gates of the Mystic Dungeon!");
            Console.WriteLine("Be wary, for inside great treasure and even greater danger awaits...");
            player.playerNamer();

        }
    }
        
    static void Main(string[] args)
    {
        Console.WriteLine("Dungeon Crawler let's go");
        Dungeon thisDungeon = new Dungeon();
        thisDungeon.InitializeDungeon();
        Console.ReadLine();
    }
}
