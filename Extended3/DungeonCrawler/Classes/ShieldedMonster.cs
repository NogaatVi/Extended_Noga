using System;
using MonsterClass;
using PlayerClass;

namespace ShieldedMonsterClass
{
	public  class ShieldedMonster : Monster
	{
        public int ressurectionPoint = Monster.monsterCounter;

        public ShieldedMonster(int power, int health , int shield) : base(power, health, shield)
        {
            this.power = power;
            this.health = health;
            this.shield = shield;
        }

        public override void monsterPowerAndHealthSetter()
        {
            base.monsterPowerAndHealthSetter();
            setShield();
        }

        public override void introduceMonster()
        {
            base.introduceMonster();
            base.printEffect("It's tough carpace shines dully.\nSharpen your weapon, adventurer!");
        }// just a little more descritption

        public void setShield() 
        {
            base.printEffect("The monster bristles, it's sturdy shield prickling dangerously.");
            shield = Monster.monsterCounter + 1;
        }// set shield to monster counter +1

        public override void getDamage(int damage) 
        {
            if (shield > 0) 
            {
                Console.WriteLine($"{name} roars, one of it's armored shields cracked!");
                shield--;
            }
            else 
            { 
                getDamage(damage);
            }
        }

    }
}


