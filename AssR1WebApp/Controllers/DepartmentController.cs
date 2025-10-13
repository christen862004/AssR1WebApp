using AssR1WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult Index()
        {
            List<Department> DeptList = context.Departments.ToList();
            return View("Index",DeptList);
        }

        #region NEw
        public IActionResult New()
        {
            return View("New");
        }
        //Department/SaveNew?Name=as&ManagerName=ahmed-->
        //public IActionResult SaveNew(string Name,string ManagerName)
        [HttpPost]
        public IActionResult SaveNew(Department deptFromReq)
        {
            //Post Only
            //if (Request.Method == "POST") { }
            if(deptFromReq.Name != null) {
                //save
                context.Departments.Add(deptFromReq);
                context.SaveChanges();


                return RedirectToAction("Index", "Department");
            }
            return View("New",deptFromReq);//View ="New" ,Model =Department
        }
        #endregion
        //Department/MEthod1
        [HttpGet]
        public IActionResult MEthod1()
        {
            return Content("M1Get");
        }
        [HttpPost]
        public IActionResult MEthod1(int id)
        {
            return Content("M1post ");
        }


    }
}
