using StudentInformationSystem.Model;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Exceptions
{
    internal class TeacherNotFoundException : Exception
    {
        public TeacherNotFoundException(string message) : base(message) { }

        public static void TeacherNotFound(Teacher teacher)
        {
            TeacherRepository teacherRepository = new TeacherRepository();
            if (!teacherRepository.TeacherExists(teacher))
            {
                throw new TeacherNotFoundException("Teacher does not exist. Please try again!");
            }
        }
    }
}
