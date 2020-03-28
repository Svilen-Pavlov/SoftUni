using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Trips
{
    public interface ITripsService
    {
        AllTripsViewModel All();
        string Add(AddTripInputModel model);
        TripDetailsViewModel GetTripById(string id);
        bool TripExists(string id);
        void AddUserToTrip(string tripId, string userId);
        bool UserAlreadyAdded(string tripId, string userId);
        bool AllSeatsAreTaken(string tripId);
    }
}
