using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Domain.Entities
{
    public class Actor
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeceaseDate { get; set; }
        public virtual List<Actor> Actors { get; set; }
    }
}
