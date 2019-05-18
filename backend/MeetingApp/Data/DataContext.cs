using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
              
        public DbSet<Value> Values { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Photo> Photo { get; set; } 
    }
}
