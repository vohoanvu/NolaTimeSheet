using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NolaTimeSheet.Models
{
    public class Time
    {
        public long Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Hours { get; set; }

        [Required]
        public DateTime WorkingDate { get; set; }

        public string Reference { get; set; }

        public bool Closed { get; set; }

        public bool Paid { get; set; }
    
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
