using StudentInformationSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Menu
{
    internal class StudentInfo
    {
        StudentService studentService;
        CourseService courseService;
        EnrollmentService enrollmentService;
        TeacherService teacherService;
        PaymentService paymentService;

        public StudentInfo()
        {
            studentService = new StudentService();
            courseService = new CourseService();
            enrollmentService = new EnrollmentService();
            teacherService = new TeacherService();
            paymentService = new PaymentService();
        }

        public void MainMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("   Welcome to Student Information System   ");
                Console.WriteLine("  _______________________________________  ");
                Console.WriteLine("Main Menu::\n");
                Console.WriteLine("1: Student Records");
                Console.WriteLine("2: Course Records");
                Console.WriteLine("3: Enrollment Records");
                Console.WriteLine("4: Teacher Records");
                Console.WriteLine("5: Payment Records");
                Console.WriteLine("6: Exit from Student Information System");

                Console.WriteLine("\nWhat would you like to do: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        studentService.HandleStudentMenu();
                        break;

                    case 2:
                        courseService.HandleCourseMenu();
                        break;

                    case 3:
                        enrollmentService.HandleEnrollmentMenu();
                        break;

                    case 4:
                        teacherService.HandleTeacherMenu();
                        break;

                    case 5:
                        paymentService.HandlePaymentMenu();
                        break;

                    case 6:
                        Console.WriteLine("Thank you for using Student Information System!");
                        break;

                    default:
                        Console.WriteLine("Wrong choice! Try again !");
                        break;
                }
            } while (choice != 6);
        }
    }
}
