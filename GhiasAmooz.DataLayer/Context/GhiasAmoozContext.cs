using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GhiasAmooz.DataLayer.Entities.User;
using GhiasAmooz.DataLayer.Entities.Wallet;
using GhiasAmooz.DataLayer.Entities.Permissions;
using GhiasAmooz.DataLayer.Entities.Course;

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

        #region Permission
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        #endregion
        #region Course
        public DbSet<CourseGroup> CourseGroups { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDelete);
            modelBuilder.Entity<CourseGroup>().HasQueryFilter(g => !g.IsDelete);

            base.OnModelCreating(modelBuilder);
        }

    }
}
