using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsTooth
{
    public class HUD
    {
        private Point hud0;
        public Point nameLocation { get; set; }
        // where to print name
        public Point name { get; }
        // where to print HP
        public Point HP { get; }
        // where to print maxHP
        public Point maxHP { get; }
        // where to print experience
        public Point exp { get; }
        // where to print experience to next level
        public Point nextLvl { get; }
        // where to print level
        public Point level { get; }
        // where to print attack
        public Point attack { get; }
        // where to print defense
        public Point defense { get; }



        public HUD(Player player, int startX, int startY, int xOffset, int height)
        {
            hud0 = new Point(startX, startY);
            // set the Points for all the variables
            name = new Point(hud0.X + 2, 2);
            level = new Point(hud0.X + 9, 4);
            HP = new Point(hud0.X+2+4, 6);
            maxHP = new Point(HP.X + 5, 6);
            exp = new Point(hud0.X + 2+5, 8);
            nextLvl = new Point(exp.X + 3, 8);

            // print the title and outline
            Console.SetCursorPosition(hud0.X, hud0.Y);
            Console.Write("*****Dragon's Tooth*****");

            for (int i = 1; i < height; i++)
            {
                Console.SetCursorPosition(hud0.X, hud0.Y + i);
                Console.Write("*");
            }
            for (int i=1; i<height; i++)
            {
                Console.SetCursorPosition(hud0.X+xOffset-1, hud0.Y + i);
                Console.Write("*");
            }
            Console.SetCursorPosition(hud0.X, height);
            Console.Write(new string('*', xOffset));

            // print player name
            Console.SetCursorPosition(name.X, name.Y);
            Console.Write(player.Name);
            // print player level
            Console.SetCursorPosition(level.X-7, level.Y);
            Console.Write("Level: {0}", player.Level);
            // print player health
            Console.SetCursorPosition(HP.X-4, HP.Y);
            Console.Write("HP: {0} / {1}", player.HitPoints, player.MaxHP);
            // print player experience
            Console.SetCursorPosition(exp.X-5, exp.Y);
            Console.Write("EXP: {0} / {1}", player.Exp, player.ExpToNext);

            
        
            

        }

        

        

        
    }
}
