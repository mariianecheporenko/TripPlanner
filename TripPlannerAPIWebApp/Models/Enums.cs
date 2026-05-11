namespace TripPlannerAPI.Models
{
    
        public enum TripStatus
        {
            Draft,      // being planned
            Confirmed,  // finalized
            Ongoing,    // currently happening
            Completed,
            Cancelled
        }

        public enum MemberRole
        {
            Organizer,  // full control
            Editor,     // can add/edit activities
            Viewer      // read-only
        }

        public enum ActivityType
        {
            Transport,      // train, flight, bus
            Accommodation,  // hotel, hostel
            Attraction,     // museum, park
            Food,           // restaurant, café
            Event,          // concert, tour
            Other
        }

        public enum HistoryAction
        {
            TripCreated,
            TripUpdated,
            DestinationAdded,
            DestinationRemoved,
            ActivityAdded,
            ActivityUpdated,
            ActivityRemoved,
            MemberInvited,
            MemberRemoved,
            RoleChanged,
            BudgetUpdated
        }
   
}
