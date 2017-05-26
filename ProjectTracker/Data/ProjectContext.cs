using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Data
{
    public class ProjectContext : DbContext
    {
        private IConfigurationRoot _config;

        public ProjectContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet<UserStats> UserStats { get; set; }
        public DbSet<UserParticipation> UserParticipation { get; set; }
        public DbSet<ProjectChange> ProjectChange { get; set; }
        public DbSet<Project> Project { get; set; }

    }
}
