using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController(RoleManager<IdentityRole> roleManager) : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleFromReq)
        {
            if(ModelState.IsValid)
            {
                IdentityRole role=new IdentityRole() { 
                    Name=roleFromReq.RoleName
                };
                //create role
                IdentityResult result=await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return View("Create", roleFromReq);
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }
            }
            return View("Create",roleFromReq);
        }
    }
}
