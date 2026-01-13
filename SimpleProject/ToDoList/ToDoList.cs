namespace ToDoListManager
{
    public class ToDoList
    {
        private List<string> Items {get; set; } = new List<string>();

        /// <summary>
        /// This is a ToDo List managing application
        /// This method manages the execution flow based on option selected by user
        /// </summary>
        public void AppRun()
        {            
            bool shallExit = false;
            while (!shallExit)
            {
                string userSelection = GetUserSelection();
                switch (userSelection)
                {
                    // Display all available ToDos
                    case "S":
                    case "s":
                        ListToDos(Items);
                        break;
                    // Adds an item to the TODO list
                    case "a":
                    case "A":
                        AddToDo(Items);
                        break;
                    // Removes an item from a TODO list
                    case "r":
                    case "R":
                        RemoveToDo(Items);
                        break;

                    // Close the application
                    case "e":
                    case "E":
                        shallExit = true;
                        break;

                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            }
        }

        /// <summary>
        /// Gets the selected option from user
        /// </summary>
        public string GetUserSelection()
        {
            Console.WriteLine("Hello!\nWhat do you want to do?\n[S]ee all TODOs\n[A]dd a TODO\n[R]emove a TODO\n[E]xit");
            string userInput = Console.ReadLine() ?? string.Empty;

            return userInput;
        }

        /// <summary>
        /// Lists the available ToDos
        /// </summary>
        public void ListToDos(List<string> inputList)
        {
            if (inputList.Count() == 0)
            {
                Console.WriteLine("No TODOs have been added yet.");
            }
            else
            {
                for (int i = 1; i <= inputList.Count(); i++)
                {
                    Console.WriteLine($"{i}. {inputList[i - 1]}");
                }
            }
        }

        /// <summary>
        /// Adds a new description to a ToDo List
        /// </summary>
        public void AddToDo(List<string> todoList)
        {
            string? newTodo;
            Console.WriteLine("Enter the TODO description");
            newTodo = Console.ReadLine();

            if (todoList.Contains(newTodo!))
            {
                Console.WriteLine("The description must be unique");
            }
            else if (string.IsNullOrEmpty(newTodo))
            {
                Console.WriteLine("The description cannot be empty");
            }
            else
            {
                todoList.Add(newTodo);
                Console.WriteLine($"TODO successfully added: {newTodo}");
            }
        }

        /// <summary>
        ///  Removes a description from ToDo List
        /// </summary>
        public void RemoveToDo(List<string> inputList)
        {
            if (inputList.Count() == 0)
            {
                Console.WriteLine("No TODOs have been added yet");
                return;
            }
            else
            {        
                bool isValidIndex = false;
                while (!isValidIndex)
                {
                    Console.WriteLine("Select the index of the TODO you want to remove:");

                    ListToDos(inputList);

                    string getIndex = Console.ReadLine();

                    if (string.IsNullOrEmpty(getIndex))
                    {
                        Console.WriteLine("Selected index cannot be empty");
                    }
                    else if (int.TryParse(getIndex, out int index) && index >= 1 && index <= inputList.Count)
                    {
                                
                        Console.WriteLine($"TODO removed: {inputList[index - 1]}");
                        inputList.RemoveAt(index - 1);
                        isValidIndex = true;
                    }
                    else
                    {
                        Console.WriteLine("The given index is not valid");
                    }
                }
            }
        }
    }
}
