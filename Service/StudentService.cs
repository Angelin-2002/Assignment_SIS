using StudentInformationSystem.Exceptions;
using StudentInformationSystem.Model;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public void AddRecords(Student student)
        {
            try
            {
                InvalidStudentDataException.InvalidStudentData(student);
                _studentRepository.InsertRecords(student);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void UpdateRecords(Student student)
        {

            try
            {
                InvalidStudentDataException.InvalidStudentData(student);
                _studentRepository.UpdateStudentInfo(student);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public void EnrollStudentInCourse(Course course, int studentID)
        {
            try
            {
                CourseNotFoundException.CourseNotFound(course);
                Enrollment enrollment = new Enrollment();
                enrollment.CourseID = course.CourseID;
                enrollment.StudentID = studentID;
                DuplicateEnrollmentException.DuplicateEnrollment(enrollment);
                _studentRepository.EnrollInCourse(course, studentID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MakePaymentByStudentId(int studentId, int amount)
        {
            try
            {
                Payment payment = new Payment();
                payment.Amount = amount;
                PaymentValidationException.PaymentValidData(payment);
                _studentRepository.MakePayment(studentId, amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetEnrolledCoursesbyStudent(int studentId)
        {
            try
            {
                StudentNotFoundException.StudentNotFound(studentId);
                _studentRepository.GetEnrolledCourses(studentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetPaymentByStudent(int studentId)
        {
            try
            {
                StudentNotFoundException.StudentNotFound(studentId);
                _studentRepository.GetPaymentHistory(studentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayStudentRecords()
        {
            _studentRepository.DisplayStudentInfo();
        }

        public void HandleStudentMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Welcome to Student Management");
                Console.WriteLine($"1: Insert Student Records\n2: Update student Records\n3: Enrole Student in Course\n4: Make Payment\n5: Display Student Records\n6: Get enrolled courses\n7: Get payment history\n8: Exit\n");
                Console.WriteLine("What would you like to do :  ");
                choice = int.Parse(Console.ReadLine());
                Student student = new Student();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the first name: ");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Enter the last name: ");
                        string lname = Console.ReadLine();
                        Console.WriteLine("Enter the date of birth in yyyy-mm-dd format: ");
                        string dob = Console.ReadLine();
                        Console.WriteLine("Enter the email: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter the phone number: ");
                        string phno =Console.ReadLine();
                        student = new Student() { FirstName = fname, LastName = lname, DateOfBirth = DateTime.Parse(dob), Email = email, PhoneNumber = phno };
                        AddRecords(student);
                        Console.WriteLine("Record inserted successfully");
                        break;

                    case 2:
                        Console.WriteLine("Enter the Student id to be updated: ");
                        int updt_id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the first name: ");
                        string updt_fname = Console.ReadLine();
                        Console.WriteLine("Enter the last name: ");
                        string updt_lname = Console.ReadLine();
                        Console.WriteLine("Enter the date of birth  in yyyy-mm-dd format: ");
                        string updt_dob = Console.ReadLine();
                        Console.WriteLine("Enter the email: ");
                        string updt_email = Console.ReadLine();
                        Console.WriteLine("Enter the phone number: ");
                        string updt_phno = Console.ReadLine();
                        Student student1 = new Student(updt_id, updt_fname, updt_lname, DateTime.Parse(updt_dob), updt_email, updt_phno);
                        UpdateRecords(student1);
                        Console.WriteLine("Record updated successfully");
                        break;

                    case 3:
                        Console.WriteLine("Enter the Course id: ");
                        int cour_id = int.Parse(Console.ReadLine());
                        Course courses = new Course();
                        courses.CourseID = cour_id;
                        Console.WriteLine("Enter the student id: ");
                        int stud_id = int.Parse(Console.ReadLine());
                        EnrollStudentInCourse(courses, stud_id);
                        break;

                    case 4:
                        Console.WriteLine("Enter the student id: ");
                        int studentid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the amount");
                        int amount = int.Parse(Console.ReadLine());
                        MakePaymentByStudentId(studentid, amount);
                        break;

                    case 5:
                        Console.WriteLine("List of the students: ");
                        DisplayStudentRecords();
                        break;

                    case 6:
                        Console.WriteLine("Enter the student id: ");
                        int s_id1 = int.Parse(Console.ReadLine());
                        GetEnrolledCoursesbyStudent(s_id1);
                        break;

                    case 7:
                        Console.WriteLine("Enter the student id: ");
                        int s_id2 = int.Parse(Console.ReadLine());
                        GetPaymentByStudent(s_id2);
                        break;

                    case 8:
                        Console.WriteLine("Exiting from Student Management");
                        break;

                    default:
                        Console.WriteLine("wrong choice! Try again!");
                        break;
                }
            } while (choice != 8);
        }
    }
}
