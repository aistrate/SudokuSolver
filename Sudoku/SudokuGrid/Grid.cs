using System;
using System.Collections.Generic;

namespace Sudoku.SudokuGrid
{
    public class Grid
    {
        public Grid(List<List<int>> grid)
        {
            if (grid == null || grid.Count != 9 || grid.Exists(row => row == null || row.Count != 9))
            {
                throw new ApplicationException("Grid has the wrong dimensions.");
            }

            if (grid.Exists(row => row.Exists(elem => elem < 0 || elem > 9)))
            {
                throw new ApplicationException("Grid should contain numbers between 0 and 9.");
            }
        }

        /// <summary>
        /// Partially resolve the grid (the cells that have a unique solution). The grid is changed in place.
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
    }
}
