using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming2_Console_Game
{
   /* 

//  Create NPC: When this command is called, ask for the name of the NPC and create an NPC object with a randomly generated position on a 100 x 100 grid and randomly
generated type and backstory values (the type and backstory should be related). A maximum of 5 NPC objects can be created.

3. Shoot: When this command is called, ask for the name of the NPC to shoot. If the NPC is within distance, is an enemy and has health points remaining, then reduce their
health by 1. If the NPC is a friend, then reduce the players health points by 2. When an enemy’s health reaches 0, the enemy is dead. Each time an enemy is killed,
the status of all friends and enemies has to be checked to determine if the game is over.

        4. Move: When this command is called, ask for a new position, update the players position and reduce their health by 1.

5. Query NPC: When this command is called, ask for an NPC’s name and print the NPC’s
backstory.

6. Request Alliance: When this command is called, ask for the NPC’s name. If the NPC’s type is enemy, then the player loses 2 health points and their allegiance status
is set to “enemy”. If the NPC’s type is friend, then their allegiance status is set to “friend”.

7. Print Player Status: When this command is called, print the current status of the player.This should include the players health value, ammunition value and position.

 8. Print NPC Status: When this commend is called, print the current status of all NPCs. This should include health values, their allegiance status and their distance
 from the player.*/


    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello what is you're name?");
            String name = Console.ReadLine();
            // Part 1 - Instantiate Number of Enemies
            Enemy redGhost = new Enemy("Red Ghost", "Killable", new Grid(40, 40));
            Enemy blueGhost = new Enemy("Blue Ghost", "not Killable", new Grid(90, 10));
            Enemy greenGhost = new Enemy("Green Ghost", "Killable", new Grid( 10, 60));

            randomNumber generator = new randomNumber();
            int randomX = generator.RandomNumber(0, 100);
            int randomY = generator.RandomNumber(0, 100);

            // Part 3 Create PLayer Object
            Player thePlayer = new Player( name, 100, 10, new Grid( 40, 100));

            // Part 2 Create a List that holds Enemy objects
            List<Enemy> myEnemyList = new List<Enemy>();

            // Add Objects to the List 
            myEnemyList.Add(redGhost);
            myEnemyList.Add(blueGhost);
            myEnemyList.Add(greenGhost);

            // Print Status of Each enemy and the player
            thePlayer.printStatus();
            redGhost.printStatus();
            blueGhost.printStatus();
            greenGhost.printStatus();

            // Print distance from an Enemy (Red Ghost) to the Player
            Console.WriteLine("Distance from {0} to the Player is {1}", redGhost.enemyType, redGhost.getPositionTo(thePlayer));

            // Print distance from Player to all Enemey Obejcts 
            thePlayer.getPositionToAllEnemies(myEnemyList);
        }

        // Part 1 - Create class with member variables, constructor and printStatus function
        public class Enemy
        {

            public string enemyType;
            public string enemyState;
            public Grid enemyPosition;
            public static int numberEnemies;

            public Enemy(string type, string state, Grid position)
            {
                enemyType = type;
                enemyState = state;
                enemyPosition = position;
                numberEnemies++;
            }

            // Member function that prints status of Eenemy object
            public void printStatus()
            {
                Console.WriteLine("The {0} Enemy is {1} and is at <{2},{3}> location", enemyType, enemyState, enemyPosition.x, enemyPosition.y);
            }

            // Part 4 - Function to Update elemnets of list with new x, y values
            public double getPositionTo(Player thePlayer)
            {
                double theDistance = (Math.Sqrt(Math.Pow(Math.Abs(this.enemyPosition.x - thePlayer.playerPosition.x), 2) + Math.Pow(Math.Abs(this.enemyPosition.y - thePlayer.playerPosition.y), 2)));
                //Console.WriteLine ("The Distance to the Player is: {0}", theDistance);
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
           

            //Print status of the Player object
            public void printStatus()
            {
                Console.WriteLine("The Player {0}  is at {1},{2} location", playerName, playerPosition.x, playerPosition.y);
            }

            // Function to determine distannce to list of enemies
            public void getPositionToAllEnemies(List<Enemy> theEnemies)
            {

                // loop through the enemies list
                foreach (Enemy enemy in theEnemies)
                {

                    // Calculate the diatance from each enemy to the player
                    double theDistance = (Math.Sqrt(Math.Pow(Math.Abs(enemy.enemyPosition.x - this.playerPosition.x), 2) + Math.Pow(Math.Abs(enemy.enemyPosition.y - this.playerPosition.y), 2)));

                    // condition that checks the distance is < 10 m
                    if (theDistance < 10)
                    {
                        Console.WriteLine("The distance between {0} and {1} is {2}, so ATTACK", this.playerName, enemy.enemyType, theDistance);
                    }
                    else
                    {
                        Console.WriteLine("The distance between {0} and {1} is {2}, so DONT ATTACK", this.playerName, enemy.enemyType, theDistance);
                    }
                }
            }
        }

        // Create a ThreeDPoint struct to store the location
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
        public class randomNumber
         {
            public int RandomNumber(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }
    }


}
}
