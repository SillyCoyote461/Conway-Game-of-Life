using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    public class GridState
    {
        //sizes
        public int Rows { get; }
        public int Cols { get; }

        //grids
        public bool[,] Grid { get; set; }
        public bool[,] Updater { get; }

        //constructor
        public GridState(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Grid = new bool[rows, cols];
            Updater = new bool[rows, cols];
        }

        //methods
        public void AddEntities()
        {
            //percentage of entities
            int entities = Rows * Cols;
            entities = (entities / 100) * 5;

            //adding entities
            for(int i = 0; i < entities; i++)
            {
                int x = RandomNum(Rows);
                int y = RandomNum(Cols);

                if (Grid[x, y] == false) Grid[x, y] = true;
                else i--;
            }
        }

        public void NextTick()
        {
            for( int x = 0;  x < Rows; x++)
            {
                for( int y = 0; y < Cols; y++)
                {
                    int condition = CountNeighbors(x, y);
                    switch(condition)
                    {
                        case 2:
                            if (Grid[x, y] is true)
                            {
                                Updater[x, y] = true;
                            }
                            break;

                        case 3:
                            Updater[x, y] = true;
                            break;


                        default:
                            Updater[x, y] = false;
                            break;
                    }
                }
            }

            Grid = Updater;
        }

        //utilities
        static int RandomNum(int max)
        {
            Random rnd = new Random();
            return rnd.Next(max);
        }

        internal int CountNeighbors(int row, int col)
        {
            int count = 0;

            //checking neighbors
            do
            {           
                if (Grid[row - 1, col - 1] is true) count++;
                if (Grid[row + 1, col + 1] is true) count++;

                if (Grid[row - 1, col + 1] is true) count++;
                if (Grid[row + 1, col - 1] is true) count++;

                if (Grid[row - 1, col] is true) count++;
                if (Grid[row, col - 1] is true) count++;

                if (Grid[row + 1, col] is true) count++;
                if (Grid[row, col + 1] is true) count++;

            } while (count < 4);

           
            return count;
        }
    }
}
