using System;
using PlayerClass;
using lootClass;
using MonsterClass;
using DungeonClass;

namespace roomClass
{
    public class Room
    {
        public string Name { get; set; }
        Loot loot = new Loot(0, "");
        Monster Monster = new Monster(0,0);
        bool win = false;
        public static int roomsInitialized = 0;
        public Room(string name)
        {
            roomsInitialized++;
            Name = name;
        }
        public void BracketPutter()//i want a bracket here
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------");
        }

        public void InitializeLoot() //get loot
        {
            BracketPutter();
            Console.WriteLine("Upon entering, you spot a curious object:");
            loot.lootNamer();
            loot.lootPowerSetter();
            loot.lootAnnouncer();
        }

        public void InitializeMonster() //get monster
        {
            BracketPutter();
            Monster.titleGiver();
            Monster.nameSetter();
            Monster.monsterPowerSetter();
            Monster.monsterAnnouncer();
        }

        public bool Fight(Player player)
        {
            return win;
        }

        public bool Flee(Player player)
        {
            return win;
        }

        public void Encounter(Player player)// finish encounter- compare monster and player power. bool win. 
        {
            BracketPutter();
            Console.WriteLine($"You've entered {Name}");
            InitializeLoot();
            InitializeMonster();
            Console.WriteLine($"Will you flee, or will you fight?");
            string action = Console.ReadLine();
            if ("fight".Equals(action, StringComparison.OrdinalIgnoreCase)) 
            { 
                Console.WriteLine("Fight!");
            }
            else if ("flee".Equals(action, StringComparison.OrdinalIgnoreCase)) 
            {
                Console.WriteLine("You've fled...");
            }
            else 
            {
                Console.WriteLine($"What will you do,{player.name}.");
                return;
            }

        }
    }
}


