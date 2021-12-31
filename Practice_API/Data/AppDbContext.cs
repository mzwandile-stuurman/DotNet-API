using Microsoft.EntityFrameworkCore;
using Practice_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_API.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Job> Jobs { get; set; }
    }
}