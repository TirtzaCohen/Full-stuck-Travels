using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Inretfaces
{
    public interface ITripBll
    {
        List<TripDTO> get_all();
        TripDTO get(int code);
        int add(TripDTO trip);
        bool update(TripDTO trip);
        List<BookingPlaceDTO> get_registration_to_trip(int code);
        bool add_registration_to_trip(int code);
        bool delete(int code);
        bool Need_a_medic();
    }
}
