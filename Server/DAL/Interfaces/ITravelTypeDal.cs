using DAL.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITravelTypeDal
    {
        List<TravelType> get_all();
        TravelType get(int code);
        int add(TravelType t);
        bool delete(int code);
    }
}
