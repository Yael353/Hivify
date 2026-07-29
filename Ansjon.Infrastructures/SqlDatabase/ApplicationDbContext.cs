using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Associations.Staff;
using Ansjon.Core.Aggregates.Complaints;
using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.ValuesObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.SqlDatabase;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<House> Houses { get; set; }
    public DbSet<AssociationEntity> Associations { get; set; }
    public DbSet<StaffMember> StaffMembers { get; set; }
    public DbSet<Feed> Feeds => Set<Feed>();
    public DbSet<Complaint> Complaints => Set<Complaint>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // =====================
        // Complaint
        // =====================

        modelBuilder.Entity<Complaint>()
            .Property(c => c.Id)
            .HasConversion(
                id => id.Value,
                value => new ComplaintID(value));


        modelBuilder.Entity<Complaint>()
            .Property(c => c.TenantId)
            .HasConversion(
                id => id.Value,
                value => new TenantID(value));



        // =====================
        // Feed
        // =====================

        modelBuilder.Entity<Feed>()
            .Property(f => f.Id)
            .HasConversion(
                id => id.Value,
                value => new FeedID(value));


        modelBuilder.Entity<Feed>()
            .Property(f => f.AuthorId)
            .HasConversion(
                id => id.Value,
                value => new StaffMemberID(value));


        modelBuilder.Entity<Feed>()
            .Property(f => f.Title)
            .HasConversion(
                title => title.Value,
                value => new Title(value))
            .HasMaxLength(200);


        modelBuilder.Entity<Feed>()
            .Property(f => f.Content)
            .HasConversion(
                content => content.Value,
                value => new Description(value))
            .HasMaxLength(1000);



        // =====================
        // Association
        // =====================

        modelBuilder.Entity<AssociationEntity>()
            .Property(a => a.Id)
            .HasConversion(
                id => id.Value,
                value => new AssociationID(value));



        // =====================
        // StaffMember
        // =====================

        modelBuilder.Entity<StaffMember>()
            .Property(s => s.Id)
            .HasConversion(
                id => id.Value,
                value => new StaffMemberID(value));



        // =====================
        // House
        // =====================

        modelBuilder.Entity<House>()
            .Property(h => h.Id)
            .HasConversion(
                id => id.Value,
                value => new HouseID(value));


        modelBuilder.Entity<House>()
            .Property(h => h.AssociationId)
            .HasConversion(
                id => id.Value,
                value => new AssociationID(value));


        // House -> Association relationship
        modelBuilder.Entity<House>()
            .HasOne<AssociationEntity>()
            .WithMany()
            .HasForeignKey(h => h.AssociationId)
            .OnDelete(DeleteBehavior.Restrict);



        // =====================
        // House Value Objects
        // =====================

        modelBuilder.Entity<House>()
            .OwnsOne(
                h => h.Address,
                address =>
                {
                    address.Property(a => a.Value)
                        .HasColumnName("Address")
                        .HasMaxLength(200);
                });


        modelBuilder.Entity<House>()
            .OwnsOne(
                h => h.HouseNumber,
                houseNumber =>
                {
                    houseNumber.Property(h => h.Value)
                        .HasColumnName("HouseNumber")
                        .HasMaxLength(20);
                });


        modelBuilder.Entity<House>()
            .OwnsOne(
                h => h.PostalCode,
                postalCode =>
                {
                    postalCode.Property(p => p.Value)
                        .HasColumnName("PostalCode")
                        .HasMaxLength(20);
                });
    }
}