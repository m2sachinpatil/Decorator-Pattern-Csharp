using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Assignment1.Helper
{
    /// <summary>
    /// OutputWrapper.
    /// </summary>
    /// <typeparam name="T">type of OutputObject. </typeparam>
   public class OutputWrapper<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputWrapper{T}"/> class.
        /// OutputWrapper.
        /// </summary>
        public OutputWrapper() => this.Errors = new List<ErrorContainer<T>>();

        /// <summary>
        /// Gets or sets OutputObject.
        /// </summary>
        public List<T> OutputObject { get; set; }

        /// <summary>
        /// Gets or sets Errors.
        /// </summary>
        public List<ErrorContainer<T>> Errors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Failure.
        /// </summary>
        public bool Failure { get; set; }

        /// <summary>
        /// AddError.
        /// </summary>
        /// <param name="errorObject">errorObject.</param>
        /// <param name="errorId">errorId.</param>
        /// <param name="errorMessage">errorMessage.</param>
        public void AddError(T errorObject, int errorId, object errorMessage)
        {
            this.Errors.Add(new ErrorContainer<T>
            {
                ErrorMessage = errorMessage,
                ErrorId = errorId,
                ErrorObject = errorObject
            });
        }
    }
}
