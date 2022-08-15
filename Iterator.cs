using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Helpers
    {
        public class BaseEnumerator<T> : IEnumerator<T>, IEnumerable<T>
        {
            public BaseEnumerator( Func<int, bool> predicate)
            {
                Predicate = predicate;
              
            }

            public BaseEnumerator(IEnumerator<T> enumer)
            {
                enumerator = enumer;
            }

            public BaseEnumerator()
            {
            }

            public  Func<int, bool> Predicate;
            protected virtual IEnumerator<T> enumerator { get; set; }

            protected virtual Func<int, bool> predicate { get; set; }

            protected virtual T current { get; set; }

            public virtual bool MoveNext()
            {
                return enumerator.MoveNext();
            }

            public virtual IEnumerator<T> GetEnumerator()
            {
                return enumerator;
            }

            public virtual T Current { get { return enumerator.Current; } }

            object IEnumerator.Current { get { return enumerator.Current; } }

            public virtual void Reset() { }

            public virtual void Dispose() { }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                return GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return enumerator;
            }
        }

        public class IndexedEnumerator<T> : BaseEnumerator<T>
        {
            public IndexedEnumerator( Func<int, bool> predicate) : base( predicate) { }

            public IndexedEnumerator(IEnumerator<T> enumer) : base(enumer) { }

            public IndexedEnumerator()
            {
            }

            public int Index { get; private set; }

            public int Count { get; private set; }
            public T GetT()
            {
                return enumerator.Current;
            }
            public int SetT(int count)
            {
                Count = count;
                return Count;
            }

            public override bool MoveNext()
            {
                int cnt = 0;
                if (Predicate(Index))
                {
                    cnt++;
                    Console.WriteLine(enumerator.Current);
                    Index++;
                }

                if (cnt > Count)
                    return false;
                return true;
            }

        }
    }
}
