using System.Collections.Generic;

namespace Sudoku.Backtracking
{
    internal class BacktrackingStack<TItem> where TItem : class
    {
        public void PushAlternatives(IEnumerable<TItem> alternatives)
        {
            currentFrame = new StackFrame<TItem>(alternatives, currentFrame);
        }

        public TItem NextAlternative()
        {
            TItem nextAlternative = currentFrame.NextAlternative();

            if (nextAlternative == null)
            {
                currentFrame = currentFrame.PreviousFrame;

                if (currentFrame != null)
                {
                    nextAlternative = currentFrame.NextAlternative();
                }
            }

            return nextAlternative;
        }

        private StackFrame<TItem> currentFrame;
    }
}
