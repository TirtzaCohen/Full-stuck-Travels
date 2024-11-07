using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Inretfaces
{
    public interface ITravelTypeBll
    {
        List<TravelTypeDTO> get_all();
        int add(TravelTypeDTO t);
        bool delete(int code);
    }
}
