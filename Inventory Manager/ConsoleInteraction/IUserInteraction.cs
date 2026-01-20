using Inventory_Manager.Model;

namespace Inventory_Manager.ConsoleInteraction
{
    public interface IUserInteraction
    {
        string GetInputString(string displayMessage);
        int GetInputInt(string message);
        string DisplayOptions();
        void DisplayingAvailableProducts(List<Product> input);
        void DisplayProductDetail(Product? product);
        void DisplayEditMenuOptions();
        void DisplayStatusMessage(string message);
    }
}