using System;
using System.Collections.Generic;
using System.IO;
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

            Console.WriteLine(grid);
            Console.WriteLine(solutions[0]);
        }

        [Test]
        public void EmptyGrid()
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

            const int solutionCount = 10;

            Grid[] solutions = Solver.GetSolutions(emptyGrid).Take(solutionCount).ToArray();

            Assert.AreEqual(solutionCount, solutions.Length, "Number of solutions");

            for (int i = 0; i < solutionCount; i++)
            {
                Assert.IsTrue(solutions[i].IsSolved, "Solution " + (i + 1));

                Console.WriteLine(solutions[i]);
            }
        }

        [Test]
        public void Performance()
        {
            const int repetitions = 10;    // Can be a larger number

            for (int i = 0; i < repetitions; i++)
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
            }
        }

        [Test]
        public void SolveEasyGrids()
        {
            // All 50 grids take 128 sec to run. The slowest are Grid 47 (40 sec) and Grid 49 (63 sec).
            // The first 46 grids take 23 sec to run. The first 10 take 5 sec.
            Grid[] grids = readGridsFromFile(@"..\..\Examples\EasyGrids.txt").Take(10).ToArray();
            solveGrids(grids);
        }

        //[Test]
        public void SolveHardGrids()
        {
            // 95 grids; they run very slow
            Grid[] grids = readGridsFromFile(@"..\..\Examples\HardGrids.txt").ToArray();
            solveGrids(grids);
        }

        [Test]
        public void SolveHarderGrid()
        {
            // 1 grid, 2 sec to run
            Grid[] grids = readGridsFromFile(@"..\..\Examples\HarderGrid.txt").ToArray();
            solveGrids(grids);
        }

        private void solveGrids(Grid[] grids)
        {
            for (int i = 0; i < grids.Length; i++)
            {
                Grid[] solutions = Solver.GetSolutions(grids[i]).ToArray();

                Assert.AreEqual(1, solutions.Length, "Solutions for grid " + (i + 1));
                Assert.IsTrue(solutions[0].IsSolved, "IsSolved for grid " + (i + 1));

                Console.WriteLine("Grid " + (i + 1));
                Console.WriteLine(grids[i]);
                Console.WriteLine(solutions[0]);
            }
        }

        private IEnumerable<Grid> readGridsFromFile(string filePath)
        {
            List<int[]> grid = null;
            int gridLine = 0;

            foreach (string line in readLinesFromFile(filePath))
            {
                if (gridLine == 0)
                {
                    grid = new List<int[]>();
                }
                else
                {
                    int[] gridRow = line.ToCharArray().Select(c => ((int)c - (int)'0')).ToArray();
                    grid.Add(gridRow);
                }

                gridLine++;

                if (gridLine > 9)
                {
                    gridLine = 0;
                    yield return new Grid(grid.ToArray());
                }
            }
        }

        private IEnumerable<string> readLinesFromFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                        break;
                    yield return line;
                }
            }
        }
    }
}
