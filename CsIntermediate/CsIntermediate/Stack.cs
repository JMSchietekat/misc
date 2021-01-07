using System;
using System.Collections.Generic;

namespace CsIntermediate
{
    class Stack
    {
        private List<object> list = new List<object>();
        
        public void Push(object obj)
        {
            if (obj == null)
                throw new InvalidOperationException();
            
            list.Add(obj);
        }

        public object Pop()
        {
            if (list.Count == 0)
                throw new InvalidOperationException();

            var obj = list[list.Count-1];
            list.Remove(obj);
            return obj;
        }

        public void Clear()
        {
            list.Clear();
        }
    }
}