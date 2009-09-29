using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class ProductionStudioRatingComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.production_studio.ToString().CompareTo(y.production_studio.ToString());
        }
    }
}