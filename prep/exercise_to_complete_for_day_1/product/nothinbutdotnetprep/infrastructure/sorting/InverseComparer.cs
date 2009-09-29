using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class InverseComparer<Item> : IComparer<Item> {
        IComparer<Item> item_comparer;

        public InverseComparer(IComparer<Item> item_comparer)
        {
            this.item_comparer = item_comparer;
        }

        public int Compare(Item x, Item y)
        {
            return -(item_comparer.Compare(x, y));
        }
    }
}