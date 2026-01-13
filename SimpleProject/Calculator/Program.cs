namespace Program
{
    public class Program
    {
        /// <summary>
        ///  This runs a simple calculator application
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