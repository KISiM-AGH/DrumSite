using DrumSite.Entities;
using DrumSiteApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DrumSite.Migrations
{
    public class DrumSiteSeeder
    {
        private readonly DrumSiteDbContext _dbContext;
        public DrumSiteSeeder(DrumSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Days.Any())
                {
                    var days = GetDays();
                    _dbContext.Days.AddRange(days);
                    _dbContext.SaveChanges();
                }
            }
        }

        private List<Day> GetDays()
        {
            var days = new List<Day>()
            {
                new Day()
                {
                    Date = System.DateTime.Now,
                    systemATime = 30,
                    systemBTime = 60,
                    systemCTime = 15,
                    systemDTime = 10
                }
            };

            return days;
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User() {
                    FirstName = "Maja",
                    LastName = "Kornaga",
                    Email = "mkornagamajka@gmail.com",
                    NickName = "Mahja"
                },
                new User() {
                    FirstName = "Maciej",
                    LastName = "Kucia",
                    Email = "macikucia@onet.pl",
                    NickName = "McKucia"
                }
            };


            return users;
        }
    }
}
