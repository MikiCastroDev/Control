using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Control.Infrastructure.Repo.DBContext.Models;

public partial class ControlContext : DbContext
{
    public ControlContext()
    {
    }

    public ControlContext(DbContextOptions<ControlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.15;Database=control;User=sa;Password=Zebrahead310; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'(current_user())')");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EnabledAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EnabledBy)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'(current_user())')");
            entity.Property(e => e.Fkrole).HasColumnName("FKRole");
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
