using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsTooth
{
    public class Player
    {
        private int hitPoints;
        private int maxHP;
        private int level;
        private string name;
        private string story;
        private int exp;
        private int expToNext;
        private int money;
        private int attack;
        private int defense;
        private int locX; // determines player's location
        private int locY; // on the map
        private int move; // player move counter (direction)

        // Default Constructor
        public Player()
        {
            name = nameGen();
            story = historyGen();
            hitPoints = 100;
            maxHP = 100;
            exp = 0;
            expToNext = 100;
            level = 1;


            move = 0;

        }

        public static string nameGen()
        {
            string[] fNom = { "Jarben", "Sterve", "Cranston", "Flaque", "Franch", "Lispon", "Caliette", "Frondon", "Altsy", "Lacrid", "Gless", "Bors" };
            string[] lNom = { "Strongapple", "Elemenson", "Allots", "Shandz", "Iverns", "Helkim", "Ahf", "Sindaloy", "Ucho", "Flandge", "Malfonch", "Omarrrr" };

            int fLuck = dieRoller.roll(fNom.Length - 1);
            int lLuck = dieRoller.roll(lNom.Length - 1);

            return fNom[fLuck] + " " + lNom[fLuck];
        }
        public static string historyGen()
        {
            string[] stories = new string[12];
            stories[0] = "From Sol";
            stories[1] = "From Mercury";
            stories[2] = "From Venus";
            stories[3] = "From Earth";
            stories[4] = "From Asteroid Belt";
            stories[5] = "From Jupiter";
            stories[6] = "From Saturn";
            stories[7] = "From Uranus";
            stories[8] = "From Pluto";
            stories[9] = "From Space Station Prime";
            stories[10] = "From Outpost Charles Barkley";
            stories[11] = "From Catastrophic Ruins";

            int luck = dieRoller.roll(stories.Length-1);
            return stories[luck];
        }

        // places player the first time it finds a '.' - floor tile
        public static void placePlayer(Board board, Player player)
        {
            bool superfluousBoolean = false;
            for (int i = 1; i < board.H; i++)
            {
                for (int j = 1; j < board.W; j++)
                {
                    if (board.TheMap[i, j].Symbol == ".")
                    {
                        if (superfluousBoolean == false)
                        {
                            player.locY = i; 
                            player.locX = j;
                            board.TheMap[i, j].Symbol = "@";
                            board.TheMap[i, j].Color = ConsoleColor.DarkRed;
                            superfluousBoolean = true;
                        }
                    }
                }
            }


             
        }

        
       

        // Properties
        public int HitPoints
        {
            get
            {
                return hitPoints;
            }
            set
            {
                hitPoints = value;
            }
        }
        public int MaxHP
        {
            get
            {
                return maxHP;
            }
            set
            {
                maxHP = value;
            }
        }
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Story
        {
            get
            {
                return story;
            }
        }
        public int Move { get; set; }
        public int Exp
        {
            get
            {
                return exp;
            }
            set
            {
                exp = value;
            }
        }
        public int ExpToNext
        {
            get
            {
                return expToNext;
            }
            set
            {
                expToNext = value;
            }
        }
        public int Money { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int LocX
        {
            get
            {
                return locX;
            }
            set
            {
                locX = value;
            }
        }
        public int LocY
        {
            get
            {
                return locY;
            }
            set
            {
                locY = value;
            }
        }


    }

}
