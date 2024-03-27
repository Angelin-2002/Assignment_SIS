using StudentInformationSystem.Model;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Exceptions
{
    internal class CourseNotFoundException :Exception
    {
        public CourseNotFoundException(string message) : base(message) { }
        public static void CourseNotFound(Course course)
        {

            CourseRepository courseRepository = new CourseRepository();
            if (!courseRepository.CourseExists(course))
            {
                throw new CourseNotFoundException("Course not found. Please try again!");
            }
        }
    }
}
