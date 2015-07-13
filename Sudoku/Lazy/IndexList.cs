using System;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku.Lazy
{
    /// <summary>
    /// Helper class for LazyEnumerable.
    /// </summary>
    internal class IndexList<T> : IEnumerable<T>
    {
        public void Add(T item)
        {
            list.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new IndexListEnumerator(list);
        }

        private List<T> list = new List<T>();

        private class IndexListEnumerator : IEnumerator<T>
        {
            public IndexListEnumerator(List<T> list)
            {
                this.currentIndex = -1;
                this.list = list;
            }

            object IEnumerator.Current { get { return ((IEnumerator<T>)this).Current; } }

            T IEnumerator<T>.Current
            {
                get { return (0 <= currentIndex && currentIndex < list.Count) ? list[currentIndex] : default(T); }
            }

            public bool MoveNext()
            {
                currentIndex = Math.Min(currentIndex + 1, list.Count);

                return (currentIndex < list.Count);
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose() { }

            private int currentIndex;

            private List<T> list;
        }
    }
}
