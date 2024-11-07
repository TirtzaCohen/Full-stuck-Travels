using BLL.DTO;
using BLL.Inretfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingPlaceController : ControllerBase
    {
        IBookingPlaceBll I;
        public BookingPlaceController(IBookingPlaceBll i)
        {
            this.I = i;
        }
        [HttpGet("GetAllBookingPlace")]
        public ActionResult<List<BookingPlaceDTO>> GetAllBookingPlace()
        {
            return Ok(I.get_all());
        }

        [HttpGet("GetAllToTrip")]
        public ActionResult<List<BookingPlaceDTO>> GetAllToTrip(int code)
        {
            return Ok(I.get_all_to_trip(code));
        }
        [HttpPost("AddBookingPlace")]
        public ActionResult<int> AddBookingPlace(BookingPlaceDTO bookingplace)
        {
            return Ok(I.add(bookingplace));
        }
        [HttpDelete("DeleteBookingPlace")]
        public ActionResult<bool> DeleteBookingPlace(int code)
        {
            return Ok(I.delete(code));
        }
    }
}