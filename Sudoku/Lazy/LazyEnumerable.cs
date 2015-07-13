using System.Collections;
using System.Collections.Generic;

namespace Sudoku.Lazy
{
    public class LazyEnumerable<T> : IEnumerable<T>
    {
        public LazyEnumerable(IEnumerable<T> collection)
        {
            evaluatedColl = new List<T>();
            unevaluatedCollEnumerator = collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LazyEnumerator(evaluatedColl, unevaluatedCollEnumerator);
        }

        private List<T> evaluatedColl;
        private IEnumerator<T> unevaluatedCollEnumerator;

        public class LazyEnumerator : IEnumerator<T>
        {
            public LazyEnumerator(List<T> evaluatedColl, IEnumerator<T> unevaluatedCollEnumerator)
            {
                this.evaluatedColl = evaluatedColl;
                this.evaluatedCollEnumerator = evaluatedColl.GetEnumerator();

                this.unevaluatedCollEnumerator = unevaluatedCollEnumerator;

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

            private List<T> evaluatedColl;
            private IEnumerator<T> evaluatedCollEnumerator;

            private IEnumerator<T> unevaluatedCollEnumerator;
        }
    }
}
