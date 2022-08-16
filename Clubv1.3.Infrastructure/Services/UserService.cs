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
    public class UserService : IUserService
    {
        private readonly IUserService _userService;
        private readonly ClubDbContext _dbContext;
        private static readonly List<User> _users = new();
        private static readonly List<Movie> _movies = new();
        private static readonly List<Serie> _series = new();
        private static readonly List<Renting> _rents = new();

        public UserService(ClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserService(IUserService userService)
        {
            _userService = userService;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void DeleteById(int id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            _users.Remove(user);
        }

        public void GetAll()
        {
            _users.ToList();
        }

        public void GetById(int id) => _users.SingleOrDefault(u => u.Id == id);

        public void UpdateById(int id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            user = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public User rentMovie(int id, int movieId)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            var movie = _movies.SingleOrDefault(u => u.Id == movieId);
            var rent = new Renting
            {
                DateOfRent = DateTime.Now,
                RentedMovie = movie
            };
           movie.AvailableCds--;
           user.Rented.Add(rent);
            return user;
        }

        public User rentSerie(int id, int serieId)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            var serie = _movies.SingleOrDefault(u => u.Id == serieId);
            var rent = new Renting
            {
                DateOfRent = DateTime.Now,
                RentedMovie = serie
            };
            serie.AvailableCds--;
            user.Rented.Add(rent);
            return user;
        }
    }
}
