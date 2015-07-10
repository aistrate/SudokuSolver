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

            this.grid = grid;
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
            return string.Join(",", grid.Select(row => string.Join("", row)));
        }

        private int[][] grid;
    }
}
