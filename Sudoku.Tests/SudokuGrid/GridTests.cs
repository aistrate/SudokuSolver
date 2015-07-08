using System.Collections.Generic;
using NUnit.Framework;
using Sudoku.SudokuGrid;

namespace Sudoku.Tests.SudokuGrid
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void ObjectCreation()
        {
            Grid grid = new Grid(
                new List<List<int>>
                {
                    new List<int> { 0, 0, 3, 0, 2, 0, 6, 0, 0 },
                    new List<int> { 9, 0, 0, 3, 0, 5, 0, 0, 1 },
                    new List<int> { 0, 0, 1, 8, 0, 6, 4, 0, 0 },
                    new List<int> { 0, 0, 8, 1, 0, 2, 9, 0, 0 },
                    new List<int> { 7, 0, 0, 0, 0, 0, 0, 0, 8 },
                    new List<int> { 0, 0, 6, 7, 0, 8, 2, 0, 0 },
                    new List<int> { 0, 0, 2, 6, 0, 9, 5, 0, 0 },
                    new List<int> { 8, 0, 0, 2, 0, 3, 0, 0, 9 },
                    new List<int> { 0, 0, 5, 0, 1, 0, 3, 0, 0 },
                });
        }
    }
}
