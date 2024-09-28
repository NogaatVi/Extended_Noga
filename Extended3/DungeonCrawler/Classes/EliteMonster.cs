using System;
using MonsterClass;
using PlayerClass;

namespace EliteMonsterClass
{
	public  class EliteMonster : Monster
	{
        public int ressurectionPoint = Monster.monsterCounter;

        public EliteMonster(int power, int health , int shield, int ressurectionPoint) : base(power, health, shield)
        {
            this.power = power;
            this.health = health;
            this.shield = shield;
            this.ressurectionPoint = ressurectionPoint;
        }

        public override void introduceMonster()
        {
            base.introduceMonster();
            base.printEffect("It's bulging muscle strikes fear into your heart.\nBeware adventurer!");
        }

        public void useressurection() //if has ressurection point, add a little life, and decrease ressurection point
        {
            if (ressurectionPoint > 0) 
            {
                health += Monster.monsterCounter * 2;
                ressurectionPoint--;
            }
        }
        public override bool isAlive()
        {
            if (health < 0) 
            {
                if (ressurectionPoint > 1) //if i still have res point but health <0
                {
                    health += monsterCounter * 2;
                    ressurectionPoint--;
                    Console.WriteLine($"{name} roars, getting back on it's hideious feet.\nIt's hissing and spitting blood, but somehow still alive.");
                    return alive = true;
                }
                else if (ressurectionPoint == 1)
                {
                    Console.WriteLine($"{name} roars, wobblying tiredly, but stays alive.\nImpossible!\nIt's almost dead!");
                    ressurectionPoint--;
                    return alive = true;
                }
                else
                {
                    Console.WriteLine($"{name} has been vanquished!");
                    return alive = false;
                }
            }
            //else: health > 0
            return alive = true;

        }//are you alive?
    }
}



