using System.Collections;
using System.Collections.Generic;

namespace Sudoku.Lazy
{
    public class LazyEnumerable<T> : IEnumerable<T>
    {
        public LazyEnumerable(IEnumerable<T> collection)
        {
            unevaluatedCollEnumerator = collection.GetEnumerator();
            evaluatedColl = new List<T>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LazyEnumerator(unevaluatedCollEnumerator, evaluatedColl);
        }

        private IEnumerator<T> unevaluatedCollEnumerator;
        private List<T> evaluatedColl;

        public class LazyEnumerator : IEnumerator<T>
        {
            public LazyEnumerator(IEnumerator<T> unevaluatedCollEnumerator, List<T> evaluatedColl)
            {
                this.unevaluatedCollEnumerator = unevaluatedCollEnumerator;
                this.evaluatedColl = evaluatedColl;

                this.evaluatedCollEnumerator = evaluatedColl.GetEnumerator();

                this.isNextEvaluated = true;
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
                    if (unevaluatedCollEnumerator.MoveNext())
                    {
                        current = unevaluatedCollEnumerator.Current;
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
            private bool isNextEvaluated;

            private IEnumerator<T> unevaluatedCollEnumerator;
            private List<T> evaluatedColl;

            private IEnumerator<T> evaluatedCollEnumerator;
        }
    }
}
