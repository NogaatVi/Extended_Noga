namespace DungeonCrawler;

class Program
{
    public class Loot
    {
        

    }

    public class Room
    {
        List<Creature> monsterList = new List<Creature> { };
        List<Loot> lootList = new List<Loot> { };

    }

    public class Dungeon
    {
        List<Room> roomList = new List<Room> { };
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Dungeon Crawler let's go");
    }
}

