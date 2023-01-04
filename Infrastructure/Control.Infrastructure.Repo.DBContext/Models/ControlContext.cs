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

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tax> Taxs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.17;Database=control;User=sa;Password=Zebrahead310; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3214EC07C4F3E957");

            entity.ToTable(tb => tb.HasTrigger("tr_UpdateClient"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BusinessName).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.DisabledAt).HasColumnType("datetime");
            entity.Property(e => e.DisabledBy).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fkrole).HasColumnName("FKRole");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(50);
            entity.Property(e => e.Prefix).HasMaxLength(5);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.Telephone).HasMaxLength(10);
            entity.Property(e => e.VarNumber).HasMaxLength(20);

            entity.HasOne(d => d.FkroleNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Fkrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_Roles");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoices__3214EC076163AB46");

            entity.ToTable(tb => tb.HasTrigger("tr_UpdateInvoice"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DisabledAt).HasColumnType("datetime");
            entity.Property(e => e.DisabledBy).HasMaxLength(50);
            entity.Property(e => e.Fkclient).HasColumnName("FKClient");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.Ref).HasMaxLength(300);

            entity.HasOne(d => d.FkclientNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Fkclient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Clients");
        });

        modelBuilder.Entity<InvoiceLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceL__3214EC077F342CCE");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Fkinvoice).HasColumnName("FKInvoice");
            entity.Property(e => e.Fktax).HasColumnName("FKTax");
            entity.Property(e => e.NetPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.FkinvoiceNavigation).WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.Fkinvoice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceLine_Invoices");

            entity.HasOne(d => d.FktaxNavigation).WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.Fktax)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceLine_Tax");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07FC47A47E");

            entity.ToTable(tb => tb.HasTrigger("tr_UpdateRole"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.DisabledAt).HasColumnType("datetime");
            entity.Property(e => e.DisabledBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Tax>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Taxs__3214EC07A929F818");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Value).HasColumnType("decimal(3, 1)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07E3825EFA");

            entity.ToTable(tb => tb.HasTrigger("tr_UpdateUser"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.DisabledAt).HasColumnType("datetime");
            entity.Property(e => e.DisabledBy).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fkrole).HasColumnName("FKRole");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.FkroleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Fkrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
