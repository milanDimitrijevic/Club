using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Domain.Entities
{
    public class Renting
    {
        public int Id { get; set; }
        public DateTime DateOfRent { get; set; }
        public Movie RentedMovie { get; set; }
        public Serie RentedSerie { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Serie> Series { get; set; }
        public virtual List<Renting> Rents { get; set; }
    }

}
