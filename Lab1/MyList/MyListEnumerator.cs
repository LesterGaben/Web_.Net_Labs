﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.MyList {
    public class MyListEnumerator<T> : IEnumerator<T> {

        private readonly IList<T> _list;
        
        private int _index;
        private T _current;
        public T Current => _current;
        object IEnumerator.Current => _current;

        public MyListEnumerator(IList<T> list) {
            _list = list;
            _index = 0;

            if(list.Any() == true) {
                _current = _list[_index];
            }
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public bool MoveNext() {
            throw new NotImplementedException();
        }

        public void Reset() {
            _index = 0;
            _current = _list[_index];
        }
    }
}
