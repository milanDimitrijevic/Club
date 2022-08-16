using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Domain.Entities
{
    public class Serie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GenreType Genre { get; set; }
        public int Seasons { get; set; }
        public int Episodes { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AvailableCds { get; set; }
        public int TotalCds { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public virtual List<Serie> Series { get; set; }
    }
}
