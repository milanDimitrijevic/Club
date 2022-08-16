using clubv1._3.Database;
using Clubv1._3.Domain.Entities;
using Clubv1._3.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly ClubDbContext _dbContext;
        private static readonly List<Movie> _movies = new();
        private static readonly List<Actor> _actors = new();

        public MovieService(ClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly IMovieService _movieService;

        public MovieService(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public void DeleteById(int id)
        {
            var movie = _movies.SingleOrDefault(u => u.Id == id);
            _movies.Remove(movie);
        }
       

        public void GetAll()
        {
           _movies.ToList();
        }

        public void GetById(int id) => _movies.SingleOrDefault(u => u.Id == id);

        public void UpdateById(int id)
        {
            var movie = _movies.SingleOrDefault(u => u.Id == id);
            movie = new Movie
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Producer = movie.Producer,
                ReleaseDate = movie.ReleaseDate
            };
        }

        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public Movie AddCds(int id, int amount)
        {
            var movie = _movies.SingleOrDefault(u => u.Id == id);
            movie.AvailableCds += amount;
            movie = new Movie
            { AvailableCds = movie.AvailableCds };
            return movie;
        }

        public Movie AddActorToMovie(int id, string name)
        {
            var movie = _movies.SingleOrDefault(u => u.Id == id);
            var actor = _actors.SingleOrDefault(q => q.Name == name);
            movie.Actors.Add(actor);
            return movie;
        }
    }
}
