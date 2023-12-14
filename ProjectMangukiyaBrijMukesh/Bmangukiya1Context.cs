using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectMangukiyaBrijMukesh;

public partial class Bmangukiya1Context : DbContext
{
    public Bmangukiya1Context()
    {
    }

    public Bmangukiya1Context(DbContextOptions<Bmangukiya1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TblGenre> TblGenres { get; set; }
    public virtual DbSet<TblWatchList> TblWatchLists { get; set; }
    public virtual DbSet<TblWatchListItem> TblWatchListItems { get; set; }
    public virtual DbSet<VwByMediaType> VwByMediaTypes { get; set; }
    public virtual DbSet<VwCountByDate> VwCountByDates { get; set; }
    public virtual DbSet<VwGenreCount> VwGenreCounts { get; set; }
    public virtual DbSet<spByWatchList> spByWatchLists { get; set; }
    public virtual DbSet<spByGenre> spByGenres { get; set; }
    public virtual DbSet<spDeleteMedia> spDeleteMedia { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.22.13.242; Initial Catalog =BMangukiya1 ; User ID= bmangukiya1 ; Password = H703226129 ; TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<spDeleteMedia>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("spDeleteMedia");
        });

        modelBuilder.Entity<spByGenre>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("spByGenre");
            entity.Property(e => e.Genre).HasColumnName("Name").HasMaxLength(255);

            entity.Property(e => e.Description).HasColumnName("Description").HasMaxLength(300);

            entity.Property(e => e.ItemId).HasColumnName("ItemID");

            entity.Property(e => e.MediaId).HasColumnName("MediaID");

            entity.Property(e => e.MediaType).HasColumnName("MediaType").HasMaxLength(50);

            entity.Property(e => e.Poster).HasColumnName("poster");

            entity.Property(e => e.Title).HasColumnName("Title").HasMaxLength(50);
        });

        modelBuilder.Entity<spByWatchList>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("spByWatchList");

            entity.Property(e => e.Description).HasColumnName("Description").HasMaxLength(300);

            entity.Property(e => e.ItemId).HasColumnName("ItemID");

            entity.Property(e => e.ListId).HasColumnName("ListID");

            entity.Property(e => e.MediaId).HasColumnName("MediaID");

            entity.Property(e => e.MediaType).HasColumnName("MediaType").HasMaxLength(50);

            entity.Property(e => e.Poster).HasColumnName("poster");

            entity.Property(e => e.Title).HasColumnName("Title").HasMaxLength(50);
        });

        modelBuilder.Entity<TblGenre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__tblGenre__0385055ED8E78410");

            entity.ToTable("tblGenre");

            entity.HasIndex(e => e.Name, "UQ__tblGenre__737584F69F57908E").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TblWatchList>(entity =>
        {
            entity.HasKey(e => e.ListId).HasName("PK__tblWatch__E3832865A171F297");

            entity.ToTable("tblWatchList");

            entity.Property(e => e.ListId).HasColumnName("ListID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TblWatchListItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__tblWatch__727E83EBF93A8D7B");

            entity.ToTable("tblWatchListItems");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.ListId).HasColumnName("ListID");
            entity.Property(e => e.MediaId)
                .HasMaxLength(255)
                .HasColumnName("MediaID");
            entity.Property(e => e.MediaType).HasMaxLength(50);
            entity.Property(e => e.Poster)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("poster");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Genre).WithMany(p => p.TblWatchListItems)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__tblWatchL__Genre__6B24EA82");

            entity.HasOne(d => d.List).WithMany(p => p.TblWatchListItems)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblWatchL__ListI__6A30C649");
        });

        modelBuilder.Entity<VwByMediaType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwByMediaType");

            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.MediaType).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCountByDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwCountByDate");
        });

        modelBuilder.Entity<VwGenreCount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwGenreCount");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NumberOfMedia).HasColumnName("numberOfMedia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
