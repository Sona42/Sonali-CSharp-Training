
using System.ComponentModel.Design;
using System.Data;
using System.Net;
using System.Threading.Tasks.Dataflow;

List<string> todoList = new List<string>();
string newTodo;
int index;
string getIndex;

GetUserSelection();
/// <summary>
/// This is a TODO manager application.
/// Gets the user selected option that needs to be applied to the TODOs available
/// </summary>
void GetUserSelection()
{
    System.Console.WriteLine("Hello!\nWhat do you want to do?\n[S]ee all TODOs\n[A]dd a TODO\n[R]emove a TODO\n[E]xit");
    string userInput = Console.ReadLine();
    CheckUserSelection(userInput);
}

/// <summary>
/// Handles addition, deletion and listing of TODOs based on the option selected by the user
/// The user can keep selecting different options until the option “[E] xit” is selected, which will close the application.
/// </summary>

void CheckUserSelection(string userSelection)
{
    
    switch(userSelection)
    {
        // lists the available TODOs to the user
        case "S":
        case "s":
            ListTodos();
            GetUserSelection();
            break;
        // Adds an item to the TODO list
        case "a":
        case "A":
            EnterDescription();
            GetUserSelection();
            break;
        // Removes an item from a TODO list
        case "r":
        case "R":  
            GetInputIndex();
            break;

        // Close the application
        case "e":
        case "E":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Incorrect input");
            GetUserSelection();
            break;  

    }
}

Console.ReadKey();

/// <summary>
/// The below method list the available ToDos to the user
/// </summary>

void ListTodos()
{
    if (todoList.Count() == 0)
    {
        System.Console.WriteLine("No TODOs have been added yet.");

    }
    else
    {
        for (int i = 1; i <= todoList.Count(); i++)
        {
            System.Console.WriteLine(i + "." + todoList[i - 1]);
        }
    }
}

/// <summary>
///  Get input index from user for an item to be removed from the TODO list
/// </summary>
void GetInputIndex()
{
    if (todoList.Count() == 0)
    {
        Console.WriteLine("No TODOs have been added yet");
        GetUserSelection();
    }
    else
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");
        ListTodos();
        getIndex = Console.ReadLine();
        if (int.TryParse(getIndex, out int num))
        {
            index = num;
        }
        else
        {
            index = 0;
        }
        CheckInputIndex();
    }
}

/// <summary>
/// Validates the Index provided by the user from which the item in TODO list need to be removed
/// </summary>

void CheckInputIndex()
{
    if (index == 0)
    {
        if (string.IsNullOrEmpty(getIndex))
        {
            Console.WriteLine("Selected index cannot be empty");
        }
        else
        {
            Console.WriteLine("The given index is not valid");
        }

        GetInputIndex();
    }
    else if ((index > todoList.Count()) || (index <= 0))
    {
        Console.WriteLine("The given index is not valid");
        GetInputIndex();
    }
    else
    {
        Console.WriteLine("TODO removed:" + todoList[index - 1]);
        todoList.RemoveAt(index - 1);
        GetUserSelection();
    }
}

/// <summary>
/// Validates the description provided by the user that needs to be added to the TODO list
/// </summary>

void ValidateDescription()
{
    if (todoList.Contains(newTodo))
    {

        Console.WriteLine("The description must be unique");
        EnterDescription();
    }

    else if (string.IsNullOrEmpty(newTodo))
    {
        Console.WriteLine("The description cannot be empty");
        EnterDescription();

    }
    else
    {
        todoList.Add(newTodo);
        Console.WriteLine("TODO successfully added:" + newTodo);
    }
}

/// <summary>
/// Gets the description of the new TODO to be added
/// </summary>


void EnterDescription()
{
    System.Console.WriteLine("Enter the TODO description");
    newTodo = Console.ReadLine();
    ValidateDescription();
}