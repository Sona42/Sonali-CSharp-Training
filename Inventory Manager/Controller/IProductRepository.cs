using Inventory_Manager.Model;

namespace Inventory_Manager.Controller
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        void AddProduct(Product newProduct);
        bool DeleteProduct(string productName);
        Product? SearchProduct(string userInput);
        bool IsNameUnique(string name);
        bool IsIdUnique(int id);
    }
}