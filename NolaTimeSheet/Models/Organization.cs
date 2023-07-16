using System.Collections.Generic;

namespace NolaTimeSheet.Models
{
    public class Organization
    {
        public Organization()
        {
            this.Projects = new HashSet<Project>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public bool Closed { get; set; }
        public System.Guid GId { get; set; }
        
        public virtual ICollection<Project> Projects { get; set; }
    }
}
