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
            if (currentFrame == null)
            {
                return null;
            }

            TItem nextAlternative = currentFrame.NextAlternative();

            if (nextAlternative == null)
            {
                currentFrame = currentFrame.PreviousFrame;

                return NextAlternative();
            }

            return nextAlternative;
        }

        private StackFrame<TItem> currentFrame;
    }
}
