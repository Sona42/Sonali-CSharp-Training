namespace Program
{
    public class Calculator
    {
        /// <summary>
        /// This is a simple calculator application
        /// This method gets the input operand and the operation to perform from user
        /// </summary>
        public (decimal input1, decimal input2, string optionSelected) ConsoleInteraction()
        {
            Console.WriteLine("Hello!\nInput the first number:");
            decimal operand1 = ValidateInputNumber(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Input the second number:");
            decimal operand2 = ValidateInputNumber(Console.ReadLine() ?? string.Empty);

            string operation;

            while (true)
            {
                Console.WriteLine("What do you want to do with those numbers?\n[A]dd\n[S]ubtract\n[M]ultiply\n[E]xit");
                operation = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

                if (operation == "a" || operation == "s" || operation == "m" || operation == "e")
                {
                    break; // valid choice
                }

                Console.WriteLine("Invalid option");
            }

            return (operand1, operand2, operation);
        }

        /// <summary>
        /// Performs the arithmetic operation based on the user input
        /// </summary>
        public void PerformArithmeticOperation(decimal input1, decimal input2, string operation)
        {
            //Do calculation based on the option selected
            switch (operation.ToLower())
            {
                case "a":
                    Console.WriteLine($"{input1}+{input2}={input1 + input2}");
                    break;
                case "s":
                    Console.WriteLine($"{input1}-{input2}={input1 - input2}");
                    break;
                case "m":
                    Console.WriteLine($"{input1}*{input2}={input1 * input2}");
                    break;
                case "e":
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

        /// <summary>
        /// Validates the input decimal number
        /// </summary>
        public decimal ValidateInputNumber(string input)
        {
            decimal number;

            while (!decimal.TryParse(input, out number))
            {
                Console.WriteLine("Invalid Input. Re-enter a valid integer");
                input = Console.ReadLine();
            }

            return number;
        }

        /// <summary>
        /// Exits the application if any key is pressed
        /// </summary>
        public void ExitApp()
        {
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}