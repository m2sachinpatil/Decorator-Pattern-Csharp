using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Assignment1.Helper
{
    /// <summary>
    /// ErrorContainer.
    /// </summary>
    /// <typeparam name="T">tyoe of error object.</typeparam>
    public class ErrorContainer<T>
    {
        /// <summary>
        /// Gets or sets ErrorObject.
        /// </summary>
        public T ErrorObject { get; set; }

        /// <summary>
        /// Gets or sets ErrorId.
        /// </summary>
        public int ErrorId { get; set; }

        /// <summary>
        /// Gets or sets ErrorMessage.
        /// </summary>
        public object ErrorMessage { get; set; }
    }
}
