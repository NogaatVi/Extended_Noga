using System;
using MonsterClass;
using PlayerClass;

namespace RageMonsterClass
{
	public  class RageMonster : Monster
	{

        public RageMonster(int power, int health, int shield) : base(power, health ,shield)
        {
            this.power = power;
            this.health = health;
            this.shield = shield;
        }

        public override void monsterPowerAndHealthSetter() 
        {
            base.monsterPowerAndHealthSetter();
            addDamage();
        }

        public override void introduceMonster()
        {
            base.introduceMonster();
            base.printEffect("It's beady eyes shows potent, bubbling rage.\nBeware adventurer!");
        }

        public void addDamage() //add the amount of monsters to monster power each attack
        {
            power += Monster.monsterCounter * 2;
        }
    }
}


