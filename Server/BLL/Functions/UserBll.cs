using AutoMapper;
using BLL.DTO;
using BLL.Inretfaces;
using DAL.Interfaces;
using DAL.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Functions
{
    public class UserBll : IUserBll
    {
        IBookingPlaceBll bp;
        IUserDal idal;
        IMapper imapper;
        public UserBll(IUserDal idal, IBookingPlaceBll bp)
        {
            this.idal = idal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<mapper>();
            });
            imapper = config.CreateMapper();
            this.bp = bp;
        }
        public int add(UserDTO user)
        {
            try
            {
                idal.add(imapper.Map<UserDTO, User>(user));
                return user.UserCode;
            }
            catch 
            { 
                return -1;
            }
            
        }

        public bool delete(UserDTO user)
        {
            List<TripDTO> at = get_all_trips(user.UserCode);
            if (at.Count==0)
                return idal.delete(user.UserCode);
            return false;
        }

        public UserDTO get(string email, string login_Password)
        {
            return imapper.Map<User, UserDTO>(idal.get(email, login_Password));
        }

        public List<UserDTO> get_all()
        {
            return imapper.Map<List<User>, List<UserDTO>>(idal.get_all());
        }


        public List<TripDTO> get_all_trips(int code)
        {
            List<User> au = idal.get_all();
            User u = au.FirstOrDefault(x=>x.UserCode==code)!;
            List<BookingPlace> bp = u.BookingPlaces.ToList();
            List<Trip> res = new List<Trip>();
            foreach (BookingPlace b in bp)
                res.Add(b.TripCodeNavigation!);
            return imapper.Map<List<Trip>, List<TripDTO>>(res);
        }

        public bool update(UserDTO user)

        {
            try
            {
                idal.update(imapper.Map<UserDTO, User>(user));
                return true;
            }
            catch { return false; }
                
            
        }
    }
}
