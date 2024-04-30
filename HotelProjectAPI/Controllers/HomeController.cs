using Microsoft.AspNetCore.Mvc;

namespace HotelProjectAPI.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetData()
        {
            return "gamarjoba";
        }
    }
}
