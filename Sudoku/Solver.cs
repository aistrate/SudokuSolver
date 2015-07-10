using System.Collections.Generic;
using Sudoku.Backtracking;
using Sudoku.SudokuGrid;

namespace Sudoku
{
    public static class Solver
    {
        public static IEnumerable<Grid> GetSolutions(Grid grid)
        {
            var backtrackingStack = new BacktrackingStack<Grid>();

            backtrackingStack.PushAlternatives(new[] { grid.Clone() });

            while (true)
            {
                Grid currentGrid = backtrackingStack.NextAlternative();

                if (currentGrid == null)
                {
                    yield break;
                }

                currentGrid.Resolve();

                if (currentGrid.IsUnsolvable)
                {
                    continue;
                }
                else if (currentGrid.IsSolved)
                {
                    yield return currentGrid;
                }

                backtrackingStack.PushAlternatives(currentGrid.GetAlternatives());
            }
        }
    }
}
