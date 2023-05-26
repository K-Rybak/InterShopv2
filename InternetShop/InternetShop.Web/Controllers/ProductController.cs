using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entities;
using InternetShop.Web.Models;
using InternetShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;

namespace InternetShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProducRepository _producRepository;
        private readonly ImageService _imageService;
        private readonly ProductService _productService;
        public ProductController(
            IProducRepository producRepository,
            ImageService imageService,
            ProductService productService)
        {
            _producRepository = producRepository;
            _imageService = imageService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var entity = _producRepository.GetProducts();
            var products = entity.Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category,
                ApplicationType = p.ApplicationType,
            })
            .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var products = new ProductVM
            {
                CategoryDropDown = _productService.GetCategoryList(),
                TypeDropDown = _productService.GetApplicationType()
            };

            return View(products);
        }

        [HttpPost]
        public IActionResult Create(ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                product.CategoryDropDown = _productService.GetCategoryList();
                product.TypeDropDown = _productService.GetApplicationType();
                return View(product);
            }

            var files = HttpContext.Request.Form.Files;
            product.Image = _imageService.ImageLoad(files);

            var entity = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Image = product.Image,
                CategoryId = product.CategoryId,
                ApplicationTypeId = product.ApplicationTypeId,
            };

            _producRepository.Add(entity);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _producRepository.GetById(id);

            var product = new ProductVM
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Image = _imageService.imagePath + entity.Image,
                CategoryId = entity.CategoryId,
                CategoryDropDown = _productService.GetCategoryList(),
                TypeDropDown = _productService.GetApplicationType(),
            };

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var currentProduct = _producRepository
                .GetProductById(product.Id);
            _imageService.DeleteImage(currentProduct.Image);

            var files = HttpContext.Request.Form.Files;

            var entity = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = _imageService.ImageLoad(files),
                CategoryId = product.CategoryId,
                ApplicationTypeId = product.ApplicationTypeId,
            };

            _producRepository.Update(entity);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            string imageName = _producRepository
                .GetProductById(id)
                .Image;

            _imageService.DeleteImage(imageName);

            var category = _producRepository.GetById(id);

            _producRepository.Remove(category);

            return RedirectToAction("Index");
        }
    }
}
