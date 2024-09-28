using System;
using MonsterClass;
using PlayerClass;

namespace EliteMonsterClass
{
	public  class EliteMonster : Monster
	{
        public int ressurectionPoint = Monster.monsterCounter;

        public EliteMonster(int power, int health) : base(power, health)
        {
            this.power = power;
            this.health = health;
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
    }
}


