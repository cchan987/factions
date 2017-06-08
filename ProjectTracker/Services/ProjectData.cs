using ProjectTracker.Models;
using System.Collections.Generic;
using System;
using ProjectTracker.Data;
using System.Linq;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;

namespace ProjectTracker.Services
{

    public interface IProjectData
    {
        List<Project> GetAcceptingParticipants();
        List<Project> GetInProgress();
        Project ParticipatingIn(String UserId); //Pass userId to this, returns the project that the user is part of
        Project Add(Project newProject);
        Project Get(int id);
        void Delete(int id);
        void Commit();
        UserParticipation GetParticipation(string Username);
        List<String> GetUsersInProject(int ProjId);
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

        public List<Project> GetAcceptingParticipants()
        {
            return _context.Project.Where(r => r.isActive && r.isAcceptingParticipants).ToList();
        }

        public List<Project> GetInProgress()
        {
            return _context.Project.Where(r => r.isActive && !r.isAcceptingParticipants).ToList();
        }

        public Project ParticipatingIn(String UId)
        {
            UserParticipation projChange = _context.UserParticipation.Where(r => r.UserId == UId).FirstOrDefault();
            Project relevantProject = Get(projChange.ProjectId);
            return relevantProject;
        }

        public UserParticipation GetParticipation(string Username)
        {
            return _context.UserParticipation.FirstOrDefault(r => r.UserId == Username);
        }

        public List<String> GetUsersInProject(int ProjId)
        {
            List<UserParticipation> up = _context.UserParticipation.Where(r => r.ProjectId == ProjId).Select(r => new UserParticipation { UserId = r.UserId }).ToList();
            List<String> us = new List<string>();
            foreach (var userp in up)
            {
                us.Append(userp.UserId);
            }
            return us;
        }
    }
}
