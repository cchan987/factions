using ProjectTracker.Models;
using System.Collections.Generic;
using System;
using ProjectTracker.Data;
using System.Linq;

namespace ProjectTracker.Services
{

    public interface IProjectData
    {
        IEnumerable<Project> GetAcceptingParticipants();
        IEnumerable<Project> GetInProgress();
        Project ParticipatingIn(int id); //Pass userId to this, returns the project that the user is part of
        Project Add(Project newProject);
        Project Get(int id);
        void Delete(int id);
        void Commit();
    }

    public class SqlProjectData : IProjectData
    {
        private ApplicationDbContext _context;

        public SqlProjectData(ApplicationDbContext context)
        {
            _context = context;
        }

        public Project Add(Project newProject)
        {
            _context.Add(newProject);
            Commit();
            return newProject;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var toBeDeleted = Get(id);
            if (toBeDeleted == null) return;
            _context.Remove<Project>(toBeDeleted);
        }

        public Project Get(int id)
        {
            return _context.Project.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Project> GetAcceptingParticipants()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetInProgress()
        {
            throw new NotImplementedException();
        }

        public Project ParticipatingIn(int id)
        {
            throw new NotImplementedException();
        }
    }
}
