using System;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku.Lazy
{
    public class DynamicList<T> : IEnumerable<T>
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
            return new DynamicEnumerator(list);
        }

        private List<T> list = new List<T>();

        public class DynamicEnumerator : IEnumerator<T>
        {
            public DynamicEnumerator(List<T> list)
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
