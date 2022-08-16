using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class MyIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        public Func<int, bool> Predicate;

        public IEnumerator<T> enumerator;
        public MyIterator(IEnumerator<T> enumer, Func<int, bool> predicate)
        {
            Predicate = predicate;
            enumerator = enumer;

        }
        public T Current => enumerator.Current;
        object IEnumerator.Current => enumerator.Current;
        void IDisposable.Dispose()
        {
           
        }
        public int Index { get; private set; }
        public int Count { get; private set; }
        public int SetT(int count)
        {
            Count = count;
            return Count;
        }
        public bool MoveNext()
        {
            if (Predicate(Index))
            {
                Console.WriteLine(Index);
                Index++;
                return true;
            }
            Index++;
            return false;
        }

        void IEnumerator.Reset()
        {
           
        }
        public virtual IEnumerator<T> GetEnumerator()
        {
            return enumerator;
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return enumerator;
        }
    }
}
