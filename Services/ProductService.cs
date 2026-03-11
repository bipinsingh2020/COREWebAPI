using COREWebAPI.Models;
using COREWebAPI.Repositories;

namespace COREWebAPI.Services
{
    public class ProductService:IProductService 
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository productservice) 
        {
            _repo = productservice;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        public void Add(Product product)
        {
            _repo.Add(product);
        }

        public void Update(Product product,int id)
        {
            _repo.Update(product,id);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
