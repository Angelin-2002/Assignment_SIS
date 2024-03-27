using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Model
{
    internal class Enrollment
    {
        int enrollment_id;
        int? student_id;
        int? course_id;
        DateTime enrollment_date;


        public int EnrollmentID
        {
            get { return enrollment_id; }
            set { enrollment_id = value; }
        }

        public int? StudentID
        {
            get { return student_id; }
            set { student_id = value; }
        }

        public int? CourseID
        {
            get { return course_id; }
            set { course_id = value; }
        }

        public DateTime EnrollmentDate
        {
            get { return enrollment_date; }
            set { enrollment_date = value; }
        }
        public Enrollment() { }
        public Enrollment(int enrollmentID, int studentID, int courseID, DateTime enrollmentDate)
        {
            this.EnrollmentID = enrollmentID;
            this.StudentID = studentID;
            this.CourseID = courseID;
            this.EnrollmentDate = enrollmentDate;

        }
        public override string ToString()
        {
            return $"{EnrollmentID} {StudentID} {CourseID} {EnrollmentDate}";
        }
    }
}
