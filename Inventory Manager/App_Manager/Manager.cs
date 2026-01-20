using Inventory_Manager.Controller;
using Inventory_Manager.Model;
using Inventory_Manager.ConsoleInteraction;

namespace Inventory_Manager.App_Manager
{
    /// <summary>
    /// Defines the application workflow
    /// </summary>
    public class Manager
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserInteraction _userConsoleInteraction;

        bool isExit = false;
        bool isUnique;

        public Manager(IUserInteraction userConsoleInteraction, IProductRepository productRepository)
        {
            _userConsoleInteraction = userConsoleInteraction;
            _productRepository = productRepository;
        }
        
        /// <summary>
        /// starts the main workflow
        /// </summary>
        public void Run()
        {
            while (!isExit)
            {
                GetUserOption();
            }
        }

        /// <summary>
        /// Initializes the work flow for an inventory manager application
        /// </summary>
        public void GetUserOption()
        {
            string userSelectedOption = _userConsoleInteraction.DisplayOptions();

            switch(userSelectedOption)
            {
                case "1":
                    AddNewProduct();
                    break;
                case "2":
                    EditExistingProduct();
                    break;
                case "3":
                    ListAvailableProducts();
                    break;
                case "4":
                    DeleteProduct();
                    break;
                case "5":
                    Product? product = SearchProducts();
                    _userConsoleInteraction.DisplayProductDetail(product);
                    break;
                case "6":
                    isExit = true;
                    break;
                default:
                    _userConsoleInteraction.DisplayStatusMessage("Invalid Option Selected");
                    break;
            }
        }

        /// <summary>
        /// Defines the workflow for adding a new product to the inventory
        /// </summary>
        public void AddNewProduct()
        {
            int id = GetUniqueId();
            string name = GetUniqueName();
            int price = _userConsoleInteraction.GetInputInt("Price");
            int quantity = _userConsoleInteraction.GetInputInt("Quantity");

            Product newProduct= new Product(id, name, price, quantity);

            _productRepository.AddProduct(newProduct);
            _userConsoleInteraction.DisplayStatusMessage("Product added successfully");
        }

        /// <summary>
        /// Defines the workflow for listing all the available products from inventory
        /// </summary>
        public void ListAvailableProducts()
        {
            _userConsoleInteraction.DisplayingAvailableProducts(_productRepository.GetAllProducts());
        }

        /// <summary>
        /// Defines the workflow for deleting a product from inventory
        /// </summary>
        public void DeleteProduct()
        {
            Product? productToDelete = SearchProducts();
            bool isRemoved = _productRepository.DeleteProduct(productToDelete!.Name);

            if (!isRemoved)
                _userConsoleInteraction.DisplayStatusMessage("Invalid product name! No product is deleted");
            else
                _userConsoleInteraction.DisplayStatusMessage("Product deleted successfully");
        }

        /// <summary>
        /// Defines the workflow for editing an existing product from inventory
        /// </summary>
        public void EditExistingProduct()
        {
            
            Product? product = SearchProducts();

            _userConsoleInteraction.DisplayProductDetail(product);
            _userConsoleInteraction.DisplayEditMenuOptions();

            string userEditOption = _userConsoleInteraction.GetInputString("the option to edit");

            switch(userEditOption)
            {
                case "1":               
                    product!.Name = GetUniqueName();
                    _userConsoleInteraction.DisplayStatusMessage("Name updated successfully");
                    break;

                case "2":                  
                    product!.Id = GetUniqueId();
                    _userConsoleInteraction.DisplayStatusMessage("Id updated successfully");
                    break;
                case "3":
                    product!.Price = _userConsoleInteraction.GetInputInt("new price");
                    _userConsoleInteraction.DisplayStatusMessage("Price updated successfully");
                    break;
                case "4":
                    product!.QuantityInStock = _userConsoleInteraction.GetInputInt("quantity to be updated");
                    break;
            }   
        }

        /// <summary>
        /// Defines a workflow for searching a product from inventory
        /// </summary>
        public Product? SearchProducts()
        {
            if(_productRepository.GetAllProducts().Count==0)
            {
                return null;
            }
            string userInput = _userConsoleInteraction.GetInputString("product name or Id");
            return _productRepository.SearchProduct(userInput);
        }

        /// <summary>
        /// This method defines a workflow for getting an unique input name from user
        /// </summary>
        private string GetUniqueName()
        {
            string uniqueName;

            do
            {
                uniqueName = _userConsoleInteraction.GetInputString("Name");
                isUnique=_productRepository.IsNameUnique(uniqueName);

                if (!isUnique)
                    _userConsoleInteraction.DisplayStatusMessage("***Name already exists***");

            } while (!isUnique);

            return uniqueName;
        }

        /// <summary>
        /// This method defines a workflow for getting an unique input Id from user
        /// </summary>
        private int GetUniqueId()
        {
            int uniqueId;
            do
            {
                uniqueId = _userConsoleInteraction.GetInputInt("Id");
                isUnique = _productRepository.IsIdUnique(uniqueId);

                if (!isUnique)
                    _userConsoleInteraction.DisplayStatusMessage("***Id already exists***");

            } while (!isUnique);

            return uniqueId;
        }    
    }
}