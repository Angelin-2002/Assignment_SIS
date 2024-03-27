using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Model
{
    internal class Teacher
    {
        int teacher_id;
        String first_name;
        String last_name;
        String email;

        public int TeacherID
        {
            get { return teacher_id; }
            set { teacher_id = value; }
        }

        public string FirstName
        {
            get { return first_name; }
            set { first_name = value; }
        }

        public string LastName
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public Teacher() { }

        public Teacher(int teacherID, String firstName, String lastName, String email)
        {
            TeacherID = teacherID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public override string ToString()
        {
            return $"{TeacherID} {FirstName} {LastName} {Email}";
        }
    }
}
