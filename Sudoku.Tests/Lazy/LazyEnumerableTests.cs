using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Sudoku.Lazy;

namespace Sudoku.Tests.Lazy
{
    [TestFixture]
    public class LazyEnumerableTests
    {
        [Test]
        public void EmbeddedEnumerators()
        {
            IEnumerable<int> naturalNumbers = new LazyEnumerable<int>(NaturalNumbers());

            List<int> result = new List<int>();

            foreach (int i in naturalNumbers.Take(15))
            {
                Console.Write("{0} ", i);
                result.Add(i);

                if (i == 5)
                {
                    Console.WriteLine();

                    foreach (int j in naturalNumbers.Take(10))
                    {
                        Console.Write("{0} ", j);
                        result.Add(j);
                    }

                    Console.WriteLine();
                }
            }

            List<int> expected = new List<int>
            {
                1, 2, 3, 4, 5,
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
            };

            CollectionAssert.AreEqual(expected, result);
        }

        private IEnumerable<int> NaturalNumbers()
        {
            int n = 1;

            while (true)
            {
                Thread.Sleep(500);

                yield return n++;
            }
        }
    }
}
