using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Exceptions
{
    internal class PaymentValidationException :Exception
    {
        public PaymentValidationException(string message) : base(message) { }

        public static void PaymentValidData(Payment payment)
        {
            if (payment.Amount <= 0)
            {
                throw new PaymentValidationException("Invalid Amount. Amount should be greater than 1. Please try again!");
            }
            else if (payment.PaymentDate <= DateTime.MinValue)
            {
                throw new PaymentValidationException("Enter the correct Payment Date. Try Again!");
            }
        }
    }
}
