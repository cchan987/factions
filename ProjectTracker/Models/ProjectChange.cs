using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Models
{
    public class ProjectChange
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [MaxLength(100)]
        public String Change { get; set; }
        public int ChangeBy { get; set; }
        public int ChangeConcerns { get; set; }
    }
}