namespace Program
{
    public class Program
    {
        /// <summary>
        ///  This launches a simple calculator application
        ///  Can perform operation such as addition,subtraction and multiplication
        /// </summary>
        public static void Main(string[] args)
        {
            var calculator = new Calculator();
            var (operand1, operand2, operation) = calculator.ConsoleInteraction();
            calculator.PerformArithmeticOperation(operand1, operand2, operation);
            calculator.ExitApp();
        }
    }
}