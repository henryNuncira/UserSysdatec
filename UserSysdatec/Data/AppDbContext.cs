using System;
using System.Collections.Generic;
using UserSysdatec.Models;
using Microsoft.EntityFrameworkCore;

namespace UserSysdatec.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FB2229688");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164BB0423FE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
           
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("name");
            entity.Property(e => e.NumberDocument)
                .HasMaxLength(15)
                .HasColumnName("number_document");
            entity.Property(e => e.Password)
                .HasMaxLength(191)
                .HasColumnName("password");
            
            entity.Property(e => e.TypeDocument)
                .HasMaxLength(20)
                .HasColumnName("type_document");
           
            entity.Property(e => e.Sal)
                .HasMaxLength(50)
                .HasColumnName("sal");
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .HasColumnName("token");
            entity.Property(e => e.Status).HasColumnName("status");
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
