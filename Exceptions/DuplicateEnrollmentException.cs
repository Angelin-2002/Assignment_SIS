using StudentInformationSystem.Model;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Exceptions
{
    internal class DuplicateEnrollmentException : Exception
    {
        public DuplicateEnrollmentException(String message) : base(message) { }

        public static void DuplicateEnrollment(Enrollment enrollment)
        {
            EnrollmentRepository enrollmentRepository = new EnrollmentRepository();
            if (enrollmentRepository.DuplicateEnrollmentExists(enrollment))
            {
                throw new DuplicateEnrollmentException("StudentID already exists. Please try again! ");

            }
        }
    }
}
