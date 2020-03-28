using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class Trip
    {
        public Trip()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        public string StartPoint { get; set; }
        
        [Required]
        public string EndPoint { get; set; }
       
        //"dd.MM.yyyy HH:mm"
        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        [Range(2,6)]
        public int Seats { get; set; }

        [Required]
        [MaxLength(80)]
        public string Description { get; set; }

        public string ImagePath { get; set; }
        public virtual ICollection<UserTrip> UserTrips { get; set; }

    }
}
