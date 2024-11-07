using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Inretfaces
{
    public interface IBookingPlaceBll
    {
        List<BookingPlaceDTO> get_all();
        List<BookingPlaceDTO> get_all_to_trip(int code);
        int add(BookingPlaceDTO bookingplace);
        bool delete (int code);
    }
}
