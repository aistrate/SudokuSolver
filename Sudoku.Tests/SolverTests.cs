using System.Linq;
using NUnit.Framework;
using Sudoku.SudokuGrid;

namespace Sudoku.Tests
{
    [TestFixture]
    public class SolverTests
    {
        [Test]
        public void GetSolutions()
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

            Grid[] solutions = Solver.GetSolutions(grid).ToArray();

            Assert.AreEqual(1, solutions.Length, "Number of solutions");
            Assert.IsTrue(solutions[0].IsSolved, "IsSolved");
        }
    }
}
