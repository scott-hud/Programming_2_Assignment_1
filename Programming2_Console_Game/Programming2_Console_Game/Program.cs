using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming2_Console_Game
{
    /* 

 3. Shoot: When this command is called, ask for the name of the NPC to shoot. If the NPC is within distance, is an enemy and has health points remaining, then reduce their
 health by 1. If the NPC is a friend, then reduce the players health points by 2. When an enemy’s health reaches 0, the enemy is dead. Each time an enemy is killed,
 the status of all friends and enemies has to be checked to determine if the game is over.


 5. Query NPC: When this command is called, ask for an NPC’s name and print the NPC’s
 backstory.

 6. Request Alliance: When this command is called, ask for the NPC’s name. If the NPC’s type is enemy, then the player loses 2 health points and their allegiance status
 is set to “enemy”. If the NPC’s type is friend, then their allegiance status is set to “friend”.
*/


    class MainClass
    {
        public static void Main(string[] args)
        {
            //Boolean RequestStats = false;
            Random random = new Random();
            int x = random.Next(1, 101);
            int y = random.Next(1, 101);

            Console.WriteLine("Hello what is you're name? NPCs will be randomly generated too.");
            String name = Console.ReadLine();
            if (!String.IsNullOrEmpty(name))
            {
                // Creating the player
                Player thePlayer = new Player(name, 100, 10, new Grid(x, y));

                // Creating the NPCs
                Enemy NPC1 = new Enemy("Dave", "Killable", 10,  new Grid(x, y));
                Enemy NPC2 = new Enemy("John", "not Killable", 10, new Grid(x, y));
                Enemy NPC3 = new Enemy("Samantha", "Killable", 10, new Grid(x, y));

                // List holding NPCs data
                List<Enemy> myEnemyList = new List<Enemy>();

                // Add Objects to the List 
                myEnemyList.Add(NPC1);
                myEnemyList.Add(NPC2);
                myEnemyList.Add(NPC3);

                // Print Status of Each enemy and the player
                thePlayer.printStatus();
                NPC1.printStatus();
                NPC2.printStatus();
                NPC3.printStatus();

                // Print distance from Player to all Enemey Obejcts 
                thePlayer.getPositionToAllEnemies(myEnemyList);
                
            }

            //Console.WriteLine("");
        }


        //   Create NPC: When this command is called, ask for the name of the NPC and create an NPC object with a randomly generated position on a 100 x 100 grid and randomly
        // generated type and backstory values(the type and backstory should be related). A maximum of 5 NPC objects can be created.
        public class Enemy
        {

            public string NPCName;
            public string NPCState;
            public Grid NPCPosition;
            public static int numberNPCs;
            public int NPCHealth;

            public Enemy(string nName, string state, int health, Grid position)
            {
                NPCName = nName;
                NPCState = state;
                NPCHealth = health;
                NPCPosition = position;
                numberNPCs++;
            }

            // Member function that prints status of Eenemy object
            public void printStatus()
            {
                Console.WriteLine("NPC {0}'s health is {4} is {1} and is at ({2},{3}) location", NPCName, NPCState, NPCPosition.x, NPCPosition.y, NPCHealth);
            }

            // Part 4 - Function to Update elements of list with new x, y values
            public double getPositionTo(Player thePlayer)
            {
                double theDistance = (Math.Sqrt(Math.Pow(Math.Abs(this.NPCPosition.x - thePlayer.playerPosition.x), 2) + Math.Pow(Math.Abs(this.NPCPosition.y - thePlayer.playerPosition.y), 2)));

                return theDistance;
            }
        }

        // Player: When this command is called, ask for name of the player and create a player object with a randomly generated position on a 100 x 100 grid.
        //Only 1 player can be created.
        public class Player
        {

            // Player member variables
            public string playerName;
            public int playerHealth;
            public Grid playerPosition;
            public int playerAmmo;

            // Player instance constructor
            public Player(string name, int health, int Ammo, Grid position)
            {

                playerName = name;
                playerHealth = health;
                playerAmmo = Ammo;
                playerPosition = position;

            }

            //7. Print Player Status: When this command is called, print the current status of the player.This should include the players health value, ammunition value and position.
            public void printStatus()
            {
                // Console.WriteLine("You can request to see your status anytime by typing STATS");
                //Console.ReadLine();
                Console.WriteLine("The Player {0} is at {3},{4} location, You're health is: {1}. Ammo count: {2}.", playerName, playerHealth, playerAmmo, playerPosition.x, playerPosition.y);

            }

            // Function to determine distance to list of enemies
            public void getPositionToAllEnemies(List<Enemy> theEnemies)
            {

                // loop through the enemies list
                foreach (Enemy enemy in theEnemies)
                {

                    // Calculate the diatance from each enemy to the player
                    double theDistance = (Math.Sqrt(Math.Pow(Math.Abs(enemy.NPCPosition.x - this.playerPosition.x), 2) + Math.Pow(Math.Abs(enemy.NPCPosition.y - this.playerPosition.y), 2)));

                    // condition that checks the distance is < 30 
                    if (theDistance < 30)
                    {
                        Console.WriteLine("The distance between {0} and {1} is {2}, so Shoot", this.playerName, enemy.NPCName, theDistance);
                    }
                    else
                    {
                        Console.WriteLine("The distance between {0} and {1} is {2}, so dont Shoot", this.playerName, enemy.NPCName, theDistance);
                    }
                }
            }
        }

        // Create a 2D grid 
        public struct Grid
        {

            public int x;
            public int y;


            public Grid(int p1, int p2)
            {
                x = p1;
                y = p2;

            }
        }

        // 4. Move: When this command is called, ask for a new position, update the players position and reduce their health by 1.
        public void Move()
        {
            double n;
            double y;
            Console.WriteLine("Please Enter A Number:");
            //get input from the user and store it in the variable myInputNumber
            String myInputNumber = Console.ReadLine();
            //now use a selection to determine whether the user typed anything
            if (String.IsNullOrEmpty(myInputNumber))
            {
                
                Console.WriteLine("No input was provided!");

            }
            else if (double.TryParse(myInputNumber, out n ))
            {
                Console.WriteLine("The number you entered was: " + n );

            }
            else
            {
                Console.WriteLine("You did not enter a number!");

            }

        }
    }
}
