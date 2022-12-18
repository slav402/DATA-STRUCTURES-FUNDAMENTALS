using System;

namespace Exam.MovieDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var movie1 = new Movie("1", 20, "qwe", 5, 1000);
            var movie2 = new Movie("2", 20, "asd", 5, 345);
            var movie3 = new Movie("3", 20, "zxc", 5, 24657);
            var movie4 = new Movie("4", 20, "rty", 5, 546456);

            var actor1 = new Actor("1", "Slav", 30);
            var actor2 = new Actor("2", "Pipi", 33);

            MovieDatabase movDB = new MovieDatabase();

            movDB.AddActor(actor1);
            movDB.AddActor(actor2);
            movDB.AddActor(actor2);

            movDB.AddMovie(actor1, movie1);
            movDB.AddMovie(actor1, movie2);
            movDB.AddMovie(actor2, movie3);
            movDB.AddMovie(actor2, movie4);
            movDB.AddMovie(actor2, movie1);

            movDB.GetActorsOrderedByMaxMovieBudgetThenByMoviesCount();
        }
    }
}
