using Microsoft.AspNetCore.Mvc;

namespace MDERP.Web.API.Controllers
{
    [ApiController]
    [Route("user/login")]
    public class LoginController : Controller
    {
        [HttpGet]
        public JsonResult Index()
        {
            return new JsonResult("");
        }
    }
}
