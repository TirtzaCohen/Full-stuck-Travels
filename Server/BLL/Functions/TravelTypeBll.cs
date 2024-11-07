using AutoMapper;
using BLL.DTO;
using BLL.Inretfaces;
using DAL.Interfaces;
using DAL.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Functions
{
    public class TravelTypeBll : ITravelTypeBll
    {
        ITravelTypeDal idal;
        IMapper imapper;
        public TravelTypeBll(ITravelTypeDal idal)
        {
            this.idal = idal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<mapper>();
            });
            imapper = config.CreateMapper();
        }

        public int add(TravelTypeDTO t)
        {
            if(idal.get_all().FirstOrDefault(x=>x.TypeCode==t.TypeCode)!=null)
               return idal.add(imapper.Map<TravelTypeDTO, TravelType>(t));
            return -1;
        }

        public bool delete(int code)
        {
            return idal.delete(code);
        }
         
        public List<TravelTypeDTO> get_all()
        {
            return imapper.Map<List<TravelType>, List<TravelTypeDTO>>(idal.get_all());
        }
    }
}
