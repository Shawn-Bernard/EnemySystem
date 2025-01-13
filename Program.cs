using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnemySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Skeleton mySkeleton = new Skeleton();
            Ghost myGhost = new Ghost();
            Boss myBoss = new Boss();
            for(int i = 0; i < 5; i++)
            {
                myGhost.Attack(1);
            }
            
            
            Console.ReadLine();
        }
    }
    public class Enemy
    {
        int health;
        int damage;

        public int Health
        {
            get => health;
            set
            {
                if (value < 0) value = 0;
                if (value > 100) value = 0;
                health = value;
            }
        }
        public virtual void Attack(int damage = 0)
        {
            Console.WriteLine($"Basic attack for {damage}");
        }

        public virtual void takeDamage(int damage = 0)
        {
            Console.WriteLine($"I've been hit for {damage}");
        }
        public virtual void Death()
        {
            
        }
    } 
    public class Skeleton: Enemy
    {
        
    }
    public class Ghost: Enemy
    {
        Random rng = new Random();

        public override void Attack(int damage)
        {
            Console.WriteLine($"Ghost chop hit for {damage}");
            

        }
        public override void takeDamage(int damage)
        {
            int rngHit = rng.Next(0, 1);
            if (rngHit == 0)
            {
                base.takeDamage(damage);
            }
            else if (rngHit == 1)
            {
                Console.WriteLine($"the attack missed because its a ghost");
            }
        }
        public override void Death()
        {
            base.Death();
        }
    }
    public class Boss: Enemy
    {
        Random rng = new Random();
        public override void Attack(int damage)
        {
            int rngAttack = rng.Next(0, 3);
            if (rngAttack == 0)
            {
                Console.WriteLine("random attack 0");
            }
            else if (rngAttack == 1)
            {
                Console.WriteLine("random attack 1");
            }
            else if (rngAttack == 2)
            {
                Console.WriteLine("random attack 2");
            }
        }
        public override void takeDamage(int damage)
        {
            base.takeDamage(damage);
        }
        public override void Death()
        {
            base.Death();
        }
    }
}
