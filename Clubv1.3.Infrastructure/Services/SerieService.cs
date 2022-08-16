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
    public class SerieService : ISerieService
    {
        private readonly ClubDbContext _dbContext;
        private static readonly List<Serie> _series = new();
        private static readonly List<Actor> _actors = new();
        public SerieService(ClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly ISerieService _serieService;

        public SerieService(ISerieService serieService)
        {
            _serieService = serieService;
        }
        public void DeleteById(int id)
        {
            var serie = _series.SingleOrDefault(u => u.Id == id);
            _series.Remove(serie);
        }

        public void GetAll()
        {
            _series.ToList();
        }

        public void GetById(int id) => _series.SingleOrDefault(u => u.Id == id);

        public void UpdateById(int id)
        {
            var serie = _series.SingleOrDefault(u => u.Id == id);
            serie = new Serie
            {
                Title = serie.Title,
                Genre = serie.Genre,
                Seasons = serie.Seasons,
                Episodes = serie.Episodes,
                Producer = serie.Producer,
                ReleaseDate = serie.ReleaseDate,
                AvailableCds = serie.AvailableCds,
                TotalCds = serie.TotalCds
            };

        }

        public void AddSerie(Serie serie)
        {
            _series.Add(serie);
        }

        public Serie AddCds(int id, int amount)
        {
            var serie = _series.SingleOrDefault(u => u.Id == id);
            serie.AvailableCds += amount;
            serie = new Serie
            { AvailableCds = serie.AvailableCds};
            return serie;

        }

        public Serie AddActorToSerie(int id, string name)
        {
            var serie = _series.SingleOrDefault(u => u.Id == id);
            var actor = _actors.SingleOrDefault(q => q.Name == name);
            serie.Actors.Add(actor);
            return serie;
        }
    }
}
