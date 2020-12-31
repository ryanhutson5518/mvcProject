using Microsoft.EntityFrameworkCore;   // This needs to be added as a package. It inherits from DbContext
using mvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)   // This is basic configuration for my database
        {

        }

        public DbSet<Category> Category { get; set; }   // After adding these ... PM> add-migration !name! ... PM> update-database
        public DbSet<ApplicationType> ApplicationType { get; set; }
    }
}
