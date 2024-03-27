using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Model
{
    internal class Course
    {
        int course_id;
        String course_name;
        String courseCode;
        String instructorName;
        int? credits;
        int? instructorID;

        public int CourseID
        {
            get { return course_id; }
            set { course_id = value; }
        }

        public string CourseName
        {
            get { return course_name; }
            set { course_name = value; }
        }

        public String CourseCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }

        public string InstructorName
        {
            get { return instructorName; }
            set { instructorName = value; }
        }

        public int? Credits
        {
            get { return credits; }
            set { credits = value; }

        }

        public int? InstructorID
        {
            get { return instructorID; }
            set { instructorID = value; }
        }
        public Course() { }


        public Course(int courseID, string courseName, int? credits, int? instructorID)
        {
            CourseID = courseID;
            CourseName = courseName;
            Credits = credits;
            InstructorID = instructorID;

        }
        public override string ToString()
        {
            return $"{CourseID} {CourseName} {Credits} {InstructorID}";
        }
    }
}
