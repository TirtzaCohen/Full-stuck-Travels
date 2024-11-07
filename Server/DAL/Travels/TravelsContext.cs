using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Travels;

public partial class TravelsContext : DbContext
{
    public TravelsContext()
    {
    }

    public TravelsContext(DbContextOptions<TravelsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookingPlace> BookingPlaces { get; set; }

    public virtual DbSet<TravelType> TravelTypes { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=תרצה\\SQLEXPRESS;Database=Travels;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingPlace>(entity =>
        {
            entity.HasKey(e => e.BookingCode).HasName("PK__Booking___FF29040EDB928CE8");

            entity.ToTable("Booking_Places");

            entity.Property(e => e.BookingCode).HasColumnName("booking_code");
            entity.Property(e => e.BookingDate)
                .HasColumnType("date")
                .HasColumnName("booking_date");
            entity.Property(e => e.BookingTime).HasColumnName("booking_time");
            entity.Property(e => e.NumberOfPlaces).HasColumnName("number_of_places");
            entity.Property(e => e.TripCode).HasColumnName("trip_code");
            entity.Property(e => e.UserCode).HasColumnName("user_code");

            entity.HasOne(d => d.TripCodeNavigation).WithMany(p => p.BookingPlaces)
                .HasForeignKey(d => d.TripCode)
                .HasConstraintName("FK__Booking_P__trip___5165187F");

            entity.HasOne(d => d.UserCodeNavigation).WithMany(p => p.BookingPlaces)
                .HasForeignKey(d => d.UserCode)
                .HasConstraintName("FK__Booking_P__user___5070F446");
        });

        modelBuilder.Entity<TravelType>(entity =>
        {
            entity.HasKey(e => e.TypeCode).HasName("PK__TravelTy__E9DAA9C68BC86FBA");

            entity.ToTable("TravelType");

            entity.Property(e => e.TypeCode).HasColumnName("typeCode");
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("typeName");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripCode).HasName("PK__Trips__F6B4147DD3F37942");

            entity.Property(e => e.TripCode).HasColumnName("trip_code");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.DepartureTime).HasColumnName("departure_time");
            entity.Property(e => e.NumberOfAvailablePlaces).HasColumnName("number_of_available_places");
            entity.Property(e => e.Photo)
                .HasColumnType("text")
                .HasColumnName("photo");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.TripDestination)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("trip_destination");
            entity.Property(e => e.TripDurationHours).HasColumnName("trip_duration_hours");
            entity.Property(e => e.TypeCode).HasColumnName("type_code");

            entity.HasOne(d => d.TypeCodeNavigation).WithMany(p => p.Trips)
                .HasForeignKey(d => d.TypeCode)
                .HasConstraintName("FK__Trips__type_code__4D94879B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserCode).HasName("PK__Users__EDC4140E735AA890");

            entity.Property(e => e.UserCode).HasColumnName("user_code");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Family)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("family");
            entity.Property(e => e.FirstAidCertificate).HasColumnName("first_aid_certificate");
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("login_password");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
