using DataAccessObjects;
using DataAccessObjects.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingReservationRepository
    {
        public List<BookingReservation> GetBookingReservations() => BookingReservationDAO.GetBookingReservations(); 
    }
}
