using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyWebSite.Models
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext() : base("DefaultConnection") { }

        public DbSet<Client> Clients { get; set; }
    }
}