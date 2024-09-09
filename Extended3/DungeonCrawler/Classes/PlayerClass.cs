using System;

namespace PlayerClass
{
    public class Player
    {
        public int level;
        public int power;
        public int health;
        public string name = null;

        public Player(int level, int power, int health) //for player
        {
            this.level = level;
            this.power = power;
            this.health = health;
        }
        public string playerNamer() //Name that bitch!
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What is your name, brave dungeon delver?");
            while (string.IsNullOrWhiteSpace(name))// if u try to be cheeky
            {
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Do not dawdle, Adventurer! What is your name?");
                }
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

