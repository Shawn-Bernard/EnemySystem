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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Skeleton:");
            mySkeleton.Attack(5);
            mySkeleton.takeDamage(10);
            mySkeleton.Death();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Ghost:");
            mySkeleton.Attack(10);
            for (int i = 0; i < 3; i++)
            {
                myGhost.takeDamage(15);
            }
            myGhost.Death();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Boss:");
            myBoss.Attack(20);
            myBoss.takeDamage(5);
            myBoss.Death();


            Console.ReadLine();
        }
    }
    public class Enemy
    {
        int health;
        public int Damage { get; set; }

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
            Console.WriteLine("Oh, what a world! What a world!");
        }
    } 
    public class Skeleton: Enemy
    {
        //The skeleton is using the base methods so no need to override
    }
    public class Ghost: Enemy
    {
        static Random rng = new Random();

        public override void Attack(int damage)
        {
            Console.WriteLine($"Ghost chop hit for {damage}");
        }
        public override void takeDamage(int damage)
        {
            int rngHit = rng.Next(2);
            if (rngHit == 0)
            {
                base.takeDamage(damage);
            }
            else if (rngHit == 1)
            {
                Console.WriteLine($"the attack missed because its a ghost");
            }
        }
    }
    public class Boss: Enemy
    {
        
        Random rng = new Random();
        public override void Attack(int damage)
        {
            
            for (int i = 0; i < 3; i++)
            {
                int rngAttack = rng.Next(3);
                if (rngAttack == 0)
                {
                    Console.WriteLine($"Slam hit for {damage} ");
                }
                else if (rngAttack == 1)
                {
                    Console.WriteLine($"Kick hit for {damage}");
                }
                else if (rngAttack == 2)
                {
                    Console.WriteLine($"Bat hit for {damage}");
                }
            }
            
        }
    }
}
