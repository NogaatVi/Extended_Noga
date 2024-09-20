using System;
using PlayerClass;
using lootClass;
using MonsterClass;
using DungeonClass;
using System.Numerics;

namespace roomClass
{
    public class Room
    {
        public string Name { get; set; }
        Loot loot = new Loot(0, "");
        Monster thisRoomMonster = new Monster(0, 0);
        bool hasBeenExplored = false;
        public static int roomsVisited = 0;
        public Room(string name)
        {
            roomsVisited++;
            Name = name;
        }
        public void BracketPutter()//i want a bracket here
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------");
        }

        public void InitializeLoot() //get loot REMEMBER to move lloot after winning- except for Entrance hall which has only loot
        {
            BracketPutter();
            Console.WriteLine("The Monster lies dead, and behind you spot a curious object:");
            loot.lootNamer();
            loot.lootPowerSetter();
            loot.lootAnnouncer();
        }

        public void InitializeMonster() //get monster
        {
            BracketPutter();
            thisRoomMonster.titleGiver();
            thisRoomMonster.nameSetter();
            thisRoomMonster.monsterPowerAndHealthSetter();
            thisRoomMonster.monsterAnnouncer();
        }

        public void Fight(Player player)
        {
            int turnsElapsed = 0;
            while (player.alive && thisRoomMonster.alive)
            {
                if (turnsElapsed % 2 == 0) // Player hits monster
                {
                    Console.WriteLine($"{player.name} ({player.health}) hit {thisRoomMonster.name} ({thisRoomMonster.health}).");
                    thisRoomMonster.health -= player.power;
                }
                else // Monster hits player
                {
                    Console.WriteLine($"{thisRoomMonster.name} ({thisRoomMonster.health}) hit {player.name} ({player.health}).");
                    player.health -= thisRoomMonster.power;
                }

                player.isAlive();//check if both alive
                thisRoomMonster.isAlive();

                if (!player.alive || !thisRoomMonster.alive)
                {
                    break; // Stop if somone dead
                }

                turnsElapsed++;
            }
            Console.WriteLine("Encounter Over");//FOR TEST
        }

        public void Flee(Player player)//u need to pay more ATTENTION HERE
        {
            hasBeenExplored = false;
            Console.WriteLine("You've fled...");
        }

        public void TakeLoot(Player player) 
        {
            player.power += loot.lootPower;
        }

        public void Encounter(Player player)
        {
            string action = "";
            BracketPutter();
            Console.WriteLine($"You've entered {Name}");
            player.announcePlayer();
            InitializeMonster();
            while (string.IsNullOrWhiteSpace(action)) 
            {
                Console.WriteLine($"Will you flee, or will you fight?");
                action = Console.ReadLine();
                if ("fight".Equals(action, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Let's Fight!");
                    Fight(player);
                    if (player.alive)//if u lived after fightning
                    {
                        InitializeLoot();
                        TakeLoot(player);
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
                    break;
                }
                else
                {
                    Console.WriteLine($"What will you do,{player.name}.");
                    continue;
                }
            }
        }

        public void EntranceRoomEncounter(Player player)
        {
            BracketPutter();
            Console.WriteLine($"You've entered {Name}");
            InitializeLoot();
            TakeLoot(player);
            Console.WriteLine($"You feel your power grow! ({player.power})");
            hasBeenExplored = true;
        }

        public void EncounterBossRoom(Player player) 
        {
            string action = "";
            BracketPutter();
            Console.WriteLine("Brave adventurer, gird your loins!");
            player.announcePlayer();
            Console.WriteLine("Something in the room around you changes, a smell of stagnant death lingers in the air.");
            Console.WriteLine("You hear a creepy slithering sound, as all of a sudden you see two, bright red eyes, shining from the darkness.");
            InitializeMonster();
            while (string.IsNullOrWhiteSpace(action))
            {
                Console.WriteLine($"Will you flee, or will you fight?");
                action = Console.ReadLine();
                if ("fight".Equals(action, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Let's Fight!");
                    Fight(player);
                    if (player.alive)//if u lived after fightning
                    {
                        InitializeLoot();
                        TakeLoot(player);
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
                    break;
                }
                else
                {
                    Console.WriteLine($"What will you do,{player.name}.");
                    continue;
                }
            }
        }
    }
}


