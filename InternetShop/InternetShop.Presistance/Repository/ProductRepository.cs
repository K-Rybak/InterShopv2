using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Presistance.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProducRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public Product GetProductById(int id)
        {
            var product = _appDbContext.Products
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _appDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ApplicationType);

            return products;
        }
    }
}
