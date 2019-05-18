using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingApp.Models;

namespace MeetingApp.Data
{
    public interface IMeetingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<Users> GetUser(int id);
        Task<IEnumerable<Users>> GetAllUsers();

        Task<bool> SaveAll();
    }
}
