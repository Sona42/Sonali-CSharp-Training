using Inventory_Manager.Model;

namespace Inventory_Manager.Controller
{
    /// <summary>
    /// Maintains a list of products
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private List<Product> _productList;

        /// <summary>
        /// constructor of product repository
        /// </summary>
        public ProductRepository()
        {
            _productList = new List<Product>();
        }

        /// <summary>
        /// Gives out the list of products
        /// </summary>
        /// <returns> returns list of objects</returns>
        public List<Product> GetAllProducts()
        {
            return _productList;
        }       

        /// <summary>
        /// Adds a new product to the list
        /// </summary>
        public void AddProduct(Product newProduct)
        {
            _productList.Add(newProduct);
        }

        /// <summary>
        /// Deletes a product from the list
        /// </summary>
        public bool DeleteProduct(string productName)
        {
            bool isDeleted = false;
            foreach (Product item in _productList)
            {
                if (productName == item.Name)
                {
                    _productList.Remove(item);
                    isDeleted = true;
                    break;
                }
            }

            return isDeleted;
        }

        /// <summary>
        /// Searches for a particular product in the list
        /// </summary>
        public Product? SearchProduct(string userInput)
        {
            foreach (Product product in _productList)
            {
                if (product.Id.ToString().Equals(userInput) || product.Name.Equals(userInput))
                { 
                    return product; 
                }
            }

            return null;
        }

        /// <summary>
        /// Checks whether the new product name is unique
        /// </summary>
        public bool IsNameUnique(string name)
        {
            Product? product = _productList.Find(p=>p.Name== name);
            return product == null;
        }

        /// <summary>
        /// Checks whether the new Id is unique
        /// </summary>
        public bool IsIdUnique(int id)
        {
            Product? product = _productList.Find(p => p.Id == id);
            return product == null;
        }
    }
}

