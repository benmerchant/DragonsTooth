using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsTooth
{
    public class Tile
    {
        private string symbol;
        private ConsoleColor color;
        private bool playerHere;
        private bool stairsHere;
        private bool monsterHere;

        public Tile()
        {
            symbol = "#";
            color = ConsoleColor.Blue;
            playerHere = false;
            stairsHere = false;
            monsterHere = false;
        }








        public string Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
            }
        }
        public ConsoleColor Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public bool StairsHere
        {
            get
            {
                return stairsHere;
            }
            set
            {
                stairsHere = value;
            }
        }
        public bool PlayerHere
        {
            get
            {
                return playerHere;
            }
            set
            {
                playerHere = value;
            }
        }
        public bool MonsterHere
        {
            get
            {
                return monsterHere;
            }
            set
            {
                monsterHere = value;
            }
        }
    }
}
