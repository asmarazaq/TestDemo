using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Help_FinalProject.Models;

public partial class HelpContext : DbContext
{
    public HelpContext()
    {
    }

    public HelpContext(DbContextOptions<HelpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(" Data Source=423Z1F3\\SQLEXPRESS;Initial Catalog=HELP;Integrated Security=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC074CD97043");

            entity.ToTable("Favorite");

            entity.Property(e => e.CompleteAddress).HasMaxLength(1000);
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Favorite__User_I__4BAC3F29");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Review__3214EC0753E7AFFD");

            entity.ToTable("Review");

            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CompleteAddress).HasMaxLength(1000);
            entity.Property(e => e.Detail).HasMaxLength(3000);
            entity.Property(e => e.PropertyAdress).HasMaxLength(500);
            entity.Property(e => e.PropertyCity).HasMaxLength(500);
            entity.Property(e => e.PropertyState).HasMaxLength(50);
            entity.Property(e => e.Reporter).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(500);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC076EF25AB3");

            entity.ToTable("User");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
