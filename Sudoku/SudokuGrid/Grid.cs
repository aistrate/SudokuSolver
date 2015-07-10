using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.SudokuGrid
{
    public class Grid : IEquatable<Grid>
    {
        public Grid(int[][] grid)
        {
            if (grid == null || grid.Length != 9 || grid.Any(row => row == null || row.Length != 9))
            {
                throw new ApplicationException("Grid has the wrong dimensions.");
            }

            if (grid.Any(row => row.Any(elem => elem < 0 || elem > 9)))
            {
                throw new ApplicationException("Grid should contain numbers between 0 and 9.");
            }

            this.grid = grid.Select(row => row.Select(val => new Cell(val)).ToArray()).ToArray();

            assignGroups();
        }

        private void assignGroups()
        {
            rows = grid;

            columns = Enumerable.Range(0, 9).Select(colIndex => Enumerable.Range(0, 9).Select(rowIndex => grid[rowIndex][colIndex]).ToArray()).ToArray();

            threeSquares = new Cell[9][];
            for (int row = 0; row < 9; row++)
                threeSquares[row] = new Cell[9];

            for (int outerRow = 0; outerRow < 3; outerRow++)
                for (int outerCol = 0; outerCol < 3; outerCol++)
                    for (int innerRow = 0; innerRow < 3; innerRow++)
                        for (int innerCol = 0; innerCol < 3; innerCol++)
                            threeSquares[3 * outerRow + outerCol][3 * innerRow + innerCol] = grid[3 * outerRow + innerRow][3 * outerCol + innerCol];

            //Console.WriteLine(string.Join("\n", threeSquares.Select(row => string.Join(",", row.Select(cell => cell.Value)))) + "\n");
        }

        /// <summary>
        /// Partially resolve the grid (the cells that have a unique solution). The grid will be changed in place.
        /// </summary>
        public void Resolve()
        {

        }

        /// <summary>
        /// Get the first set of alternatives with the minimal count. The original Grid remains unchanged.
        /// </summary>
        /// <returns>A collection of Grids representing alternatives.</returns>
        public IEnumerable<Grid> GetAlternatives()
        {
            return new List<Grid>();
        }

        public bool IsSolved
        {
            get { return false; }
        }

        public bool IsUnsolvable
        {
            get { return false; }
        }

        bool IEquatable<Grid>.Equals(Grid other)
        {
            return other != null &&
                   this.ToString() == other.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return ((IEquatable<Grid>)this).Equals(obj as Grid);
        }

        public override string ToString()
        {
            return string.Join(",", grid.Select(row => string.Join("", row.Select(cell => cell.Value))));
        }

        private Cell[][] grid;

        private Cell[][] rows;
        private Cell[][] columns;
        private Cell[][] threeSquares;
    }
}
