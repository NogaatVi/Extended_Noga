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
        private static int monsterCounter = 1;//how many monster did we have by now?
        public bool alive = true;

        List<string> titleList = new List<string> { "The Fearsome", "The Mighty", "The Dreaded", "The Slimy", "The Indomitable", "The Unholy" , "The Voracious" , "The Relentless" };
        List<string> nameList = new List<string> { "Morganna", "Samir", "Vincent", "Delila", "Noga", "Aviv" , "Lydia", "Shalev" , "Mario" ,"Goombelino"};

        public Monster(int power, int health)
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

        public void monsterPowerAndHealthSetter()// sets the power of monster depending on how many monster initialized
        {
            
            Random random = new Random();
            power = random.Next(monsterCounter, monsterCounter + 8);
            health = random.Next(monsterCounter * 2, monsterCounter * 6);
            switch (monsterCounter)
            {
                case 0:
                    power *= 1;
                    health *= 1;
                    monsterCounter++;
                    break;

                case < 1:
                    power *= 2;
                    health *= 2;
                    monsterCounter++;
                    break;

                case < 2:
                    power *= 3;
                    health *= 3;
                    monsterCounter++;
                    break;

                case < 4:
                    power *= 4;
                    health *= 4;
                    monsterCounter++;
                    break;

                case < 6:
                    power *= 5;
                    health *= 5;
                    monsterCounter++;

                    break;

                case < 8:
                    power *= 6;
                    health *= 6;
                    monsterCounter++;
                    break;
            }
        }

        public void IntroduceMonster()
        {
            Random random = new Random();
            List<string> descriptionList = new List<string>
            {
                $"Coalescing from acrid, yellow smoke,  it's {name}.\nIt's teeth gleam in the low light as it prepares to attack!", 
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
            Console.WriteLine($"{descriptionList[num]}");
        }//For flavor

        public void monsterAnnouncer()//A big scary monster appears! Shout it from the rooftops! 
        {
            IntroduceMonster();
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
        }//are you alive?
    }
}


