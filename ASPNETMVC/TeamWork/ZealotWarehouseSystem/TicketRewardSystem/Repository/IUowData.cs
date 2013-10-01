﻿namespace TicketRewardSystem.Repository
{
    using System;

    using TicketRewardSystem.Models;

    public interface IUowData : IDisposable
    {
        IRepository<Ticket> Tickets { get; }
        IRepository<Rule> Rules { get; }
        IRepository<Achievement> Achievements { get; }
        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
