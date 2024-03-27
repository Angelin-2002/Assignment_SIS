using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Exceptions
{
    internal class InvalidEnrollmentDataException : Exception
    {
        public InvalidEnrollmentDataException(string message) : base(message) { }


        public static void InvalidEnrollmentData(Enrollment enrollment)
        {
            if (enrollment.EnrollmentID == null)
            {
                throw new InvalidEnrollmentDataException("ENrollment ID cannot be null. Please try again!");
            }
            else if (enrollment.StudentID == null)
            {
                throw new InvalidEnrollmentDataException("Student ID cannot be null. Please try again!");
            }
            else if (enrollment.EnrollmentDate > DateTime.Now)
            {
                throw new InvalidEnrollmentDataException("Enter a valid enrollment date.");
            }
        }
    }
}
