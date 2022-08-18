using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
   class MyEnumerable : IEnumerable<int>
    {
        private readonly int _start;
        private readonly Func<int, bool> _func;

        public MyEnumerable(int start, Func<int, bool> func)
        {
            _start = start;
            _func = func;
        }

        public IEnumerator<int> GetEnumerator() => new MyIterator(_start, _func);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class MyIterator : IEnumerator<int>
    {
        private int _current;
        private int _state;
        private readonly int _start;
        private readonly Func<int, bool> _func;
        public int Current => _current;
        object IEnumerator.Current => Current;

        public MyIterator(int start, Func<int, bool> func)
        {
            _start = start;
            _current = start;
            _func = func;
        }

        public bool MoveNext()
        {
            switch (_func(_current))
            {
                case false:
                    _current = _start;
                    _state = 1;
                    break;
                case true:
                    _current += 2;
                    break;
            
            }
            return true;
        }

        public void Reset()
        {
            _state = 0;
        }

        public void Dispose()
        {
        }
    }
}
