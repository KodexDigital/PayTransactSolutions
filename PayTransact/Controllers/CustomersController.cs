using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PayTransact.Models.Models;
using PayTransact.Models.ViewModels;
using PayTransact.Persistence.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PayTransact.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public CustomersController(IUnitOfWork uow, IMapper mapper, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Invest()
        {
            var product = uow.ProductRepository.GetAll();
            ViewData["Products"] = new SelectList(product, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Invest(InvestViewModel model)
        {
            var user = await userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
                ModelState.AddModelError(string.Empty, "Error found while login in");

            var invest = mapper.Map<Investment>(model);
            invest.CustomerId = user.Id;
            uow.TransactionRepository.Add(invest);
            await uow.SaveAsync();

            var product = uow.ProductRepository.GetAll();
            ViewData["Products"] = new SelectList(product, "Id", "Name");

            ViewBag.Success = "Your investment has been recorded successful";
            ModelState.Clear();

            return View();
        }

        public IActionResult Transaction() => View(uow.TransactionRepository.GetAll());
        public IActionResult TransactionDetails(Guid Id) => View(uow.TransactionRepository.Get(Id));
        public async Task<IActionResult> Balance()
        {
            var user = await userManager.GetUserAsync(User);
            ViewData["TotalTransaction"] = uow.TransactionRepository.TotalTransaction(user.Id);
            return View();
        }
    }
}
