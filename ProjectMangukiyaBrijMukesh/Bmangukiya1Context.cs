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

    public virtual DbSet<OwnerDetail> OwnerDetails { get; set; }

    public virtual DbSet<PetDetail> PetDetails { get; set; }

    public virtual DbSet<TblCar> TblCars { get; set; }

    public virtual DbSet<TblDriver> TblDrivers { get; set; }

    public virtual DbSet<TblFaculty> TblFaculties { get; set; }

    public virtual DbSet<TblGenre> TblGenres { get; set; }

    public virtual DbSet<TblIncident> TblIncidents { get; set; }

    public virtual DbSet<TblIncident1> TblIncidents1 { get; set; }

    public virtual DbSet<TblPolice> TblPolices { get; set; }

    public virtual DbSet<TblPublicSafety> TblPublicSafeties { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblViolation> TblViolations { get; set; }

    public virtual DbSet<TblWatchList> TblWatchLists { get; set; }

    public virtual DbSet<TblWatchListItem> TblWatchListItems { get; set; }

    public virtual DbSet<VwByOfficer> VwByOfficers { get; set; }

    public virtual DbSet<VwFinesPerViolation> VwFinesPerViolations { get; set; }

    public virtual DbSet<VwIncidentList> VwIncidentLists { get; set; }

    public virtual DbSet<VwViolationsByCity> VwViolationsByCities { get; set; }
    public virtual DbSet<spByWatchList> spByWatchLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.22.13.242; Initial Catalog =BMangukiya1 ; User ID= bmangukiya1 ; Password = H703226129 ; TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<OwnerDetail>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__OwnerDet__81938598585C46D5");

            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OwnerFirstName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.OwnerLastName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Town)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PetDetail>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__PetDetai__390CC5FE65F59221");

            entity.Property(e => e.PetId).HasColumnName("pet_id");
            entity.Property(e => e.Breed)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.PetName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PetNotes)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Type)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.PetDetails)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__PetDetail__Owner__38996AB5");
        });

        modelBuilder.Entity<TblCar>(entity =>
        {
            entity.HasKey(e => e.CarId);

            entity.ToTable("tblCar");

            entity.Property(e => e.CarId).HasColumnName("carID");
            entity.Property(e => e.CarYear)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("carYear");
            entity.Property(e => e.Color)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("licensePlate");
            entity.Property(e => e.Make)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("make");
            entity.Property(e => e.Model)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("model");
        });

        modelBuilder.Entity<TblDriver>(entity =>
        {
            entity.HasKey(e => e.Driverid).HasName("PK__tblDrive__F152282A111D53D8");

            entity.ToTable("tblDriver");

            entity.Property(e => e.Driverid)
                .ValueGeneratedNever()
                .HasColumnName("driverid");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Dname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dname");
            entity.Property(e => e.Dstate)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dstate");
            entity.Property(e => e.Zip).HasColumnName("zip");
        });

        modelBuilder.Entity<TblFaculty>(entity =>
        {
            entity.HasKey(e => e.FacultyId).HasName("PK__tblFacul__DBBF6FD188E4ADF5");

            entity.ToTable("tblFaculty");

            entity.Property(e => e.FacultyId).HasColumnName("facultyID");
            entity.Property(e => e.CarId).HasColumnName("carID");
            entity.Property(e => e.FacGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("facGender");
            entity.Property(e => e.FacName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("facName");
            entity.Property(e => e.HireDate).HasColumnName("hireDate");
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.Car).WithMany(p => p.TblFaculties)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__tblFacult__carID__267ABA7A");
        });

        modelBuilder.Entity<TblGenre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__tblGenre__0385055ED8E78410");

            entity.ToTable("tblGenre");

            entity.HasIndex(e => e.Name, "UQ__tblGenre__737584F69F57908E").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TblIncident>(entity =>
        {
            entity.HasKey(e => e.IncidentId).HasName("PK__tblIncid__06A5D761A6A18CF5");

            entity.ToTable("tblIncident");

            entity.Property(e => e.IncidentId).HasColumnName("incidentID");
            entity.Property(e => e.CarId).HasColumnName("carID");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.Facultyid).HasColumnName("facultyid");
            entity.Property(e => e.IncidentDate).HasColumnName("incidentDate");
            entity.Property(e => e.PsafetyId).HasColumnName("psafetyId");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Car).WithMany(p => p.TblIncidents)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__tblIncide__carID__30F848ED");

            entity.HasOne(d => d.Faculty).WithMany(p => p.TblIncidents)
                .HasForeignKey(d => d.Facultyid)
                .HasConstraintName("FK__tblIncide__facul__2F10007B");

            entity.HasOne(d => d.Psafety).WithMany(p => p.TblIncidents)
                .HasForeignKey(d => d.PsafetyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblIncide__psafe__300424B4");

            entity.HasOne(d => d.Student).WithMany(p => p.TblIncidents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__tblIncide__stude__2E1BDC42");
        });

        modelBuilder.Entity<TblIncident1>(entity =>
        {
            entity.HasKey(e => e.IncidentId).HasName("PK__tblIncid__06A5D761E0D4EE08");

            entity.ToTable("tblIncidents");

            entity.Property(e => e.IncidentId).HasColumnName("incidentID");
            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.IncidentDate).HasColumnName("incidentDate");
            entity.Property(e => e.PoliceId).HasColumnName("policeID");
            entity.Property(e => e.ViolationId).HasColumnName("violationID");

            entity.HasOne(d => d.Driver).WithMany(p => p.TblIncident1s)
                .HasForeignKey(d => d.Driverid)
                .HasConstraintName("FK__tblIncide__drive__5070F446");

            entity.HasOne(d => d.Police).WithMany(p => p.TblIncident1s)
                .HasForeignKey(d => d.PoliceId)
                .HasConstraintName("FK__tblIncide__polic__4F7CD00D");

            entity.HasOne(d => d.Violation).WithMany(p => p.TblIncident1s)
                .HasForeignKey(d => d.ViolationId)
                .HasConstraintName("FK__tblIncide__viola__4E88ABD4");
        });

        modelBuilder.Entity<TblPolice>(entity =>
        {
            entity.HasKey(e => e.PoliceId).HasName("PK__tblPolic__F2063982625D5869");

            entity.ToTable("tblPolice");

            entity.Property(e => e.PoliceId)
                .ValueGeneratedNever()
                .HasColumnName("policeID");
            entity.Property(e => e.Pname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pname");
        });

        modelBuilder.Entity<TblPublicSafety>(entity =>
        {
            entity.HasKey(e => e.PsafetyId).HasName("PK__tblPubli__9192AD2565F98012");

            entity.ToTable("tblPublicSafety");

            entity.Property(e => e.PsafetyId).HasColumnName("psafetyID");
            entity.Property(e => e.Badge)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("badge");
            entity.Property(e => e.PGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pGender");
            entity.Property(e => e.PName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("pName");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__tblStude__4D11D65C20EEE4C3");

            entity.ToTable("tblStudent");

            entity.Property(e => e.StudentId).HasColumnName("studentID");
            entity.Property(e => e.CarId).HasColumnName("carID");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("fName");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.LName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("lName");
            entity.Property(e => e.Major)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("major");

            entity.HasOne(d => d.Car).WithMany(p => p.TblStudents)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__tblStuden__carID__29572725");
        });

        modelBuilder.Entity<TblViolation>(entity =>
        {
            entity.HasKey(e => e.ViolationId).HasName("PK__tblViola__68930B7009B2AA05");

            entity.ToTable("tblViolation");

            entity.Property(e => e.ViolationId)
                .ValueGeneratedNever()
                .HasColumnName("violationID");
            entity.Property(e => e.Fine).HasColumnName("fine");
            entity.Property(e => e.Violation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("violation");
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
            entity.Property(e => e.Title).HasColumnName("Title").HasMaxLength(50);
            entity.Property(e => e.poster).HasColumnName("poster");

            entity.HasOne(d => d.Genre).WithMany(p => p.TblWatchListItems)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__tblWatchL__Genre__6B24EA82");

            entity.HasOne(d => d.List).WithMany(p => p.TblWatchListItems)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblWatchL__ListI__6A30C649");
        });

        modelBuilder.Entity<VwByOfficer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwByOfficer");

            entity.Property(e => e.Pname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pname");
        });

        modelBuilder.Entity<VwFinesPerViolation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwFinesPerViolation");

            entity.Property(e => e.Violation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("violation");
        });

        modelBuilder.Entity<VwIncidentList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwIncidentList");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Dname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dname");
            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Dstate)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dstate");
            entity.Property(e => e.Fine).HasColumnName("fine");
            entity.Property(e => e.IncidentDate).HasColumnName("incidentDate");
            entity.Property(e => e.Pname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pname");
            entity.Property(e => e.PoliceId).HasColumnName("policeID");
            entity.Property(e => e.Violation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("violation");
            entity.Property(e => e.ViolationId).HasColumnName("violationID");
            entity.Property(e => e.Zip).HasColumnName("zip");
        });

        modelBuilder.Entity<VwViolationsByCity>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwViolationsByCity");

            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
