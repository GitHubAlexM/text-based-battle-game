using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textbased_Game
{
    class Player
    {
        /***|PRIVATE PROPERTIES|***/

        private int strength;
        private int speed;
        private int health;


        private int bSTR; 
        private int bSPE;
        private int bHP;
        private int newbHP;

        /***|PUBLIC PROPERTIES|***/

        public string name;
        

        /***|CONSTRUCTOR|***/
        public Player(string name)
        {
            this.name = name; //assigns name
            generateAbilities(); //assigns strength, speed and health to player
            show();
            //generate bully stats
            Random rnd2 = new Random();
            bSTR = this.strength = rnd2.Next(25, 81); //assigns random number between 25 to 80
            bSPE = this.speed = rnd2.Next(25, 81);
            bHP = this.health = rnd2.Next(75, 101);
            newbHP = bHP;
        }

        /***|PRIVATE METHODS|***/

        //method to generate initial Player stats
        private void generateAbilities()
        {
            Random rnd = new Random();
            this.strength = rnd.Next(1, 101); //assigns random number between 1 and 100
            this.speed = rnd.Next(1, 101);
            this.health = rnd.Next(1, 101);

        }

        //method to determine the success of an attack
        public void hitAttempt()
        {
            
            Console.WriteLine("You are aiming to hit!");
            Random rnd = new Random();
            int accuracy = rnd.Next(this.speed, 101); // generates random int between 1 and 100
            Console.WriteLine("You rolled {0}", accuracy);
            int bullyDodgeScore = rnd.Next(Convert.ToInt32(bSPE/2), 76);
            if (accuracy > bullyDodgeScore) //Player hits with 20% accuracy (on an 60+)
            {
                Console.WriteLine("You hit!");
                hitDamage(); // on a hit, calls the hitDamage method
            }
            else
            {
                Console.WriteLine("You missed..."); // on a miss, prints result and terminates
                Console.WriteLine("The bully hits back!");
                Random rnd3 = new Random();
                int bATK = rnd3.Next(0, this.health);
                int newPHP = bATK - this.health;
                
                if (bATK == 0) { Console.WriteLine("Bully missed!"); hitAttempt(); }
                if (newPHP >= 1) { Console.WriteLine("You survived the bully's attack!\n\nYou took{0}damage and have{1} health left!",bATK,newPHP); }
                else { Console.WriteLine("Feelsbadman! The bully killed you!"); }
            }
        }

        // method to determine damage dealt
        private int hitDamage()
        {
            
            int dmgDealt;
            Random rnd = new Random();

            dmgDealt = rnd.Next(1, 100);
            int critChance = rnd.Next(1,7);
            if (critChance >= 5) { Console.WriteLine("\nYou dealt {0} damage!", dmgDealt*2); }

            else { Console.WriteLine("\nYou dealt {0} damage!", dmgDealt); }

            newbHP = bHP - dmgDealt;//bully's hp calculation after damage dealt
            if (newbHP <= 0) { Console.WriteLine("\nBully has 0 health left!"); }
            else{ Console.WriteLine("\nBully has {0} health left!",newbHP); }

            return newbHP; //sends final damage result with modifiers
        }

        /***|PUBLIC METHODS|***/

        // method to start a fight
        public void fight()
        {
            Console.WriteLine("Wow! A bully appeared!");

            hitAttempt(); //calls hitAttempt method

            if (newbHP == 0) { Console.WriteLine("Congrats you killed the bully.\n\nNow you are in prison you cold blooded killer..."); }

        }

        public void show() // method to show character's current stats
        {
            Console.WriteLine("\n{0}'s Stats\nStrength  Speed  Health \n========  =====  ======\n{1, 6}{2, 8}{3, 8}", this.name, this.strength, this.speed, this.health); // displays stats with some visual fluff

            //if stats are bad
            if (this.strength <= 20 && this.speed <= 20 && this.health <= 20)
            {
                Console.WriteLine("Feelsbadman!");
            }
            else
            {
                Console.WriteLine("Feelsgoodman!");
            }
        }
    }
}
