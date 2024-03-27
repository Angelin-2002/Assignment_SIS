using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Exceptions
{
    internal class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }

        public void InvalidFund(decimal amount)
        {
            if (amount < 2000)
            {
                throw new InsufficientFundsException("Insufficient Fund to enroll in this course. Please provide a sufficient amount for this course.");
            }
        }
    }
}
