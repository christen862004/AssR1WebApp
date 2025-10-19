using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
    public class StateController : Controller
    {

        //public IActionResult Home()
        //{
        //    if (Request.Cookies["loged"] == null)
        //    {
        //        return RedirectToAction("login");
        //    }
        //}

        public StateController()
        {
            
        }
        //string Name=null;
        public IActionResult SetSession(string name,int age)
        {
            //  logic
            //  Store Info
            //Serialize to josn
           // HttpContext.Session.SetString("Name","{name:hamed'}");
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("Session Save");
        }
        //read at any controller
        public IActionResult GetSession()
        {
            string name= HttpContext.Session.GetString("Name");
            int? age= HttpContext.Session.GetInt32("Age");

            return Content($"name={name}\t age={age}");
        }

        public IActionResult SetCookie(string name,int age)
        {
            //Session Cookie
            HttpContext.Response.Cookies.Append("Name", name);


            //Preisitent Cookie
            CookieOptions options=new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);
            HttpContext.Response.Cookies.Append("Age", age.ToString(),options);

            return Content("Cookie Save");
        }
        //Get Cookie at any Contooler
        public IActionResult GetCookie()
        {
            string n = HttpContext.Request.Cookies["Name"];
            string a = HttpContext.Request.Cookies["Age"];
            return Content($"Name={n}\tAge={a}");
        }
    }
}
