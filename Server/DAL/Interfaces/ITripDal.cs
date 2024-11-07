using DAL.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITripDal
    {
        List<Trip> get_all();
        Trip get(int code);
        bool delete(int code);
        int add(Trip trip);
        bool update(Trip trip);
        bool add_registration_to_trip(int code);
    }
}
