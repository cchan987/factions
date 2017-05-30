using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Models
{
    public class UserParticipation
    {
        [Key]
        public String UserId { get; set; }
        public int ProjectId { get; set; }
    }
}