using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Exceptions
{
    internal class InvalidCourseDataException : Exception
    {
        public InvalidCourseDataException(string message) : base(message) { }


        public static void InvalidCourseData(Course course)
        {
            if (course.CourseID == 0)
            {
                throw new InvalidCourseDataException("CourseID cannot be null. Please enter a valid Course ID");
            }
            else if (course.CourseCode == null)
            {
                throw new InvalidCourseDataException("CourseCode is invalid. Please enter a valid Course Code");

            }
            else if (course.CourseName == null)
            {
                throw new InvalidCourseDataException("CourseName is invalid. Please enter a valid Course Name");
            }
            else if (course.InstructorName == null)
            {
                throw new InvalidCourseDataException("InstructorName is invalid. Please enter a valid Instructor Name");
            }
        }
    }
}
