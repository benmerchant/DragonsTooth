using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsTooth
{
    public class Board
    {
        private int h; // height of the Board
        private int w; // width of the Board
        private Tile[,] theMap; // the Board itself
        private int innerH; // height of the board inside border
        private int innerW; // width of the board inside border
        private int mapArea; // the Area of Tiles in the map
        public List<Point> midPoints; // list of midpoints
        public const int NUMROOMS = 10; // number of rooms
        public List<Point> walkinTiles; // list of walkable area tiles
        public List<int> monsterPoints; // list of indexes in walkinTiles where a monster exists


        public Board(int height, int width)
        {
            h = height;
            w = width;
            theMap = new Tile[h, w];
            innerH = h - 2;
            innerW = w - 2;
            mapArea = h * w;
            midPoints = new List<Point>();
            walkinTiles = new List<Point>();
            monsterPoints = new List<int>();

            //create Board
            createBoard();
            int roomCounter = 0;
            
            while (roomCounter < NUMROOMS)
            {
                int roomWidth = StaticRandom.Instance.Next(7, 14);//dieRoller.roll(3, 3);
                int roomHeight = StaticRandom.Instance.Next(4, 7);//dieRoller.roll(3, 3);
                int randX = dieRoller.roll(innerW - roomWidth);
                int randY = dieRoller.roll(innerH - roomHeight);
                
                
                if (checkRoom(randX, randY, roomHeight, roomWidth) == true)
                {
                    roomCarve(randX, randY, roomHeight, roomWidth);
                    roomCounter++;
                }
            }

            

            buildCorridors();
            placeStairs();
            hideMonsters();
            
            
        }

        private void createBoard()
        {
            for(int i=0; i<h; i++)
            {
                for(int j=0; j<w; j++)
                {
                    theMap[i, j] = new Tile();
                    
                }
            }
         
        }
        public static void showBoard(Board theBoard, Player thePlayer)
        {
            for(int i=0; i<theBoard.h; i++)
            {
                for(int j=0; j<theBoard.w; j++)
                {
                    Console.ForegroundColor = theBoard.theMap[i, j].Color;
                    Console.Write(theBoard.theMap[i, j].Symbol);

                    if (j == theBoard.w-1)
                    {
                        Console.WriteLine();
                    }
                    
                }
            }
            Console.ResetColor();
        }
        private bool checkRoom(int x, int y, int h, int l)
        {
            for(int i = y; i < y + h; i++)
            {
                for(int j = x; j < x +l; j++)
                {
                    if(theMap[i,j].Symbol != "#")
                    {
                        return false;
                    }
                }
            }
            // give each room a border (no rooms touching)

            // check left and right side
            for(int i = y-1; i < y + h + 1; i++)
            {
                if(theMap[i, x-1].Symbol == "." || theMap[i, x+l+1].Symbol == ".")
                {
                    return false;
                    
                }
                
            }
            // check top and bottom
            // no need to check the right and left edges
            for(int j = x; j<x+l; j++)
            {
                if(theMap[y-1, j].Symbol == "." || theMap[y+h+1,j].Symbol == ".")
                {
                    return false;
                }
            } // could nest those two for loops
           
            




            return true;
        }
        private void roomCarve(int x, int y, int h, int l)
        {
            int xMid;
            int yMid;

            for (int i = y; i < y + h; i++)
            {
                for(int j = x; j < x + l; j++)
                {
                    theMap[i, j].Symbol = ".";
                    theMap[i, j].Color = ConsoleColor.Green;
                }
            }

            //find the midpoint
            xMid = (x + x + l) / 2; 
            yMid = (y + y + h) / 2;

           // theMap[yMid, xMid].Symbol = "m"; // test symbol on the midpoint

            midPoints.Add(new Point(xMid, yMid)); // store midpoint in the list of Points

            
            
            
        }
        private void placeStairs()
        {
            int stairX;
            int stairY;
            int roomFailCount =0; // number of times the tile was a wall
            while (true)
              {
                stairX = dieRoller.roll(innerW);
                stairY = dieRoller.roll(innerH);
                
                if(theMap[stairY, stairX].Symbol != "#")
                {
                    theMap[stairY, stairX].StairsHere = true;
                    theMap[stairY, stairX].Symbol = "<";
                    //theMap[stairY, stairX].Color = ConsoleColor.Red;
                    break;
                }
                else
                {
                    roomFailCount++;
                }
            }
            //Console.WriteLine("stairs not on acceptabel tile => {0}", roomFailCount);
        }
        private void buildCorridors()
        {
            int roomCounter = 0;
            int room1X, room1Y, room2X, room2Y;

            while (roomCounter < NUMROOMS) // links all rooms to next room
                                               // add later connecting last room to first room
            {
                int roomCounterNext = roomCounter + 1; 

                if(roomCounter == NUMROOMS - 1)
                {
                    roomCounterNext = 0;
                }

                room1X = midPoints[roomCounter].X;
                room1Y = midPoints[roomCounter].Y;
                room2X = midPoints[roomCounterNext].X;
                room2Y = midPoints[roomCounterNext].Y;

                


                // this if statemen will print corridors over other coriders
                // build corridor vertically
                if (room1Y < room2Y) // room 1 lower than room 2
                {
                    for (int i = room1Y; i <= room2Y; i++)
                    {
                        theMap[i, room1X].Symbol = ".";
                        theMap[i, room1X].Color = ConsoleColor.Green;
                    }
                    
                }
                else if (room1Y > room2Y) // room 1 higher than room 2
                {
                    for (int i = room1Y; i >= room2Y; i--)
                    {
                        theMap[i, room1X].Symbol = ".";
                        theMap[i, room1X].Color = ConsoleColor.Green;
                    }
                }

                // build corridor vertically
                if (room1X < room2X) // room 1 further left than room 2
                {
                    for (int j = room1X; j <= room2X; j++)
                    {
                        theMap[room2Y, j].Symbol = ".";
                        theMap[room2Y, j].Color = ConsoleColor.Green;
                    }
                } else if (room1X>room2X) // room 1 further right than room 2
                {
                    for(int j = room1X; j >= room2X; j--)
                    {
                        theMap[room2Y, j].Symbol = ".";
                        theMap[room2Y, j].Color = ConsoleColor.Green;
                    }
                }




               // theMap[room1Y, room1X].Symbol = "M"; // test symbol on the midpoint
                roomCounter++;
            }
        }
        private void hideMonsters()
        {
            // save all the good tiles, maybe unncessary, but makes it easy for randomization
            for (int i = 1; i < h; i++)
            {
                for (int j = 1; j < w; j++)
                {
                    if (theMap[i, j].Symbol == ".") walkinTiles.Add(new Point(j, i));
                }
            }

            int numTiles = walkinTiles.Count<Point>();
            // i want 5 percent of the tiles to have a monster
            int numMonsters = numTiles / 20;

            int monsterCounter = 0;

            while (monsterCounter < numMonsters - 1)
            {
                // add a new random integer from all the numbered floor tiles
                monsterPoints.Add(dieRoller.roll(numTiles));
                // add a monster the tile corresponding to the index in the point list
                theMap[walkinTiles[monsterPoints[monsterCounter]].Y,
                       walkinTiles[monsterPoints[monsterCounter]].X]
                       .MonsterHere = true;

                theMap[walkinTiles[monsterPoints[monsterCounter]].Y,
                      walkinTiles[monsterPoints[monsterCounter]].X]
                      .Symbol = "X";

                monsterCounter++;
            }



           

            
                
            

            
        }




        public int H
        {
            get
            {
                return h;
            }

        }
        public int W
        {
            get
            {
                return w;
            }
        }
        public Tile[,] TheMap
        {
            get
            {
                return theMap;
            }
            
        }
        public int MapArea
        {
            get
            {
                return mapArea;
            }
        }
    }
}
