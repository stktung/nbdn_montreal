using System;
using nothinbutdotnetprep.infrastructure;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public bool Equals(Movie other)
        {
            return other == null ? false : ReferenceEquals(this, other) || fields_are_equal_to(other);
        }

        bool fields_are_equal_to(Movie other)
        {
            return other.title == title;
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        static public Filter<Movie> is_published_by(ProductionStudio studio)
        {
            return new IsPublishedByProductionStudio(studio).is_satisfied_by;
        }

        static public Filter<Movie> is_published_by_pixar_or_disney
        {
            get
            {
                return new IsPublishedByProductionStudio(ProductionStudio.Pixar)
                    .or(new IsPublishedByProductionStudio(ProductionStudio.Disney))
                    .is_satisfied_by;
            }
        }

        static public Filter<Movie> is_published_after(int year)
        {
            return new IsPublishedAfterYear(year).is_satisfied_by;
        }
    }
}