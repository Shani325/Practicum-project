using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyProject.Context
{
    public class DBContext : DbContext, IContext
    {
        //public DbSet<Role> Roles { get ; set ; }
        //public DbSet<Permission> Permissions { get ; set ; }
        //public DbSet<Claim> Claims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SEP_ProjectDb;Trusted_Connection=True;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Child>()
        //        .HasOne(p => p.Father)
        //        .WithMany()
        //        .IsRequired(false)
        //        .OnDelete(DeleteBehavior.SetNull);
        //    modelBuilder.Entity<Child>()
        //        .HasOne(p => p.Mother)
        //        .WithMany()
        //        .IsRequired(false)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    //modelBuilder.Entity<Child>()
        //    //    .HasRequired(s => s.Mother)
        //    //    .WithMany()
        //    //    .WillCascadeOnDelete(false);
        //}
    }
}
