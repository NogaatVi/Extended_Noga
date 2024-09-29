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

namespace LootRoomClass
{
    public class LootRoom : Room
    {
        public string Name { get; set; }
        Random random = new Random();
        public int Shield;

        public LootRoom(string name) : base(name)
        {
            Name = name;
        }

        public override void DescribeRoom() 
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
            PrintEffect($"{descriptionList[num]}", ConsoleColor.Blue);
            roomDescription = descriptionList[num];
            descriptionList.RemoveAt( num );
        }//just for flavor

        public override void Encounter(Player player)// gain loot encounter
        {
            string action = "";
            BracketPutter(Name);
            MakeItColorful($"You've entered {Name}", ConsoleColor.Green);
            if (roomDescription == string.Empty)
            {
                DescribeRoom();
            }
            else
            {
                base.PrintEffect(roomDescription, ConsoleColor.Blue);
            }
            base.InitializeLoot();
            base.TakeLoot(player);
            player.regenerateHealth();
            hasBeenExplored = true;
            player.announcePlayer();
        }
    }
}


