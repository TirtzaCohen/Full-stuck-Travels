using DAL.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBookingPlaceDal
    {
        List<BookingPlace> get_all();
        BookingPlace get(int code);
        int add(BookingPlace bookingPlace);
        bool delete (int code); 
    }
}
