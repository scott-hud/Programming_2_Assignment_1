using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming2_Console_Game
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Part 1 - Instantiate Number of Enemies
            Enemy redGhost = new Enemy("Red Ghost", "Killable", new ThreeDPoint(20, 40, 100));
            Enemy blueGhost = new Enemy("Blue Ghost", "not Killable", new ThreeDPoint(80, 100, 100));
            Enemy greenGhost = new Enemy("Green Ghost", "Killable", new ThreeDPoint(10, 10, 100));

            // Part 3 Create PLayer Object
            Player thePlayer = new Player("Steve", 100, 10, new ThreeDPoint(18, 40, 100));

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
            public ThreeDPoint enemyPosition;
            public static int numberEnemies;

            public Enemy(string type, string state, ThreeDPoint position)
            {
                enemyType = type;
                enemyState = state;
                enemyPosition = position;
                numberEnemies++;
            }

            // Member function that prints status of Eenemy object
            public void printStatus()
            {
                Console.WriteLine("The <{0}> Enemy is <{1}> and is at <{2},{3},{4}> location", enemyType, enemyState, enemyPosition.x, enemyPosition.y, enemyPosition.z);
            }

            // Part 4 - Function to Update elemnets of list with new x, y, z values
            public double getPositionTo(Player thePlayer)
            {
                double theDistance = (Math.Sqrt(Math.Pow(Math.Abs(this.enemyPosition.x - thePlayer.playerPosition.x), 2) + Math.Pow(Math.Abs(this.enemyPosition.y - thePlayer.playerPosition.y), 2) + Math.Pow(Math.Abs(this.enemyPosition.z - thePlayer.playerPosition.z), 2)));
                //Console.WriteLine ("The Distance to the Player is: {0}", theDistance);
                return theDistance;
            }
        }

        // Part 3 - Create Player Class with Constrctor and function that takes a list of enemies and calculated the distance to them.
        public class Player
        {

            // Player member variables
            public string playerName;
            public int playerHealth;
            public ThreeDPoint playerPosition;
            public int playerAmmo;

            // Player instance constructor
            public Player(string name, int health, int Ammo, ThreeDPoint position)
            {
                playerName = name;
                playerHealth = health;
                playerAmmo = Ammo;
                playerPosition = position;
            }

            //Print status of the Player object
            public void printStatus()
            {
                Console.WriteLine("The Player <{0}>  is at <{1},{2},{3}> location", playerName, playerPosition.x, playerPosition.y, playerPosition.z);
            }

            // Function to determine distannce to list of enemies
            public void getPositionToAllEnemies(List<Enemy> theEnemies)
            {

                // loop through the enemies list
                foreach (Enemy enemy in theEnemies)
                {

                    // Calculate the diatance from each enemy to the player
                    double theDistance = (Math.Sqrt(Math.Pow(Math.Abs(enemy.enemyPosition.x - this.playerPosition.x), 2) + Math.Pow(Math.Abs(enemy.enemyPosition.y - this.playerPosition.y), 2) + Math.Pow(Math.Abs(enemy.enemyPosition.z - this.playerPosition.z), 2)));

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
        public struct ThreeDPoint
        {

            public int x;
            public int y;
            public int z;

            public ThreeDPoint(int p1, int p2, int p3)
            {
                x = p1;
                y = p2;
                z = p3;
            }
        }


    }
}
