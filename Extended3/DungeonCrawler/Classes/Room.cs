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
            Name = name;
        }

        public void MakeItGreen(string yourTextHere) 
        { 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(yourTextHere);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MakeItRed(string yourTextHere)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(yourTextHere);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void BracketPutter()//i want a bracket here
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------");
        }

        public void InitializeLoot() //get loot REMEMBER to move lloot after winning- except for Entrance hall which has only loot
        {
            BracketPutter();
            if (Name == "Entrance Hall")
            {
                Console.WriteLine("With daylight still shining behind you, you spot a curious object:");
            }
            else 
            { 
                Console.WriteLine("The Monster lies dead, and behind you spot a curious object:");
            }
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
            roomsVisited++;//add to rooms visitied only on fight
            int turnsElapsed = 0;
            while (player.alive && thisRoomMonster.alive)
            {
                if (turnsElapsed % 2 == 0) // Player hits monster
                {
                    MakeItGreen($"{player.name} ({player.health}) hit {thisRoomMonster.name} ({thisRoomMonster.health}).");
                    thisRoomMonster.health -= player.power;
                }
                else // Monster hits player
                {
                    MakeItRed($"{thisRoomMonster.name} ({thisRoomMonster.health}) hit {player.name} ({player.health}).");
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
        }

        public void Flee(Player player)//u need to pay more ATTENTION HERE
        {
            hasBeenExplored = false;
            Console.WriteLine("You've fled...");
            return;
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
                MakeItRed($"Will you flee, or will you fight?");
                action = Console.ReadLine();
                if ("fight".Equals(action, StringComparison.OrdinalIgnoreCase))
                {
                    MakeItGreen("Let's Fight!");
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
            MakeItRed("Brave adventurer, gird your loins!");
            player.announcePlayer();
            Console.WriteLine("Something in the room around you changes, a smell of stagnant death lingers in the air.");
            Console.WriteLine("You hear a creepy slithering sound, as all of a sudden you see two, bright red eyes, shining from the darkness.");
            InitializeMonster();
            while (string.IsNullOrWhiteSpace(action))
            {
                MakeItRed($"Will you flee, or will you fight?");
                action = Console.ReadLine();
                if ("fight".Equals(action, StringComparison.OrdinalIgnoreCase))
                {
                    MakeItGreen("Let's Fight!");
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


