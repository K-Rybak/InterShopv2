using InternetShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternetShop.Web.Services
{
    public class ProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IApplicationTypeRepository _typeRepository;
        public ProductService(
            ICategoryRepository categoryRepository,
            IApplicationTypeRepository typeRepository)
        {
            _categoryRepository = categoryRepository;
            _typeRepository = typeRepository;
        }

        public List<SelectListItem> GetCategoryList()
        {
            var categories = _categoryRepository.GetAll();

            var dropdown = categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            })
                .ToList();

            return dropdown;
        } 

        public List<SelectListItem> GetApplicationType() 
        {
            var types = _typeRepository.GetAll();

            var dropdown = types.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            })
                .ToList();

            return dropdown;
        }
    }
}
