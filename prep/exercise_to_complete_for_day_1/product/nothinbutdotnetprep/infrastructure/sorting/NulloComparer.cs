using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class NulloComparer<Item> : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return 0;
        }
    }
}