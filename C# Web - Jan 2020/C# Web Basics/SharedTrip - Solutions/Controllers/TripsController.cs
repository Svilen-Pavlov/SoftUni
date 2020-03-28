using SharedTrip.Services.Trips;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }
            AllTripsViewModel model = this.tripsService.All();

            return this.View(model);
        }

        public HttpResponse Add()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Add(AddTripInputModel model)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }
            string errorUrl = "/Trips/Add";

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                return this.Redirect(errorUrl);
            }
            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                return this.Redirect(errorUrl);
            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                return this.Redirect(errorUrl);
            }
            }
            if (string.IsNullOrWhiteSpace(model.DepartureTime))
            {
                return this.Redirect(errorUrl);
            }
            //DateTime depTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            if (DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date)==false)
            {
                return this.Redirect(errorUrl);
            }
            if (string.IsNullOrWhiteSpace(model.Seats))
            {
                return this.Redirect(errorUrl);
            }
            int.TryParse(model.Seats, out int seatsParsed);
            if (seatsParsed < 2 || seatsParsed > 6)
            {
                return this.Redirect(errorUrl);
            }

            if(string.IsNullOrWhiteSpace(model.Description))
            {
                return this.Redirect(errorUrl);
            }

            if (model.Description.Length>80)
            {
                return this.Redirect(errorUrl);
            }

            string tripId=this.tripsService.Add(model);


            return this.Redirect("/");
        }

        public HttpResponse Details (string tripId)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }
            if (this.tripsService.TripExists(tripId) ==false)
            {
                return this.Redirect("/Trips/All");
            }
            TripDetailsViewModel model = this.tripsService.GetTripById(tripId);

            return this.View(model, "Details");
        }

        public HttpResponse AddUserToTrip (string tripId)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }
            if (this.tripsService.TripExists(tripId) == false)
            {
                return this.Redirect("/Trips/All");
            }

            if (this.tripsService.UserAlreadyAdded(tripId, this.User))
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            if (this.tripsService.AllSeatsAreTaken(tripId))
            {
                return this.Redirect("/Trips/All");
            }

            this.tripsService.AddUserToTrip(tripId, this.User);

            return this.Redirect("/Trips/All");
        }

    }
}
