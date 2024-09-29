﻿using System;
using System.Net.Mail;
using MonsterClass;

namespace PlayerClass
{
    public class Player
    {
        public int power;
        public int health;
        public int maxHealth = 20;
        public string name = null;
        public bool alive = true;
        List<string> playerTitles = new List<string> 
        { 
            "The Valiant",
            "The Courageous",
            "The Unyielding",
            "The Resolute",
            "The Noble",
            "The Indomitable"
        };

        static int delay = 40;
        static void PrintEffect(string text)
        {
            foreach (char letter in text)
            {
                Console.Write(letter); // Print each letter
                Thread.Sleep(delay); // Wait for the specified delay
            }
            Console.WriteLine(); // Move to the next line after finishing
        }

        public Player( int power, int health) //for player
        {
            this.power = power;
            this.health = health;
        }

        public void getDamage(int damage) 
        {
            health -= damage;
        }

        public string playerNamer() //Name that bitch!
        {
            Console.WriteLine("What is your name, brave dungeon delver?");
            while (string.IsNullOrWhiteSpace(name))// if u try to be cheeky
            {
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Do not dawdle, Adventurer! What is your name?");
                }
            }
            Random random = new Random();
            int num = random.Next(0, playerTitles.Count);
            name = playerTitles[num]+ " " + name;
            return name;
        }

        public void regenerateHealth()
        {
            health = maxHealth;   
        }//very simple back to max health 

        public void announcePlayer() 
        {
            PrintEffect($"{name}, your power is {power}, and your health is {health}.");
        }

        public bool isAlive() 
        {
            if (health <= 0)
            {
                return alive = false;
            }
            else 
            {
                return alive = true;
            }
        }
    }
}

