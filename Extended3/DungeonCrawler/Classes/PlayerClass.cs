using System;

namespace PlayerClass
{
    public class Player
    {
        public int level;
        public int power;
        public int health;
        public string name;

        public Player(int level, int power, int health) //for player
        {
            this.level = level;
            this.power = power;
            this.health = health;
        }
        public string playerNamer() //Name that bitch!
        {
            while (name == null) 
            {
                Console.WriteLine("What is your name, brave dungeon delver?");
                name = Console.ReadLine();
            }
            return name;
        }
        public int reduceHealth() //nothing here yet
        {
            return health;
        }
        public int regenerateHealth()
        {
            return health;
        }//nothing here yet
    }
}

