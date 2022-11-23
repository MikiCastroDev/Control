using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Control.Infrastructure.Repo.DBContext.Models;

namespace Control.Infrastructure.Repo.DBContext
{
    public partial class MySQLControlContext : DbContext
    {
        public MySQLControlContext()
        {
        }

        public MySQLControlContext(DbContextOptions<MySQLControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoreRole> CoreRoles { get; set; } = null!;
        public virtual DbSet<CoreUser> CoreUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<CoreRole>(entity =>
            {
                entity.Property(e => e.Enabled).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CoreUser>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'CURRENT_USER'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
