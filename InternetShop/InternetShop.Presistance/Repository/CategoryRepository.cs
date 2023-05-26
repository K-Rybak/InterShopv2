using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entities;

namespace InternetShop.Presistance.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
