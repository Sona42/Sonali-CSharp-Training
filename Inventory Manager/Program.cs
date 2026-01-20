using Inventory_Manager.App_Manager;
using Inventory_Manager.ConsoleInteraction;
using Inventory_Manager.Controller;

namespace Inventory_Manager
{
    /// <summary>
    /// Main program which launches the inventory manager application
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var consoleInteraction = new UserConsoleInteraction();
            var productRepository = new ProductRepository();

            Manager inventoryManagerApp = new Manager(consoleInteraction, productRepository);
        
            inventoryManagerApp.Run();
        }
    }
}