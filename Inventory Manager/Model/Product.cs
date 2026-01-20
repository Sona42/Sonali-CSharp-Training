namespace Inventory_Manager.Model
{
    /// <summary>
    /// stores product information
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int QuantityInStock { get; set; }

        /// <summary>
        /// Initializes the product values
        /// </summary>
        /// <param name="id"> Id </param>
        /// <param name="name"> Name </param>
        /// <param name="price"> Price </param>
        /// <param name="quantity"> Quantity </param>
        public Product(int id, string name, int price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            QuantityInStock = quantity;
        }

        /// <summary>
        /// Gives product information
        /// </summary>
        /// <returns>returns string</returns>
        public override string ToString() 
        {
            return $"ID: {Id}\tName: {Name}\tPrice: {Price}\tQuantity: {QuantityInStock}";
        }
    }
}