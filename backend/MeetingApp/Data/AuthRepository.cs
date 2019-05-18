using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingApp.Data
{
    public class AuthRepository : IAuthRepository
    {

        DataContext _context;

        public AuthRepository(DataContext context) {
            _context = context;
        }
        public async Task<Users> Login(string username, string password)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == username);
            if (user == null)
                return null;

            if (!VerifyPassword(password, user.Password, user.Salt)) {
                return null;
            }
            return user;
        }

        private bool VerifyPassword(string password, byte[] hashpassword, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt)) {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < hashpassword.Length; i++) {
                    if (computedHash[i] != hashpassword[i])
                        return false;
                }
                return true;
            }
        }

        public async Task<Users> Register(Users user, string password)
        {
            byte[] HashPassword, SaltPassword;
            CreatePasswordHash(password,out HashPassword,out SaltPassword);
            user.Password = HashPassword;
            user.Salt = SaltPassword;

            await _context.AddAsync<Users>(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public void CreatePasswordHash(string password, out byte[] hashPassword, out byte[] saltPassword)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) {
                saltPassword = hmac.Key;
                hashPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Name == username))
                return true;
            return false;
        }
    }
}
