using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class MinesweeperBoard
    {
        public char[,] board { get; }

        public List<(int x, int y)> mineList { get; }

        public int width { get; }
        public int height { get; }

        public MinesweeperBoard(int width, int height, int mines)
        {
            if (mines > width * height)
            {
                throw new Exception("Too many mines for board size");
            }

            board = new char[width, height];
            board.Fill(' ');

            this.width = width;
            this.height = height;
            this.mineList = new List<(int x, int y)>();

            FillBoard(mines);
        }

        public MinesweeperBoard(char[,] savedBoard)
        {
            board = savedBoard;

            this.width = board.GetLength(0);
            this.height = board.GetLength(1);
            this.mineList = FindMines();
        }

        private List<(int x, int y)> FindMines()
        {
            var mineListTemp = new List<(int x, int y)>();

            for (var x = 0; x < board.GetLength(0); x++)
                for (var y = 0; y < board.GetLength(1); y++)
                    if (board[x, y] == 'X')
                        mineListTemp.Add((x, y));

            return mineListTemp;
        }

        private void FillBoard(int mines)
        {
            var r = new Random();

            for (var i = 0; i < mines; i++)
            {
                var x = r.Next(width);
                var y = r.Next(height);

                if (board[x, y] == 'X')
                {
                    continue;
                }

                board[x, y] = 'X';
                mineList.Add((x, y));
            }
        }

        public int CalculateNearbyBombs(int x, int y)
        {
            if (board[x, y] == 'X')
            {
                return -1;
            }
            
            var coordSets = GetSurroundingCells(x, y);

            var bombCounter = 0;
            foreach (var coordSet in coordSets)
            {
                if (board.IsBomb(coordSet.x, coordSet.y))
                    bombCounter++;
            }

            return bombCounter;
        }

        public List<(int x, int y)> GetSurroundingCells(int x, int y)
        {
            //  ________
            // |p1|p2|p3|
            // ——————————
            // |p8|xy|p4|
            // ——————————
            // |p7|p6|p5|
            // ‾‾‾‾‾‾‾‾‾‾

            (int x, int y) p1 = (x - 1, y - 1);
            (int x, int y) p2 = (x - 0, y - 1);
            (int x, int y) p3 = (x + 1, y - 1);
            (int x, int y) p4 = (x + 1, y - 0);
            (int x, int y) p5 = (x + 1, y + 1);
            (int x, int y) p6 = (x - 0, y + 1);
            (int x, int y) p7 = (x - 1, y + 1);
            (int x, int y) p8 = (x - 1, y - 0);

            var coordSets = new List<(int x, int y)> {p1, p2, p3, p4, p5, p6, p7, p8};
            var newCoordSets = new List<(int x, int y)>();

            for (var i = 0; i < coordSets.Count; i++)
            {
                if (ValidateCoordSet(coordSets[i]))
                    newCoordSets.Add(coordSets[i]);
            }

            return newCoordSets;
        }

        public bool ValidateCoordSet(int[] coord)
        {
            if (coord.Contains(-1))
                return false;

            if (coord[0] >= width)
                return false;

            if (coord[1] >= height)
                return false;

            return true;
        }

        public bool ValidateCoordSet((int x, int y) coord)
        {
            if (coord.x < 0 || coord.y < 0)
                return false;

            if (coord.x >= width)
                return false;

            if (coord.y >= height)
                return false;

            return true;
        }
    }
}
