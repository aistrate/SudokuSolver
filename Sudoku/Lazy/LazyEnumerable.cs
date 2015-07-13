using System.Collections;
using System.Collections.Generic;

namespace Sudoku.Lazy
{
    public class LazyEnumerable<T> : IEnumerable<T>
    {
        public LazyEnumerable(IEnumerable<T> collection)
        {
            onceOnlyEnumerator = collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LazyEnumerator(onceOnlyEnumerator, evaluatedColl);
        }

        private IEnumerator<T> onceOnlyEnumerator;
        private List<T> evaluatedColl = new List<T>();

        public class LazyEnumerator : IEnumerator<T>
        {
            public LazyEnumerator(IEnumerator<T> onceOnlyEnumerator, List<T> evaluatedColl)
            {
                this.onceOnlyEnumerator = onceOnlyEnumerator;
                this.evaluatedColl = evaluatedColl;

                this.evaluatedCollEnumerator = evaluatedColl.GetEnumerator();
            }

            object IEnumerator.Current { get { return current; } }
            T IEnumerator<T>.Current { get { return current; } }

            public bool MoveNext()
            {
                if (isNextEvaluated)
                {
                    if (evaluatedCollEnumerator.MoveNext())
                    {
                        current = evaluatedCollEnumerator.Current;
                        return true;
                    }
                    else
                    {
                        isNextEvaluated = false;
                        return MoveNext();
                    }
                }
                else
                {
                    if (onceOnlyEnumerator.MoveNext())
                    {
                        current = onceOnlyEnumerator.Current;
                        evaluatedColl.Add(current);
                        return true;
                    }
                    else
                    {
                        current = default(T);
                        return false;
                    }
                }
            }

            public void Reset()
            {
                evaluatedCollEnumerator = evaluatedColl.GetEnumerator();
                isNextEvaluated = true;
            }

            public void Dispose() { }

            private T current;
            private bool isNextEvaluated = true;

            private IEnumerator<T> onceOnlyEnumerator;
            private List<T> evaluatedColl;

            private IEnumerator<T> evaluatedCollEnumerator;
        }
    }
}
