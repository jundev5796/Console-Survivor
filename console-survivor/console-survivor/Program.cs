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
                    case 72:  // up 아스키코드                    
                        playerY--;
                        if (playerY < 1)
                            playerY = 1;
                        break;
                    case 75:
                        // left 화살표키
                        playerX--;
                        if (playerX < 0)
                            playerX = 0;
                        break;
                    case 77:
                        // right
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
            enemyY = 10;
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
                if (dwTime + 50 < Environment.TickCount)
                {
                    dwTime = Environment.TickCount;
                    Console.Clear();

                    player.PlayerMain();
                    enemy.EnemyCreate();
                    enemy.EnemyMove();
                }
            }
            Console.ReadKey(true); // hide extra message
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
