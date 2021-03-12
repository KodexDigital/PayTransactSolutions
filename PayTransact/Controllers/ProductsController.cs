using Microsoft.AspNetCore.Mvc;
using PayTransact.Models.ViewModels;
using PayTransact.Persistence.Data.Repositories.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayTransact.Models.Models;

namespace PayTransact.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ProductsController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public IActionResult Index() => View(uow.ProductRepository.GetAll());

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Error found!");
                return View(model);
            }
           
            var product = mapper.Map<Product>(model);
            uow.ProductRepository.Add(product);
            await uow.SaveAsync();
            ViewBag.Success = "New product creates successfully";
            ModelState.Clear();
            return View();
        }
    }
}
