using Clubv1._3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Domain.Interfaces
{
    public interface IUserService : IService
    {
        void AddUser(User user);
        User rentMovie(int id, int movieId);
        User rentSerie(int id, int serieId);
    }
}
