using COREWebAPI.Models;

namespace COREWebAPI.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        void Add(Product product);
        void Update(Product product, int id);
        void Delete(int id);
    }
}
