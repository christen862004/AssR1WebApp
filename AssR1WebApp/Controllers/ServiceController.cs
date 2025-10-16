using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService service;

        public ServiceController(IService _Service)//inject (Ask)
        {
            service = _Service;
        }
        //Service/index
        public IActionResult Index()
        {
            ViewData["Id"] = service.Id;
            return View();
        }
    }
}
