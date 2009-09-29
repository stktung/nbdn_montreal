using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class IsPublishedByProductionStudio : Criteria<Movie>
    {
        ProductionStudio studio;

        public IsPublishedByProductionStudio(ProductionStudio studio)
        {
            this.studio = studio;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.production_studio == studio;
        }
    }
}