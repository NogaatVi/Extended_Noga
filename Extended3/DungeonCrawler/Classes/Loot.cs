using System;
using PlayerClass;
namespace lootClass
{
    public class Loot
    {
        public int lootPower;
        string p1 ="";//for name setter
        string p2= "";//for name setter
        public string lootName = "";
        static int delay = 40;
        static void PrintEffect(string text)
        {
            foreach (char letter in text)
            {
                Console.Write(letter); // Print each letter
                Thread.Sleep(delay); // Wait for the specified delay
            }
            Console.WriteLine(); // Move to the next line after finishing
        }

        public Loot(int lootPower, string lootName)
        {
            this.lootPower = lootPower;
            this.lootName = lootName;
        }

        public void lootNamer() 
        {
            List<string> lootName0 = new List<string> { "Mordekainen's Great", "Sparkling Nando's", "A Worn", "A Simple", "A Good", "An Excellent" };
            List<string> lootName1 = new List<string> { "Sword", "Shield", "Cloak", "Magical Orb", "Lantern", "Pack", "Staff", "Tome", "Quiver", "Helm", "Boots", "Gauntlet", "Wand", };
            Random random = new Random();
            int num = random.Next(0, lootName0.Count);
            int num1 = random.Next(0, lootName1.Count);
            p1 = lootName0[num];
            p2 = lootName1[num1];
            lootName = $"{p1} {p2}";
        }

        public void lootPowerSetter() 
        {
            int basePower;
            Random random = new Random();
            basePower = random.Next(2, 5);
            if (lootName != null) 
            {
                if (lootName.Contains("A Worn"))
                {
                    basePower *= 1;
                }
                else if (lootName.Contains("A Simple"))
                {
                    basePower *= 1;
                }
                else if (lootName.Contains("A Good"))
                {
                    basePower *= 2;
                }
                else if (lootName.Contains("An Excellent")) 
                {
                    basePower *= 3;
                }
                else if (lootName.Contains("Sparkling Nando's"))
                {
                    basePower *= 5;
                }
                else if (lootName.Contains("Mordekainen's Great"))
                {
                    basePower *= 6;
                }
                else
                {
                    basePower *= 1;
                }
                lootPower = basePower;
            }
        }

        public void lootAnnouncer() 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (lootName != null)
            {
                PrintEffect($"Could it be?\n{lootName}!\nLooking closer, you assess it's power is {lootPower}.");
            }
            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}


