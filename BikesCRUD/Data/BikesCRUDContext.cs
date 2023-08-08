using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BikesCRUD.Models;

namespace BikesCRUD.Data
{
    public class BikesCRUDContext : DbContext
    {
        public BikesCRUDContext (DbContextOptions<BikesCRUDContext> options)
            : base(options)
        {
        }

        public DbSet<BikesCRUD.Models.Bike> Bike { get; set; } = default!;
    }
}
