using System;
using PlayerClass;
using lootClass;
using MonsterClass;
using DungeonClass;

namespace roomClass
{
    public class Room
    {
        Loot loot = new Loot(0, "");
        Monster Monster = new Monster(0,0);
        public static int roomsInitialized = 0;
        public Room()
        {
            roomsInitialized++;
        }
        public void InitializeLoot() //get loot
        {
            Console.WriteLine("Upon entering the room, you spot a curious thing:");
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
            Console.WriteLine("Encounter");
            InitializeLoot();
            InitializeMonster();
        }
    }
}


