using COREWebAPI.Models;

namespace COREWebAPI.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void Add(Product product);
        void Update(Product product,int id);
        void Delete(int id);
    }
}
