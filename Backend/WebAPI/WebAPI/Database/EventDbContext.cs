using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization;
using WebAPI.Models.Events;
using WebAPI.Models.Notification;

namespace WebAPI.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
       
        public DbSet<User> User { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet <EventType> EventTypes { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ReceiptItem> ReceiptItems { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
    }
}
