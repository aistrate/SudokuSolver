using System.Collections.Generic;

namespace Sudoku.Backtracking
{
    internal class StackFrame<TItem> where TItem : class
    {
        public StackFrame(IEnumerable<TItem> alternatives, StackFrame<TItem> previousFrame)
        {
            this.alternatives = alternatives != null ? new List<TItem>(alternatives) : new List<TItem>();
            this.previousFrame = previousFrame;
        }

        public TItem NextAlternative()
        {
            if (alternatives.Count == 0 || currentIndex >= alternatives.Count)
            {
                return null;
            }

            return alternatives[currentIndex++];
        }

        public StackFrame<TItem> PreviousFrame
        {
            get { return previousFrame; }
        }

        public int Depth
        {
            get { return previousFrame != null ? previousFrame.Depth + 1 : 1; }
        }

        private int currentIndex = 0;
        private List<TItem> alternatives;
        private StackFrame<TItem> previousFrame;
    }
}
