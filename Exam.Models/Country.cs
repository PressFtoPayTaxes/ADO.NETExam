using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
