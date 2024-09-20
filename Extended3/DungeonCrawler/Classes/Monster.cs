using System;
using PlayerClass;
namespace MonsterClass
{
	public class Monster
	{
        public int power;
        public int health;
        public string name = "Not a Name";
        public string title = "Not a Title";
        private static int monsterCounter = 0;//how many monster did we have by now?
        public bool alive = true;

        List<string> titleList = new List<string> { "The Fearsome", "The Mighty", "The Dreaded", "The Slimy", "The Indomitable"};
        List<string> nameList = new List<string> { "Morganna", "Samir", "Vincent", "Delila", "Noga", "Aviv" , "Lydia", "Shalev"};

        public Monster(int power, int health)//Constructor for monstere
        {
            this.power = power;
            this.health = health;
            monsterCounter++;
        }
        public string titleGiver()//get a fearsome title...
        {
            Random random = new Random();
            int num = random.Next(0, titleList.Count);
            title = titleList[num];
            return title;
        }

        public string nameSetter()// and add it to a silly name...
        {
            Random random = new Random();
            int num = random.Next(0, nameList.Count);
            name = title + " " + nameList[num];
            return name;
        }

        public void monsterPowerAndHealthSetter()// sets the power of monster depending on how many monster initialized
        {
            int incresingNum = 1;
            Random random = new Random();
            power = random.Next(incresingNum, 5);
            health = random.Next(incresingNum * 5, 10);
            switch (monsterCounter)
            {
                case 0:
                    power *= 1;
                    health *= 1;
                    incresingNum++;
                    break;

                case < 1:
                    power *= 2;
                    health *= 2;
                    incresingNum++;
                    break;

                case < 2:
                    power *= 3;
                    health *= 3;
                    incresingNum++;
                    break;

                case < 4:
                    power *= 4;
                    health *= 4;
                    incresingNum++;
                    break;

                case < 6:
                    power *= 5;
                    health *= 5;
                    incresingNum++;

                    break;

                case < 8:
                    power *= 6;
                    health *= 6;
                    incresingNum++;
                    break;
            }
        }

        public void monsterAnnouncer()//A big scary monster appears! Shout it from the rooftops! 
        {
            Console.WriteLine($"Before you stands {name}");
            Console.WriteLine($"Their power is ({power})");
            Console.WriteLine($"Their Health is ({health})");
        }

        public bool isAlive()
        {
            if (health < 0)
            {
                Console.WriteLine($"{name} has been vanquished!");
                return alive = false;
            }
            else
            {
                return alive = true;
            }
        }
    }
}


