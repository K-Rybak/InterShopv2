using InternetShop.Domain.Entities;

namespace InternetShop.Application.Interfaces
{
    public interface IProducRepository : IGenericRepository<Product>
    {
        public IEnumerable<Product> GetProducts();

        public Product GetProductById(int id);
    }
}
