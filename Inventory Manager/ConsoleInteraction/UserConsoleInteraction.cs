using Inventory_Manager.Model;

namespace Inventory_Manager.ConsoleInteraction;

public class UserConsoleInteraction : IUserInteraction
{
    /// <summary>
    /// Displays the available options to be performed with inventory manager
    /// </summary>
    public string DisplayOptions()
    {
        string ?selectedOption;

        do
        {
            Console.WriteLine("\nChoose the option to perform \n 1.Add a product \n 2.Edit an existing product \n 3.View the list of all products \n 4. Delete product \n 5. Search product\n 6. Exit the application");
            selectedOption = Console.ReadLine();

            if (string.IsNullOrEmpty(selectedOption))
                Console.WriteLine("\n***Input cannot be empty***\n");

        } while (string.IsNullOrEmpty(selectedOption));
        
        return selectedOption;
    }

    /// <summary>
    /// Gets a valid input string from the user
    /// </summary>
    public string GetInputString(string message)
    {
        string ?inputString;

        do
        {
            Console.Write($"Enter {message} :");
            inputString = Console.ReadLine();

            if (inputString == "" || inputString is null)
            {
                Console.WriteLine("**** Input should not be null ****");
            }

        } while (inputString == "" || inputString is null);

        return inputString;
    }

    /// <summary>
    /// Displays the details of all available products in the inventory
    /// </summary>
    public void DisplayingAvailableProducts(List<Product> input)
    {
        if (input is not null && input.Count != 0)
        {
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }
        else
            Console.WriteLine("\nNo products available in inventory\n");    
    }

    /// <summary>
    /// Displays the detail of a required product
    /// </summary>
    public void DisplayProductDetail(Product? product)
    {
        if(product is not null)
        {
            Console.WriteLine(product);
        }
        else
        {
            Console.WriteLine("Product Not Found!");
        }
    }

    /// <summary>
    /// Displays the options that can be edited for a particular product
    /// </summary>
    public void DisplayEditMenuOptions()
    {
        Console.WriteLine("1.Name\n2.Id\n3.Price\n4.Quantity");
    }

    /// <summary>
    /// Gets a valid input integer from the user
    /// </summary>
    public int GetInputInt(string message)
    {
        int inputInt;
        bool isValidInt;

        do
        {
            isValidInt= int.TryParse(GetInputString(message), out inputInt);
            if (!isValidInt)
                Console.WriteLine("***Input should be Number***");
        } while (!isValidInt);

        return inputInt;
    }

    /// <summary>
    /// Displays a string message to the user
    /// </summary>
    public void DisplayStatusMessage(string message)
    {
        Console.WriteLine($"\n***{message}***");
    }
}