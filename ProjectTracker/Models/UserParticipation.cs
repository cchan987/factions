using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Models
{
    public class UserParticipation
    {
        [Key]
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}