using Clubv1._3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Domain.Interfaces
{
    public interface IMovieService : IService
    {
        void AddMovie(Movie movie);
        Movie AddCds(int id, int amount);
        Movie AddActorToMovie(int id, string name);
    }
}
