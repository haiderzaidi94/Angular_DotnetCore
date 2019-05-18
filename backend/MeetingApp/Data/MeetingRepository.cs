using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingApp.Data
{
    public class MeetingRepository : IMeetingRepository
    {
        public DataContext _context { get; set; }

        public MeetingRepository(DataContext context)
        {
            _context = context;
        }

        
        public void Add<T>(T entity) where T : class
        {
            _context.Add<T>(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove<T>(entity);
        }
        
        public async Task<Users> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(p => p.id == id);
            return user;
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }
    }
}
