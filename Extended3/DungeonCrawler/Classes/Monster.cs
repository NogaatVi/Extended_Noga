using System;
namespace MonsterClass
{
	public class Monster
	{
        public int power;
        public int health;
        public string name = "Not a Name";
        public string title = "Not a Title";
        private static int monsterCounter = 0;

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
        public int monsterPowerSetter()// sets the power of monster depending on how many monster initialized
        {
            Random random = new Random();
            power = random.Next(2, 5);
            switch (monsterCounter)
            {
                case 0:
                    power *= 1;
                    break;

                case <= 3:
                    power *= 2;
                    break;

                case <= 6:
                    power *= 3;
                    break;

                case <= 9:
                    power *= 4;
                    break;

                case <= 12:
                    power *= 5;
                    break;

                case <= 15:
                    power *= 6;
                    break;
            }
            return power;
        }
        public void monsterAnnouncer()//A big scary monster appears! Shout it from the rooftops! 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Before you stands {name}");
            Console.WriteLine($"Their power is great! ({power})");
            Console.WriteLine("Tremble in fear, Mortal!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
    }
}


