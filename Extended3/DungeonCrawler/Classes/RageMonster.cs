using System;
using MonsterClass;
using PlayerClass;

namespace RageMonsterClass
{
	public  class RageMonster : Monster
	{

        public RageMonster(int power, int health) : base(power, health)
        {
            this.power = power;
            this.health = health;
        }

        public override void introduceMonster()
        {
            base.introduceMonster();
            base.printEffect("It's beady eyes shows potent, bubbling rage.\nBeware adventurer!");
        }

        public void addDamage() //add the amount of monsters to monster power each attack
        {
            power += Monster.monsterCounter;
        }
    }
}


