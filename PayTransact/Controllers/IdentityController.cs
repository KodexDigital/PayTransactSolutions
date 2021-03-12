using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayTransact.Models.Models;
using PayTransact.Models.ViewModels;
using PayTransact.Persistence.Data.Repositories.Interfaces;
using PayTransact.Utilities.Globals;
using PayTransact.Utilities.Helpers;
using System.Threading.Tasks;

namespace PayTransact.Controllers
{
    [AllowAnonymous]
    public class IdentityController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityController(IUnitOfWork uow, IMapper mapper, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Error found!");
                return View(model);
            }

            var customerReg = mapper.Map<ApplicationUser>(model);
            var result = await userManager.CreateAsync(customerReg, model.Password);
            if (result.Succeeded)
            {
                //Assing User to customer role
                var identityRoleHelper = new IdentityRoleHelper(roleManager);
                await identityRoleHelper.CreateNewRoleAsync(StaticConstants.CustomerRole);
                await userManager.AddToRoleAsync(customerReg, StaticConstants.CustomerRole);

                Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if(signInResult.Succeeded)
                    return RedirectToAction("Transaction", "Customers");
            }

            return View();
        }

        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var appUser = await userManager.FindByEmailAsync(model.Username);
            if (!ModelState.IsValid)
                ModelState.AddModelError(string.Empty, "Error found while login in");

            if (appUser != null)
            {
                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, model.Password, false, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        return Redirect(model.ReturnUrl ?? "/");

                    if (User.IsInRole(StaticConstants.CustomerRole))
                        return RedirectToAction("Transaction", "Customers");
                    
                    if (User.IsInRole(StaticConstants.AdminRole))
                        return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Error = "Error encountered during login in!";
            }
            else
                ViewBag.Error = "User not found!";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
            if (returnUrl != null)
                return LocalRedirect(returnUrl);
            else
                return RedirectToAction("Login", "Identity");
        }

        public IActionResult AccessDenied() => View();
    }
}
