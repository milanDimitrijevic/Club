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
    public class ActorService : IActorService
    {
        private readonly IActorService _actorService;
        private readonly ClubDbContext _dbContext;

        public ActorService(ClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly List<Actor> _actors = new();
        private readonly List<Movie> _movies = new();

       

        public ActorService(IActorService actorService)
        {
            _actorService = actorService;
        }
        void IService.DeleteById(int id)
        {
            var actor = _actors.SingleOrDefault(u => u.Id == id);
            _actors.Remove(actor);
        }

        void IService.GetAll()
        {
            _actors.ToList();
        }

        void IService.GetById(int id) => _actors.SingleOrDefault(u => u.Id == id);

        void IService.UpdateById(int id)
        {
            var actor = _actors.SingleOrDefault(u => u.Id == id);
            actor = new Actor
            {
                Name = actor.Name,
                BirthDate = actor.BirthDate,
                DeceaseDate = actor.DeceaseDate
            };
        }
        public void AddActor(Actor actor)
        {
            _actors.Add(actor);
        }
    }
}
