using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Models
{
    public class UserStats
    {
        [Key]
        public String UserId { get; set; }
        public int DataA { get; set; }
        public int DataB { get; set; }
        public int DataC { get; set; }
        public int DataD { get; set; }
        public int DataE { get; set; }
    }
}