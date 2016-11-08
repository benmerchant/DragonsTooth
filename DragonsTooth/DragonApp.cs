using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsTooth
{
    class DragonApp
    {
        static void Main(string[] args)
        {
            int row = 30; // height
            int col = 70; // width

            int windowX = col + 25; // width
            int windowY = row + 20; // height

            // HUD offset from right edge of screen
            int hudOffset = 24;
            int hudHeight = 20;
            // where to place HUD
            int hudPosX = windowX-hudOffset;     // x-position 
            int hudPosY = 0;    // y-position



            Player _player = new Player(); // instantiate new player
            

            // set the console size
            Console.SetWindowSize(windowX, windowY);
           
            Board _board = new Board(row, col); // instantiate new Board object

            Player.placePlayer(_board, _player);

            Board.showBoard(_board, _player);

            HUD _hud = new HUD(_player, hudPosX, hudPosY, hudOffset, hudHeight);

            

            functionality.playerMove(_board, _player, _hud);

            Console.WriteLine("MAIN - playerMove exited");
            Console.ReadKey();

                

            

            
           

        } 
    }
}
