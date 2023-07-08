using System;

namespace NetLs_Fedoriv
{  /// <summary>
   /// Custom exception class for handling wrong input.
   /// </summary>
    public class WrongInputException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrongInputException"/> class with a default error message.
        /// </summary>
        public WrongInputException()
        {
            Console.WriteLine("Input exception occurred");
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WrongInputException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public WrongInputException(string message) : base(message)
        {
            Console.WriteLine($"Sorry but: {message} :(");
        }

    }
}
