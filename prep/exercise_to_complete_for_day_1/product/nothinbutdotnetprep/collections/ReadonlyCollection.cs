using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class ReadonlyCollection<T>  : IEnumerable<T>
    {
        IList<T> items;

        public ReadonlyCollection(IList<T> items)
        {
            this.items = items;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator(); 
        }
    }
}