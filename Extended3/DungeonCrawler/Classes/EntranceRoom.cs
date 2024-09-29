using System;
using PlayerClass;
using lootClass;
using MonsterClass;
using DungeonClass;
using System.Numerics;
using RageMonsterClass;
using EliteMonsterClass;
using ShieldedMonsterClass;
using RegularMonsterClass;
using roomClass;

namespace EntranceroomClass
{
    public  class EntranceRoom : Room
    {
        Random random = new Random();
        public int ranEvent;

        public EntranceRoom(string name) : base(name)
        {
            Name = name;
        }

        static int delay = 20;

        public override void Encounter(Player player)
        {
            roomsVisited++;
            BracketPutter("Entrance Hall");
            PrintEffect($"You've entered {Name}", ConsoleColor.White);
            if (!hasBeenExplored)
            {
                InitializeLoot();
                TakeLoot(player);
                PrintEffect($"You feel your power grow! ({player.power})", ConsoleColor.White);
                hasBeenExplored = true;
                ranEvent = 3;
            }
            else 
            {
                hasBeenExplored = true;
                ranEvent = 3;
                PrintEffect("You come back to the Entrance Hall, the doors to the outside world are shut.\nYou are still trapped inside.", ConsoleColor.White);
            }
        }

    }
}


