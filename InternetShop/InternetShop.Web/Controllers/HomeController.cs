using InternetShop.Application.Interfaces;
using InternetShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InternetShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProducRepository _productRepository;
        private readonly IConfiguration _config;
        private readonly ICategoryRepository _categoryRepository;
        public HomeController(
            IProducRepository productRepository,
            IConfiguration config,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _config = config;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var entity = _productRepository.GetProducts();
            var categories = _categoryRepository.GetAll();
            var model = new HomeViewModel
            {
                Products = entity.Select(p => new ProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Category,
                    ApplicationType = p.ApplicationType,
                    Image = _config["ImagePath"] + p.Image
                }).ToList(),
                Categories = categories.Select(c => new CategoryViewModel 
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            };

            return View(model);
        }
    }
}