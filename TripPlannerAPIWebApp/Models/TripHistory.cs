using System.ComponentModel.DataAnnotations;

namespace TripPlannerAPI.Models
{
    public class TripHistory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid TripId { get; set; }
        public Trip Trip { get; set; } = null!;

        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public HistoryAction Action { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        /// Which entity type was affected (e.g. "Activity", "Destination").
        [MaxLength(100)]
        public string? EntityType { get; set; }

        /// PK of the affected entity.
        public Guid? EntityId { get; set; }

        public DateTime OccurredAt { get; set; } = DateTime.UtcNow;

        /// Client IP for security audit trail.
        [MaxLength(50)]
        public string? IpAddress { get; set; }
    }
}