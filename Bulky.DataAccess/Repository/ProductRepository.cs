using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsWithCategories()
        {
            var products = _context.Products.Include(p => p.Category).ToList();

            return products;
        }

        public void Update(Product product)
        {
            _context.SaveChanges();
        }
    }
}
