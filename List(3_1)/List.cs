﻿using System.Collections;

namespace List_3_1_
{
    class List<T> : IEnumerable, IComparable<T>
        where T : IComparable<T>
    {
        private T[] _arr = new T[0];
        private int _index = 0;
        public T this[int i]
        {
            get { return _arr[i]; }
            set
            {
                if (i < _arr.Length)
                {
                    _arr[i] = value;
                }
                else throw new IndexOutOfRangeException("Некоректно ведений iндекс");
            }
        }
        public T[] Add(T data)
        {
            T[] arr = new T[_arr.Length + 1];
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                for (int i = 0; i < _arr.Length; i++)
                {
                    arr[i] = _arr[i];
                }
                arr[_index] = data;
                _arr = arr;
                _index++;
            }
            return _arr;
        }
        public T[] AddRange(int size)
        {
            T[] arr = new T[_arr.Length + size];
            for (int i = 0; i < _arr.Length; i++)
            {
                arr[i] = _arr[i];
            }
            _arr = arr;
            return _arr;
        }
        public bool Remove(T item)
        {
            T[] arr = new T[_arr.Length - 1];

            bool successful = false;
            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i].Equals(item))
                {
                    for (int index = 0; index < _arr.Length; index++)
                    {
                        if (index < i)
                        {
                            arr[index] = _arr[index];
                        }
                        else if (index > i)
                        {
                            arr[index - 1] = _arr[index];
                        }
                    }
                    successful = true;
                    _arr = arr;
                    _index--;
                    break;
                }
            }
            return successful;
        }

        public T[] RemoveAt(int data)
        {
            if (data < _arr.Length)
            {
                T[] arr = new T[_arr.Length - 1];
                for (int i = 0; i < _arr.Length; i++)
                {
                    if (i < data)
                    {
                        arr[i] = _arr[i];
                    }
                    else
                    {
                        arr[i - 1] = _arr[i];
                    }
                }
                _index--;
                _arr = arr;
            }
            else throw new IndexOutOfRangeException("Некоректно ведений iндекс для видалення");
            return _arr;
        }

        public T[] Sort()
        {
            T item;
            for (int j = 0; j < _arr.Length; j++)
            {
                for (int i = 1; i < _arr.Length; i++)
                {
                    if (_arr[i].CompareTo(_arr[i - 1]) == -1)
                    {
                        item = _arr[i];
                        _arr[i] = _arr[i - 1];
                        _arr[i - 1] = item;

                    }

                }
            }
            return _arr;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in _arr)
            {
                yield return item;
            }
        }

        public int CompareTo(T data)
        {
            return _arr[_index].CompareTo(data);
        }
    }
}
