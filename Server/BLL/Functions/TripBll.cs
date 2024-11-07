using AutoMapper;
using BLL.DTO;
using BLL.Inretfaces;
using DAL.Interfaces;
using DAL.Functions;
using DAL.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Functions
{
    public class TripBll : ITripBll
    {
        IUserBll ub;
        IBookingPlaceBll bb;
        ITripDal idal;
        IMapper imapper;
        public TripBll(ITripDal idal, IBookingPlaceBll bb, IUserBll ub )
        {
            this.idal = idal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<mapper>();
            });
            imapper = config.CreateMapper();
            this.bb = bb;
            this.ub = ub;
        }
        public int add(TripDTO trip)
        {
            try 
            {
                return idal.add(imapper.Map<TripDTO, Trip>(trip));
            }
            catch
            {
                return -1;
            }
            
        }

        public TripDTO get(int code)
        {
            return get_all().First(x=>x.TripCode==code);
        }

        public List<TripDTO> get_all()
        {
            return imapper.Map<List<Trip>, List<TripDTO>>(idal.get_all());
        }

        public List<BookingPlaceDTO> get_registration_to_trip(int code)
        {
            return bb.get_all_to_trip(code);
        }
        public bool add_registration_to_trip(int code)
        {
            return idal.add_registration_to_trip(code);
        }
        public bool update(TripDTO trip)
        {
            try
            {
                return idal.update(imapper.Map<TripDTO, Trip>(trip));
            }
            catch
            {
                return false;
            }
            
        }
        public bool delete(int code)
        {
            return idal.delete(code);
        }


        public bool Need_a_medic()
        {

            List<UserDTO> Users = ub.get_all();
            foreach (UserDTO user in Users)
            {
                if (user.FirstAidCertificate == true)
                    return false;
            }
            return true;
        }
    }
}
