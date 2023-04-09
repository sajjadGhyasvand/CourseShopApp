﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GhiasAmooz.DataLayer.Entities.User;
using GhiasAmooz.DataLayer.Entities.Wallet;

namespace GhiasAmooz.DataLayer.Context
{
   public class GhiasAmoozContext:DbContext
    {

        public GhiasAmoozContext(DbContextOptions<GhiasAmoozContext> options):base(options)
        {
            
        }

        #region User

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        #endregion

        #region Wallet
        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);

            base.OnModelCreating(modelBuilder);
        }

    }
}