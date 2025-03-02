using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.SetCursorPosition(28, 3);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(28, 4);
            Console.Write("┃                                                                 ┃");
            Console.SetCursorPosition(28, 5);
            Console.Write("┃             _____                       _                       ┃");
            Console.SetCursorPosition(28, 6);
            Console.Write("┃            / ____|                     | |                      ┃");
            Console.SetCursorPosition(28, 7);
            Console.Write("┃            | |     ___  _ __  ___  ___ | | ___                  ┃");
            Console.SetCursorPosition(28, 8);
            Console.Write("┃            | |    / _ \\| '_ \\/ __|/ _ \\| |/ _ \\                 ┃");
            Console.SetCursorPosition(28, 9);
            Console.Write("┃            | |___| (_) | | | \\__ \\ (_) | |  __/                 ┃");
            Console.SetCursorPosition(28, 10);
            Console.Write("┃             \\_____\\___/|_| |_|___/\\___/|_|\\___|                 ┃");
            Console.SetCursorPosition(28, 11);
            Console.Write("┃             / ____|                (_)                          ┃");
            Console.SetCursorPosition(28, 12);
            Console.Write("┃            | (___  _   _ _ ____   _____   _____  _ __           ┃");
            Console.SetCursorPosition(28, 13);
            Console.Write("┃             \\___ \\| | | | '__\\ \\ / / \\ \\ / / _ \\| '__|          ┃");
            Console.SetCursorPosition(28, 14);
            Console.Write("┃             ____) | |_| | |   \\ V /| |\\ V / (_) | |             ┃");
            Console.SetCursorPosition(28, 15);
            Console.Write("┃            |_____/ \\__,_|_|    \\_/ |_| \\_/ \\___/|_|             ┃");
            Console.SetCursorPosition(28, 16);
            Console.Write("┃                                                                 ┃");
            Console.SetCursorPosition(28, 17);
            Console.Write("┃                                                                 ┃");
            Console.SetCursorPosition(28, 18);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

            // copyright name
            Console.SetCursorPosition(46, 27);
            Console.Write("© 2025 LikeLion Unity 4th Class");

            // start button
            bool showBtn = true;

            while (!Console.KeyAvailable)
            {
                Console.SetCursorPosition(54, 22);
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
            Console.Clear();
        }
    }


    // main screen class
    public class Player
    {
        public int playerX;
        public int playerY;

        public Player()
        {
            playerX = 60;
            playerY = 38;
        }

        public void CreatePlayer()
        {
            string[] player = new string[]
            {
                " ∧＿∧ ",
                "(・ω・)"
            };

            for (int i = 0; i < player.Length; i++)
            {
                Console.SetCursorPosition(playerX, playerY + i);
                Console.WriteLine(player[i]);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Console.SetWindowSize(120, 55);
            Console.SetBufferSize(120, 55); 

            Console.OutputEncoding = Encoding.UTF8;

            TitleScreen titleScreen = new TitleScreen();
            titleScreen.GameTitle();
            Console.Clear();

            Player player = new Player();
            player.CreatePlayer();
            
            

            Console.ReadKey(true); // hide extra message
        }
    }
}
