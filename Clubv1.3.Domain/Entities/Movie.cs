using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GenreType Genre { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int TotalCds { get; set; }
        public int AvailableCds { get; set; }
        public List<Movie> Movies { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
    public enum GenreType
    {
        horror, thriller, drama, mystery, romance, biography, action
    }
}
