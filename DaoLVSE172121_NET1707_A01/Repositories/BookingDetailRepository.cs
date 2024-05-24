using DataAccessObjects;
using DataAccessObjects.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepository
    {
        public List<BookingDetail> GetBookingDetails() => BookingDetailDAO.GetBookingDetails();
    }
}
