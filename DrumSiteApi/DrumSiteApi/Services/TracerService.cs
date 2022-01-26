using DrumSite.Entities;
using DrumSiteApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DrumSiteApi.Services
{
    public interface ITracerService
    {
        List<Day> GetDays(int userId);
        void InsertDay(int userId, Day day);
    }

    public class TracerService : ITracerService
    {
        private readonly DrumSiteDbContext _dbContext;

        public TracerService(DrumSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Day> GetDays(int userId)
        {
            var days = new List<Day>();
            var user = _dbContext.Users.Include(u => u.Days).Where(u => u.Id == userId).FirstOrDefault();
            if(user != null)
                days = user.Days;

            return days == null ? days : days.ToList();
        }

        public void InsertDay(int userId, Day day)
        {
            var user = _dbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
            var newDay = new Day()
            {
                Date = day.Date,
                systemATime = day.systemATime,
                systemBTime = day.systemBTime,
                systemCTime = day.systemCTime,
                systemDTime = day.systemDTime
            };
            if (user != null)
            {
                if (user.Days == null)
                    user.Days = new List<Day>();
                user.Days.Add(newDay);
                _dbContext.SaveChanges();
            }
        }
    }
}
