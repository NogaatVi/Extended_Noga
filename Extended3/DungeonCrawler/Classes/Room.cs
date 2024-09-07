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
        public Room()
        {
            
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
        public void Encounter(Player player) 
        {
            InitializeLoot();
            InitializeMonster();
        }
    }
}


