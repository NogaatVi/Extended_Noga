using System;
namespace Creature
{
	public class Creature
	{
        public int level;
        public int power;
        public int health;
        public string name = "";

        public Creature(int level, int power, int health, string name) //for player
        {
            this.level = level;
            this.power = power;
            this.health = health;
            this.name = name;
        }
        public Creature(int power, int health, string name)//for creature
        {
            this.power = power;
            this.health = health;
            this.name = name;
        }

        public int reduceHealth() //if power < monsterPo
        {
            return health;
        }
        public int regenerateHealth()
        {
            return health;
        }
    }
    public class Monster : Creature
    {
            List<string> titleList = new List<string> { "The Fearsome", "The Mighty", "The Dreaded", "The Slimy", "The Indomitable" };
            List<string> nameList = new List<string> { "Morganna", "Samir", "Vincent", "Delila", "Noga" };
            string title = "Not a Title what is happening with this rep?";
            public Monster(int power, int health, string name, string title) : base(power, health, name)
            {
                this.power = power;
                this.health = health;
                this.name = name;
                this.title = title;
            }
            public string titleGiver()//get a fearsome title...
            {
                Random random = new Random();
                int num = random.Next(0, 4);
                title = titleList[num];
                return title;
            }
            public string nameSetter()// and add it to a silly name...
            {
                Random random = new Random();
                int num = random.Next(0, 4);
                title = string.Join(title, nameList[num]);
                return name;
            }
    }
    public class Player : Creature
    {
        public Player(int level, int power, int health, string name) : base(level, power, health, name)
        {
        }
    }
}


