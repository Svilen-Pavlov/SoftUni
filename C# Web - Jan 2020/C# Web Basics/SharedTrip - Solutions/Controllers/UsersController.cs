using SharedTrip.Services.Users;
using SharedTrip.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    public class UsersController :Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Register()
        {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(UserRegisterViewModel model)
        {
            string errorUrl = "/Users/Register";
            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.Redirect(errorUrl);
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Redirect(errorUrl);
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect(errorUrl);
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return this.Redirect(errorUrl);
            }

            if (this.usersService.EmailExists(model.Email))
            {
                return this.Redirect(errorUrl);
            }

            if (this.usersService.UserExists(model.Username))
            {
                return this.Redirect(errorUrl);
            }

            string userId = this.usersService.Register(model);

            this.SignIn(userId);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }
        
        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            string errorUrl = "/Users/Login";

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.Redirect(errorUrl);
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Redirect(errorUrl);
            }


            string userId = this.usersService.GetUserOrNull(model.Username, model.Password);
            if (userId == null)
            {
                return this.Redirect(errorUrl);
            }

            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Logout()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }
            this.SignOut();

            return this.Redirect("/");
        }

    }
}
