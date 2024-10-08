using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WooxTravelProject.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        // public string Email { get; set; }
        public string Phone { get; set; }
        public int PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Description { get; set; }
    }
}