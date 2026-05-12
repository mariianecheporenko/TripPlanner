using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripPlannerAPI.Models
{
    public class Activity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid DestinationId { get; set; }
        public Destination? Destination { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Description { get; set; }

        public ActivityType Type { get; set; } = ActivityType.Other;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Cost { get; set; }

        [MaxLength(500)]
        public string? Location { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [MaxLength(200)]
        public string? BookingReference { get; set; }

        [MaxLength(512)]
        public string? BookingUrl { get; set; }

        public int SortOrder { get; set; }


        public bool IsFlexible { get; set; } = false;

        [MaxLength(1000)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;

        public Guid? CreatedByUserId { get; set; }
        public User? CreatedByUser { get; set; }

        [NotMapped]
        public TimeSpan Duration => EndTime - StartTime;
    }
}