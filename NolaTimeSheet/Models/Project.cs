using System.Collections.Generic;

namespace NolaTimeSheet.Models
{
    public class Project
    {
        public Project()
        {
            this.AspNetUserProjects = new HashSet<AspNetUserProject>();
            this.Times = new HashSet<Time>();
        }
    
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public decimal? BudgetHours { get; set; }
        public decimal? BudgetCost { get; set; }
        public string Url { get; set; }
        public string Ref { get; set; }
        public bool Closed { get; set; }
        public System.Guid GId { get; set; }
        
        public virtual ICollection<AspNetUserProject> AspNetUserProjects { get; set; }
        public virtual Organization Organization { get; set; }

        public virtual ICollection<Time> Times { get; set; }
    }
}
