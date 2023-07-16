using DevExpress.Mvvm;
using NolaTimeSheet.Models;

namespace NolaTimeSheet.ViewModels
{
    public class ProjectViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public decimal? BudgetHours { get; set; }
        public decimal? BudgetCost { get; set; }
        public string Url { get; set; }
        public string Ref { get; set; }
        public bool Closed { get; set; }

        public ProjectViewModel(Project project)
        {
            Id = project.Id;
            OrganizationId = project.OrganizationId;
            Name = project.Name;
            BudgetHours = project.BudgetHours;
            BudgetCost = project.BudgetCost;
            Url = project.Url;
            Ref = project.Ref;
            Closed = project.Closed;
        }
    }
}
