using AssR1WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult Index()
        {
            List<Employee> EmpList = context.Employees.ToList();

            return View("Index",EmpList);//view "Index" , Model = type List<Employee>
            //return View("Index");//View Index ,Model =Null  REject
            //return View(); // Search View With the same action name "Index ,Model =null Reject
            //return View(EmpList);//View =>Index ,Model =List<Employee>
        }

        //Employee/DEtails/1
        //Employee/DEtails?id=1
        public IActionResult Details(int id)
        {
            Employee EmpModel=
                context.Employees.FirstOrDefault(e=>e.Id== id);
            if (EmpModel==null)
            {
                return NotFound();
            }
            return View("Details", EmpModel);
        }
    }
}
