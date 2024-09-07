using System;
using PlayerClass;
using lootClass;
using MonsterClass;
namespace roomClass
{
    public class Room
    {
        Loot loot = new Loot(0, "");
        Monster Monster = new Monster(0,0);
        public Room()
        {
            
        }
        public void InitializeLoot() 
        {
            Console.WriteLine("Upon entering the room, you spot a curious thing:");
            loot.lootNamer();
            loot.lootPowerSetter();
            loot.lootAnnouncer();
        }//get loot
        public void InitializeMonster() 
        {
            Monster.titleGiver();
            Monster.nameSetter();
            Monster.monsterAnnouncer();
        }//get monster
        public void Encounter() 
        {
            InitializeLoot();
            InitializeMonster();
        }
    }
}


