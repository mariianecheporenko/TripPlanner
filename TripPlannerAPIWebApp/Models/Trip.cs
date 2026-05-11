using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace TripPlannerAPI.Models
{
    public class Trip
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Description { get; set; }

        [MaxLength(512)]
        public string? CoverImageUrl { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; } = "USD";

        [Column(TypeName = "decimal(18,2)")]
        public decimal? BudgetLimit { get; set; }

        public int BudgetWarningThresholdPercent { get; set; } = 80;

        public TripStatus Status { get; set; } = TripStatus.Draft;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Destination> Destinations { get; set; } = [];
        public ICollection<TripMember> Members { get; set; } = [];
        public ICollection<TripHistory> History { get; set; } = [];

        [NotMapped]
        public decimal TotalSpent => Destinations
            .SelectMany(d => d.Activities)
            .Sum(a => a.Cost ?? 0);

        [NotMapped]
        public bool IsBudgetWarning =>
            BudgetLimit.HasValue &&
            BudgetLimit.Value > 0 &&
            TotalSpent >= BudgetLimit.Value * BudgetWarningThresholdPercent / 100m;

        [NotMapped]
        public bool IsBudgetExceeded =>
            BudgetLimit.HasValue && TotalSpent > BudgetLimit.Value;
    }
}