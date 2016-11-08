using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsTooth
{
    public class functionality
    {
        

        public static void playerMove(Board board, Player player, HUD hud)
        {
            List<ConsoleKey> arrows = new List<ConsoleKey>();
            arrows.Add(ConsoleKey.UpArrow);
            arrows.Add(ConsoleKey.DownArrow);
            arrows.Add(ConsoleKey.LeftArrow);
            arrows.Add(ConsoleKey.RightArrow);

            int initCursorY = board.H + 3;

            Console.SetCursorPosition(0, initCursorY);
            Console.WriteLine("Use arrow keys to move your character: @\nPress [ESCAPE] to stop moving");

            Point previous = new Point(player.LocX, player.LocY); // initialize variables for initial location

            ConsoleKeyInfo mover;

            do
            {
                
                mover = Console.ReadKey();
                Console.Write(new string(' ', Console.WindowWidth));

                if (!arrows.Contains(mover.Key))
                {
                    Console.SetCursorPosition(0, initCursorY + 2);
                    
                    continue;
                }
                previous.Y = player.LocY;
                previous.X = player.LocX;


                // based on arrow key, change a player coordimate
                if (mover.Key == ConsoleKey.UpArrow) player.LocY--;
                if (mover.Key == ConsoleKey.DownArrow) player.LocY++;
                if (mover.Key == ConsoleKey.RightArrow) player.LocX++;
                if (mover.Key == ConsoleKey.LeftArrow) player.LocX--;

                // if new tile is a wall
                if (board.TheMap[player.LocY, player.LocX].Symbol == "#")
                {
                    Console.SetCursorPosition(0, initCursorY + 2);
                    Console.WriteLine("you've hit a wall, sorry m8");
                    player.LocY = previous.Y;
                    player.LocX = previous.X;
                    continue;
                }

                // if new tile is a set of stairs
                if (board.TheMap[player.LocY, player.LocX].StairsHere == true)
                {
                    Console.SetCursorPosition(0, initCursorY + 2);
                    Console.WriteLine("YOU WALKED DOWN THE STAIRS");
                    player.LocY = previous.Y;
                    player.LocX = previous.X;
                    continue;
                }
                if (board.TheMap[player.LocY, player.LocX].MonsterHere == true)
                {
                    Console.SetCursorPosition(0, initCursorY + 2);
                    Console.WriteLine("You just ate a monster");
                    board.TheMap[player.LocY, player.LocX].MonsterHere = false;
                    player.Exp += 10; // update then display
                    Console.SetCursorPosition(hud.exp.X, hud.exp.Y);
                    Console.Write(player.Exp + " / " + player.ExpToNext);

                }

                // if successful input for player movement on walkable tile

                // update new tile symbol, color
                board.TheMap[player.LocY, player.LocX].Symbol = "@";
                board.TheMap[player.LocY, player.LocX].Color = ConsoleColor.DarkRed;
                // re-write the new tile
                Console.SetCursorPosition(player.LocX, player.LocY);
                Console.ForegroundColor = board.TheMap[player.LocY, player.LocX].Color;
                Console.Write(board.TheMap[player.LocY, player.LocX].Symbol);

                // update previous tile symbol, color
                board.TheMap[previous.Y, previous.X].Symbol = ".";
                board.TheMap[previous.Y, previous.X].Color = ConsoleColor.Green;
                // re-write the previous tile
                Console.ForegroundColor = board.TheMap[previous.Y, previous.X].Color;
                Console.SetCursorPosition(previous.X, previous.Y);
                Console.Write(board.TheMap[previous.Y, previous.X].Symbol);

                // reset the cursor to the print out area 
                Console.ResetColor();
                Console.SetCursorPosition(0, initCursorY + 2);



            } while (mover.Key != ConsoleKey.Escape);



        }
    }
}
