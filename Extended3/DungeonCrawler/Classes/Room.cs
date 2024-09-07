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
            Console.WriteLine("Upon entering the room, you spot a curious thing:");
            loot.lootNamer();
            loot.lootPowerSetter();
            loot.lootAnnouncer();
        }
    }
}


