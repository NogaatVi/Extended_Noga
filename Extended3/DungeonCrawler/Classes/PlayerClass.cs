using System;
namespace Extended3.DungeonCrawler.Classes
{
    public class Player
    {
        public int level;
        public int power;
        public int health;
        public string name = "";

        public Player(int level, int power, int health, string name) //for player
        {
            this.level = level;
            this.power = power;
            this.health = health;
            this.name = name;
        }
        public string playerNamer()
        {
            Console.WriteLine("What is your name, brave dungeon delver?");
            return name;
        }

        public int reduceHealth() //if power < monsterPo
        {
            return health;
        }
        public int regenerateHealth()
        {
            return health;
        }
    }
}

