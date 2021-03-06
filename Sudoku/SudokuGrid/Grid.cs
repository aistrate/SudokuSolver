﻿using System;
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
            validateGroups();

            if (!isValid)
            {
                throw new ApplicationException("Value appearing more than once in a group.");
            }
        }

        private void assignGroups()
        {
            Cell[][] rows = grid;

            Cell[][] columns = Enumerable.Range(0, 9).Select(colIndex => Enumerable.Range(0, 9).Select(rowIndex => grid[rowIndex][colIndex]).ToArray()).ToArray();

            Cell[][] threeSquares = new Cell[9][];

            for (int row = 0; row < 9; row++)
                threeSquares[row] = new Cell[9];

            for (int outerRow = 0; outerRow < 3; outerRow++)
                for (int outerCol = 0; outerCol < 3; outerCol++)
                    for (int innerRow = 0; innerRow < 3; innerRow++)
                        for (int innerCol = 0; innerCol < 3; innerCol++)
                            threeSquares[3 * outerRow + outerCol][3 * innerRow + innerCol] = grid[3 * outerRow + innerRow][3 * outerCol + innerCol];

            allGroups = rows.Concat(columns).Concat(threeSquares).ToArray();
        }

        private void validateGroups()
        {
            foreach (Cell[] group in allGroups)
            {
                int[] filledValues = group.Where(cell => cell.Value != 0).Select(cell => cell.Value).ToArray();

                if (filledValues.Count() != filledValues.Distinct().Count())
                {
                    isValid = false;
                    return;
                }
            }

            isValid = true;
        }

        /// <summary>
        /// Get the first set of alternatives with the minimal count. The original Grid remains unchanged.
        /// </summary>
        /// <returns>A collection of Grids representing alternatives.</returns>
        public IEnumerable<Grid> GetAlternatives()
        {
            if (IsUnsolvable)
            {
                throw new ApplicationException("Grid is unsolvable.");
            }

            int minEmptyCells = 10;
            Cell[] minGroup = null;

            foreach (Cell[] group in allGroups)
            {
                int emptyCells = group.Count(cell => cell.Value == 0);

                if (0 < emptyCells && emptyCells < minEmptyCells)
                {
                    minEmptyCells = emptyCells;
                    minGroup = group;
                }
            }

            var alternatives = new List<Grid>();

            if (minGroup != null)
            {
                int[] missingValues = Enumerable.Range(1, 9).Except(minGroup.Where(cell => cell.Value != 0).Select(cell => cell.Value)).ToArray();
                Cell firstEmptyCell = minGroup.First(cell => cell.Value == 0);

                foreach (int missingValue in missingValues)
                {
                    firstEmptyCell.Value = missingValue;
                    validateGroups();

                    if (isValid)
                    {
                        alternatives.Add(this.Clone());
                    }
                }

                firstEmptyCell.Value = 0;
                isValid = (alternatives.Count > 0);
            }

            return alternatives;
        }

        public Grid Clone()
        {
            return new Grid(grid.Select(row => row.Select(cell => cell.Value).ToArray()).ToArray());
        }

        public bool IsSolved
        {
            get { return isValid && grid.All(row => row.All(cell => cell.Value != 0)); }
        }

        public bool IsUnsolvable
        {
            get { return !isValid; }
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
        private Cell[][] allGroups;
        private bool isValid;
    }
}
