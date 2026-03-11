using COREWebAPI.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace COREWebAPI.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly IConfiguration _config;
        public ProductRepository(IConfiguration config)
        {
            _config = config;
        }
        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public IEnumerable<Product> GetProducts()
        {
            var parameters = new { Type="Get"};
            using var db = Connection;
            return db.Query<Product>("sp_Products",parameters, commandType: CommandType.StoredProcedure);
        }

        public void Add(Product product)
        {
            var parameters = new { Type = "Insert", product.Name, product.Price };
            using var db = Connection;

            db.Execute("sp_Products",parameters,commandType: CommandType.StoredProcedure );
        }

        public void Update(Product product,int id)
        {
            var parameters = new { Type = "Update", Id = id, product.Name, product.Price };
            using var db = Connection;

            db.Execute("sp_Products",parameters,commandType: CommandType.StoredProcedure);
        }
        public void Delete(int id)
        {
            var parameters = new { Type = "Delete",Id=id };
            using var db = Connection;

            db.Execute("sp_Products",parameters,commandType: CommandType.StoredProcedure);
        }
    }
}
