using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Domain.Interfaces
{
    public interface IService
    {
        void GetAll();
        void GetById(int id);
        void UpdateById(int id);
        void DeleteById(int id);
    }
}
