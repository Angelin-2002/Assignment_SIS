using StudentInformationSystem.Model;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal class TeacherService
    {
        private readonly TeacherRepository _teacherRepository;

        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();
        }

        public void DisplayTeacherRecords()
        {
            _teacherRepository.displayTeacherInfo();
        }

        public void UpdateTeacherRecords(Teacher teacher)
        {
            _teacherRepository.UpdateTeacherInfo(teacher);
        }

        public void GetAssignedCoursesByTeacher(int teacherId)
        {
            _teacherRepository.GetAssignedCourses(teacherId);
        }

        public void HandleTeacherMenu()
        {
            Teacher teacher = new Teacher();
            int choice = 0;
            do
            {
                Console.WriteLine("Welcome to Teacher Management");
                Console.WriteLine($"1: Update teacher details\n2: Get Assigned Course\n3: Display Teacher info\n4: Exit\n");
                Console.WriteLine("What would you like to do: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the teacher id: ");
                        int updt_tid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the first name: ");
                        string updt_fname = Console.ReadLine();
                        Console.WriteLine("Enter the last name: ");
                        string updt_lname = Console.ReadLine();
                        Console.WriteLine("Enter the email: ");
                        string updt_email = Console.ReadLine();
                        Teacher teacher1 = new Teacher(updt_tid, updt_fname, updt_lname, updt_email);
                        UpdateTeacherRecords(teacher1);
                        Console.WriteLine("Updated Teacher records successfully");
                        break;

                    case 2:
                        Console.WriteLine("Enter the teacher id: ");
                        int teacherId = int.Parse(Console.ReadLine());
                        GetAssignedCoursesByTeacher(teacherId);
                        break;

                    case 3:
                        Console.WriteLine("Teacher details: ");
                        DisplayTeacherRecords();
                        break;

                    case 4:
                        Console.WriteLine("Exiting from Teacher Management");
                        break;

                    default:
                        Console.WriteLine("Wrong choice! Try again!");
                        break;
                }
            } while (choice != 4);
        }
    }
}
