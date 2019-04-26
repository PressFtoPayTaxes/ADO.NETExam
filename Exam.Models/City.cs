using System;
using System.Collections.Generic;

namespace Exam.Models
{
    public class City : Entity
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public ICollection<Street> Streets { get; set; } = new List<Street>();
    }
}