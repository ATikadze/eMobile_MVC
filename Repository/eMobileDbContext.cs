using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    using Domain;
    public class eMobileDbContext : DbContext
    {
        public eMobileDbContext(DbContextOptions<eMobileDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
