using DrumSiteApi.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrumSite.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string PasswordHash { get; set; }

        public virtual List<Day> Days { get; set; }
    }
}
