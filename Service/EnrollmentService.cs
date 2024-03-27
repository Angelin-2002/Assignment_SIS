using StudentInformationSystem.Model;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal class EnrollmentService
    {
        private readonly EnrollmentRepository _enrollmentRepository;

        public EnrollmentService()
        {
            _enrollmentRepository = new EnrollmentRepository();
        }

        public void GetStudentByEnrollment(int enrollmentId)
        {
            _enrollmentRepository.GetStudent(enrollmentId);
        }

        public void GetCourseByEnrollments(int enrollmentId)
        {
            _enrollmentRepository.GetCourse(enrollmentId);
        }

        public void HandleEnrollmentMenu()
        {
            Enrollment enrollment = new Enrollment();
            int choice = 0;
            do
            {
                Console.WriteLine("Welcome to Enrollment Management");
                Console.WriteLine($"1: Get Student\n2: Get Course\n3: Exit\n");
                Console.WriteLine("What would you like to do: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the enrollment id: ");
                        int enrollmentId = int.Parse(Console.ReadLine());
                        GetStudentByEnrollment(enrollmentId);
                        break;

                    case 2:
                        Console.WriteLine("Enter the enrollment id: ");
                        int enrollment_Id = int.Parse(Console.ReadLine());
                        GetCourseByEnrollments(enrollment_Id);
                        break;

                    case 3:
                        Console.WriteLine("Exiting from Enrollment Management");
                        break;

                    default:
                        Console.WriteLine("Wrong choice! Try again!");
                        break;
                }
            } while (choice != 3);
        }
    }
}
