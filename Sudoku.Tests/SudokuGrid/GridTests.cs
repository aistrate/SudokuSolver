using System;
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

        //[Test]
        //public void AssignThreeSquares()
        //{
        //    Grid grid = new Grid(new[]
        //    {
        //        new[] { 11, 12, 13, 21, 22, 23, 31, 32, 33 },
        //        new[] { 14, 15, 16, 24, 25, 26, 34, 35, 36 },
        //        new[] { 17, 18, 19, 27, 28, 29, 37, 38, 39 },
        //        new[] { 41, 42, 43, 51, 52, 53, 61, 62, 63 },
        //        new[] { 44, 45, 46, 54, 55, 56, 64, 65, 66 },
        //        new[] { 47, 48, 49, 57, 58, 59, 67, 68, 69 },
        //        new[] { 71, 72, 73, 81, 82, 83, 91, 92, 93 },
        //        new[] { 74, 75, 76, 84, 85, 86, 94, 95, 96 },
        //        new[] { 77, 78, 79, 87, 88, 89, 97, 98, 99 },
        //    });
        //}

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

        //[Test]
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
