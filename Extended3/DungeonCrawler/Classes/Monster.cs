using System;
namespace MonsterClass
{
	public class Monster
	{
        public int power;
        public int health;
        public string name = "Not a Name";
        public string title = "Not a Title";

        List<string> titleList = new List<string> { "The Fearsome", "The Mighty", "The Dreaded", "The Slimy", "The Indomitable"};
        List<string> nameList = new List<string> { "Morganna", "Samir", "Vincent", "Delila", "Noga"};

        public Monster(int power, int health)//Constructor for monstere
        {
            this.power = power;
            this.health = health;
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
        public void monsterAnnouncer() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Before you stand the fearsome {name}");
            Console.WriteLine("Tremble in fear, mortal!");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}


