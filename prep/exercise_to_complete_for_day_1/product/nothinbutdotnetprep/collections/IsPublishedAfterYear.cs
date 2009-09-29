using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class IsPublishedAfterYear : Criteria<Movie>
    {
        int year;

        public IsPublishedAfterYear(int year)
        {
            this.year = year;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.date_published.Year > year;
        }
    }
}