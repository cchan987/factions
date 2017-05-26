﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public int CountParticipants { get; set; }
        public int CountActiveParticipants { get; set; }
        public Boolean isActive { get; set; }
        public Boolean isAcceptingParticipants { get; set; }
        public int WhoseTurn { get; set; }
    }
}