using System;
using System.Net.Mail;
using MonsterClass;

namespace PlayerClass
{
    public class Player
    {
        public int level;
        public int power;
        public int health;
        public int maxHealth = 20;
        public string name = null;
        public bool alive = true;

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
        public void regenerateHealth()
        {
            health = maxHealth;   
        }//very simple back to max health 
        public void announcePlayer() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{name}, your power is {power}, and your health is {health}.");
        }
        public bool isAlive() 
        {
            if (health > 0)
            {
                return alive = true;
            }
            else 
            {
                Console.WriteLine("Oh no! You've died!");
                return alive = false;
            }
        }
    }
}

