using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TicketRewardSystem.Models;

namespace TicketRewardSystem.ViewModels
{
    public class TicketViewModel
    {
        public static Expression<Func<Ticket, TicketViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketViewModel
                {
                    TicketId = ticket.TicketId,
                    Title = ticket.Title,
                    Description = ticket.Description,
                    PostedOn = ticket.PostedOn,
                    PostedBy = ticket.PostedBy.UserName,
                    Status = ticket.Status
                };
            }
        }
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        
        public DateTime PostedOn { get; set; }


        public string PostedBy { get; set; }

        public string Priority { get; set; }

        public StatusEnum Status { get; set; }
    }
}
