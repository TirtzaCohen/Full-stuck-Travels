using AutoMapper;
using BLL.DTO;
using BLL.Inretfaces;
using DAL.Functions;
using DAL.Interfaces;
using DAL.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Functions
{
    public class BookingPlaceBll : IBookingPlaceBll
    {
        ITripDal tb;
        IBookingPlaceDal idal;
        IMapper imapper;
        public BookingPlaceBll(IBookingPlaceDal idal, ITripDal tb)
        {
            this.idal = idal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<mapper>();
            });
            imapper = config.CreateMapper();
            this.tb = tb;
        }


        public int add(BookingPlaceDTO bookingplace)
        {
            Trip t = this.tb.get(bookingplace.TripCode);
            if(bookingplace.TripDate >= DateTime.Now) 
            { 
                bookingplace.BookingDate = DateTime.Now;
                t.NumberOfAvailablePlaces -= 1;
                return this.idal.add(imapper.Map<BookingPlaceDTO, BookingPlace>(bookingplace));
            }
                       
            return -1;
            
        }

        public bool delete(int code)
        {
            try
            {
                idal.delete(code);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public List<BookingPlaceDTO> get_all()
        {
            return imapper.Map<List<BookingPlace>, List<BookingPlaceDTO>>(idal.get_all());
        }

        public List<BookingPlaceDTO> get_all_to_trip(int code)
        {
            List<BookingPlaceDTO> bookingplaces = imapper.Map<List<BookingPlace>, List<BookingPlaceDTO>>(idal.get_all());
            return bookingplaces.Where(x=>x.TripCode==code).ToList();
        }
    }
}
