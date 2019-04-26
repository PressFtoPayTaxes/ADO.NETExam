using System;

namespace Exam.Models
{
    public class Street : Entity
    {
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public virtual City City { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}