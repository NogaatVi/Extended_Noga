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

namespace MonsterRoomClass
{
    public class MonsterRoom : Room
    {
        Random random = new Random();

        public MonsterRoom(string name) : base(name)
        {
            Name = name;
        }

        public override void InitializeMonster() //done
        {
            BracketPutter("A Great Monster Appears!");
            if (thisRoomMonster == null) 
            {
                ranEvent = random.Next(0, 3);
                switch (ranEvent) 
                {
                    case 0:
                    thisRoomMonster = new RageMonster(0, Monster.monsterCounter, 0);
                        Console.WriteLine("Rage Monster");
                    break;

                    case 1:
                        thisRoomMonster = new EliteMonster(0, 0, 0, Monster.monsterCounter);
                        Console.WriteLine("Elite Monster");
                        break;

                    case 2:
                        thisRoomMonster = new ShieldedMonster(0, 0, Monster.monsterCounter);
                        Console.WriteLine("Shield Monster");

                        break;
                    case 3:
                        thisRoomMonster = new RegularMonster(0, 0, 0);
                        Console.WriteLine("Regular Monster");

                        break;
                }
              thisRoomMonster.titleGiver();
              thisRoomMonster.nameSetter();
              monstersName = thisRoomMonster.name;
              thisRoomMonster.monsterPowerAndHealthSetter();
            }
            thisRoomMonster.announceMonster();
        }

        public override void InitializeLoot()
        {
            BracketPutter("Loot");
            base.ranEvent = random.Next(0,3);
            switch (base.ranEvent) 
                {
                    case 0: //monster
                        PrintEffect($"The Monster lies dead.\nit's dark blood pooling beneath it's massive body.\nBehind it, you spot a curious object:", ConsoleColor.Yellow);
                        break;

                    case 1://monster
                        PrintEffect("The Monster twitches as it dies.\nThe twitches of it's jaws give you the creeps.\nNear it, you spot a curious object:", ConsoleColor.Yellow);
                        break;

                    case 2://loot
                        PrintEffect($"You spot a hidden chest behind some rubble.\nIn it, youspot a curious object:", ConsoleColor.Yellow);
                        break;

                    case 3://empty
                        PrintEffect($"There is nothing in the room;", ConsoleColor.Yellow);
                        break;
                }
            loot.lootNamer();
            loot.lootPowerSetter();
            loot.lootAnnouncer();
        }

        public override void Encounter(Player player)
        {
            string action = "";
            base.BracketPutter(Name);
            base.MakeItColorful($"You've entered {Name}", ConsoleColor.Green);
            if (roomDescription == string.Empty) 
            { 
                DescribeRoom();
            }
            else
            {
                PrintEffect(roomDescription, ConsoleColor.Blue);
            }
            player.announcePlayer();
            base.InitializeMonster();
            while (string.IsNullOrWhiteSpace(action))
            {
              base.MakeItColorful($"Will you flee, or will you fight?", ConsoleColor.Red);
              action = Console.ReadLine();
              if ("fight".Equals(action, StringComparison.OrdinalIgnoreCase))
                        {
                            base.MakeItColorful("Let's Fight!", ConsoleColor.Red);
                            base.Fight(player);
                            if (player.alive)//if u lived after fightning
                            {
                                base.InitializeLoot();
                                base.TakeLoot(player);
                                player.maxHealth += loot.lootPower;
                                player.regenerateHealth();
                                hasBeenExplored = true;
                                break;
                            }
                            else
                            {
                                //have game intiializing here
                                hasBeenExplored = true;
                                break;
                            }
                        }
              else if ("flee".Equals(action, StringComparison.OrdinalIgnoreCase))
                        {
                            Flee(player);
                            return;
                        }
              else
                        {
                            PrintEffect($"What will you do,{player.name}.", ConsoleColor.White);
                            continue;
                        }
            }
            player.announcePlayer();
        }
    }
}


