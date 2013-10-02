using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketRewardSystem.ViewModels
{
    public class TicketViewModel
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PostedOn { get; set; }


        public string PostedBy { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }
    }
}
