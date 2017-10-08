using System;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Resource.db");
        }
    }
}
