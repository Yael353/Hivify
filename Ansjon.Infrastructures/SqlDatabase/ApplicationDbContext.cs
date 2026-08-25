using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.Aggregates.Complaints;
using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.Infrastructures.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.SqlDatabase;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<House> Houses { get; set; }
    public DbSet<Association> Associations { get; set; }
    public DbSet<Member> StaffMembers { get; set; }
    public DbSet<Feed> Feeds => Set<Feed>();
    public DbSet<Complaint> Complaints => Set<Complaint>();

    public DbSet<Tenant> Tenants { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // =====================
        // Complaint
        // =====================

        modelBuilder.Entity<Complaint>(entity =>
        {
            // 1. ID
            entity.Property(c => c.Id)
                .HasConversion(
                    id => id.Value,
                    value => new ComplaintID(value));

            // 2. UserId
            entity.Property(c => c.UserId)
                .HasConversion(
                    userId => userId.Value,
                    value => new UserID(value));

            // 4. Category (enum)
            entity.Property(c => c.Category)
                .HasConversion<int>();

            // 5. Title (Value Object)
            entity.OwnsOne(c => c.Title, title =>
            {
                title.Property(t => t.Value)
                    .HasColumnName("Title")
                    .HasMaxLength(200)
                    .IsRequired();
            });

            // 6. Description (Value Object)
            entity.OwnsOne(c => c.Description, description =>
            {
                description.Property(d => d.Value)
                    .HasColumnName("Description")
                    .HasMaxLength(2000)
                    .IsRequired();
            });

            // 7. ImageUrl
            entity.Property(c => c.ImageUrl)
                .HasMaxLength(5000)
                .IsRequired(false);

            // 8. Status (enum)
            entity.Property(c => c.Status)
                .HasConversion<int>();

            // 9. CreatedDate
            entity.Property(c => c.CreatedDate)
                .IsRequired();

            // 10. UpdatedDate (nullable)
            entity.Property(c => c.UpdatedDate)
                .IsRequired(false);

            // 11. ResolvedDate (nullable)
            entity.Property(c => c.ResolvedDate)
                .IsRequired(false);

            // 12. AdminComment (nullable)
            entity.Property(c => c.AdminComment)
                .HasMaxLength(1000)
                .IsRequired(false);
        });



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
                value => new UserID(value));

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

        modelBuilder.Entity<Association>(builder =>
        {
            builder.Property(a => a.Id)
                .HasConversion(
                    id => id.Value,
                    value => new AssociationID(value));

            builder.Property(a => a.Name)
                .HasConversion(
                    name => name.Value,
                    value => new Name(value));

            builder.HasMany<Member>("_members")
                .WithOne()
                .HasForeignKey(m => m.AssociationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation("_members")
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        });


        // =====================
        // StaffMember
        // =====================

        modelBuilder.Entity<Member>(builder =>
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasConversion(
                    id => id.Value,
                    value => new MemberID(value));

            builder.Property(m => m.AssociationId)
                .HasConversion(
                    id => id.Value,
                    value => new AssociationID(value));

            builder.Property(m => m.UserId)
                .HasConversion(
                    userId => userId.Value,
                    value => new UserID(value))
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(m => m.FullName)
                .HasConversion(
                    name => name.Value,
                    value => new Name(value))
                .HasColumnName("FullName")
                .IsRequired();

            builder.Property(m => m.Role)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(m => m.DeletedAt)
                .HasColumnName("DeletedAt");

            builder.HasIndex(m => new
            {
                m.AssociationId,
                m.UserId
            })
            .IsUnique()
            .HasFilter("[DeletedAt] IS NULL");
        });

        // =====================
        // House
        // =====================

        modelBuilder.Entity<House>()
            .Property(h => h.Id)
            .HasConversion(
                id => id.Value,
                value => new HouseID(value));



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
        // =====================
        // Tenant – Entity
        // =====================

        modelBuilder.Entity<Tenant>(tenant =>
        {
            tenant.HasKey(t => t.Id);

            tenant.Property(t => t.Id)
                .HasConversion(
                    id => id.Value,
                    value => new TenantID(value))
                .HasColumnName("TenantId");

            tenant.Property(t => t.UserId)
                .HasConversion(
                    id => id.Value,
                    value => new UserID(value))
                .HasColumnName("UserId")
                .IsRequired();

            tenant.Property(t => t.Email)
                .HasConversion(
                    email => email.Value,
                    value => new Email(value))
                .HasColumnName("Email")
                .IsRequired();

            tenant.Property(t => t.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            tenant.Property(t => t.DeletedAt)
                .HasColumnName("DeletedAt");


            // =====================
            // Tenant Value Objects
            // =====================

            tenant.OwnsOne(
                t => t.FullName,
                fullName =>
                {
                    fullName.Property(n => n.Value)
                        .HasColumnName("FullName")
                        .HasMaxLength(200)
                        .IsRequired();
                });

            tenant.OwnsOne(
                t => t.PhoneNumber,
                phoneNumber =>
                {
                    phoneNumber.Property(p => p.Value)
                        .HasColumnName("PhoneNumber")
                        .HasMaxLength(30)
                        .IsRequired();
                });
        });
    }

}