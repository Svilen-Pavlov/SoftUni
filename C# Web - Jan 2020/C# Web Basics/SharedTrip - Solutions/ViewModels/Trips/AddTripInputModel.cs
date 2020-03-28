using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class AddTripInputModel
    {
        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        //"dd.MM.yyyy HH:mm"
        public string DepartureTime { get; set; } //Datetime?

        public string Seats { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
