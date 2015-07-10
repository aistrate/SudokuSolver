using System.Collections.Generic;
using NUnit.Framework;
using Sudoku.SudokuGrid;

namespace Sudoku.Tests.SudokuGrid
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void Constructor()
        {
            Grid grid = new Grid(new[]
            {
                new[] { 0, 0, 3, 0, 2, 0, 6, 0, 0 },
                new[] { 9, 0, 0, 3, 0, 5, 0, 0, 1 },
                new[] { 0, 0, 1, 8, 0, 6, 4, 0, 0 },
                new[] { 0, 0, 8, 1, 0, 2, 9, 0, 0 },
                new[] { 7, 0, 0, 0, 0, 0, 0, 0, 8 },
                new[] { 0, 0, 6, 7, 0, 8, 2, 0, 0 },
                new[] { 0, 0, 2, 6, 0, 9, 5, 0, 0 },
                new[] { 8, 0, 0, 2, 0, 3, 0, 0, 9 },
                new[] { 0, 0, 5, 0, 1, 0, 3, 0, 0 },
            });
        }

        [Test]
        public void Equals()
        {
            Grid first = new Grid(new[]
            {
                new[] { 0, 0, 3, 0, 2, 0, 6, 0, 0 },
                new[] { 9, 0, 0, 3, 0, 5, 0, 0, 1 },
                new[] { 0, 0, 1, 8, 0, 6, 4, 0, 0 },
                new[] { 0, 0, 8, 1, 0, 2, 9, 0, 0 },
                new[] { 7, 0, 0, 0, 0, 0, 0, 0, 8 },
                new[] { 0, 0, 6, 7, 0, 8, 2, 0, 0 },
                new[] { 0, 0, 2, 6, 0, 9, 5, 0, 0 },
                new[] { 8, 0, 0, 2, 0, 3, 0, 0, 9 },
                new[] { 0, 0, 5, 0, 1, 0, 3, 0, 0 },
            });

            Grid second = new Grid(new[]
            {
                new[] { 0, 0, 3, 0, 2, 0, 6, 0, 0 },
                new[] { 9, 0, 0, 3, 0, 5, 0, 0, 1 },
                new[] { 0, 0, 1, 8, 0, 6, 4, 0, 0 },
                new[] { 0, 0, 8, 1, 0, 2, 9, 0, 0 },
                new[] { 7, 0, 0, 0, 0, 0, 0, 0, 8 },
                new[] { 0, 0, 6, 7, 0, 8, 2, 0, 0 },
                new[] { 0, 0, 2, 6, 0, 9, 5, 0, 0 },
                new[] { 8, 0, 0, 2, 0, 3, 0, 0, 9 },
                new[] { 0, 0, 5, 0, 1, 0, 3, 0, 0 },
            });

            Assert.AreEqual(first, second);
        }

        [Test]
        public void SimpleResolve()
        {
            Grid before = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 3, 0, 8, 1, 4, 2, 9, 6, 5 },
                new[] { 0, 0, 0, 5, 3, 0, 0, 0, 0 },
                new[] { 7, 5, 2, 9, 6, 8, 1, 4, 0 },
                new[] { 0, 0, 0, 0, 7, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 9, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 8, 0, 0, 0, 0 },
            });

            Grid after = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 5, 0, 0, 0, 0 },
                new[] { 3, 7, 8, 1, 4, 2, 9, 6, 5 },
                new[] { 0, 0, 0, 5, 3, 7, 0, 0, 0 },
                new[] { 7, 5, 2, 9, 6, 8, 1, 4, 3 },
                new[] { 0, 0, 0, 0, 7, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 9, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 8, 0, 0, 0, 0 },
            });

            before.Resolve();

            Assert.AreEqual(before, after);
        }
    }
}
