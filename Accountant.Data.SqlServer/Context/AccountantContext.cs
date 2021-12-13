﻿using Accountant.Data.Entities;
using Accountant.Data.SqlServer.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.Data.SqlServer.Context
{
    public class AccountantContext : DbContext
    {
        public AccountantContext(DbContextOptions<AccountantContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Entry> Entrys { get; set; }

        public DbSet<EntryItem> EntryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new EntryConfiguration());

            modelBuilder.ApplyConfiguration(new EntryItemConfiguration());
        }
    }
}
