using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Team12.Models
{
    public class ToDoDatabaseContext : DbContext 
    {
        public ToDoDatabaseContext (DbContextOptions<ToDoDatabaseContext> options) : base (options)
        {

        }

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Quadrant> Quadrants { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData
            (
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" }, 
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" } 
            );

            mb.Entity<Quadrant>().HasData
            (
                new Quadrant { Id = 1, QuadrantName = "Urgent/Important" },
                new Quadrant { Id = 2, QuadrantName = "Urgent/Not Important" },
                new Quadrant { Id = 3, QuadrantName = "Not Urgent/Important" },
                new Quadrant { Id = 4, QuadrantName = "Not Urgent/Not Important" }
            );
        }
    }
}
