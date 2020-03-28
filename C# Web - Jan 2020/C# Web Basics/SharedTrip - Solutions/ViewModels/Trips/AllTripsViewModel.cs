using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class AllTripsViewModel
    {
        public IEnumerable<AllSingleTripViewModel> Trips { get; set; }
    }
}
