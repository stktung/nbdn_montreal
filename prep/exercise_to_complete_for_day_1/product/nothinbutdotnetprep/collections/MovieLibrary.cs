using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        private IList<Movie> _list_of_movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            _list_of_movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            foreach (var movie in _list_of_movies) 
            {
                yield return movie;
            }
        }

        public void add(Movie movie)
        {
            
            foreach (var i in all_movies())
            {
                //if (!movie.GetHashCode().Equals(i.GetHashCode()))
                //{
                //    _list_of_movies.Add(movie);
                //}
                if (!i.Equals(movie)) 
                {
                    _list_of_movies.Add(movie);
                }
            }
            
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            var movies = new List<Movie>(_list_of_movies);
            movies.Sort(delegate(Movie x, Movie y) 
            {
                return y.title.CompareTo(x.title);
            });

            return movies;
            
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var movie in _list_of_movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in _list_of_movies)
            {
                if ((movie.production_studio == ProductionStudio.Pixar)||(movie.production_studio == ProductionStudio.Disney))
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            var movies = new List<Movie>(_list_of_movies);
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
            foreach (var movie in _list_of_movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (var movie in _list_of_movies)
            {
                if (movie.date_published.Year > year)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in _list_of_movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (var movie in _list_of_movies)
            {
                if (movie.genre == Genre.kids)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (var movie in _list_of_movies)
            {
                if (movie.genre == Genre.action)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var movies = new List<Movie>(_list_of_movies);
            movies.Sort(delegate(Movie x, Movie y)
            {
                return y.date_published.CompareTo(x.date_published);
            });

            return movies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var movies = new List<Movie>(_list_of_movies);
            movies.Sort(delegate(Movie x, Movie y)
            {
                return x.date_published.CompareTo(y.date_published);
            });

            return movies;
        }
    }
}