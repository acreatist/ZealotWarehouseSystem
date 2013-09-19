using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketRewardSystem.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PostedOn { get; set; }
        [DataType(DataType.DateTime)]
        public Nullable<DateTime> ResolvedOn { get; set; }
        public virtual ApplicationUser PostedBy { get; set; }
        public virtual ApplicationUser AssignedTo { get; set; }

        
        public PriorityEnum Priority { get; set; }
        public StatusEnum Status { get; set; }
    }
}