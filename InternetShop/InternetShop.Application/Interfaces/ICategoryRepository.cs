using InternetShop.Domain.Entities;

namespace InternetShop.Application.Interfaces
{
    public interface ICategoryRepository
    {
        public void Add(Category category);
    }
}
