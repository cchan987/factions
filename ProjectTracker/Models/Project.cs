using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProjectTracker.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountParticipants { get; set; }
        public int CountActiveParticipants { get; set; }
        public Boolean isActive { get; set; }
        public Boolean isAcceptingParticipants { get; set; }
        public String WhoseTurn { get; set; }

        public string ToJSON(string status = "", string type = "ListUpdate")
        {
            var json = JsonConvert.SerializeObject(new { Type = type, Data = new { Status = status, Project = this } });
            return json;
        }
    }
}