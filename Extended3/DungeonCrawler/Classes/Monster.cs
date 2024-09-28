using System;
using PlayerClass;

namespace MonsterClass
{
	public abstract class Monster
	{
        public int power;
        public int health;
        public int shield;
        public string name = "Not a Name";
        public string title = "Not a Title";
        public bool alive = true;

        private int maxMonsterHealthThreshold = 8;
        private int maxMonstherPowerThreshold = 6;
        
        Random random = new Random();

        public  static int monsterCounter = 1;//how many monster did we have by now?

        static int delay = 40;

        List<string> titleList = new List<string> 
        { "The Fearsome", "The Mighty", "The Dreaded", "The Slimy", "The Indomitable", "The Unholy" , "The Voracious" , "The Relentless" };
        List<string> nameList = new List<string> 
        { "Morganna", "Samir", "Vincent", "Delila", "Noga", "Aviv" , "Lydia", "Shalev" , "Mario" ,"Goombelino"};

        public Monster(int power, int health, int shield)
        {
            this.power = power;
            this.health = health;
            this.shield = shield;
        }

        public void printEffect(string text)
        {
            foreach (char letter in text)
            {
                Console.Write(letter); // Print each letter
                Thread.Sleep(delay); // Wait for the specified delay
            }
            Console.WriteLine(); // Move to the next line after finishing
        }

        public string titleGiver()//get a fearsome title...
        {
            int num = random.Next(0, titleList.Count);
            title = titleList[num];
            return title;
        }

        public string nameSetter()// and add it to a silly name...
        {
            int num = random.Next(0, nameList.Count);
            name = title + " " + nameList[num];
            return name;
        }

        public virtual void monsterPowerAndHealthSetter()// sets the power of monster depending on how many monster initialized
        {
            
            Random random = new Random();
            power = random.Next(monsterCounter, monsterCounter + maxMonsterHealthThreshold);
            health = random.Next(monsterCounter * 2, monsterCounter * maxMonstherPowerThreshold);
            switch (monsterCounter)
            {
                case 1:
                    power *= 1;
                    health *= 1;
                    break;

                case < 3:
                    power *= 2;
                    health *= 2;
                    break;

                case < 4:
                    power *= 3;
                    health *= 3;
                    break;

                case < 5:
                    power *= 4;
                    health *= 4;
                    break;

                case < 6:
                    power *= 5;
                    health *= 5;
                    break;

                case < 8:
                    power *= 6;
                    health *= 6;
                    break;

            }
            monsterCounter++;
        }

        public  virtual void introduceMonster()
        {
            Random random = new Random();
            List<string> descriptionList = new List<string>
            {
                $"Coalescing from acrid, yellow smoke, it's {name}.\nIt's teeth gleam in the low light as it prepares to attack!", 
                $"Slithering from a hidden crevice,  it's {name}.\nIt gurgles as it leaps for your throat!",
                $"Spitting out old bones, it's {name}.\nIt grins hideiously before running at you, full tilt.",
                $"Brandishing impressively sharp claws,  it's {name}.\nWatch yourself, this may get ugly.",
                $"Revealing itself with an ear-splitting shriek, it's {name}.\nIt yips and snarls, moving in twitching leaps and bounds.",
                $"Landing with a sickening crunch, it's {name}.\nIt's massive girth makes you tremble in your boots.",
                $"Skittering up a wall, it's {name}.\nIt's jaw opens strangley, like a flower filled with razor-sharp teeth.",
                $"Hanging from a crumbling pillar, it's {name}.\nIt's tail snakes around, vicious like a whip.",
                $"Leaping from a darkened corner, it's {name}.\nIt's razor-sharp teeth are bare and ready.",
            };
            int num = random.Next(1, descriptionList.Count);
            printEffect($"{descriptionList[num]}");
        }//For flavor

        public void announceMonster()//A big scary monster appears! Shout it from the rooftops! 
        {
            introduceMonster();
            printEffect($"Their power is ({power})");
            printEffect($"Their Health is ({health})");
        }

        public virtual bool isAlive()
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
        }//are you alive?

        public virtual void getDamage(int damage) 
        {
            health -= damage;
        }
    }
}


