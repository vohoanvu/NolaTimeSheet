using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NolaTimeSheet.Models
{
    public partial class AspNetUserProject
    {
        [ForeignKey("User")]
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Project")]
        [Key, Column(Order = 1)]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
