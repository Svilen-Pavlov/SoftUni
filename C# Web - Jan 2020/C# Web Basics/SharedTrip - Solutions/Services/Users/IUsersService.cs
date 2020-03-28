using SharedTrip.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Users
{
    public interface IUsersService
    {
        bool UserExists(string username);
        string Register(UserRegisterViewModel model);
        string GetUserOrNull(string username, string password);
        bool EmailExists(string email);
    }
}
