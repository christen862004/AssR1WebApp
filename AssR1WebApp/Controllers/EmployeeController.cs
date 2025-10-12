using AssR1WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public EmployeeController()
        {
            
        }

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
            string Msg = "Hi";
            int Temp = 30;
            List<string> brches= new List<string>() { "Alex","New Capital" ,"Assiut" ,"Mansoura" ,"Smart"};
            string Color = "red";

            //set Data  to ViewData To Send To View 
            ViewData["Msg"] = Msg;
            ViewData["Temp"] = Temp;
            ViewData["Brch"] = brches;
            ViewData["Clr"] = Color;
            ViewBag.Address = "Assiut";//ViewData["Address"]="Assiut"



            Employee EmpModel=
                context.Employees.FirstOrDefault(e=>e.Id== id);
            if (EmpModel==null)
            {
                return NotFound();
            }
            return View("Details", EmpModel);//Model ==>Employee
        }



        public IActionResult DetailsVM(int id)
        {
            //Collected data (Source)
            string Msg = "Hi";
            int Temp = 30;
            List<string> brches = new List<string>() { "Alex", "New Capital", "Assiut", "Mansoura", "Smart" };
            string Color = "red";
            Employee EmpModel =
                context.Employees.FirstOrDefault(e => e.Id == id);
            // DEclare ViewModel (Destination)
            EmployeeNameWithTempMsgClrBranchViewModel EmpVM = new();


            // mapping from source ==>destination(VM) (automapper)
            EmpVM.EmpId = EmpModel.Id;
            EmpVM.EmpName = EmpModel.Name;
            EmpVM.Temp = Temp;
            EmpVM.Color = Color;
            EmpVM.Branches = brches;
            EmpVM.Message = Msg;

            //return view with  Viewmodel
            return View("DetailsVM",EmpVM);
        }
    }
}












