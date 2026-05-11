using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripPlannerAPI.Models
{
    public class TripMember
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid TripId { get; set; }
        public Trip Trip { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public MemberRole Role { get; set; } = MemberRole.Viewer;

        /// Pending = invite sent but not yet accepted.
        /// Accepted = active member.
        /// Declined / Removed = no longer active.
        public string InviteStatus { get; set; } = "Accepted"; // Pending | Accepted | Declined | Removed

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PersonalBudget { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        public Guid? InvitedByUserId { get; set; }
        public User? InvitedByUser { get; set; }
    }
}