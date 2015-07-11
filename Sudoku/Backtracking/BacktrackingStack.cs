using System.Collections.Generic;

namespace Sudoku.Backtracking
{
    public class BacktrackingStack<TItem> where TItem : class
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

        public int Depth
        {
            get { return currentFrame.Depth; }
        }

        private StackFrame<TItem> currentFrame;
    }
}
