using System.Collections;
using System.Collections.Generic;

namespace Sudoku.Lazy
{
    public class LazyEnumerable<T> : IEnumerable<T>
    {
        public LazyEnumerable(IEnumerable<T> collection)
        {
            evaluatedColl = new DynamicList<T>();
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

        private DynamicList<T> evaluatedColl;
        private IEnumerator<T> unevaluatedCollEnumerator;

        public class LazyEnumerator : IEnumerator<T>
        {
            public LazyEnumerator(DynamicList<T> evaluatedColl, IEnumerator<T> unevaluatedCollEnumerator)
            {
                this.evaluatedColl = evaluatedColl;
                this.evaluatedCollEnumerator = evaluatedColl.GetEnumerator();

                this.unevaluatedCollEnumerator = unevaluatedCollEnumerator;
            }

            object IEnumerator.Current { get { return ((IEnumerator<T>)this).Current; } }

            T IEnumerator<T>.Current { get { return current; } }

            public bool MoveNext()
            {
                bool hasNext = evaluatedCollEnumerator.MoveNext();

                if (!hasNext)
                {
                    hasNext = unevaluatedCollEnumerator.MoveNext();

                    if (hasNext)
                    {
                        evaluatedColl.Add(unevaluatedCollEnumerator.Current);
                    }
                }

                current = evaluatedCollEnumerator.Current;

                return hasNext;
            }

            public void Reset()
            {
                evaluatedCollEnumerator = evaluatedColl.GetEnumerator();
            }

            public void Dispose() { }

            private T current;

            private DynamicList<T> evaluatedColl;
            private IEnumerator<T> evaluatedCollEnumerator;

            private IEnumerator<T> unevaluatedCollEnumerator;
        }
    }
}
