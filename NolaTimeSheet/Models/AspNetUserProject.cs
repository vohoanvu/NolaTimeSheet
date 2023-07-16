using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NolaTimeSheet.Models
{
    public class AspNetUserProject
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
