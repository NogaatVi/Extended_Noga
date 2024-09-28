using System;
using MonsterClass;
using PlayerClass;

namespace RegularMonsterClass
{
	public  class RegularMonster : Monster
	{
        public int ressurectionPoint = Monster.monsterCounter;

        public RegularMonster(int power, int health , int shield) : base(power, health, shield)
        {
            this.power = power;
            this.health = health;
            this.shield = shield;
        }

        public override void monsterPowerAndHealthSetter()
        {
            base.monsterPowerAndHealthSetter();
        }

       
    }
}


