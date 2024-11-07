using BLL.DTO;
using BLL.Inretfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        ITripBll I;
        public TripController(ITripBll i)
        {
            this.I = i;
        }

        [HttpGet("GetAllTrips")]
        public ActionResult<List<TripDTO>> GetAllTrips()
        {
            return Ok(I.get_all());
        }

        [HttpGet("GetTripById/{code}")]
        public ActionResult<TripDTO> GetTripById(int code)
        {
            return Ok(I.get(code));
        }

        [HttpGet("Get_registration_to_trip")]
        public ActionResult<List<BookingPlaceDTO>> Get_registration_to_trip(int code)
        {
            return Ok(I.get_registration_to_trip(code));
        }

        [HttpPost("AddTrip")]
        public ActionResult<bool> AddTrip(TripDTO trip)
        {
            return Ok(I.add(trip));
        }

        [HttpPost("Add_registration_to_trip")]
        public ActionResult<bool> Add_registration_to_trip(int code)
        {
            return Ok(I.add_registration_to_trip(code));
        }

        [HttpPut("UpdateTrip")]
        public ActionResult<bool> UpdateTrip(TripDTO trip)
        {
            return Ok(I.update(trip));
        }

        [HttpDelete("DeleteTrip")]
        public ActionResult<bool> DeleteTrip(int code)
        {
            return Ok(I.delete(code));
        }

    }
}

