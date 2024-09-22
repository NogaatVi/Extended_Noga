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
        public Monster thisRoomMonster;
        public string monstersName = "";
        public bool hasBeenExplored = false;
        public static int roomsVisited;
        public string roomDescription = string.Empty;
        public int ranEvent;
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

        public void MakeItMagenta(string yourTextHere)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(yourTextHere);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MakeItBlue(string yourTextHere)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(yourTextHere);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MakeItRed(string yourTextHere)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(yourTextHere);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void BracketPutter(string myTextHere)//i want a bracket here
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n--------------------------{myTextHere}--------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void InitializeMonster() //get monster
        {
            BracketPutter("A Great Monster Appears!");
            if (thisRoomMonster == null) 
            { 
              thisRoomMonster = new Monster(0, 0);
              thisRoomMonster.titleGiver();
              thisRoomMonster.nameSetter();
              monstersName = thisRoomMonster.name;
              thisRoomMonster.monsterPowerAndHealthSetter();
            }
            thisRoomMonster.monsterAnnouncer();
        }

        public void InitializeLoot()
        {
            BracketPutter("Loot");
            if (Name == "Entrance Hall")
            {
                Console.WriteLine("With the sounds of the great doors shutting still ringing in your ears, you spot a curious object:");
            }
            else 
            {
                switch (ranEvent) 
                {
                    case 0: //monster
                        Console.WriteLine($"The Monster lies dead.\nit's dark blood pooling beneath it's massive body.\nBehind it, you spot a curious object:");
                        break;

                    case 1://monster
                        Console.WriteLine("The Monster twitches as it dies.\nThe twitches of it's jaws give you the creeps.\nNear it, you spot a curious object:");
                        break;

                    case 2://loot
                        Console.WriteLine($"You spot a hidden chest behind some rubble.\nIn it, youspot a curious object:");
                        break;

                    case 3://empty
                        Console.WriteLine($"There is nothing in the room;");
                        break;
                }
            }
            loot.lootNamer();
            loot.lootPowerSetter();
            loot.lootAnnouncer();
        }

        public void DescribeRoom() 
        {
            Random random = new Random();
            List<string> descriptionList = new List<string>
            {
                "The door creaks open on ancient hinges and you discover an old, decrepid kitchen.\nPots and pans still hand from hooks, and the smell of dust and mold hangs heavy inthe air.",
                "You Enter a curiously circular room.\nThe floor is lined with an intecat ancient carpet--You are afaraid to step on it, for it may crumble to dust at the barest touch",
                "A foul odor fills your nose as you push open a rotten looking door.\nPeeking Inside, you hesitate to think of what had left these human remains on the floor so broken.",
                "It's a small latrine! \nYou chuckle, 'Even monsters have to poo, huh?'",
                "As you push past a heavy steel door, you step on something that crunches.\n Looking down, you spy a long, thin bone. \nIt doesn't look like it belongs in a human.",
                "You should have known by the smell that you'd be stepping into an old beast's den. \nOn a scraggly looking nest you spy the broken remains of some large, colorful eggs. \nCurious.",
                "It's almost a relief finding an old torturer's dungeon. \nI'ts old metal contraptions, moth-eaten leather straps and scraming skulls are better then other thing you have seen...",
                "A long corridor lined with tarnished mirrors, each one showing twisted reflections that whisper your darkest fears. \nAs you pass by, the whispers grow louder, trying to drive you mad with the secrets they reveal.",
                "Shelves filled with dusty, ancient tomes line the walls, but each book is alive and bound with faces that scream when touched. \nThe texts constantly mutter spells of madness in forgotten languages.",
                "A seemingly cheerful room, decorated with colorful banners and enchanted with a perpetual giggle. \nAt first, it seems harmless—until the laughter starts to mimic your voice. \nIt mocks your every move and feeding on your insecurities. ",
                "Once a grand armory, this room is now filled with rusted weapons and shattered armor, all covered in a thick layer of dust. \nThe only light comes from a single, flickering torch in the corner. \nOccasionally, weapons or pieces of armor rattle or clatter as if disturbed by an invisible hand.",
                "An ancient storage room filled with rotten, decaying food and broken barrels. \nMice and giant insects scuttle in the darkness, and every shadow seems to hide something crawling. \nThe smell is putrid, and strange, wet sounds can be heard from the far corners. \nWhatever is hiding in the dark seems to be waiting for fresh meat.",
                "A cold, dark forge with tools scattered on the ground. \nThe furnace occasionally roars to life on its own, casting monstrous shadows that move when they shouldn’t.",
                "Rusted cages line the walls, their doors twisted open. \nThe stench of decay fills the air, and the soft pad of unseen paws follows you wherever you go.",
                "A circular chamber with a giant, painted eye on the ceiling. \nFrom the corner of your eye, you swear you saw it blink.",
                "An abandoned altar covered in melted candles and long-dead flowers. \nThe air is thick with the scent of old incense, and shadows seem to flit just beyond the light.", 
            };
            int num = random.Next(1, descriptionList.Count);
            MakeItBlue($"{descriptionList[num]}");
            roomDescription = descriptionList[num];
            descriptionList.RemoveAt( num );
        }//just for flavor

        public void Encounter(Player player)
        {
            string action = "";
            BracketPutter(Name);
            MakeItGreen($"You've entered {Name}");
            if (roomDescription == string.Empty) 
            { 
            DescribeRoom();
            }
            else
            {
                Console.WriteLine(roomDescription);
            }
            player.announcePlayer();

            Random random = new Random();
            ranEvent = random.Next(0, 3);

            switch (ranEvent) 
            {
                case 0:
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
                            Console.WriteLine($"What will you do,{player.name}.");
                            continue;
                        }
                    }
                    break;//get monster

                case 1:
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
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"What will you do,{player.name}.");
                            continue;
                        }
                    }
                    break;//get monster

                case 2:
                    InitializeLoot();
                    TakeLoot(player);
                    player.maxHealth += loot.lootPower;
                    player.regenerateHealth();
                    hasBeenExplored = true;
                    break;//get loot

                case 3:
                    Console.WriteLine("The room is eerily empty. \nOther than conwebs,there is nothing here for you.");
                    player.regenerateHealth();
                    hasBeenExplored = true;
                    break;//get empty room
            }
        }

        public void EntranceRoomEncounter(Player player)
        {
            roomsVisited++;
            BracketPutter("Entrance Hall");
            Console.WriteLine($"You've entered {Name}");
            if (!hasBeenExplored)
            {
                InitializeLoot();
                TakeLoot(player);
                Console.WriteLine($"You feel your power grow! ({player.power})");
                hasBeenExplored = true;
                ranEvent = 3;
            }
            else 
            {
                hasBeenExplored = true;
                ranEvent = 3;
                Console.WriteLine("You come back to the Entrance Hall, the doors to the outside world are shut.\nYou are still trapped inside.");
            }
        }

        public void EncounterBossRoom(Player player) 
        {
            string action = "";
            BracketPutter($"Mind yourself, {player.name}");
            player.announcePlayer();
            BracketPutter("Boss Time!");
            MakeItRed("Brave adventurer, gird your loins!");
            DescribeRoom();
            Console.WriteLine("Something around you changes, a smell of stagnant death lingers in the air.");
            Console.WriteLine("You hear a creepy slithering sound, as all of a sudden you see two, bright red eyes, shining from the darkness.");
            InitializeMonster();
            while (string.IsNullOrWhiteSpace(action))
            {
                MakeItRed($"It's the final battle! \nWill you flee, or will you fight?");
                action = Console.ReadLine();
                if ("fight".Equals(action, StringComparison.OrdinalIgnoreCase))
                {
                    MakeItGreen("Let's do this!");
                    Fight(player);
                    if (player.alive)//if u lived after fightning
                    {
                        player.regenerateHealth();
                        Console.WriteLine("With the great monster laying dead, you here the sound of the dungeon's doors opening again. \nYou are free!");
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

        public void Fight(Player player)
        {
            roomsVisited++;//add to rooms visitied only on fight
            int turnsElapsed = 0;
            while (player.alive && thisRoomMonster.alive)
            {
                if (turnsElapsed % 2 == 0) // Player hits monster
                {
                    MakeItGreen($"{player.name} ({player.health}) attacked {thisRoomMonster.name} ({thisRoomMonster.health}).");
                    thisRoomMonster.health -= player.power;
                }
                else // Monster hits player
                {
                    MakeItRed($"{thisRoomMonster.name} ({thisRoomMonster.health}) attacked {player.name} ({player.health}).");
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
        }//lets go

        public void Flee(Player player)//let's NOT go
        {
            hasBeenExplored = false;
            MakeItRed("You've fled...\nThere is no shame in coming back with more power!");
            return;
        }

        public void TakeLoot(Player player) 
        {
            player.power += loot.lootPower;
        }


    }
}


