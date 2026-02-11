using System;

namespace Day7
{
    public class ExceptionDemo
    {
        public static void Run()
        {
            try
            {
                First();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                Console.WriteLine($"Inner Exception: {ex.InnerException}");
            }
            finally
            {
                Console.WriteLine("finally.");
            }

            Console.WriteLine("Program continues after handling the exception.");
        }

        private static void First()
        {
            Second();
        }

        private static void Second()
        {
            try
            {
                Third();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception From Third: {ex.Message}");
                throw new Exception("My Exception here", ex);
            }
        }

        private static void Third()
        {
            var numerator = 10;
            var denominator = 0;

            var result = numerator / denominator;
        }
    }

    public class BankException : ApplicationException
    {
        public BankException(string message) : base(message) { }

        public BankException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class NotEnoughBalanceException : BankException
    {
        public NotEnoughBalanceException(string message) : base(message) { }

        public NotEnoughBalanceException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
