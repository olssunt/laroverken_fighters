using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace laroverken_fighters
{
    class Program
    {
        static Enemy enemy = new Enemy ();

        

        static Random randomness = new Random();
        static int playerHP = randomness.Next(10, 20);

        static int playerDmg = randomness.Next(2, 6);
        static string userInput;


        static void Main(string[] args)
        {
            enemy.Setup();       

            Console.Title = "Läroverket Fighters";
            Console.SetWindowSize(32, 12);


            //Game loop. As long as both lives, do this
            while (playerHP > 0 && enemy.hp > 0)
            {
                Console.Clear();

                DisplayStats();



                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("1: Attack \n2: Heal\n\nUser input:");
                userInput = Console.ReadLine();

                //User choice
                if (userInput == "1") //attack
                {
                    playerDmg = randomness.Next(3, 8);
                    enemy.hp -= playerDmg;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player attacked for " + playerDmg);

                }
                else if(userInput == "2") //heal
                {
                    int healAmount = randomness.Next(1, 3);
                    playerHP += healAmount;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Player healed for " + playerDmg);

                }
                else //invalid menu input
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write("Invalid Input!");
                    Console.ReadKey(); //pause until user presses key
                    continue;
                }

                EnemyTurn();
                Console.ReadKey(); //pause until user presses key
            } //end of while loop

            //if we are here someone died
            if (enemy.hp < 1)
            {
                //Enemy died died
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n" + enemy.name + " died! ");

            }
            else
            {
                //Player died
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nYou died!");

            }
            
            Console.Read();
        }

        static void EnemyTurn()
        {
            if (randomness.Next(0, 10) >= 7) //Enemy heals if number is greater than X

            {
                int healAmount = randomness.Next(1, 3);
                enemy.hp += healAmount;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(enemy.name + " healed for " + enemy.dmg);
            }
            else
            {
                //Enemy attacks
                enemy.dmg = randomness.Next(2, 7);
                playerHP -= enemy.dmg;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.name + " attacked for " + enemy.dmg);
            }
        }


        static void DisplayStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PLayer HP:" + playerHP);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(enemy.name + "'s HP: " + enemy.hp);
        }
    }
}
