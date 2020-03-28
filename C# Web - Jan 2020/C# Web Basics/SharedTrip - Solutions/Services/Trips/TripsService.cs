using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services.Trips
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Add(AddTripInputModel model)
        {
            var format = "dd.MM.yyyy HH:mm";
            DateTime depTime = DateTime.ParseExact(model.DepartureTime, format, CultureInfo.InvariantCulture);
            
            int.TryParse(model.Seats, out int seatsParsed);


            var trip = new Trip
            {
                DepartureTime = depTime,
                Description = model.Description,
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                ImagePath = model.ImagePath,
                Seats = seatsParsed
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();

            return trip.Id;
        }

        public void AddUserToTrip(string tripId, string userId)
        {
           // var user = this.db.Users.FirstOrDefault(x => x.Id == userId);
            var trip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);
            trip.Seats -= 1;

            var usertrip = new UserTrip { UserId = userId, TripId = tripId };

            this.db.UserTrip.Add(usertrip);
            this.db.SaveChanges();
        }

        public AllTripsViewModel All()
        {
            var model = new AllTripsViewModel() { Trips = new List<AllSingleTripViewModel>() };
            //Seats>0 по съвет на Стоян , да не се показват пълните трипове
            var list = this.db.Trips.Where(x=>x.Seats>0).Select(x => new AllSingleTripViewModel
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                Seats = x.Seats,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm")
            }).ToList();
            
            model.Trips = list;

            return model;
        }

        public bool AllSeatsAreTaken(string tripId)
        {
            var trip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);

            if(trip.Seats==0)
            {
                return true;
            }
            return false;
        }

        public TripDetailsViewModel GetTripById(string id)
        {
            var trip = this.db.Trips.FirstOrDefault(x => x.Id == id);

            var model = new TripDetailsViewModel
            {
                Id = trip.Id,
                DepartureTime = trip.DepartureTime.ToString(),
                Description = trip.Description,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                ImagePath = trip.ImagePath,
                Seats = trip.Seats
            };

            return model;
        }

        public bool TripExists(string id)
        {
            var trip = this.db.Trips.FirstOrDefault(x => x.Id == id);
            
            if (trip!=null)
            {
                return true;
            }
            return false;
        }

        public bool UserAlreadyAdded(string tripId, string userId)
        {
            var userTrip = this.db.UserTrip.FirstOrDefault(x => x.UserId == userId && x.TripId == tripId);

            if (userTrip!=null)
            {
                return true;
            }
            return false;

        }
    }
}
