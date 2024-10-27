using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class CalculationException : Exception
    {
        private const string DefaultMessage = "An error occurred during calculation. Ensure that the operator is supported and that the values are within the valid ranges for the requested operation.";

        /// <summary>
        /// Creates a new <see cref="CalculationException"/> with a predefined message.
        /// </summary>
        public CalculationException() : base(DefaultMessage) { }

        /// <summary>
        /// Creates a new <see cref="CalculationException"/> with a user-supplied message.
        /// </summary>
        public CalculationException(string message) : base(message) { }

        /// <summary>
        /// Creates a new <see cref="CalculationException"/> with 
        /// a predefined message and a wrapped inner exception.
        /// </summary>
        public CalculationException(Exception innerException) :
            base(DefaultMessage, innerException)
        { }

        /// <summary>
        /// Creates a new <see cref="CalculationException"/> with a user-supplied message 
		/// and a wrapped inner exception.
        /// </summary>
        public CalculationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
