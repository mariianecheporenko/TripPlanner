using Microsoft.EntityFrameworkCore;
using TripPlannerAPI.Models;

namespace TripPlannerAPI.Data
{

    public class TripPlannerContext : DbContext
    {
        public TripPlannerContext(DbContextOptions<TripPlannerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<Destination> Destinations { get; set; } = null!;
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<TripMember> TripMembers { get; set; } = null!;
        public DbSet<TripHistory> TripHistories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }

            modelBuilder.Entity<TripMember>(entity =>
            {
                entity.HasOne(tm => tm.User)
                    .WithMany(u => u.TripMemberships) 
                    .HasForeignKey(tm => tm.UserId)
                    .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(tm => tm.InvitedByUser)
                    .WithMany() 
                    .HasForeignKey(tm => tm.InvitedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}