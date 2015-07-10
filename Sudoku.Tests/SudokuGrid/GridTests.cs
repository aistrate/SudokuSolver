using System;
using System.Linq;
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
        [ExpectedException(typeof(ApplicationException))]
        public void ValidateRow()
        {
            Grid grid = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 1, 0, 5, 0, 0, 2, 1, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            });
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void ValidateColumn()
        {
            Grid grid = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 2, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 5, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 7, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 5, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 6, 0, 0, 0 },
            });
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void ValidateThreeSquare()
        {
            Grid grid = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 2, 0, 6, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 9, 4, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 2, 0, 0, 0, 0 },
            });
        }

        [Test]
        public void SimpleResolve()
        {
            Grid grid = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 3, 0, 8, 1, 4, 2, 9, 6, 5 },
                new[] { 0, 0, 0, 5, 3, 0, 0, 0, 0 },
                new[] { 4, 5, 2, 9, 6, 8, 1, 7, 0 },
                new[] { 0, 0, 0, 0, 7, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 9, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 8, 0, 0, 0, 0 },
            });

            Grid resolved = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 5, 0, 0, 0, 0 },
                new[] { 3, 7, 8, 1, 4, 2, 9, 6, 5 },
                new[] { 0, 0, 0, 5, 3, 7, 0, 0, 0 },
                new[] { 4, 5, 2, 9, 6, 8, 1, 7, 3 },
                new[] { 0, 0, 0, 0, 7, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 9, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 8, 0, 0, 0, 0 },
            });

            grid.Resolve();

            Assert.AreEqual(resolved, grid);
        }

        [Test]
        public void IsSolved()
        {
            Grid grid = new Grid(new[]
            {
                new[] { 2, 9, 5, 7, 4, 3, 8, 6, 1 },
                new[] { 4, 3, 1, 8, 6, 5, 9, 2, 7 },
                new[] { 8, 7, 6, 1, 9, 2, 5, 4, 3 },
                new[] { 3, 8, 7, 4, 5, 9, 2, 1, 6 },
                new[] { 6, 1, 2, 3, 8, 7, 4, 9, 5 },
                new[] { 5, 4, 9, 2, 1, 6, 7, 3, 8 },
                new[] { 7, 6, 3, 5, 2, 4, 1, 8, 9 },
                new[] { 9, 2, 8, 6, 7, 1, 3, 5, 4 },
                new[] { 1, 5, 4, 9, 3, 8, 6, 7, 2 },
            });

            Assert.IsTrue(grid.IsSolved);
        }

        [Test]
        public void Clone()
        {
            Grid grid = new Grid(new[]
            {
                new[] { 2, 9, 5, 7, 4, 3, 8, 6, 1 },
                new[] { 4, 3, 1, 8, 6, 5, 9, 2, 7 },
                new[] { 8, 7, 6, 1, 9, 2, 5, 4, 3 },
                new[] { 3, 8, 7, 4, 5, 9, 2, 1, 6 },
                new[] { 6, 1, 2, 3, 8, 7, 4, 9, 5 },
                new[] { 5, 4, 9, 2, 1, 6, 7, 3, 8 },
                new[] { 7, 6, 3, 5, 2, 4, 1, 8, 9 },
                new[] { 9, 2, 8, 6, 7, 1, 3, 5, 4 },
                new[] { 1, 5, 4, 9, 3, 8, 6, 7, 2 },
            });

            Grid clone = grid.Clone();

            Assert.AreEqual(grid, clone);
        }

        [Test]
        public void GetAlternatives()
        {
            Grid grid = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 6, 0, 8, 0, 4, 2, 0, 3, 5 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 4, 5, 0, 9, 6, 8, 1, 7, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            });

            Grid alternative1 = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 6, 0, 8, 0, 4, 2, 0, 3, 5 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 4, 5, 2, 9, 6, 8, 1, 7, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            });

            Grid alternative2 = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 6, 0, 8, 0, 4, 2, 0, 3, 5 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 4, 5, 3, 9, 6, 8, 1, 7, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            });

            Grid[] alternatives = grid.GetAlternatives().ToArray();

            Assert.AreEqual(2, alternatives.Length, "Number of alternatives");

            Assert.AreEqual(alternative1, alternatives[0], "First alternative");
            Assert.AreEqual(alternative2, alternatives[1], "Second alternative");
        }

        [Test]
        public void GetAlternativesFromEmpty()
        {
            Grid emptyGrid = new Grid(new[]
            {
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            });

            Grid alternative7 = new Grid(new[]
            {
                new[] { 7, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            });

            Grid[] alternatives = emptyGrid.GetAlternatives().ToArray();

            Assert.AreEqual(9, alternatives.Length, "Number of alternatives");

            Assert.AreEqual(alternative7, alternatives[6], "Alternative 7");
        }
    }
}
