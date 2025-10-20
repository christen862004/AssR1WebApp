using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
    //r/{action}
    public class RouteController : Controller
    {
        //Route/Method1?age=12&name=ahmed
        //r1?age=12&name=ahmed
        //r1/{name}/{age}
        [HttpGet("r1/{age}/{name?}")]
        //[Route("r/{age:int}/{name?}",Name ="r1")]//only route
        public IActionResult Method1(int age,string name,int id)
        {
            return Content("M1");
        }
        //Route/Method2
        //r2
        public IActionResult Method2()
        {
            return Content("M2");
        }
    }
}
