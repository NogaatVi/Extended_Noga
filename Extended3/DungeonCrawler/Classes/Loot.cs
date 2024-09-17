﻿using System;
using PlayerClass;
namespace lootClass
{
    public class Loot
    {
        public int lootPower;
        string p1 ="";//for name setter
        string p2= "";//for name setter
        public string lootName = "";
        public Loot(int lootPower, string lootName)
        {
            this.lootPower = lootPower;
            this.lootName = lootName;
        }

        public void lootNamer() 
        {
            List<string> lootName0 = new List<string> { "Mordekainen's Great", "Sparkling Nando's", "A Broken", "A Simple", "A Good", "An Excellent" };
            List<string> lootName1 = new List<string> { "Sword", "Shield", "Cloak", "Orb", "Lantern", "Pack", "Staff", "Whip" };
            Random random = new Random();
            int num = random.Next(0, lootName0.Count);
            int num1 = random.Next(0, lootName1.Count);
            p1 = lootName0[num];
            p2 = lootName1[num1];
            lootName = $"{p1} {p2}";
        }

        public int lootPowerSetter() 
        {
            int basePower;
            Random random = new Random();
            basePower = random.Next(1, 5);
            if (lootName != null) 
            {
                if (lootName.Contains("A Broken"))
                {
                    basePower *= 1;
                }
                else if (lootName.Contains("A Simple"))
                {
                    basePower *= 2;
                }
                else if (lootName.Contains("A Good"))
                {
                    basePower *= 3;
                }
                else if (lootName.Contains("An Excellent")) 
                {
                    basePower *= 4;
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
                return lootPower;
            }
            lootPower = basePower;
            return lootPower;
        }

        public void lootAnnouncer() 
        {
            if (lootName != null)
            {
                Console.WriteLine($"Could it be? {lootName}?");
                Console.WriteLine($"If you squint, you assess it's power is {lootPower}");
            }
        }
    }
}


