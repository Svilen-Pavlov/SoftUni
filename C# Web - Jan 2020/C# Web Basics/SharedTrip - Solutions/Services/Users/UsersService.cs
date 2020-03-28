using SharedTrip.Models;
using SharedTrip.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool EmailExists(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public string GetUserOrNull(string username, string password)
        {
            string hashedPass = this.HashPassword(password);
            var user = this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashedPass);

            if (user != null)
            {
                return user.Id;
            }
            return null;
        }

        public string Register(UserRegisterViewModel model)
        {
            var passwordHash = this.HashPassword(model.Password);
            var user = new User
            { 
                Username=model.Username,
                Password=passwordHash,
                Email=model.Email,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();


            return user.Id;
        }

        public bool UserExists(string username)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == username);
            if (user!=null)
            {
                return true;
            }
            return false;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
