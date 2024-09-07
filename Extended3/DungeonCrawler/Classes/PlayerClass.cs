using System;

namespace PlayerClass
{
    public class Player
    {
        public int level;
        public int power;
        public int health;
        public string name = "not a name";

        public Player(int level, int power, int health) //for player
        {
            this.level = level;
            this.power = power;
            this.health = health;
        }
        public string playerNamer()
        {
            Console.WriteLine("What is your name, brave dungeon delver?");
            name = Console.ReadLine();
            while (name == null) 
            {
               name = Console.ReadLine();
            }
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

