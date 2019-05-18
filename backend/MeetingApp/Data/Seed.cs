using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingApp.Models;
using Newtonsoft.Json;

namespace MeetingApp.Data
{
    public class Seed
    {
        public DataContext _context { get; set;  }

        public Seed(DataContext context) {
            _context = context;
        }

        public void SeedData() {
            var userdata = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<Users>>(userdata);

            foreach(var user in users) {
                Users n_user = user;
                AuthRepository auth = new AuthRepository(_context);
                byte[] HashPassword, SaltPassword; 
                auth.CreatePasswordHash("password", out HashPassword, out SaltPassword);

                n_user.Password = HashPassword;
                n_user.Salt = SaltPassword;
                n_user.Name = user.Name;

                _context.Users.Add(n_user);
                
            }
            _context.SaveChanges();

        }

    }
}
