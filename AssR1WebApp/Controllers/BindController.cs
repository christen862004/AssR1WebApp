using AssR1WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
    public class BindController : Controller
    {
        /*
         <form method="get" action="/Bind/TestPrimitive">
            <input type=text name="name">
            <input type=number name="age">

         </form>
         
         */

        //Bind/TestPrimitive?name=sd&age=12&id=10
        //Bind/TestPrimitive/10?name=sd&age=12&color[1]=black&color[0]=red
        //Bind/TestPrimitive/10?name=sd&age=12&color=red&color=black
        public IActionResult TestPrimitive(int age ,string name,int id,string[] color)
        {
            return Content($"name={name}");
        }


        //Collection
        //Bind/TestDic?name=christen&phoneBook[Ahmed]=123&phoneBook[Mohamed]=456
        public IActionResult TestDic(Dictionary<string,string> phoneBook ,string name)
        {
            return Content($"name={name}");

        }


        //Custom Class
        //Bind/TestObj?id=1&name=sd&ManagerName=ahmed&Employees[0].name=1000
        public IActionResult TestObj(Department dept,string name)
       // public IActionResult TestObj
       // (int Id, string Name, string? ManagerName, List<Employee> Employees)
        {
            return Content("");
        }
    }
}
