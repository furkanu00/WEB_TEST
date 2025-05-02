using WEB_TEST.Models;

namespace WEB_TEST.Services
{
    public class PService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Kalem", Price = 10 },
            new Product { Id = 2, Name = "Defter", Price = 20 },
            new Product { Id = 3, Name = "Silgi", Price = 5 },
            new Product { Id = 4, Name = "Cetvel", Price = 8 },
            new Product { Id = 5, Name = "Makas", Price = 15 },
            new Product { Id = 6, Name = "Yapıştırıcı", Price = 12 },
            new Product { Id = 7, Name = "Dosya", Price = 7 },
            new Product { Id = 8, Name = "Kalemtraş", Price = 6 },
            new Product { Id = 9, Name = "Pergel", Price = 18 },
            new Product { Id = 10, Name = "Boyama Kalemi", Price = 25 }
        };
        public List<Product> GetAll() => _products;

        public Product? GetById(int id) =>
            _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product) =>
            _products.Add(product);

        public bool Update(int id, Product updated)
        {
            var product = GetById(id);
            if (product is null) return false;

            product.Name = updated.Name;
            product.Price = updated.Price;
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product is null) return false;

            _products.Remove(product);
            return true;
        }
    }
}
