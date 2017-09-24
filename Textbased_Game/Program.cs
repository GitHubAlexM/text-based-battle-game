using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textbased_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            DisplayTitle();//displays title

            Console.Write("Enter player's name: ");
            name = Console.ReadLine();//assign's user input as their name

            Player player = new Player(name);
            Pause();

            player.fight();
            Pause();
        }
        // method to pause the console and wait for user
        private static void Pause()
        {
            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();
        }

        private static void DisplayTitle()
        {
            Console.WriteLine("BULLY FIGHT\nThere's this piece of shit always bothering the heck out of you.\nGo kick their ass...\n");
            
        }
    }
}
