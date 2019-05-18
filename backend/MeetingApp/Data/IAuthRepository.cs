using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingApp.Models;

namespace MeetingApp.Data
{
    public interface IAuthRepository
    {
        Task<Users> Register(Users user, string password);

        Task<Users> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}
