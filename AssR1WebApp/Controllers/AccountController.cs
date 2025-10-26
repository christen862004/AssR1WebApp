using AssR1WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AssR1WebApp.Controllers
{
    public class AccountController : Controller //primary constructor
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager) //not register service
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #region register
        //Get :/Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//hacking
        public async Task<IActionResult> Register(RegisterViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                //Mapp vm to moel "automapper'
                ApplicationUser userModel = new ApplicationUser() { 
                    UserName=userFromReq.UserName,
                    PasswordHash=userFromReq.Password,
                    Address=userFromReq.Address
                };
                //save db
                IdentityResult result=
                    await userManager.CreateAsync(userModel,userFromReq.Password);
                if(result.Succeeded)
                {
                    //add user to role addmin

                    await userManager.AddToRoleAsync(userModel, "Admin");
                    //create cookie(id,username,email (if foun),Role (if foun)
                    await signInManager.SignInAsync(userModel,false);//next time login
                    return RedirectToAction("Index", "Department");
                }
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }

            }
            return View("Register",userFromReq);
        }

        #endregion

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel  userfromReq)
        {
            if (ModelState.IsValid)
            {
                //check
                ApplicationUser userFRomDb=
                    await userManager.FindByNameAsync(userfromReq.UserName);
                if (userFRomDb !=null)
                {
                    //check passsor 
                    bool found = await userManager.CheckPasswordAsync(userFRomDb, userfromReq.Password);
                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address",userFRomDb.Address));

                        //create cookie idd,username [email | role]
                        await signInManager
                            .SignInWithClaimsAsync(userFRomDb, userfromReq.RememberMe,claims);
                        //redie
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login",userfromReq);
        }
    
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
