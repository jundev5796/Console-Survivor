using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;

namespace ConsoleSurvivor
{
    // title screen class
    public class TitleScreen
    {
        public void GameTitle()
        {
            // game title
            Console.SetCursorPosition(10, 2);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(10, 3);
            Console.Write("┃                                                                 ┃");
            Console.SetCursorPosition(10, 4);
            Console.Write("┃             _____                       _                       ┃");
            Console.SetCursorPosition(10, 5);
            Console.Write("┃            / ____|                     | |                      ┃");
            Console.SetCursorPosition(10, 6);
            Console.Write("┃            | |     ___  _ __  ___  ___ | | ___                  ┃");
            Console.SetCursorPosition(10, 7);
            Console.Write("┃            | |    / _ \\| '_ \\/ __|/ _ \\| |/ _ \\                 ┃");
            Console.SetCursorPosition(10, 8);
            Console.Write("┃            | |___| (_) | | | \\__ \\ (_) | |  __/                 ┃");
            Console.SetCursorPosition(10, 9);
            Console.Write("┃             \\_____\\___/|_| |_|___/\\___/|_|\\___|                 ┃");
            Console.SetCursorPosition(10, 10);
            Console.Write("┃             / ____|                (_)                          ┃");
            Console.SetCursorPosition(10, 11);
            Console.Write("┃            | (___  _   _ _ ____   _____   _____  _ __           ┃");
            Console.SetCursorPosition(10, 12);
            Console.Write("┃             \\___ \\| | | | '__\\ \\ / / \\ \\ / / _ \\| '__|          ┃");
            Console.SetCursorPosition(10, 13);
            Console.Write("┃             ____) | |_| | |   \\ V /| |\\ V / (_) | |             ┃");
            Console.SetCursorPosition(10, 14);
            Console.Write("┃            |_____/ \\__,_|_|    \\_/ |_| \\_/ \\___/|_|             ┃");
            Console.SetCursorPosition(10, 15);
            Console.Write("┃                                                                 ┃");
            Console.SetCursorPosition(10, 16);
            Console.Write("┃                                                                 ┃");
            Console.SetCursorPosition(10, 17);
            Console.Write("┛━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

            // copyright name
            Console.SetCursorPosition(27, 24);
            Console.Write("© 2025 LikeLion Unity 4th Class");

            // start button
            bool showBtn = true;

            while (!Console.KeyAvailable)
            {
                Console.SetCursorPosition(35, 20);
                if (showBtn)
                {
                    Console.Write("PRESS ANY BUTTON\n\n\n");
                }
                else
                {
                    Console.Write("                      ");
                }
                showBtn = !showBtn;
                Thread.Sleep(700);
            }
            Console.ReadKey(true);
        }
    }

    public class Shoot
    {
        public int x;
        public int y;
        public bool fire;
    }

    // player class
    public class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();

        public int playerX;
        public int playerY;
        public int time = 20; // Timer starts at 20
        private int lastTimerUpdate;

        public Player()
        {
            playerX = 40;
            playerY = 12;
            lastTimerUpdate = Environment.TickCount;
        }

        public void PlayerMain()
        {
            TimerUI(); // player score
            PlayerCreate(); // player creation
            PlayerKey(); // player movement
        }

        public void PlayerCreate()
        {
            string[] player = new string[]
            {
                " ∧＿∧",
                "(・ω・)"
            };

            for (int i = 0; i < player.Length; i++)
            {
                Console.SetCursorPosition(playerX, playerY + i);
                Console.WriteLine(player[i]);
            }
        }

        public void PlayerKey()
        {
            int playerKey;

            if (Console.KeyAvailable)
            {
                playerKey = _getch();

                if (playerKey == 0 || playerKey == 224)
                {
                    playerKey = _getch();
                }

                switch (playerKey)
                {
                    case 72:  // up
                        playerY--;
                        if (playerY < 1)
                            playerY = 1;
                        break;
                    case 75: // left
                        playerX--;
                        if (playerX < 0)
                            playerX = 0;
                        break;
                    case 77: // right
                        playerX++;
                        if (playerX > 75)
                            playerX = 75;
                        break;
                    case 80: // down
                        playerY++;
                        if (playerY > 21)
                            playerY = 21;
                        break;
                }
            }
        }

        public void TimerUI()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃              ┃");
            Console.SetCursorPosition(65, 1);
            Console.Write("Time : " + time);
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }

        public void UpdateTimer()
        {
            // Decrease the timer every second
            if (time > 0 && Environment.TickCount - lastTimerUpdate >= 1000)
            {
                time--;
                lastTimerUpdate = Environment.TickCount; // Update last timer update time
            }
        }
    }

    public class Enemy
    {
        public int enemyX;
        public int enemyY;
        Random rand = new Random();

        // Constructor now calls RandomSpawn() to initialize the enemy's random position
        public Enemy()
        {
            RandomSpawn();  // Randomly spawn the enemy when initialized
        }

        // Method to spawn enemy at a random edge
        public void RandomSpawn()
        {
            int spawn = rand.Next(0, 4);  // Randomly choose one of the edges (top, right, bottom, left)

            switch (spawn)
            {
                case 0: // Top edge (random X, Y = 0)
                    enemyX = rand.Next(0, 80); // Random X on top edge
                    enemyY = 0;
                    break;
                case 1: // Right edge (X = 79, random Y)
                    enemyX = 79;
                    enemyY = rand.Next(0, 25); // Random Y on right edge
                    break;
                case 2: // Bottom edge (random X, Y = 24)
                    enemyX = rand.Next(0, 80); // Random X on bottom edge
                    enemyY = 24;
                    break;
                case 3: // Left edge (X = 0, random Y)
                    enemyX = 0;
                    enemyY = rand.Next(0, 25); // Random Y on left edge
                    break;
            }
        }

        // Method to draw the enemy
        public void EnemyCreate()
        {
            string enemy = "(UwU)";
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write(enemy);
        }

        // Method to make the enemy move towards the player
        public void EnemyMove(int playerX, int playerY)
        {
            if (enemyX < playerX) enemyX++;   // Move right
            if (enemyX > playerX) enemyX--;   // Move left
            if (enemyY < playerY) enemyY++;   // Move down
            if (enemyY > playerY) enemyY--;   // Move up
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            TitleScreen titleScreen = new TitleScreen();
            titleScreen.GameTitle();
            Console.Clear();

            Player player = new Player();
            List<Enemy> enemies = new List<Enemy>(); // List to store multiple enemies

            int dwTime = Environment.TickCount;
            int lastSpawnTime = Environment.TickCount; // Track enemy spawn time
            int enemyMoveCounter = 0; // Counter to slow down enemy movement

            while (true) // Infinite game loop
            {
                if (dwTime + 50 < Environment.TickCount)
                {
                    dwTime = Environment.TickCount;
                    Console.Clear();

                    player.PlayerMain();
                    player.UpdateTimer(); // Update the timer

                    // If time runs out, clear the screen and show "YOU WIN!"
                    if (player.time == 0)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(35, 7);
                        Console.Write("┏━━━━━━━━━━━━━━┓");
                        Console.SetCursorPosition(35, 8);
                        Console.Write("┃              ┃");
                        Console.SetCursorPosition(39, 8);
                        Console.Write("YOU WIN!");
                        Console.SetCursorPosition(35, 9);
                        Console.Write("┗━━━━━━━━━━━━━━┛");
                        Console.ReadKey();
                        return; // Exit the game loop
                    }

                    // Spawn a new enemy every 3 seconds
                    if (Environment.TickCount - lastSpawnTime >= 3000)
                    {
                        enemies.Add(new Enemy());
                        lastSpawnTime = Environment.TickCount;
                    }

                    // Move enemies every 2 frames to slow them down
                    enemyMoveCounter++;
                    foreach (Enemy e in enemies)
                    {
                        e.EnemyCreate();
                        if (enemyMoveCounter % 8 == 0) // Move every 2 cycles
                        {
                            e.EnemyMove(player.playerX, player.playerY);
                        }
                    }
                }
            }
        }
    }
}






/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSurvivor
{
    // title screen class
    public class TitleScreen
    {
        public void GameTitle()
        {
            // game title
            Console.SetCursorPosition(10, 2);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(10, 3);
            Console.Write("┃                                                                 ┃");
            Console.SetCursorPosition(10, 4);
            Console.Write("┃             _____                       _                       ┃");
            Console.SetCursorPosition(10, 5);
            Console.Write("┃            / ____|                     | |                      ┃");
            Console.SetCursorPosition(10, 6);
            Console.Write("┃            | |     ___  _ __  ___  ___ | | ___                  ┃");
            Console.SetCursorPosition(10, 7);
            Console.Write("┃            | |    / _ \\| '_ \\/ __|/ _ \\| |/ _ \\                 ┃");
            Console.SetCursorPosition(10, 8);
            Console.Write("┃            | |___| (_) | | | \\__ \\ (_) | |  __/                 ┃");
            Console.SetCursorPosition(10, 9);
            Console.Write("┃             \\_____\\___/|_| |_|___/\\___/|_|\\___|                 ┃");
            Console.SetCursorPosition(10, 10);
            Console.Write("┃             / ____|                (_)                          ┃");
            Console.SetCursorPosition(10, 11);
            Console.Write("┃            | (___  _   _ _ ____   _____   _____  _ __           ┃");
            Console.SetCursorPosition(10, 12);
            Console.Write("┃             \\___ \\| | | | '__\\ \\ / / \\ \\ / / _ \\| '__|          ┃");
            Console.SetCursorPosition(10, 13);
            Console.Write("┃             ____) | |_| | |   \\ V /| |\\ V / (_) | |             ┃");
            Console.SetCursorPosition(10, 14);
            Console.Write("┃            |_____/ \\__,_|_|    \\_/ |_| \\_/ \\___/|_|             ┃");
            Console.SetCursorPosition(10, 15);
            Console.Write("┃                                                                 ┃");
            Console.SetCursorPosition(10, 16);
            Console.Write("┃                                                                 ┃");
            Console.SetCursorPosition(10, 17);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

            // copyright name
            Console.SetCursorPosition(27, 24);
            Console.Write("© 2025 LikeLion Unity 4th Class");

            // start button
            bool showBtn = true;

            while (!Console.KeyAvailable)
            {
                Console.SetCursorPosition(35, 20);
                if (showBtn)
                {
                    Console.Write("PRESS ANY BUTTON\n\n\n");
                }
                else
                {
                    Console.Write("                      ");
                }
                showBtn = !showBtn;
                Thread.Sleep(700);
            }
            Console.ReadKey(true);
        }
    }


    // main screen class
    public class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();

        public int playerX;
        public int playerY;
        public int score = 0;

        public Player()
        {
            playerX = 40;
            playerY = 12;
        }

        public void PlayerMain()
        {
            ScoreUI(); // player score
            PlayerCreate(); // player creation
            PlayerKey(); // player movement
        }

        public void PlayerCreate()
        {
            string[] player = new string[]
            {
                " ∧＿∧",
                "(・ω・)"
            };

            for (int i = 0; i < player.Length; i++)
            {
                Console.SetCursorPosition(playerX, playerY + i);
                Console.WriteLine(player[i]);
            }
        }

        public void PlayerKey()
        {
            while (true) // Infinite loop to continuously check for input
            {
                if (Console.KeyAvailable)
                {
                    int playerKey = _getch();

                    if (playerKey == 0 || playerKey == 224)
                    {
                        playerKey = _getch();
                    }

                    // Erase the player at the current position
                    ClearPlayer();

                    switch (playerKey)
                    {
                        case 72: // Up arrow
                            playerY--;
                            if (playerY < 1) playerY = 1;
                            break;
                        case 75: // Left arrow
                            playerX--;
                            if (playerX < 0) playerX = 0;
                            break;
                        case 77: // Right arrow
                            playerX++;
                            if (playerX > 75) playerX = 75; // Corrected boundary
                            break;
                        case 80: // Down arrow
                            playerY++;
                            if (playerY > 21) playerY = 21;
                            break;
                        case 27: // Escape key to exit loop
                            return;
                    }

                    // Redraw the player at the new position
                    PlayerCreate();

                    // Small delay to prevent super-fast movement
                    Thread.Sleep(100);
                }
            }
        }

        public void ClearPlayer()
        {
            for (int i = 0; i < 2; i++) // Player has 2 lines
            {
                Console.SetCursorPosition(playerX, playerY + i);
                Console.Write("       "); // Replace player with empty spaces
            }
        }

        public void ScoreUI()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃              ┃");
            Console.SetCursorPosition(65, 1);
            Console.Write("Score : " + score);
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }
    }

    public class Enemy
    {
        public int enemyX;
        public int enemyY;

        public Enemy()
        {
            enemyX = 77;
            enemyY = 12;
        }

        public void EnemyCreate()
        {
            string enemy = "( U ₩ U )";
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write(enemy);
        }

        public void EnemyMove()
        {
            Random rand = new Random();
            enemyX--;

            if (enemyX < 2) //화면 왼쪽넘어가면 새로 좌표잡아라
            {
                enemyX = 75; //좌표 77
                enemyY = rand.Next(2, 22); //2~21 
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            TitleScreen titleScreen = new TitleScreen();
            titleScreen.GameTitle();
            Console.Clear();

            Player player = new Player();
            Enemy enemy = new Enemy();

            int dwTime = Environment.TickCount;

            while (true) //무한반복
            {
                //0.05초 지연
                if (dwTime + 50 < Environment.TickCount)
                {
                    //현재시간 세팅
                    dwTime = Environment.TickCount;
                    Console.Clear();

                    player.PlayerMain();

                    enemy.EnemyMove();
                    enemy.EnemyCreate();
                }
            }
            Console.ReadKey(true); // hide extra message
        }
    }
}
*/
