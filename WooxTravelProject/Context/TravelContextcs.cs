using System.Data.Entity;
using WooxTravelProject.Entities;

namespace WooxTravelProject.Context
{
    public class TravelContextcs : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
    }
}