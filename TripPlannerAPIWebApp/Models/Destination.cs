using System.ComponentModel.DataAnnotations;

namespace TripPlannerAPI.Models
{
    public class Destination
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid TripId { get; set; }
        public Trip Trip { get; set; } = null!;

        [Required, MaxLength(200)]
        public string City { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? CountryCode { get; set; } // ISO 3166-1 alpha-2, e.g. "UA"

        public int SortOrder { get; set; }

        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<Activity> Activities { get; set; } = [];
    }
}