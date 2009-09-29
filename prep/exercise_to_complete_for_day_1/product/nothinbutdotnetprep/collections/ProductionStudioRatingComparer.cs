using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class ProductionStudioRatingComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {

            var studioOrder = new List<ProductionStudio> {ProductionStudio.MGM, ProductionStudio.Pixar, ProductionStudio.Dreamworks, ProductionStudio.Universal, ProductionStudio.Disney};

            return studioOrder.IndexOf(x.production_studio).CompareTo(studioOrder.IndexOf(y.production_studio));
          
        }
    }
}