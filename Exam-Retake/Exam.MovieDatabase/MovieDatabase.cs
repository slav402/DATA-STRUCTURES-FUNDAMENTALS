using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private Dictionary<string, Actor> actorsById = new Dictionary<string, Actor>();
        private Dictionary<string, Movie> moviesById = new Dictionary<string, Movie>();

        public void AddActor(Actor actor)
        {
            if (!actorsById.ContainsKey(actor.Id))
            {
                this.actorsById.Add(actor.Id, actor);
            }
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!moviesById.ContainsKey(movie.Id))
            {
                this.moviesById.Add(movie.Id, movie);
            }
            
            if (!actorsById.ContainsKey(actor.Id))
            {
                throw new ArgumentException();
            }

            this.actorsById[actor.Id].Movies.Add(movie);
        }

        public bool Contains(Actor actor)
        {
            return this.actorsById.ContainsKey(actor.Id);
        }

        public bool Contains(Movie movie)
        {
            return this.moviesById.ContainsKey(movie.Id);
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            return this.actorsById.Values
                .OrderByDescending(x => x.Movies.Max(x => x.Budget))
                .ThenByDescending(x => x.Movies.Count);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return this.moviesById.Values;
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            return this.moviesById.Values
                .Where(x => x.Budget >= lower && x.Budget <= upper)
                .OrderByDescending(x => x.Rating);
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
            return GetAllMovies()
                .OrderByDescending(x => x.Budget)
                .ThenByDescending(x => x.Rating);
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            throw new NotImplementedException();
            //return this.actorsById.Values.Where(x => x.Movies.Count == 0);
        }
    }
}
