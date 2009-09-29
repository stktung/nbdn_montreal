using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;
using nothinbutdotnetprep.infrastructure.extensions;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public delegate bool MovieFilter(Movie movie);


    public class MovieLibrary
    {
        IList<Movie> list_of_movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.list_of_movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return list_of_movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            list_of_movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return list_of_movies.Contains(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            var movies = new List<Movie>(list_of_movies);
            movies.Sort(delegate(Movie x, Movie y)
            {
                return y.title.CompareTo(x.title);
            });

            return movies;
        }


        public IEnumerable<Movie> all_movies_matching(Criteria<Movie> filter)
        {
            return list_of_movies.all_items_matching(filter);
        }



        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return all_movies_matching(item => item.production_studio == ProductionStudio.Pixar ||
                                               item.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            var movies = new List<Movie>(list_of_movies);
            movies.Sort(delegate(Movie x, Movie y)
            {
                return x.title.CompareTo(y.title);
            });

            return movies;
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var movie in list_of_movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in list_of_movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (var movie in list_of_movies)
            {
                if (movie.genre == Genre.kids)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (var movie in list_of_movies)
            {
                if (movie.genre == Genre.action)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var movies = new List<Movie>(list_of_movies);
            movies.Sort(delegate(Movie x, Movie y)
            {
                return y.date_published.CompareTo(x.date_published);
            });

            return movies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var movies = new List<Movie>(list_of_movies);
            movies.Sort(delegate(Movie x, Movie y)
            {
                return x.date_published.CompareTo(y.date_published);
            });

            return movies;
        }
    }
}