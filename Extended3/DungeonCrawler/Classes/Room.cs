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
        public static int roomsInitialized = 0;
        public Room(string name)
        {
            roomsInitialized++;
            Name = name;
        }
        public void InitializeLoot() //get loot
        {
            Console.WriteLine("Upon entering, you spot a curious object:");
            loot.lootNamer();
            loot.lootPowerSetter();
            loot.lootAnnouncer();
        }
        public void InitializeMonster() //get monster
        {
            Monster.titleGiver();
            Monster.nameSetter();
            Monster.monsterPowerSetter();
            Monster.monsterAnnouncer();
        }
        public void Encounter(Player player)// finish encounter- compare monster and player power. bool win. 
        {
            Console.WriteLine($"You've entered {Name}");
            InitializeLoot();
            InitializeMonster();
            Console.WriteLine($"Will you flee, or will you fight?");
            if ("fight".Equals(Console.ReadLine(), StringComparison.OrdinalIgnoreCase)) 
            { 
                Console.WriteLine("Fight!");
            }
            else if ("flee".Equals(Console.ReadLine(), StringComparison.OrdinalIgnoreCase)) 
            {
                Console.WriteLine("You've fled...");
            }
            else 
            {
                Console.WriteLine("Invalid Option.");
                return;
            }

        }
    }
}


