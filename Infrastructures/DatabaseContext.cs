﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
    }
}