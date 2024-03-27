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
    internal class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService()
        {
            _courseRepository = new CourseRepository();
        }

        public void AssignTeacherToCourse(Teacher teacher, Course course)
        {
            try
            {
                TeacherNotFoundException.TeacherNotFound(teacher);
                CourseNotFoundException.CourseNotFound(course);
                _courseRepository.AssignTeacher(teacher, course);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetEnrollmentByCourse(int course_id)
        {
            try
            {
                Course course = new Course();
                course.CourseID = course_id;
                CourseNotFoundException.CourseNotFound(course);
                _courseRepository.GetEnrollments(course_id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetTeacherByCourse(string courseName)
        {
            try
            {
                Course course = new Course();
                course.CourseName = courseName;
                InvalidCourseDataException.InvalidCourseData(course);
                _courseRepository.GetTeacher(courseName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateCourseDetails(Course course)
        {
            try
            {
                CourseNotFoundException.CourseNotFound(course);
                _courseRepository.UpdateCourseInfo(course);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayCourse()
        {
            _courseRepository.DisplayCourseInfo();
        }

        public void HandleCourseMenu()
        {
            Course course = new Course();
            int choice = 0;
            do
            {
                Console.WriteLine("Welcome to Course Management");
                Console.WriteLine($"1: Update Course Records\n2: Get enrollments\n3: Get teacher\n4: Display course Records\n5: Assign Teacher\n6: Exit\n");
                Console.WriteLine("What would you like to do: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the course id: ");
                        int updt_cid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the course name: ");
                        string updt_cname = Console.ReadLine();
                        Console.WriteLine("Enter the course credits: ");
                        int updt_credits = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the instructor id: ");
                        int updt_instructorId = int.Parse(Console.ReadLine());
                        Course course1 = new Course(updt_cid, updt_cname, updt_credits, updt_instructorId);
                        UpdateCourseDetails(course1);
                        break;

                    case 2:
                        Console.WriteLine("Enter the course id: ");
                        int course_id = int.Parse(Console.ReadLine());
                        GetEnrollmentByCourse(course_id);
                        break;

                    case 3:
                        Console.WriteLine("Enter the course name: ");
                        string course_name = Console.ReadLine();
                        GetTeacherByCourse(course_name);
                        break;

                    case 4:
                        Console.WriteLine("Course List: ");
                        DisplayCourse();
                        break;

                    case 5:
                        Console.WriteLine("Enter the teacher id: ");
                        int teach_id = int.Parse(Console.ReadLine());
                        Teacher teachers = new Teacher() { TeacherID = teach_id };
                        Console.WriteLine("Enter the course id: ");
                        int courseid = int.Parse(Console.ReadLine());
                        Course course_n = new Course();
                        course_n.CourseID = courseid;
                        AssignTeacherToCourse(teachers, course_n);
                        break;

                    case 6:
                        Console.WriteLine("Exiting from Course Management");
                        break;

                    default:
                        Console.WriteLine("Wrong choice! Try again!");
                        break;
                }
            } while (choice != 6);
        }
    }
}
