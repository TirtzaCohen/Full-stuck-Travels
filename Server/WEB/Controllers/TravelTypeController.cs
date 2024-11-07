using BLL.DTO;
using BLL.Inretfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelType : ControllerBase
    {
        ITravelTypeBll I;
        public TravelType(ITravelTypeBll i)
        {
            this.I = i;
        }

        [HttpGet("GetAllTravelTypes")]
        public ActionResult<List<TripDTO>> GetAllTravelTypes()
        {
            return Ok(I.get_all());
        }

        [HttpPost("AddTravelType")]
        public ActionResult<int> AddTravelType(TravelTypeDTO traveltype)
        {
            return Ok(I.add(traveltype));
        }

        [HttpDelete("DeleteTravelType")]
        public ActionResult<bool> DeleteTravelType(int code)
        {
            return Ok(I.delete(code));  
        } 


    }
}